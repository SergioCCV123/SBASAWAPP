//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBASAWAPP
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTSPS
    {
        public int ID_SALE { get; set; }
        public int ID_PRODUCT { get; set; }
        public int QUANTITY { get; set; }
    
        public virtual PRODUCT PRODUCTS { get; set; }
        public virtual SALES SALES { get; set; }
    }
}