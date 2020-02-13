using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        
        public double Price { get; set; }

        public SaleItem(string[] aLine)
        {
            Id = int.Parse(aLine[0]);
            Quantity = int.Parse(aLine[1]);
            Price = double.Parse(aLine[2]);
        }
    }
}
