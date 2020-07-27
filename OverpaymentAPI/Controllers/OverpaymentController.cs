using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OverpaymentAPI.Models.Request;
using OverpaymentAPI.Models.Response;
using OverpaymentAPI.Models.Custom;
using OverpaymentAPI.Services;
using Newtonsoft.Json;
using OverpaymentAPI;

namespace WebAPIDemo.Controllers
{
    public class OverpaymentController : ApiController
    {
        private readonly OverpaymentService overpaymentService;

        [HttpPost]
        [Route("api/overpayment/post")]
        public void PostOverPaymentDetail([FromBody]OverpaymentDetailRequest overpaymentDetailRequest)
        {
            var overpaymentDetailAdd = new OverpaymentDetailAdd
            {
                OverPyamentID = overpaymentDetailRequest.OverPyamentID,
                MemberId = overpaymentDetailRequest.MemberId,
                ClaimNumber = overpaymentDetailRequest.ClaimNumber,
                BalanceAmt = overpaymentDetailRequest.BalanceAmt,
                OverPaymentAmt = overpaymentDetailRequest.OverPaymentAmt
            };
            //overpaymentService.addOverpaymentDetail(overpaymentDetailAdd);
            var conn = new mainEntities();
            conn.Database.Connection.Open();
            var overpaymentDetailDB = conn.OverpaymentDetails;
            var overpayment = new OverpaymentDetail()
            {
                OverPaymentID = overpaymentDetailRequest.OverPyamentID,
                MemberId = overpaymentDetailRequest.MemberId,
                ClaimNumber = overpaymentDetailRequest.ClaimNumber,
                BalanceAmt = overpaymentDetailRequest.BalanceAmt,
                OverPaymentAmt = overpaymentDetailRequest.OverPaymentAmt,
                SysSrcSyncDate = DateTime.Today,
                LastUpdated = DateTime.Today
            };
            overpaymentDetailDB.Add(overpayment);
            conn.SaveChanges();
            conn.Dispose();


            //var conn = new System.Data.SQLite.SQLiteConnection("data source=C:/inetpub/wwwroot/OverpaymentAPISite/OverpaymentDetail.db");
            //using (var cmd = new SQLiteCommand(conn))
            //{
            //    conn.Open();
            //    cmd.CommandText = "INSERT INTO OverPaymentDetail(OverPaymentID, ClaimNumber, MemberId, BalanceAmt, OverPaymentAmt) Values("
            //        + overpaymentDetailRequest.OverPyamentID.ToString() + ", " + overpaymentDetailRequest.ClaimNumber.ToString() + ", " + overpaymentDetailRequest.MemberId.ToString() + ", " + overpaymentDetailRequest.BalanceAmt.ToString() + ", " + overpaymentDetailRequest.OverPaymentAmt.ToString() + ")";
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //}


        }
        [HttpGet]
        
        //TODO: change parameter to int id
        public Object Get(int id)
        {

            List<OverpaymentDetailSearchResponse> resultList =
                    new List<OverpaymentDetailSearchResponse>();

            var condition = new OverpaymentDetailSearch()
            {
                MemberId = id
            };
            var overpaymentService = new OverpaymentService();
            List<OverpaymentDetailSearchResult> overpaymentDetails = overpaymentService.searchOverpaymentDetail(condition);
            foreach (var overpaymentDetail in overpaymentDetails)
            {
                var resultData = new OverpaymentDetailSearchResponse();
                resultData.OverpaymentId = overpaymentDetail.OverpaymentId;
                resultData.ClaimNumber = overpaymentDetail.ClaimNumber;
                resultData.BalanceAmount = overpaymentDetail.BalanceAmount;
                resultData.OverpaymentAmount = overpaymentDetail.OverpaymentAmount;
                resultData.DaysLeft = 90-(DateTime.Now - overpaymentDetail.CreateDate).Days;

                resultList.Add(resultData);
            }

            return resultList;
        }


    }
}

