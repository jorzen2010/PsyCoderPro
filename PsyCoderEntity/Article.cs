using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Display(Name="文章标题")]
        public string ArticleTitle { get; set; }
        [Display(Name = "封面")]
        public string ArticlePhoto { get; set; }
        [Display(Name = "文章介绍")]
        public string ArticleInfo { get; set; }
        [Display(Name = "文章内容")]
        public string ArticleContent { get; set; }
       
       
        [Display(Name = "文章类别")]
        public int ArticleCategory { get; set; }
      

        [Display(Name = "置顶")]
        public bool ArticleTop { get; set; }
        [Display(Name = "推荐")]
        public bool ArticleHot { get; set; }

        [Display(Name = "发布时间")]
        public DateTime ArticleTime { get; set; }
    }
}
