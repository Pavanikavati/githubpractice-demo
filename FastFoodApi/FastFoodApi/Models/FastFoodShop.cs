using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodApi.Models
{
    public class FastFoodShop
    {
        [Key]
        public int FastFoodShopId { get; set; }
        public string FastFoodShopName { get; set; }
        public string City { get; set; }

        private string fastFoodPhonenumber;

        public string GetFastFoodPhonenumber()
        {
            return fastFoodPhonenumber;
        }

        public void SetFastFoodPhonenumber(string value)
        {
            fastFoodPhonenumber = value;
        }

        public ICollection<FastFoodShop> fastfoodShop { get; set; }
    }
}
