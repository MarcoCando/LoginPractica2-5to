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
                string email = txt_email.Text;
                //string clave;
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(email))
                {

                    var lista = LNUsuario.ObtenerClave(usuario);

                    // lblres.Text = lista.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire('Bien', 'Correo Enviado Correctamente','success')</script>");

                    EnviarCorreo(email, lista);
                    LNUsuario.restaurarintentos(txt_usu.Text);

                    Response.Redirect("~/Frm_Login.aspx");

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

        //public void ObtenerClave(string clave)
        //{

        //    var connectionstring = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        //    var pass = clave;

        //    using (SqlConnection sql = new SqlConnection(connectionstring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Sp_Correo", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@usuario", pass));
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            sql.Open();
        //            da.Fill(dt);
        //        }
        //    }


        //}

        public void ObtenerClave2(string clave)
        {
            DataSet ds = new DataSet();
            SqlConnection con;
            //Here we declare the parameter which we have to use in our application  
            SqlCommand cmd = new SqlCommand();
            SqlParameter sp1 = new SqlParameter();
            SqlParameter sp2 = new SqlParameter();
            SqlParameter sp3 = new SqlParameter();
            SqlParameter sp4 = new SqlParameter();

            con = new SqlConnection("Server=192.168.200.23l;Database=PL_Practica;Uid=andy;Pwd=1515");

            //con = new SqlConnection("server = (192.168.200.23); database = PL_Practica uid = andy; pwd = 1515");
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = clave;
            cmd = new SqlCommand("Sp_Correo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}