using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
   public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "用户名")]
        public string CustomerUserName { get; set; }
        [Display(Name = "邮箱")]
        public string CustomerEmail { get; set; }
        [Display(Name = "密码")]
        public string CustomerPassword { get; set; }
        [Display(Name = "客户状态")]
        public bool CustomerStatus { get; set; }
        [Display(Name = "认证状态")]
        public IdentiyStatus CustomerIdentity { get; set; }


        [Display(Name = "头像")]
        public string CustomerAvatar { get; set; }
        [Display(Name = "姓名")]
        public string CustomerNickName { get; set; }
        [Display(Name = "性别")]
        public string CustomerSex { get; set; }
        [Display(Name = "生日")]
        public DateTime CustomerBirthday { get; set; }
        [Display(Name = "生日类型")]
        public string CustomerBirthdayType { get; set; }
        [Display(Name = "省份")]
        public string CustomerProvince { get; set; }
        [Display(Name = "城市")]
        public string CustomerCity { get; set; }
        [Display(Name = "地区")]
        public string CustomerDistrict { get; set; }
        [Display(Name = "详细住址")]
        public string CustomerAddress { get; set; }
        [Display(Name = "注册时间")]
        public DateTime CustomerRegTime { get; set; }
        [Display(Name = "最后登录时间")]
        public DateTime CustomerLastLoginTime { get; set; }


        //身份认证

        [Display(Name = "姓名")]
        public string CustomerRealName { get; set; }

        [Display(Name = "身份证号")]
        public string CustomerIDCard { get; set; }
        [Display(Name = "手持身份证")]
        public string CustomerHoldCard { get; set; }
        [Display(Name = "身份证号正面")]
        public string CustomerIDCardzm { get; set; }
        [Display(Name = "身份证号反面")]
        public string CustomerIDCardsm { get; set; }

      

    }

     public enum IdentiyStatus
    {
            未认证 = 1,
            已认证 = 2,
            正在审核 = 3,
            审核失败 = 4
     }

     public class WechatUser
     {
         [Key]
         public int WechatUserID { get; set; }
         [Display(Name = "客户ID")]
         public int CustomerID { get; set; }
         [Display(Name = "客户openID")]
         public string Openid { get; set; }
         [Display(Name = "客户unionid")]
         public string Unionid { get; set; }

     
     }

}
