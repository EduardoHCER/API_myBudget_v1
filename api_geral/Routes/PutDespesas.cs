using API_GERAL.Data;
using API_GERAL.models;

namespace API_GERAL.Routes
{
    public static class PutDespesa
    {
        public static void MapPutDespesa(this WebApplication app)
        {
            // PUT para atualizar despesa existente.
            app.MapPut(
                "/api/despesas/{id}",
                async (int id, Despesas atualizada, AppDbContext db) =>
                {
                    // Busca a despesa existente.
                    var despesa = await db.Despesas.FindAsync(id);
                    if (despesa is null)
                        return Results.NotFound("Despesa não encontrada.");

                    // Atualiza os campos no banco.
                    despesa.titulo = atualizada.titulo;
                    despesa.data = atualizada.data;
                    despesa.valor = atualizada.valor;
                    despesa.formaPagamento = atualizada.formaPagamento;
                    despesa.categoria = atualizada.categoria;

                    // Salva as alterações no banco.
                    await db.SaveChangesAsync();

                    return Results.NoContent();
                }
            );
        }
    }
}
