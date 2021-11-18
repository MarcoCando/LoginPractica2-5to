using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPractica2_5to
{
    public partial class Frm_Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Buen Trabajo', 'Bienvenido','success')</script>");

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'Error','danger')</script>");
            }
        }
    }
}