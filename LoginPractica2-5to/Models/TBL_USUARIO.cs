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
    
    public partial class TBL_USUARIO
    {
        public int usu_id { get; set; }
        public int rol_id { get; set; }
        public string usu_login { get; set; }
        public string usu_password { get; set; }
        public string usu_email { get; set; }
        public System.DateTime usu_add { get; set; }
        public string usu_status { get; set; }
        public int per_id { get; set; }
    
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
        public virtual TBL_ROL TBL_ROL { get; set; }
    }
}
