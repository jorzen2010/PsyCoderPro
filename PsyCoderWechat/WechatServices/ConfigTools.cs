using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using PsyCoderCommon;
using PsyCoderEntity.WechatEntity;

namespace PsyCoderWechat.WechatServices
{
    public class ConfigTools
    {
       
        public static void WriteKey(string Key, string Value)
        {
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection appsection = config.GetSection("appSettings") as AppSettingsSection;

            appsection.Settings[Key].Value = Value;
            config.Save();

        }
    }
}