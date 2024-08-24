using System.Net;

namespace Fantasy.Frontend.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statuCode = HttpResponseMessage.StatusCode;
            if (statuCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado.";
            }

            if (statuCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }

            if (statuCode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que estar logeado para ejecutar esta operación.";
            }

            if (statuCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para hacer esta operación.";
            }

            return "Ha ocurrido un error inesperado.";
        }
    }
}