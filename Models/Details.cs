//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCExamen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Details
    {
        public int DetailID { get; set; }
        public bool IsActive { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public int ProductID { get; set; }
        public int InvoiceID { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        public virtual Products Products { get; set; }
    }
}
