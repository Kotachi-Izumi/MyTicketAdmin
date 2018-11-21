using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;


namespace MyTicketAdmin.Models.DatosObj
{
    public class EnvioMail
    {
        public static bool sendMail()
        {
            var envioCorrecto = false;
            using (var email = new MailMessage())
            {
                using (var smtp = new SmtpClient())
                {
                    email.To.Add(new MailAddress("martinezcartes@gmail.com"));
                    email.From = new MailAddress("konata__izumi@hotmail.com");
                    email.Subject = "Prueba envio email MYTICKETADMIN";
                    email.Body = "El correo fue enviado correctamente";
                    email.IsBodyHtml = false;
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("konata__izumi@hotmail.com", "Luckystar.86");
                    try
                    {
                        smtp.Send(email);
                        envioCorrecto = true;
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                }
            }
            return envioCorrecto;
        }

    }
}