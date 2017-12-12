namespace Codifico.SemiSenior
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;


    public enum ResponseState
    {
        /// <summary>
        /// Proceso realizado con éxito
        /// </summary>
        Success = 1,

        /// <summary>
        /// Error al procesar la solicitud.
        /// </summary>
        Error = 2
    }
}