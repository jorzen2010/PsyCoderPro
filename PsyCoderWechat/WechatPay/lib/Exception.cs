﻿using System;
using System.Collections.Generic;
using System.Web;

namespace PsyCoderWechat.WechatPay
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}