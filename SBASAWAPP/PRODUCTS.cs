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
    
    public partial class PRODUCTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTS()
        {
            this.HISTORY = new HashSet<HISTORY>();
            this.PRODUCTSPS = new HashSet<PRODUCTSPS>();
            this.SHOPP_CART = new HashSet<SHOPP_CART>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public string URL { get; set; }
        public Nullable<int> CATEGORY { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
    
        public virtual CATEGORIES CATEGORIES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORY> HISTORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTSPS> PRODUCTSPS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOPP_CART> SHOPP_CART { get; set; }
    }
}