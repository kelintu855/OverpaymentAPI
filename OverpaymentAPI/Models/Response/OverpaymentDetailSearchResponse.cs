using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OverpaymentAPI.Models.Response
{
    public class OverpaymentDetailSearchResponse
    {
        [Required]
        [JsonProperty(PropertyName = "overpayment_id")]
        public long OverpaymentId { get; set; }
        [JsonProperty(PropertyName = "claim_number")]
        public string ClaimNumber { get; set; }
        [JsonProperty(PropertyName = "balance_amount")]
        public decimal BalanceAmount { get; set; }
        [JsonProperty(PropertyName = "overpayment_amount")]
        public decimal OverpaymentAmount { get; set; }
        [JsonProperty(PropertyName = "days_left")]
        public int DaysLeft { get; set; }

    }
}