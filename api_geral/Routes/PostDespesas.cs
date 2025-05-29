using API_GERAL.Data;
using API_GERAL.models;

namespace API_GERAL.Routes
{
    public static class PostDespesa
    {
        public static void MapPostDespesa(this WebApplication app)
        {
            app.MapPost(
                "/api/despesas",
                async (Despesas novaDespesa, AppDbContext db) =>
                {
                    // Garante que o ID seja zero (auto-incremento pelo banco)
                    novaDespesa.id = 0;

                    db.Despesas.Add(novaDespesa);
                    await db.SaveChangesAsync();

                    return Results.Created($"/api/despesas/{novaDespesa.id}", novaDespesa);
                }
            );
        }
    }
}
