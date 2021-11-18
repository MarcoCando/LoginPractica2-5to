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
                && data.usu_pass.Equals(clave)).FirstOrDefaultAsync();

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
                && data.usu_pass.Equals(clave)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Usuarios");
            }

        }

        public static string ObtenerCorreos(string usuario)
        {
            string usu;

            using (var context = new PL_PracticaEntities1())
            {
                usu = context.SpObtenerCorreoUsu(usuario).FirstOrDefault();
            }


            return usu;
        }
        public static string EnviarCorreos(string usuario)
        {
            string usu;

            using (var context = new PL_PracticaEntities1())
            {
                usu = context.Sp_EnviarCorreoClave(usuario).FirstOrDefault();
            }


            return usu;
        }
        public static string EnviarCorreosXUsuario(string usuario)
        {
            string intento;
            using (var context = new PL_PracticaEntities1())
            {
                var lista = context.Sp_EnviarCorreoClave(usuario);
                intento = lista.FirstOrDefault();
            }

            return intento;

        }

        public static string ObtenerCorreoxUsu(string usuario)
        {
            string usu;

            using (var context = new PL_PracticaEntities1())
            {
               var lista = context.SpObtenerCorreoUsu(usuario);
                usu = lista.FirstOrDefault();
            }


            return usu;
        }

        public static TBL_USUARIO Intentos(string usuario)
        {
            TBL_USUARIO intento;
            using (var context = new PL_PracticaEntities1())
            {
                var lista = from ct in context.TBL_USUARIO
                            where ct.usu_login == usuario
                            select ct;
                intento = lista.FirstOrDefault();
            }

            return intento;

        }

        public static void restarintentos(string usuario)
        {
            using (var context = new PL_PracticaEntities1())
            {
                var lista = context.TBL_USUARIO.Where(x => x.usu_login.TrimEnd().TrimStart() == usuario.TrimEnd().TrimStart()).ToList();
                if (lista != null)
                {
                    lista[0].intentos = Convert.ToInt32(int.Parse(lista[0].intentos.ToString()) - 1);
                }
                context.SaveChanges();
            }
        }

        public static void restaurarintentos(string usuario)
        {
            using (var context = new PL_PracticaEntities1())
            {
                var lista = context.TBL_USUARIO.Where(x => x.usu_login.TrimEnd().TrimStart() == usuario.TrimEnd().TrimStart()).ToList();
                if (lista != null)
                {
                    lista[0].intentos = 2;
                }
                context.SaveChanges();
            }
        }
        public static SpDesencriptar_Result DesencriptarLogin(string usuario, string clave)
        {
            SpDesencriptar_Result intento;
            using (var context = new PL_PracticaEntities1())
            {
                var lista = context.SpDesencriptar(clave, usuario);
                intento = lista.FirstOrDefault();
            }

            return intento;

        }
        public static SpDesencriptarLogin_Result DesencriptarxLogin(string usuario, string clave)
        {
            SpDesencriptarLogin_Result intento;
            using (var context = new PL_PracticaEntities1())
            {
                var lista = context.SpDesencriptarLogin(clave, usuario);
                intento = lista.FirstOrDefault();
            }

            return intento;

        }


    }
}