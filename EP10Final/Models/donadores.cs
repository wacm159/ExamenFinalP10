//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EP10Final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class donadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donadores()
        {
            this.calculos = new HashSet<calculos>();
        }
    
        public int id_donador { get; set; }
        public string nombre { get; set; }
        public decimal aporte_pib { get; set; }
        public int id_porcentaje_donador { get; set; }
        public int id_producto_donador { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int id_pais_donador { get; set; }
        public int id_continente_donador { get; set; }
        public Nullable<decimal> total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calculos> calculos { get; set; }
        public virtual continente continente { get; set; }
        public virtual pais pais { get; set; }
        public virtual porcentajes porcentajes { get; set; }
        public virtual productos productos { get; set; }
    }
}
