using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
    public class SysUser
    {
        [Key]
        public int SysUserId { get; set; }
        [Display(Name = "用户名")]
        public string SysUserName { get; set; }
        [Display(Name = "密码")]
        public string SysPassword { get; set; }
        [Display(Name = "邮箱")]
        public string SysEmail { get; set; }
        [Display(Name = "是否启用")]
        public bool SysStatus { get; set; }
        [Display(Name = "头像")]
        public string SysAvatar { get; set; }
        [Display(Name = "注册时间")]
        public DateTime SysRegTime { get; set; }
        [Display(Name = "最后登录时间")]
        public DateTime SysLastLoginTime { get; set; }

        [Display(Name = "姓名")]
        public string SysName { get; set; }
        [Display(Name = "性别")]
        public string SysSex { get; set; }
        [Display(Name = "生日")]
        public DateTime? SysBirthday { get; set; }
        [Display(Name = "生日类型")]
        public string SysBirthdayType { get; set; }
    }
}
