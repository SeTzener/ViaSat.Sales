using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaSat.Sales.Entities
{
    public class Good
    {
        public Good(int quantity, string name,  bool isExempt, decimal price)
        {
            this.Quantity = quantity;
            this.Name = name;
            this.IsImported = name.IndexOf("imported") != -1 ? true : false;
            this.Price = price;

            if (!this.IsImported && isExempt)
                this.Tax = 0;
            else if (this.IsImported && isExempt)
                this.Tax = Math.Round((price / 100) * 5, 2, MidpointRounding.AwayFromZero) * quantity;
            else if (this.IsImported && !isExempt)
                this.Tax = Math.Round((price / 100) * 15, 2, MidpointRounding.AwayFromZero) * quantity;

            else
                this.Tax = Math.Round((price / 100) * 10, 2, MidpointRounding.AwayFromZero) * quantity;

            this.Total = (this.Price + this.Tax) * quantity;
        }
        public int Quantity { get; private set; }
        public string Name { get; private set; }
        public bool IsImported { get; private set; }
        public bool IsExempt { get; set; }
        public decimal Price { get; private set; }
        public decimal Tax { get; private set; }
        public decimal Total { get; private set; }
    }
}
