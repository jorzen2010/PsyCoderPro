using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
    public class Honor
    {
        public int HonorId { get; set; }
        [Display(Name = "勋章名称")]
        public string HonorName { get; set; }
        [Display(Name = "勋章简介")]
        public string HonorInfo { get; set; }
        [Display(Name = "勋章图片")]
        public string HonorImg { get; set; }
    }
    public class HonorDetail
    {
        public int HonorUserId { get; set; }
        public string UserName { get; set; }
        public int HonorId { get; set; }
    }
}
