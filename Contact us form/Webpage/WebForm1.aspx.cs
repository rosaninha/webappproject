using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Webpage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                var from = "2021rosana2021@gmail.com";
                var to = "2021rosana2021@gmail.com";
                const string Password = "Netrio84";
                string mail_subject = txt_subject.Text.ToString();
                string mail_message = "From: " + txt_name.Text + "\n";
                mail_message += "Email: " + txt_email.Text + "\n";
                mail_message += "Phone: " + txt_phone.Text + "\n";
                mail_message += "Subject: " + txt_subject.Text + "\n";
                mail_message += "Message: " + txt_message.Text + "\n";

                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, Password);
                    smtp.Timeout = 20000;
                }

                smtp.Send(from, to, mail_subject, mail_message);

                Confirm();
                confirm.Text = "Thank you for your email!";

                txt_name.Text = "";
                txt_email.Text = "";
                txt_phone.Text = "";
                txt_subject.Text = "";
                txt_message.Text = "";

            }
            catch (Exception ex)

            {
                confirm.Text = "Something went wrong! Please try again.\nError code:" + ex.Message;
                confirm.ForeColor = Color.Red;

            }
        }
        private void Confirm()
        {
            string ToEmail = txt_email.Text.Trim();
            string UserName = txt_name.Text;
            string subject2 = txt_subject.Text;

            MailMessage mailMessage = new MailMessage("2021rosana2021@gmail.com", ToEmail);

            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear" + UserName);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("Thank you for your email");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("We received your email regarding " + subject2 + "<br/>");
            sbEmailBody.Append("We will be back to you as soon as possible.");
            sbEmailBody.Append("<br/><br/><br/>");
            sbEmailBody.Append("Sincerely, ");
            sbEmailBody.Append("Master Service");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Re: Thank you for your email";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("2021rosana2021@gmail.com", "Netrio84");

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);



        }
    }
}