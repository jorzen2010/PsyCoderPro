using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
    public class Integral
    {
        public int IntegralId { get; set; }
        [Display(Name = "积分类型")]
        public string IntegralName { get; set; }
        [Display(Name = "积分数量")]
        public int IntegralValue { get; set; }
    }

    public class IntegralDetail
    {
        public int IntegralDetailId { get; set; }
        public string IntegralCustomerUserName { get; set; }        
        public string IntegralSource { get; set; }
        public int IntegralAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 hh:mm:ss}")]
        public DateTime IntegralDetailTime { get; set; }
    }
}
