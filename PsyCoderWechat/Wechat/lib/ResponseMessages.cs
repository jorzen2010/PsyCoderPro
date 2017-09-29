using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat
{
    public class TextMessages
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public MsgType text { get; set; }
        public string Content { get; set; }
        public int MsgId { get; set; }

    }
    public class ImageMessages
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public MsgType image { get; set; }
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
        public int MsgId { get; set; }

    }
    public enum MsgType { 
    
        text,
        image


    }

}
