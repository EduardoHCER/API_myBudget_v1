using API_GERAL.Data;
using Microsoft.EntityFrameworkCore;

namespace API_GERAL.Routes
{
    public static class GetDespesa
    {
        public static void MapGetDespesas(this WebApplication app)
        {
            // GET,retorna todas as despesas em lista.
            app.MapGet(
                "/api/despesas",
                async (string? categoria, AppDbContext db) =>
                {
                    var query = db.Despesas.AsQueryable();

                    return await query.ToListAsync();
                }
            );
        }
    }
}
