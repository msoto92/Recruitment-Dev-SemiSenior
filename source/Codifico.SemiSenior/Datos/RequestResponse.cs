namespace Codifico.SemiSenior
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Codifico.LogicPoker;

    public class RequestResponse
    {
        /// <summary>
        /// Mensaje para el envio de la respuesta
        /// </summary>
        public string Mesagge { get; set; }

        /// <summary>
        /// Listado de cartas.
        /// </summary>
        public PokerCard[] ListCard { get; set; }

        /// <summary>
        /// Resumen de cartas.
        /// </summary>
        public PokerCard[] ListResumen { get; set; }

        /// <summary>
        /// Estado de la respuesta.
        /// </summary>
        public ResponseState State { get; set; }
    }
}