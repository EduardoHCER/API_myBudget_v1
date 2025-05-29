using API_GERAL.Data;
using API_GERAL.models;

namespace API_GERAL.Routes
{
    public static class PostDespesa
    {
        public static void MapPostDespesa(this WebApplication app)
        {
            // POST criar nova despesa
            app.MapPost(
                    "/api/despesas",
                    async (Despesas novaDespesa, AppDbContext db) =>
                    {
                        // Validações
                        if (string.IsNullOrWhiteSpace(novaDespesa.titulo) || novaDespesa.valor <= 0)
                            return Results.BadRequest(
                                "Título é obrigatório e valor deve ser maior que 0."
                            );

                        // Adiciona ao contexto e salva
                        db.Despesas.Add(novaDespesa);
                        await db.SaveChangesAsync();

                        // Retorna Created com a despesa criada
                        return Results.Created($"/api/despesas/{novaDespesa.id}", novaDespesa);
                    }
                )
                .WithName("CreateDespesa")
                .WithTags("Despesas")
                .WithSummary("Cria uma nova despesa")
                .WithDescription("Adiciona uma nova despesa ao sistema");
        }
    }
}
