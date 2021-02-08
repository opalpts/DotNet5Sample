using System;
using System.Collections.Generic;

namespace DotNet5Sample.Core.ViewModels
{
    public class DetailViewModels
    {
        public List<ProductViewModel> Products { get; set; }

        public class OfferViewModel
        {
            public int id { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public bool approve { get; set; }
        }
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Product_Name { get; set; }
            public int Qnt { get; set; }
            public float Price { get; set; }
        }
        public class OrderViewModel
        {
            public int Order_Id { get; set; }
            public string Order_NameCus { get; set; }
            public float TotalPrice { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }
        public class OrderDetailViewModel
        {
            public int OrderDetial_Id { get; set; }
            public int Order_Id { get; set; }
            public int Product_Id { get; set; }
            public int Qnt { get; set; }
            public float Price { get; set; }
        }
    }
}
