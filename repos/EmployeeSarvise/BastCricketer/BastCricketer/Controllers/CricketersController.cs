using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BastCricketer.Models;
using BestCricketers.Core.BL;

namespace BastCricketer.Controllers
{
    public class CricketersController : ApiController
    {
        #region Variable  
        HttpResponseMessage response;
        CricketerBL cricketerBL;
        #endregion# region Public Method  
        ///<summary>  
        /// This method is used to get cricketer list  
        ///</summary>  
        ///<returns></returns>  
        [HttpGet, ActionName("GetCricketerList")]
        public HttpResponseMessage GetCricketerList()
        {
            Result result;
            cricketerBL = new CricketerBL();
            try
            {
                var cricketerList = cricketerBL.GetCricketerList();
                if (!object.Equals(cricketerList, null))
                {
                    response = Request.CreateResponse<List<CricketerProfile>>(HttpStatusCode.OK, cricketerList);
                }
            }
            catch (Exception ex)
            {
                result = new Result();
                result.Status = 0;
                result.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }
        ///<summary>  
        /// This method is used to get cricketer list by id  
        ///</summary>  
        ///<returns></returns>  
        [HttpGet, ActionName("GetCricketerInfoById")]
        public HttpResponseMessage GetCricketerInfoById(int CricketerId)
        {
            Result result;
            cricketerBL = new CricketerBL();
            try
            {
                var cricketerList = cricketerBL.GetCricketerDetailsById(CricketerId);
                if (!object.Equals(cricketerList, null))
                {
                    response = Request.CreateResponse<List<CricketerProfile>>(HttpStatusCode.OK, cricketerList);
                }
            }
            catch (Exception ex)
            {
                result = new Result();
                result.Status = 0;
                result.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;

        } 
    }
}
