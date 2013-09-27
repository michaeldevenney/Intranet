using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Shared;
using DAL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public User currentUser;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        currentUser = Data.GetUserFromLogin(Page.User.Identity.Name);
        lblLoggedInAs.Text = "Logged in as: " + currentUser.Name;
        
        //MailMessage msg = new MailMessage(new MailAddress("login@veritas-medicalsolutions.com"), new MailAddress("michael.devenney@veritas-medicalsolutions.com"));
        //msg.Subject = "Work Tracking Login";
        //msg.Body = Page.User.Identity.Name + " has logged into the " + Page.Title + " page.\r\n" +
        //    "Formatted name should be: " + Utils.GetFormattedUserNameInternal(Page.User.Identity.Name);

        //SmtpClient client = new SmtpClient("ver-sbs-01");
        //client.Send(msg);
    }
}
