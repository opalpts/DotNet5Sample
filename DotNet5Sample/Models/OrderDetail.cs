using System;

namespace DotNet5Sample.Models
{
    public class OrderDetail
    {
        public int OrderDetial_Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Qnt { get; set; }
        public float Price { get; set; }
    }
}
