using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodApi.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("Sd")]
        public Items FastFoodShopModel { get; set; }
        public int IteamId { get; set; }
        [ForeignKey("FastFoodShopId")]
        public FastFoodShopId FastFoodShopeId { get; set; }
    }
}
