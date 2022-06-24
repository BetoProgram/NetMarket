using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Error
{
    public class CodeErrorMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public CodeErrorMessage(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                401 => "No tiene autorizacion para este recurso",
                400 => "El Request enviado contiene errores",
                404 => "No se encuentra el recurso solicitado",
                500 => "Se producieron errores en el servidor", _ => null
            };
        }
    }
}
