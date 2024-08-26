using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.CartDTO
{
    public class CartItemsDto
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
