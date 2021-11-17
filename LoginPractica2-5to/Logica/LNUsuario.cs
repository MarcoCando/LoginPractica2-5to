using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LoginPractica2_5to.Models;

namespace LoginPractica2_5to.Logica
{
    public class LNUsuario
    {
        //INSTANCIAR DATOS
        private static PL_PracticaEntities1 dc = new PL_PracticaEntities1();

        public static async Task<List<TBL_USUARIO>> getAllUsers()
        {
            try
            {
                return await dc.TBL_USUARIO.Where(data => data.usu_status == "A").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Usuarios");
            }

        }

        public static List<TBL_USUARIO> getAllUsers2()
        {
            try
            {
                var res = dc.TBL_USUARIO.Where(data => data.usu_status == "A");
                return res.ToList();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Usuarios");
            }

        }

        public static async Task<TBL_USUARIO> getUserXLogin(string usuario, string clave)
        {
            try
            {
                return await dc.TBL_USUARIO.Where(data => data.usu_status == "A"
                && data.usu_login.Equals(usuario)
                && data.usu_password.Equals(clave)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Usuarios");
            }

        }
        public static async Task<TBL_USUARIO> getPass(string clave)
        {
            try
            {
                return await dc.TBL_USUARIO.Where(data => data.usu_status == "A"
                && data.usu_password.Equals(clave)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Usuarios");
            }

        }



    }
}