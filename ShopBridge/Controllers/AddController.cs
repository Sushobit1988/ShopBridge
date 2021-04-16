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
    public class AddController : ApiController
    {

        [HttpPost] // POST api/cardetails
        [AcceptVerbs("POST")]
        public HttpResponseMessage Post([FromBody]AddFields cs)
        {

             try
            {

                if (string.IsNullOrEmpty(cs.Name) || string.IsNullOrEmpty(cs.Price) || string.IsNullOrEmpty(cs.Description))
                {
                  
                    return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.NotEnoughtParamCode904), Constants.NotEnoughtParam);
                }


                bool blacklist = false;



                blacklist = Common.CommonFunction.CheckInjectBooleanNew(cs.Name);

                if (blacklist == true)
                {
                    return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.BadcharacterSupplied905), string.Format(Constants.BadcharacterSupplied, "Name"));
                }

                blacklist = Common.CommonFunction.CheckInjectBooleanNew(cs.Description);

                if (blacklist == true)
                {
                    return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.BadcharacterSupplied905), string.Format(Constants.BadcharacterSupplied, "Description"));
                }

                blacklist = Common.CommonFunction.CheckInjectBooleanNew(cs.Price);

                if (blacklist == true)
                {
                    return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.BadcharacterSupplied905), string.Format(Constants.BadcharacterSupplied, "Price"));
                }
                int n;
                bool isNumeric = int.TryParse(cs.Price, out n);

                 if(isNumeric==false)
                 {
                     return Request.CreateResponse((HttpStatusCode)Convert.ToInt32(Constants.Isnumeric906), Constants.Isnumeric);
             
                 }



                 DataTable InsertFields = new DataTable();
                 InsertFields = BussinessLogic.InsertItem(cs.Name, cs.Description, cs.Price, Common.CommonFunction.NewItemId());
                 if(InsertFields !=null && InsertFields.Rows.Count>0)
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
