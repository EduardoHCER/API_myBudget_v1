using API_GERAL.Data;

namespace API_GERAL.Routes
{
    public static class GetDespesaById
    {
        public static void MapGetDespesaById(this WebApplication app)
        {
            // GET, busca despesa por ID.
            app.MapGet(
                "/api/despesas/{id}",
                async (int id, AppDbContext db) =>
                {
                    var despesa = await db.Despesas.FindAsync(id);
                    return despesa is not null ? Results.Ok(despesa) : Results.NotFound();
                }
            );
        }
    }
}
