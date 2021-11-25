
using eMovies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.DTO
{
    public class ShoppingCartVM
    {
        public ShoppingCartService ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }

    }
}
