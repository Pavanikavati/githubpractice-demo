using FastFoodApi.DataAccess;
using System;
using System.Collections.Generic;

namespace FastFoodApi.Controllers
{
    internal class FastFoodApilDbContext
    {
        internal object fastfoodModels;
        internal object fastfoodshopModels;
        internal IEnumerable<object> medicalModels;

        public object FastFoodShopModels { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public static implicit operator FastFoodApilDbContext(FastFoodContext.FastFoodDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}