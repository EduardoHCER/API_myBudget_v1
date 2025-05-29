namespace API_GERAL.Routes
{
    public static class Routes
    {
        public static void MapDespesasRoutes(this WebApplication app)
        {
            // Registra todas as rotas.
            app.MapGetDespesas();
            app.MapGetDespesaById();
            app.MapPostDespesa();
            app.MapPutDespesa();
            app.MapDeleteDespesa();

            // Registra a rota de categoria
            app.MapGetCategorias();
        }
    }
}
