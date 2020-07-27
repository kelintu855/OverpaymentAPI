using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverpaymentAPI.Models.Response
{
    public enum ResponseResultStatus
    {
        OK = 10000,
        Failed = 10001,
        LoginTimes = 10002,
        PasswordExpired = 10003,
        AccountLocked = 10004,
        AccountInactive = 10005,
    }

    public class ResponseResult<T>
    {
        /// <summary>
        /// Response Status
        /// </summary>
        public ResponseResultStatus Status { get; set; }

        /// <summary>
        /// Response Body
        /// </summary>
        public T Body { get; set; }

        /// <summary>
        /// Response Message
        /// </summary>
        public string Message { get; set; }
    }
}