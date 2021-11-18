using LoginPractica2_5to.Models;
using LoginPractica2_5to.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

namespace LoginPractica2_5to
{
    public partial class Frm_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                string usuario = txt_usu.Text.TrimStart().TrimEnd();
                string cla = txt_pass.Text;

                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(cla))
                {

                    //SE DESENCRIPTA LA CONTRASEÑA PARA EL LOGIN
                    var login = LNUsuario.DesencriptarxLogin(usuario, cla);

                    if (login != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Buen Trabajo', 'Bienvenido','success')</script>");
                        Response.Redirect("~/Frm_Inicio.aspx");

                    }
                    else
                    {
                        //SI EL USUARIO INGRESA MAL LA CLAVE SE RESETEA LOS INTENTOS
                        LNUsuario.restarintentos(txt_usu.Text);

                        txt_pass.Text = "";
                        txt_usu.Text = "";

                        ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'Usuario o Contraseña Incorrecta','error')</script>");

                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'Ingrese Datos','info')</script>");

                }


            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'FALLO CONEXION BD','error')</script>");
            }
        }

        protected void txt_usu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //VERIFICA SI INGRESO LOS 3 INTENTOS NO TE PERMITIRA SEGUIR LOGEANDOTE
                var lista = LNUsuario.Intentos(txt_usu.Text);
                if (lista.intentos <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'SOBREPASO EL LIMITE RESTAURE SU CUENTA','error')</script>");
                    btnIngresar.Visible = false;
                    btnOlvido.Visible = true;
                    txt_usu.Visible = false;
                    txt_pass.Visible = false;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnOlvido_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Frm_Olvido.aspx");
        }
    }
}