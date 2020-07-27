using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OverpaymentAPI.Models.Custom
{
    public class OverpaymentDetailSearch
    {
        [Required]
        [JsonProperty(PropertyName = "member_id")]
        public int MemberId { get; set; }
    }
}