﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public ICollection<CartProduct> Products { get; set; }
    }
}
