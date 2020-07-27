using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OverpaymentAPI.Models.Custom
{
    public class OverpaymentDetailSearchResult
    {
        [JsonProperty(PropertyName = "overpayment_id")]
        public long OverpaymentId { get; set; }
        [JsonProperty(PropertyName = "claim_number")]
        public string ClaimNumber { get; set; }
        [JsonProperty(PropertyName = "balance_amount")]
        public decimal BalanceAmount { get; set; }
        [JsonProperty(PropertyName = "overpayment_amount")]
        public decimal OverpaymentAmount { get; set; }
        [JsonProperty(PropertyName = "create_date")]
        public DateTime CreateDate { get; set; }

        public OverpaymentDetailSearchResult(long overpaymentId, string claimNumber, decimal balanceAmt, decimal overpaymentAmt, DateTime createDate)
        {
            OverpaymentId = overpaymentId;
            ClaimNumber = claimNumber;
            BalanceAmount = balanceAmt;
            OverpaymentAmount = overpaymentAmt;
            CreateDate = createDate;
        }
    }
}