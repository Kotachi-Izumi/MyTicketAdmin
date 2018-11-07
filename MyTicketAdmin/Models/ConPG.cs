using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using MyTicketAdmin.Models.DatosObj;

namespace MyTicketAdmin.Controllers
{
    public class ConPG
    {
        NpgsqlConnection con;
        NpgsqlCommand comandos;
        String urlCon = "Host= localhost; username= myticket; password= postgres; database = myticket";
        public String mensaje { get; set; }

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

        public Boolean agregar(int cod)
        {

            var log = false;
            con.Open();

            comandos = new NpgsqlCommand
            {
                Connection = con,
                CommandText = "INSERT INTO mt_tab_region VALUES (@cod,'BIO BIO','15/07/2017','18/10/2018')",
                CommandType = System.Data.CommandType.Text

            };
            comandos.Parameters.AddWithValue("@cod", cod);
            var resultOk = comandos.ExecuteNonQuery();
            if(resultOk > 0)
            {
                mensaje = "Agregado";
            }
            con.Close();
            return log;
        }

        public static bool autenticar(string user, string pass)
        {
            var log = false;

            using (myticketEntities myTicket = new myticketEntities())
            {
                 var lst = (from d in myTicket.mt_tab_usuario
                           where (d.usuario_nick_usuario == user) && (d.usuario_cod_password == pass)
                           select d).ToList();
                if(lst.Count > 0)
                {
                    log = true;
                }
                    }

            return log;
        }

        public void ingresarPersona(MPersona per, MDireccion dir)
        {
            per.AppMaterno = "Ocampo";
            per.AppPaterno = "Palacios";
            per.CodPersona = 2;
            per.DV = "5";
            per.Fnac = Convert.ToDateTime("1986-11-21");
            per.Fono = "222222222";
            per.Mail = "julian.palacios@email.com";
            per.nombre = "Julian Andres";
            per.Rut = 24089142;
            per.CodDireccion = 2;
            per.Celular = "953439463";

            dir.CodDireccion = 2;
            dir.CodComuna = 1;
            dir.DescCasa = "Lord Cochrane";
            dir.NumCasa = 184;
            using (myticketEntities myticket = new myticketEntities())
            {
                var mtDir = new mt_tab_direccion();
                var mtPer = new mt_tab_persona();
                mtDir.comuna_cod_comuna = dir.CodComuna;
                mtDir.direccion_cod_direccion = dir.CodDireccion;
                mtDir.direccion_dsc_direccion = dir.DescCasa;
                mtDir.direccion_num_direccion = dir.NumCasa;

                mtPer.persona_cod_persona = per.CodPersona;
                mtPer.persona_dsc_apmaterno = per.AppMaterno;
                mtPer.persona_dsc_appaterno = per.AppPaterno;
                mtPer.persona_dsc_nombre = per.nombre;
                mtPer.persona_fec_nacimiento = per.Fnac;
                mtPer.persona_num_celular = per.Celular;
                mtPer.persona_num_fono = per.Fono;
                mtPer.persona_num_rut = per.Rut;
                mtPer.persona_num_dv = per.DV;
                mtPer.direccion_cod_direccion = per.CodDireccion;

                myticket.mt_tab_direccion.Add(mtDir);
                myticket.mt_tab_persona.Add(mtPer);
                myticket.SaveChanges();

            }


        }

        public Boolean autenticar5()
        {
            var log = false;
            var query = "SELECT * FROM mt_tab_usuario";
            try
            {
                con.Open();
                using(NpgsqlCommand com = new NpgsqlCommand(query, con))
                {

                    com.CommandType = CommandType.Text;


                    var resultOk = com.ExecuteNonQuery();
                    if(resultOk > 0)
                    {
                        log = true;
                    }
                }
            }
            catch (NpgsqlException npe)
            {

                var error = npe.Message;
            }
            return log;
        }
        public Boolean autenticar4(String user, String pass)
        {
            var log = false;
            var query = "SELECT * FROM mt_tab_usuario WHERE (usuario_nick_usuario = @user AND usuario_cod_password = @pass);";
            try
            {
                using (NpgsqlConnection conex = new NpgsqlConnection(urlCon))
                {
                    conex.Open();

                    using (NpgsqlCommand com = new NpgsqlCommand(query, conex))
                    {
                        com.Parameters.Clear();
                        com.Parameters.Add(new NpgsqlParameter("@user", NpgsqlDbType.Varchar, 100, "usuario_nick_usuario") {
                            NpgsqlValue = user
                    });

                    com.Parameters.Add(new NpgsqlParameter("@pass", NpgsqlDbType.Varchar, 100, "usuario_cod_password")
                    {
                        NpgsqlValue = pass
                    });
                        /*com.Parameters.AddWithValue("@user", user);
                        com.Parameters.AddWithValue("@pass", pass);*/
                        var resultOK = com.ExecuteNonQuery();
                        if(resultOK > 0)
                        {
                            log = true;
                        }
                    }
                    conex.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return log;
        }

        public Boolean autenticar3(String user, String pass)
        {
            var log = false;

            try
            {

                using (NpgsqlConnection conex = new NpgsqlConnection(urlCon))
                {
                    conex.Open();

                    using(NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM mt_tab_usuario WHERE (usuario_nick_usuario = @user AND usuario_cod_password = @pass);", conex))
                    {

                        com.AllResultTypesAreUnknown = true;

                        com.Parameters.Add(new NpgsqlParameter
                        {
                            DbType = DbType.String,
                            ParameterName = "@user",
                            ConvertedValue = NpgsqlDbType.Varchar,
                            DataTypeName = "character varying",
                            NpgsqlDbType = NpgsqlDbType.Varchar,
                            Value = user
                        } //"@user", NpgsqlDbType.Varchar
                            );

                        com.Parameters.Add(new NpgsqlParameter {
                            DbType = DbType.String,
                            ParameterName = "@pass",
                            ConvertedValue = NpgsqlDbType.Varchar,
                            DataTypeName = "character varying",
                            NpgsqlDbType = NpgsqlDbType.Varchar,
                            Value = pass
                        }); //("@pass", NpgsqlDbType.Varchar)


                        var resultOk = com.ExecuteNonQuery();
                        if(resultOk > 0)
                        {
                            log = true;
                        }
                    }
                    conex.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return log;
        }

        public Boolean autenticar2(String user, String pass)
        {
            var log = false;

            try
            {
                abrirConexion();
                comandos = new NpgsqlCommand
                {
                    Connection = con,
                    CommandText = "SELECT * FROM mt_tab_usuario WHERE (usuario_nick_usuario = @user AND usuario_cod_password = @pass);",
                    CommandType = CommandType.Text

                };

                comandos.Parameters.Clear();
                comandos.Parameters.Add(new NpgsqlParameter("@user", NpgsqlDbType.Varchar));
                comandos.Parameters.Add(new NpgsqlParameter("@pass", NpgsqlDbType.Varchar));
                comandos.Prepare();
                comandos.Parameters[0].ConvertedValue = NpgsqlDbType.Varchar;
                comandos.Parameters[1].ConvertedValue = NpgsqlDbType.Varchar;
                comandos.Parameters[0].Value = user;
                comandos.Parameters[1].Value = pass;
                var resultOk = comandos.ExecuteNonQuery();
                if(resultOk > 0)
                {
                    log = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            cerrarConexion();
            return log;
        }

        public Boolean autenticar1(String user, String pass)
        {
            var log = false;
            try
            {

            //cREAR NPGSQL PARAMETER
            var user1 = new NpgsqlParameter();
            var pass1 = new NpgsqlParameter();
                //user1.DataTypeName = "character varying";
                //pass1.DataTypeName = "character varying";
                user1.NpgsqlDbType = NpgsqlDbType.Varchar;
                pass1.NpgsqlDbType = NpgsqlDbType.Varchar;




            comandos = new NpgsqlCommand
            {
                Connection = con,
                CommandText = "SELECT usuario_cod_password, usuario_nick_usuario FROM mt_tab_usuario WHERE (usuario_nick_usuario = @user AND usuario_cod_password = @pass);",
                CommandType = System.Data.CommandType.Text
            };
                user1.ParameterName = "@user";
                pass1.ParameterName = "@pass";

                comandos.Parameters.Add(user1);
                comandos.Parameters.Add(pass1);
                comandos.Parameters[0].DataTypeName = "character varying";
                comandos.Parameters[1].DataTypeName = "character varying";

                //comandos.Prepare();

                comandos.Parameters[0].Value = user;
                comandos.Parameters[1].Value = pass;

                //comandos.Parameters.Clear();
                /*
                comandos.Parameters["@user"].Value = user;
                comandos.Parameters["@pass"].Value = pass;*/


                /*comandos.Parameters.AddWithValue("'@user'", user);
                comandos.Parameters.AddWithValue("@pass", pass);*/
                abrirConexion();
                var resultOk = comandos.ExecuteNonQuery();

                if (resultOk > 0/*comandos.ExecuteScalar() != null*/)
                {
                    log = true;
                }
            }
            catch (NpgsqlException ne)
            {
                log = false;
                var e = ne.Message;

            }
            finally
            {
                cerrarConexion();

            }
            return log;

        }

    }
}