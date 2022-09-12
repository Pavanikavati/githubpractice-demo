using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodApi.Models
{
    public class Items
    {

        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string ItemVegOrNonVeg { get; set; }
        public string ItemFastFoodShopId { get; set; }
    }
}
