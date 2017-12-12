namespace Codifico.SemiSenior
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Codifico.LogicPoker;

    /// <summary>
    /// Controlador para el manejo de randomico de cartas
    /// </summary>
    [RoutePrefix("api/Poker")]
    public class PokerController : ApiController
    {

        /// <summary>
        /// Obtiene un listado de cartas random.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCards")]
        [ResponseType(typeof(RequestResponse))]
        public IHttpActionResult Get()
        {
            RequestResponse ans = new RequestResponse();

            try
            {               
                ans.Mesagge = "Proceso Realizado con éxito";
                ans.ListCard = LogicPoker.GetCards();
                ans.ListResumen = LogicPoker.GetResume();
                ans.State = ResponseState.Success;
                return Ok(ans);
            }
            catch (Exception ex)
            {
                ans.Mesagge = "Error: " + ex.Message;
                ans.State = ResponseState.Error;
                return Ok(ans);
            }

        }

    }
}