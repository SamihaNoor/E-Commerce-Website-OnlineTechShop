//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineTechShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase_Log
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }
        public decimal BuyingPrice { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Features { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> PurchasedDate { get; set; }
    }
}
