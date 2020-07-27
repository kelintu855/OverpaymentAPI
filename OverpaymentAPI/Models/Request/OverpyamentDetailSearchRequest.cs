using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OverpaymentAPI.Models.Request
{
    public class OverpaymentDetailSearchRequest
    {
        [Required]
        [JsonProperty(PropertyName = "member_id")]
        public int MemberId { get; set; }
    }
}