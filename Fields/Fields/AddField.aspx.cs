﻿using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fields
{
    public partial class AddField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserName = "venu.kalam@acuvate.com";
            string Passkey = "Kvr@1708";
            var Password = new SecureString();

            foreach (char c in Passkey)
            {
                Password.AppendChar(c);

            }


            ClientContext clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/TestS");
            clientContext.Credentials = new SharePointOnlineCredentials(UserName, Password);
            Web web = clientContext.Web;
            clientContext.Load(web);
            List list = web.Lists.GetByTitle("Creating a List");
          //  FieldCollection fields = list.Fields;
            string Name = FieldName.Text;
            string Desc = Description.Text;

          


                //string Type = FieldType.SelectedValue;

                Field field = list.Fields.AddFieldAsXml("<Field DisplayName= '" + Name + "'     Description= '" + Desc + "'   Type='" + FieldType.SelectedValue + "'/>", true, AddFieldOptions.DefaultValue);
                field.Update();
                clientContext.ExecuteQuery();
                //string Addfiled = "<Field Type= " + Type + "/>"+ "<DisplayName= " + Name + "/>"+ "<Description= " + Description+"/>";


                //  string Addfiled = "<Field Type='Text' DisplayName = 'Silicon' Name='Silicon'/>";


                //FieldCollection fields = list.Fields;
                //fields.AddFieldAsXml(Addfiled, true, AddFieldOptions.AddToDefaultContentType);

                //clientContext.ExecuteQuery();

                Label1.Text = "Added Successfully";




            }
            //else
            //{
            //    Label2.Text = "Column name already exist,Enter with Unique Name";
            //}
        }
    }
//}