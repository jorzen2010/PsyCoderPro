using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PsyCoderEntity
{
    /// <summary>
    /// 订单表
    /// </summary>
   public class Orders
    {
       [Key]
       public int OrderId { get; set; }
        [Display(Name = "客户ID")]
       public int CustomerId { get; set; }
       [Display(Name = "订单流水号")]
       public string OrderNumber { get; set; }
       [Display(Name = "订单创建时间")]
       public DateTime OrderCreateTime { get; set; }
        [Display(Name = "订单付款时间")]
       public DateTime OrderPayTime { get; set; }
        [Display(Name = "付款状态")]
        public OrderStatus OrderStatus { get; set; }
        [Display(Name = "订单总金额")]
        public float CountPayment { get; set; }
        [Display(Name = "订单实付金额")]
        public float ActualPayment { get; set; }
        [Display(Name = "买家IP")]
        public string BuyerIP { get; set; }
        [Display(Name = "订单来源")]
        public string OrderSource { get; set; }


    }

   public enum OrderStatus
   {
       未付款 = 1,
       交易完成 = 2,
       交易取消 = 3,
       付款失败 = 4
   }

   /// <summary>
   /// 订单对应活动优惠表
   /// </summary>
   /// 
   public class OrderActivity
   {
       [Key]
       public int OrderActivityId { get; set; }
       [Display(Name = "订单ID")]
       public int OrderId { get; set; }
       [Display(Name = "活动ID")]
       public int ActivityId { get; set; }
       [Display(Name = "优惠金额")]
       public float Preferential { get; set; }



   }
   /// <summary>
   /// 订单详情表
   /// </summary>
   /// 
   public class OrderProducts
   {
       [Key]
       public int OrderProductsId { get; set; }
       [Display(Name = "订单ID")]
       public int OrderId { get; set; }
       [Display(Name = "商品名称")]
       public string ProductName { get; set; }
       [Display(Name = "商品ID")]
       public int ProductID { get; set; }
       [Display(Name = "数量")]
       public int ProductCount { get; set; }
       [Display(Name = "总金额")]
       public float CountPayment { get; set; }
       [Display(Name = "实付金额")]
       public float ActualPayment { get; set; }
       [Display(Name = "优惠金额")]
       public float Preferential { get; set; }

   }

}
