//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaContable.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVEEDOR()
        {
            this.CHEQUE = new HashSet<CHEQUE>();
            this.COMPRA = new HashSet<COMPRA>();
        }
    
        public int COD_PROVEEDOR { get; set; }
        public string NOM_PROVEEDOR { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION_PROVEEDOR { get; set; }
        public string NIT_PROVEEDOR { get; set; }
        public string GIRO_DE_EMPRESA { get; set; }
        public Nullable<int> NUM_IVA_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHEQUE> CHEQUE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRA> COMPRA { get; set; }
    }
}
