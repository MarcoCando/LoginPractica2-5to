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


        //public static List<SpDesencriptar_Result> getLoginXEncrypt(string nombre, string clave)
        //{
        //    List<SpDesencriptar_Result> ced;

        //    using (var context = new PL_PracticaEntities1())
        //    {
        //        ced = context.SpDesencriptar(nombre.TrimStart().TrimEnd(), clave.TrimStart().TrimEnd()).ToList();
        //    }
        //    ced.ToString();
        //    return ced;
        //}

        //public static List<SpDesencriptar_Result> getLoginXDesencrypt(string nombre, string clave)
        //{
        //    List<SpDesencriptar_Result> usu;

        //    using (var context = new PL_PracticaEntities1())
        //    {
        //        usu = context.SpDesencriptar(nombre,clave).ToList();
        //    }

        //   usu.ToString();

        //    return usu;
        //}
       

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

        public static string ObtenerClave(string usuario)
        {
            string usu;

            using (var context = new PL_PracticaEntities1())
            {
                usu = context.SpObtenerCorreo(usuario).FirstOrDefault();
            }


            return usu;
        }
        public static string EnviarCorreo(string usuario)
        {
            string usu;

            using (var context = new PL_PracticaEntities1())
            {
                usu = context.SpObtenerCorreo(usuario).FirstOrDefault();
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



    }
}