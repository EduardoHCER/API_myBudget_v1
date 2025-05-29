using API_GERAL.Data;
using API_GERAL.models;
using API_GERAL.Routes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=despesas.db")
);

// Config's do Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

var app = builder.Build();

// Config para habilitar Cors.
app.UseCors("AllowAll");

// Condicional para habilitar swagger caso a API tenha sido executada de forma correta, caso não retorna código de erro.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

// Registrar todas as rotas.
app.MapDespesasRoutes();

// Habilita arquivos estáticos, index.html, etc.
app.UseDefaultFiles();
app.UseStaticFiles();

// Executa a aplicação.
app.Run();
