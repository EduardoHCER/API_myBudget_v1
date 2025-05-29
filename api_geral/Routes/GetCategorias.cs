using API_GERAL.Data;
using Microsoft.EntityFrameworkCore;

namespace API_GERAL.Routes
{
    public static class GetCategorias
    {
        public static void MapGetCategorias(this WebApplication app)
        {
            // GET todas as categorias únicas
            app.MapGet(
                    "/api/categorias",
                    async (AppDbContext db) =>
                    {
                        var categorias = await db
                            .Despesas.Where(d => !string.IsNullOrEmpty(d.categoria))
                            .Select(d => d.categoria)
                            .Distinct()
                            .OrderBy(c => c)
                            .ToListAsync();

                        return categorias;
                    }
                )
                .WithName("GetAllCategorias")
                .WithTags("Categorias")
                .WithSummary("Busca todas as categorias")
                .WithDescription(
                    "Retorna uma lista de todas as categorias únicas utilizadas nas despesas"
                );
        }
    }
}
