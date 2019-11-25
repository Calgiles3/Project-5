using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;
using Hashing_DLL;

namespace Air_Travel_Info_Site.Member
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Clicked(object sender, EventArgs e)
        {
            // Look for user.
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("~/Member/App_LocalResources/Members.xml");
            FormsAuthenticationTicket ticket = null;

            XmlNode root = xmlDocument.FirstChild;
            foreach (XmlNode member in root.ChildNodes)
            {
                if(member["username"].InnerText == Username.Text)
                {
                    string storedSalt = member["salt"].InnerText;
                    string storedHash = member["hash"].InnerText;

                    string hashOfEnteredPassword = Hashing.Hash(Password.Text, storedSalt);

                    if (storedHash == hashOfEnteredPassword)
                    {
                        // Create ticket and redirect.
                        ticket = new FormsAuthenticationTicket(version: 1,
                            name: Username.Text,
                            issueDate: DateTime.Now,
                            expiration: DateTime.Now.AddMinutes(30),
                            isPersistent: false,
                            userData: "member");
                    }
                }
            }

            if (ticket != null)
            {
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(httpCookie);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(Username.Text, false));
            }
            else
            {
                Errorlabel.Text = "Username password combo is incorrect";
            }
        }
    }
}