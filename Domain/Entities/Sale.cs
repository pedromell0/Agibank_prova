using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }

        public string SalesmanName { get; set; }

        public IList<SaleItem> Items { get; set; }

        public Sale(string[] aLine)
        {
            SaleId = int.Parse(aLine[1]);
            SalesmanName = aLine[3];
            ResolveSaleItems(aLine[2]);                       
        }

        public double GetSaleTotal() => Items.Select(e => e.Quantity * e.Price).Aggregate((result, item) => result + item);        

        private void ResolveSaleItems(string itemsLineSB)
        {
            Items = new List<SaleItem>();
            string itemsLine = itemsLineSB.Substring(1, itemsLineSB.Length - 2);
            
            foreach (var item in itemsLine.Split(','))
            {
                SaleItem saleItem  = new SaleItem(item.Split('-'));
                Items.Add(saleItem);
            }
        }
    }
}
