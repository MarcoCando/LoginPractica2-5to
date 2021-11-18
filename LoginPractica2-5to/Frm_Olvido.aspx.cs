using LoginPractica2_5to.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginPractica2_5to.Logica;


namespace LoginPractica2_5to
{
    public partial class Frm_Olvido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string usuario = txt_usu.Text.TrimStart().TrimEnd();

                if (!string.IsNullOrEmpty(usuario))
                {

                    var lista = LNUsuario.ObtenerCorreoxUsu(usuario); //OBTIENE EL CORREO DEL USUARIO MEDIANTE LA BASE DE DATOS
                    var email = LNUsuario.EnviarCorreosXUsuario(usuario); //ENVIA CORREO CON LA CONTRASEÑA DESENCRIPTADA 
                    LNUsuario.restaurarintentos(txt_usu.Text);
                    EnviarCorreo(lista, email);
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Bien', 'Correo Enviado Correctamente','success')</script>");
                    Response.Write("<script language=javascript>alert('ERROR');</script>");
                    Response.Redirect("~/Frm_Login.aspx");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'Ingrese Datos','info')</script>");

                }


            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Error', 'Usuario Inexistente intente de Nuevo','error')</script>");
            }
        }

        public void EnviarCorreo(string correo, string clave)
        {
            TBL_USUARIO dc = new TBL_USUARIO();

            string emailorigen = "andy.cando.20@gmail.com";
            string emaildestino = correo;
            string contra = "1726384090";

            MailMessage oMailMessage = new MailMessage(emailorigen, emaildestino, "RECUPERACION CLAVE", "ESTIMADO USUARIO LE RECORDAMOS QUE SU CONTRASEÑA ES:" + clave);
            oMailMessage.IsBodyHtml = true;
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(emailorigen, contra);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();

        }



    }
}