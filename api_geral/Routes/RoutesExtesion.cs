namespace API_GERAL.Routes
{
    public static class RoutesExtensions
    {
        /// <summary>
        /// Registra todas as rotas relacionadas a Despesas
        /// </summary>
        /// <param name="app">WebApplication instance</param>
        public static void MapDespesasRoutes(this WebApplication app)
        {
            // Registra todas as rotas de despesas
            app.MapGetDespesas(); // GET /api/despesas
            app.MapGetDespesaById(); // GET /api/despesas/{id}
            app.MapPostDespesa(); // POST /api/despesas
            app.MapPutDespesa(); // PUT /api/despesas/{id}
            app.MapDeleteDespesa(); // DELETE /api/despesas/{id}

            // Registra rota de categorias
            app.MapGetCategorias(); // GET /api/categorias
        }
    }
}
