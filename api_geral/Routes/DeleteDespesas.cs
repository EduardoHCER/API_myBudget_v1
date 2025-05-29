using API_GERAL.Data;

namespace API_GERAL.Routes
{
    public static class DeleteDespesa
    {
        public static void MapDeleteDespesa(this WebApplication app)
        {
            // DELETE remover despesa
            app.MapDelete(
                    "/api/despesas/{id}",
                    async (int id, AppDbContext db) =>
                    {
                        // Busca a despesa para deletar
                        var despesa = await db.Despesas.FindAsync(id);
                        if (despesa is null)
                            return Results.NotFound("Despesa não encontrada.");

                        // Remove do contexto e salva
                        db.Despesas.Remove(despesa);
                        await db.SaveChangesAsync();

                        return Results.NoContent();
                    }
                )
                .WithName("DeleteDespesa")
                .WithTags("Despesas")
                .WithSummary("Remove uma despesa")
                .WithDescription("Exclui permanentemente uma despesa pelo seu ID");
        }
    }
}
