//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplicationDBApproach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_product
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Phonenum { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
    
        public virtual tbl_category tbl_category { get; set; }
    }
}