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
    
    public partial class calculos
    {
        public int id_calculo { get; set; }
        public int id_donador_calculos { get; set; }
        public int id_gasto_calculos { get; set; }
        public int id_gasto1_calculos { get; set; }
        public int id_gasto2_calculos { get; set; }
        public System.DateTime fecha { get; set; }
        public decimal total { get; set; }
    
        public virtual donadores donadores { get; set; }
        public virtual gasto gasto { get; set; }
        public virtual gasto1 gasto1 { get; set; }
        public virtual gasto2 gasto2 { get; set; }
    }
}
