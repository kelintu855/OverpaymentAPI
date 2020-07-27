using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OverpaymentAPI.Models.Custom
{
    public class OverpaymentDetailAdd
    {
        [Required]
        [JsonProperty(PropertyName = "overpayment_id")]
        public long OverPyamentID { get; set; }
        [JsonProperty(PropertyName = "claim_number")]
        public string ClaimNumber { get; set; }
        [JsonProperty(PropertyName = "member_id")]
        public long MemberId { get; set; }
        [JsonProperty(PropertyName = "balance_amt")]
        public decimal BalanceAmt { get; set; }
        [JsonProperty(PropertyName = "overpayment_amt")]
        public decimal OverPaymentAmt { get; set; }

    }
}