using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OverpaymentAPI.Models.Request;
using OverpaymentAPI.Models.Response;
using OverpaymentAPI.Models.Custom;

namespace OverpaymentAPI.Services
{
    public class OverpaymentService
    {
        public void addOverpaymentDetail(OverpaymentDetailAdd overpaymentDetail)
        {
            var conn = new mainEntities();
            conn.Database.Connection.Open();
            var overpaymentDetailDB = conn.OverpaymentDetails;
            var overpayment = new OverpaymentDetail()
            {
                OverPaymentID = overpaymentDetail.OverPyamentID,
                MemberId = overpaymentDetail.MemberId,
                ClaimNumber = overpaymentDetail.ClaimNumber,
                BalanceAmt = overpaymentDetail.BalanceAmt,
                OverPaymentAmt = overpaymentDetail.OverPaymentAmt,
                SysSrcSyncDate = DateTime.Today,
                LastUpdated = DateTime.Today
            };
            overpaymentDetailDB.Add(overpayment);
        }
        public List<OverpaymentDetailSearchResult> searchOverpaymentDetail(
            OverpaymentDetailSearch condition)
        {
            var conn = new mainEntities();
            conn.Database.Connection.Open();
            var overpaymentDetails = conn.OverpaymentDetails.Where(
                o => o.MemberId == condition.MemberId);
            var results = new List<OverpaymentDetailSearchResult>();
            foreach (var overpaymentDetail in overpaymentDetails)
            {
                results.Add(new OverpaymentDetailSearchResult(overpaymentDetail.OverPaymentID, overpaymentDetail.ClaimNumber, overpaymentDetail.BalanceAmt, overpaymentDetail.OverPaymentAmt, overpaymentDetail.SysSrcSyncDate));
            }
            conn.Database.Connection.Close();
            return results;
        }
    }
}