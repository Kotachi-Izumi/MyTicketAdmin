using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using MyTicketAdmin.Models.DatosObj;
using System.Collections.Generic;
using System.Web.Mvc;

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

        //Verifica si el usuario y el password ingresado esta registrado
        public static int autenticar(string user, string pass)
        {
            var log = 0;

            using (myticketEntities myTicket = new myticketEntities())
            {
                 var lst = (from d in myTicket.mt_tab_usuario
                           where (d.usuario_nick_usuario == user) && (d.usuario_cod_password == pass)
                           select d).ToList();
                if(lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                       log = (int) item.usuario_cod_usuario;
                    }
                }
                    }

            return log;
        }

        //Obtiene el codigo de rol de usuario
        public static int rolUsuario(int codUsuario)
        {
            var rol = 0;
            using(var myticket = new myticketEntities())
            {
                var lst = (from d in myticket.mt_tab_rolusua
                           where (d.usuario_cod_usuario == codUsuario)
                           select d).ToList();
                foreach (var item in lst)
                {
                    rol = (int)item.rol_cod_rol;
                }
             
            }
            return rol;
        }
        //Obtiene la lista de comunas
        public static List<String> comunas()
        {
            var lst = new List<String>();
            using(var bd = new myticketEntities())
            {
              
                foreach(var com in bd.mt_tab_comuna)
                {
                    lst.Add(com.comuna_nom_comuna);
                }
            }
            return lst;
        }
        //Obtiene la lista de regiones
        public static List<string> regiones()
        {
            var regiones = new List<string>();
            using (var bd = new myticketEntities())
            {
                foreach(var region in bd.mt_tab_region)
                {
                    regiones.Add(region.region_dsc_region);
                }
            }
            return regiones;
        }
        //Obtiene la lista de areas con su codigo
        public static Dictionary<int,string> areas()
        {
            var areas = new Dictionary<int,string>();
            using (var bd = new myticketEntities())
            {
                foreach (var item in bd.mt_tab_areas)
                {
                    areas.Add((int)item.area_cod_area, item.area_nombre_area);
                }
            }
            return areas;
        }
        //Obtiene la lista de roles con su codigo
        public static Dictionary<int,string>roles(){
            var roles = new Dictionary<int, string>();
            using (var bd = new myticketEntities())
            {
                foreach(var item in bd.mt_tab_rol)
                {
                    roles.Add((int)item.rol_cod_rol, item.rol_dsc_rol);
                }
            }
            return roles;
            }

        //Busca el cliente por su id
        public static MCliente buscarCliente(int idCLiente)
        {
            var id = idCLiente;
            var cliente = new MCliente();
            using(var per = new myticketEntities())
            {
                var persona = per.mt_tab_persona.Find(id);
                var dir = per.mt_tab_direccion.Find((long)persona.direccion_cod_direccion);
                var com = per.mt_tab_comuna.Find((long)dir.comuna_cod_comuna);
                var reg = per.mt_tab_region.Find((long)com.comuna_cod_region);
                cliente.apMaterno = persona.persona_dsc_apmaterno;
                cliente.apPaterno = persona.persona_dsc_appaterno;
                cliente.cel = persona.persona_num_celular;
                cliente.dv = persona.persona_num_dv;
                cliente.rut = (int)persona.persona_num_rut;
                cliente.fNac = (DateTime)persona.persona_fec_nacimiento;
                cliente.email = persona.persona_dsc_mail;
                cliente.nombre = persona.persona_dsc_nombre;
                cliente.codPersona = idCLiente;
                cliente.comuna = com.comuna_nom_comuna;
                cliente.region = reg.region_dsc_region;
                cliente.descCasa = dir.direccion_dsc_direccion;
                cliente.numCasa = (int)dir.direccion_num_direccion;
            }
            return cliente;
        }
        //buscar el ejecutivo que atendio la solicitud
        public static MCSR buscarEjecutivo(int idUsuario)
        {
            var id = idUsuario;
            var csr = new MCSR();
            using (var per = new myticketEntities())
            {
                var usuario = per.mt_tab_usuario.Find(idUsuario);
                var persona = per.mt_tab_persona.Find(usuario.usuario_cod_persona);
                var dir = per.mt_tab_direccion.Find(persona.direccion_cod_direccion);
                var com = per.mt_tab_comuna.Find(dir.comuna_cod_comuna);
                var reg = per.mt_tab_region.Find(com.comuna_cod_region);
                csr.apMaterno = persona.persona_dsc_apmaterno;
                csr.apPaterno = persona.persona_dsc_appaterno;
                csr.cel = persona.persona_num_celular;
                csr.dv = persona.persona_num_dv;
                csr.rut = (int)persona.persona_num_rut;
                csr.fNac = (DateTime)persona.persona_fec_nacimiento;
                csr.email = persona.persona_dsc_mail;
                csr.nombre = persona.persona_dsc_nombre;
                csr.codPersona = (int)persona.persona_cod_persona;
                csr.comuna = com.comuna_nom_comuna;
                csr.region = reg.region_dsc_region;
                csr.descCasa = dir.direccion_dsc_direccion;
                csr.numCasa = (int)dir.direccion_num_direccion;
                csr.codArea = (int)usuario.usuario_cod_area;
                csr.codEstado = (int)usuario.usuario_cod_estado;
                csr.codUsuario = idUsuario;
                csr.nick = usuario.usuario_nick_usuario;
                
            }
            return csr;
        }
        //Obtiene el codigo de la comuna
        public static int codComuna(string nomComuna)
        {
            var codComuna = 0;
            using(var mt = new myticketEntities())
            {
                var lst = (from d in mt.mt_tab_comuna
                           where (d.comuna_nom_comuna == nomComuna)
                           select d).ToList();
                foreach (var item in lst)
                {
                    codComuna = (int) item.comuna_cod_comuna;
                }
            }
            return codComuna;
        }
        //Obtiene el codigo de la direccion
        public static int codDireccion()
        {
            var codDir = 0;
            using (var myTicket = new myticketEntities())
            {
                var lst = (from d in myTicket.mt_tab_direccion
                           select d);
                foreach (var item in lst)
                {
                    codDir = Convert.ToInt32(item.direccion_cod_direccion);
                }

                
            }
            return codDir;
        }
        //Ingresar usuario
        public static void ingresarUsuario(MUsuario mUser)
        {
            using(var mt = new myticketEntities())
            {
                var mtUsuario = new mt_tab_usuario
                {
                    usuario_cod_area = mUser.codArea,
                    usuario_cod_estado = mUser.codEstado,
                    usuario_cod_persona = mUser.codPersona,
                    usuario_nick_usuario = mUser.nick,
                    usuario_cod_password = mUser.pass
                };
                mt.mt_tab_usuario.Add(mtUsuario);
                mt.SaveChanges();
            }
        }
        //Ingresar rol usuario
        public static void ingresarRolUsua(MRolUsuario mRolUsu)
        {
            using(var mt = new myticketEntities())
            {
                var mtRolUsua = new mt_tab_rolusua
                {
                    rol_cod_rol = mRolUsu.codRol,
                    usuario_cod_usuario = mRolUsu.codUsuario,
                    rolusua_fec_fin = mRolUsu.fechaFin,
                    rolusua_fec_ini = mRolUsu.fechaInicio
                };
                mt.mt_tab_rolusua.Add(mtRolUsua);
                mt.SaveChanges();
            }
        }
        //Ingresar direccion
        public static void ingresarDireccion(MDireccion dir)
        {
            using (var myticket = new myticketEntities())
            {
                var mtDir = new mt_tab_direccion
                {
                    comuna_cod_comuna = dir.CodComuna,
                    direccion_dsc_direccion = dir.DescCasa,
                    direccion_num_direccion = dir.NumCasa
                };
                myticket.mt_tab_direccion.Add(mtDir);
                myticket.SaveChanges();
            }
        }
        //Ingresar persona
        public static void ingresarPersona(MPersona per)
        {

            using (myticketEntities myticket = new myticketEntities())
            {
                var mtPer = new mt_tab_persona
                {

                    persona_cod_persona = per.CodPersona,
                    persona_dsc_apmaterno = per.AppMaterno,
                    persona_dsc_appaterno = per.AppPaterno,
                    persona_dsc_nombre = per.nombre,
                    persona_fec_nacimiento = per.Fnac,
                    persona_num_celular = per.Celular,
                    persona_num_fono = per.Fono,
                    persona_num_rut = per.Rut,
                    persona_num_dv = per.DV,
                    direccion_cod_direccion = per.CodDireccion
                };

                myticket.mt_tab_persona.Add(mtPer);
                myticket.SaveChanges();
            }


        }
        //Ingresa tickets
        public static void ingresarTicket(MTicket ticket)
        {
            using (var myTickets = new myticketEntities())
            {
                var fecha = DateTime.Now;
                var mtTickets = new mt_tab_ticket
                {
                    ticket_cod_gravedad = ticket.codGravedad,
                    ticket_cod_ticket = ticket.codTicket,
                    ticket_cod_per = ticket.codPersona,
                    ticket_cod_tipoatencion = ticket.codTipoAtencion,
                    ticket_est_ticket = ticket.codEstadoTicket,
                    ticket_es_masivo = ticket.esMasivo,
                    ticket_dsc_asunto = ticket.descAsunto,
                    ticket_dsc_detalle = ticket.detalleTicket,
                    ticket_fec_creacion = fecha,
                    ticket_fec_respuesta = fecha.AddDays(8),
                    ticket_fec_vencimiento = fecha.AddDays(16),
                    ticket_cod_usuaingreso = 1,
                    ticket_cod_usuaresponde = 1
                };
                myTickets.mt_tab_ticket.Add(mtTickets);
                myTickets.SaveChanges();
            }
        }
        //Obtiene los tickets
        public static List<mt_tab_ticket> Tickets(int id)
        {
            var ticket = new List<mt_tab_ticket>();
            using(var bd = new myticketEntities())
            {
                var lst = (from d in bd.mt_tab_ticket
                           orderby d.ticket_cod_ticket
                           where d.ticket_cod_per == id
                           select d).ToList();
                    ticket = lst;
            }
            return ticket;

        }
        //Convierte un modelo de tickets en entidad para bd
        public static mt_tab_ticket editTicket(MTicket ticket)
        {
        
                var mtTickets = new mt_tab_ticket
                {
                    ticket_cod_gravedad = ticket.codGravedad,
                    ticket_cod_ticket = ticket.codTicket,
                    ticket_cod_per = ticket.codPersona,
                    ticket_cod_tipoatencion = ticket.codTipoAtencion,
                    ticket_est_ticket = ticket.codEstadoTicket,
                    ticket_es_masivo = ticket.esMasivo,
                    ticket_dsc_asunto = ticket.descAsunto,
                    ticket_dsc_detalle = ticket.detalleTicket,
                    ticket_fec_respuesta = ticket.fechaRespuesta,
                    ticket_fec_vencimiento = ticket.fechaVencimiento,
                    ticket_cod_usuaingreso = ticket.codUsuarioIngreso,
                    ticket_cod_usuaresponde = ticket.codUsuarioResponde
                };
            return mtTickets;
        }
        //Convierte entidad de BD en modelo
        public static MTicket editTicket(mt_tab_ticket ticket)
        {

            var mtTickets = new MTicket
            {
                codGravedad = (int)ticket.ticket_cod_gravedad,
                codTicket = (int)ticket.ticket_cod_ticket,
                codPersona = ticket.ticket_cod_per,
                codTipoAtencion = (int)ticket.ticket_cod_tipoatencion,
                codEstadoTicket = (int)ticket.ticket_est_ticket,
                esMasivo = (bool)ticket.ticket_es_masivo,
                descAsunto = ticket.ticket_dsc_asunto,
                detalleTicket = ticket.ticket_dsc_detalle,
                fechaRespuesta = (DateTime)ticket.ticket_fec_respuesta,
                fechaVencimiento = (DateTime)ticket.ticket_fec_vencimiento,
                codUsuarioIngreso = (int)ticket.ticket_cod_usuaingreso,
                codUsuarioResponde = (int)ticket.ticket_cod_usuaresponde
            };
            return mtTickets;
        }
        //Actualiza o modifica los tickets
        public int updateTicket(MTicket ticket)
        {
            var query = "UPDATE mt_tab_ticket SET  ticket_fec_respuesta ='"+ticket.fechaRespuesta+"', ticket_cod_usuaresponde ='"+ticket.codUsuarioResponde+"',"
                +"ticket_dsc_detalle = '"+ticket.detalleTicket+"', ticket_es_masivo = '"+ticket.esMasivo+"',ticket_dsc_asunto = '"+ticket.descAsunto+"',ticket_est_ticket = '"+ticket.codEstadoTicket+"',ticket_fec_vencimiento = '"+ticket.fechaVencimiento+"',"+
                "ticket_cod_gravedad = '"+ticket.codGravedad+"', usuarioasig_cod_usuarioasign = '"+ticket.codUsuarioAsignado+"',ticket_cod_tipoatencion ='"+ticket.codTipoAtencion+"'";
            using(var com = new NpgsqlCommand(query))
            {
                abrirConexion();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                var result = com.ExecuteNonQuery();
                cerrarConexion();
                return result;
            }
        }

        //Metodos sin uso
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
            if (resultOk > 0)
            {
                mensaje = "Agregado";
            }
            con.Close();
            return log;
        }

    }
}