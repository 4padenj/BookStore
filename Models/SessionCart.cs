using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using System.Text.Json.Serialization;

namespace BookStore.Models
{
    public class SessionCart: Cart
    {
        public static Cart GetCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        
        public override void AddCartLine(Book bookToAdd, int qty)
        {
            base.AddCartLine(bookToAdd, qty);
            Session.SetJson("cart", this);
        }

        public override void RemoveCartLine(Book bookToRemove)
        {
            base.RemoveCartLine(bookToRemove);
            Session.SetJson("cart", this);
        }
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("cart");
        }
    }
}
