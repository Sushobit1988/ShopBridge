using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

using Newtonsoft.Json;
using System.Web;
using System.Collections;

using ShopBridge.Models;
using ShopBridge.Common;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace ShopBridge.Common
{
    public class ListitemController : ApiController
    {

        [HttpGet] // POST api/cardetails
        [AcceptVerbs("GET")]
        public HttpResponseMessage Get()
        {

            try
            {

               




                DataTable InsertFields = new DataTable();
                InsertFields = BussinessLogic.ListItem();
                if (InsertFields != null && InsertFields.Rows.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, InsertFields);
                }




            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);


            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "300");
        }

    }
}
