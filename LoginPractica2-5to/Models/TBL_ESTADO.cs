//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginPractica2_5to.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_ESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ESTADO()
        {
            this.TBL_INCIDENTE = new HashSet<TBL_INCIDENTE>();
        }
    
        public int est_id { get; set; }
        public string est_descripcion { get; set; }
        public string est_status { get; set; }
        public System.DateTime est_add { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INCIDENTE> TBL_INCIDENTE { get; set; }
    }
}
