using System;
using System.Collections.Generic;

namespace IBO.MVC03.CircloidTemplate
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool? Discontinued { get; set; }
        //public string CompanyName { get { return this.Supplier.ContactName; } set { CompanyName = value; } }
        //public string CategoryName { get { return this.Category.CategoryName; } set { CategoryName = value; } }
        public Categories Category { get; set; }
        public Suppliers Supplier { get; set; }
    }
}
