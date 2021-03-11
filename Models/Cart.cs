using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddCartLine(Book bookToAdd, int qty)
        {
            CartLine line = Lines.Where(b => b.Book.BookID == bookToAdd.BookID).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bookToAdd,
                    Quantity = qty
                });
            } else
            {
                line.Quantity += qty;
            }
        }
        public virtual void RemoveCartLine(Book bookToRemove) =>
            Lines.RemoveAll(line => line.Book.BookID == bookToRemove.BookID);
        public virtual void ClearCart() => Lines.Clear();

        public double ComputeTotalSum()
        {
            // Compute Total:
            
            return Lines.Sum(e => e.Book.Price * e.Quantity);
            //return 
        }

        public class CartLine 
        { 
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }

        }


    }
}
