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
    
    public partial class TBL_PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PERSONA()
        {
            this.TBL_INCIDENTE = new HashSet<TBL_INCIDENTE>();
            this.TBL_USUARIO = new HashSet<TBL_USUARIO>();
        }
    
        public int per_id { get; set; }
        public string per_tipoidentificacion { get; set; }
        public string per_identificacion { get; set; }
        public string per_apellidos { get; set; }
        public string per_nombres { get; set; }
        public string per_direccion { get; set; }
        public string per_telefono { get; set; }
        public string per_email { get; set; }
        public System.DateTime per_add { get; set; }
        public string per_status { get; set; }
        public int dep_id { get; set; }
    
        public virtual TBL_DEPARTAMENTO TBL_DEPARTAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INCIDENTE> TBL_INCIDENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USUARIO> TBL_USUARIO { get; set; }
    }
}
