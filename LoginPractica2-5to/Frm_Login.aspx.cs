using LoginPractica2_5to.Models;
using LoginPractica2_5to.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPractica2_5to
{
    public partial class Frm_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int intentos = 0;

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                string usuario = txt_usu.Text.TrimStart().TrimEnd();
                string clave = txt_pass.Text;

                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(clave))
                {
                    TBL_USUARIO dataUsuario = new TBL_USUARIO();

                    var taskUserLogin = Task.Run(() => LNUsuario.getUserXLogin(usuario, clave));
                    taskUserLogin.Wait();
                    dataUsuario = taskUserLogin.Result;

                    //var login = LNUsuario.getLoginXEncrypt(clave, usuario).ToList();
                    if (dataUsuario != null)
                   // if (login != null)

                    {
                        //Response.Redirect("~/Frm_Inicio.aspx");
                        ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Buen Trabajo', 'Bienvenido','success')</script>");

                    }
                    else
                    {
                        //if (intentos == 3)
                        //{
                        //    txt_usu.Text = "";
                        //    txt_pass.Text = "";
                        //    intentos++;

                        //    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'SOBREPASO EL LIMITE','error')</script>");
                        //    btnIngresar.Visible = false;
                        //    btnOlvido.Visible = true;
                        //}
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

        protected void btnOlvido_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Frm_Olvido.aspx");
        }
    }
}