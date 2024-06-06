using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace backend.Models
{
    public class AuthRequest
    {
        public string api_key { get; set; }
        public string api_secret { get; set; }
    }

    public class OrderRequest
    {
        public string order_type { get; set; }
        public string order_status { get; set; }
        public string store_code { get; set; }
        public string pickup_time { get; set; }
        public CustomerDetails customer_details { get; set; }
        public List<Item> items { get; set; }
        public PaymentDetails payment_details { get; set; }
        public PromotionDetails promotion_details { get; set; }
        public OrderTotals order_totals { get; set; }
        public string order_identifier { get; set; }

        public class CustomerDetails
        {
            public string id_number { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string mobile_phone { get; set; }
            public string address { get; set; }
        }

        public class Item
        {
            public string product_id { get; set; }
            public int quantity { get; set; }
            public string price { get; set; }
            public string total { get; set; }
            public List<Modifier> modifiers { get; set; }
        }

        public class Modifier
        {
            public string code { get; set; }
            public string description { get; set; }
        }

        public class PaymentDetails
        {
            public string payment_method { get; set; }
        }

        public class PromotionDetails
        {
            public string code { get; set; }
            public double discount { get; set; }
        }

        public class OrderTotals
        {
            public double total_order { get; set; }
            public double total_taxes { get; set; }
            public double total_discounts { get; set; }
        }
    }


    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class RegisterRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
    }

    public class UserRequest
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public decimal? balance { get; set; }
    }

}
