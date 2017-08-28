using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
    public class Level
    {
         [Key]
        public int LevelId { get; set; }
        [Display(Name = "等级名称")]
        public string LevelName { get; set; }
        [Display(Name = "等级分数")]
        public int LevelValue { get; set; }

    }
    public class UserLevels
    {
        [Key]
        public int UserLevelId { get; set; }
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "积分总数")]
        public int IntegralCount { get; set; }
        [Display(Name = "等级名称")]
        public string LevelName { get; set; }

    
    }
}
