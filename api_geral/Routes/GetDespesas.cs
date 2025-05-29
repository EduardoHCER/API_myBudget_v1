using API_GERAL.Data;
using Microsoft.EntityFrameworkCore;

namespace API_GERAL.Routes
{
    public static class GetDespesa
    {
        public static void MapGetDespesas(this WebApplication app)
        {
            // GET todas as despesas com filtro opcional por categoria
            app.MapGet(
                    "/api/despesas",
                    async (string? categoria, AppDbContext db) =>
                    {
                        var query = db.Despesas.AsQueryable();

                        if (!string.IsNullOrEmpty(categoria))
                        {
                            query = query.Where(d =>
                                d.categoria.ToLower().Contains(categoria.ToLower())
                            );
                        }

                        return await query.ToListAsync();
                    }
                )
                .WithName("GetAllDespesas")
                .WithTags("Despesas")
                .WithSummary("Busca todas as despesas")
                .WithDescription("Retorna todas as despesas, com filtro opcional por categoria");
        }
    }
}
