using API_GERAL.Data;
using API_GERAL.models;

namespace API_GERAL.Routes
{
    public static class PutDespesa
    {
        public static void MapPutDespesa(this WebApplication app)
        {
            // PUT atualizar despesa existente
            app.MapPut(
                    "/api/despesas/{id}",
                    async (int id, Despesas atualizada, AppDbContext db) =>
                    {
                        // Busca a despesa existente
                        var despesa = await db.Despesas.FindAsync(id);
                        if (despesa is null)
                            return Results.NotFound("Despesa não encontrada.");

                        // Validações
                        if (string.IsNullOrWhiteSpace(atualizada.titulo) || atualizada.valor <= 0)
                            return Results.BadRequest(
                                "Título é obrigatório e valor deve ser maior que 0."
                            );

                        // Atualiza os campos
                        despesa.titulo = atualizada.titulo;
                        despesa.data = atualizada.data;
                        despesa.valor = atualizada.valor;
                        despesa.formaPagamento = atualizada.formaPagamento;
                        despesa.categoria = atualizada.categoria;

                        // Salva as alterações
                        await db.SaveChangesAsync();

                        return Results.NoContent();
                    }
                )
                .WithName("UpdateDespesa")
                .WithTags("Despesas")
                .WithSummary("Atualiza uma despesa existente")
                .WithDescription("Modifica todos os campos de uma despesa pelo seu ID");
        }
    }
}
