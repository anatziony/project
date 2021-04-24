using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProj.Models;

namespace FinalProj.Controllers
{
    public class RankController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Rank r)
        {
            try
            {
                string Rname = r.Insert();
                return Request.CreateResponse(HttpStatusCode.OK, Rname);
            }
            catch (Exception ex)
            {
                if (ex.Message == "failed to connect to the server")
                {
                    //500
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
                else if (ex.Message == "no content was inserted")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    //throw (ex);
                }
                else return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}