using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;

namespace MyTicketAdmin.Controllers
{
    public class ConPG
    {
        NpgsqlConnection con;
        NpgsqlCommand comandos;
        String urlCon = "Host= localhost; username= myticket; password= postgres; database = myticket";

        public ConPG()
        {
            try
            {
                con = new NpgsqlConnection(urlCon);
            }
            catch (NpgsqlException npgsql)
            {
                Console.WriteLine("Error \n" + npgsql.Message);
            }
        }

        public void abrirConexion()
        {
            con.Open();
        }
        public void cerrarConexion()
        {
            con.Close();
        }

        public void agregar()
        {
            comandos = new NpgsqlCommand
            {
               Connection = con,
            CommandText = "INSERT INTO mt_tab_region VALUES (02,'ARAUCANIA','11/07/2017','12/10/2018')",
            //comandos.CommandText = "SELECT * FROM prueba";
            CommandType = System.Data.CommandType.Text
            };
            comandos.ExecuteNonQuery();
        }

        public Boolean autenticar(String user, String pass)
        {
            var log = false;
            abrirConexion();
            var user1 = new NpgsqlParameter();
            var pass1 = new NpgsqlParameter();
                user1.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            pass1.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            user1.NpgsqlValue = user;
            pass1.NpgsqlValue = pass;                  
            comandos = new NpgsqlCommand
            {
                Connection = con,
                CommandText = "SELECT * FROM mt_tab_usuario WHERE (usuario_nick_usuario = @user AND usuario_cod_password = @pass)",
                CommandType = System.Data.CommandType.Text,
            };
            comandos.Parameters.Clear();
            comandos.Parameters.Add(user1);
            comandos.Parameters.Add(pass1);
            //comandos.Prepare();
            var resultOk = (int) comandos.ExecuteScalar();
            //var resultOk = comandos.ExecuteNonQuery();
            if (resultOk > 0)
            {
                log = true;
            }
            return log;
        }

    }
}