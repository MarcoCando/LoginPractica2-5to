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
    
    public partial class TBL_OBSERVACION
    {
        public int obs_id { get; set; }
        public System.DateTime obs_fecha { get; set; }
        public string obs_comentario { get; set; }
        public string obs_status { get; set; }
        public System.DateTime obs_add { get; set; }
        public int inc_id { get; set; }
        public int per_id { get; set; }
    
        public virtual TBL_INCIDENTE TBL_INCIDENTE { get; set; }
        public virtual TBL_INCIDENTE TBL_INCIDENTE1 { get; set; }
    }
}
