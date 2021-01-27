using System;

namespace DotNet5Sample.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public string Order_NameCus { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
