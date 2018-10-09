using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

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
            comandos = new NpgsqlCommand();
            comandos.Connection = con;
            comandos.CommandText = "INSERT INTO mt_tab_region VALUES (02,'ARAUCANIA','11/07/2017','12/10/2018')";
            //comandos.CommandText = "SELECT * FROM prueba";
            comandos.CommandType = System.Data.CommandType.Text;
            comandos.ExecuteNonQuery();
           
        }

    }
}