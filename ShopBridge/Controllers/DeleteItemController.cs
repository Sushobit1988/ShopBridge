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

namespace ShopBridge.Controllers
{
    public class DeleteItemController : ApiController
    {
         [HttpPost] // POST api/cardetails
        [AcceptVerbs("POST")]
        public HttpResponseMessage Post([FromBody]DeleteFields cs)
        {

            try
            {

                if ( string.IsNullOrEmpty(cs.ItemId))
                {

                    return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.NotEnoughtParamCode904), Constants.NotEnoughtParam);
                }


                bool blacklist = false;



             

                blacklist = Common.CommonFunction.CheckInjectBooleanNew(cs.ItemId);

                if (blacklist == true)
                {
                    return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.BadcharacterSupplied905), string.Format(Constants.BadcharacterSupplied, "Item Id"));
                }
               



                DataTable InsertFields = new DataTable();
                InsertFields = BussinessLogic.DeleteItem(cs.ItemId);
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

