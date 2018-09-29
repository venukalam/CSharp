﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Repository.Products;
using Repository.Repositories;

namespace September24_2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.IsInRole("Product"))
            {

            }
            else
            {
                Response.Redirect("/Account/Lockout");
            }



            int LengthOfList = 0;

            List<Product> List = new List<Product>();

            
            GetAllProducts getAllProducts = new GetAllProducts();

            List = getAllProducts.GetallProductsMethod();


            HyperLink Insert = new HyperLink();

            Insert.Text = "INSERT";
            Insert.NavigateUrl = "Insert.aspx";

            PlaceHolderforInsertButton.Controls.Add(Insert);

           
            Table tb = new Table();
            tb.BorderWidth = 3;
            tb.BorderStyle = BorderStyle.Solid;
            tb.ID = "myTable";
            tb.CellSpacing = 20;
            tb.CellPadding = 10;

            TableRow tr = new TableRow();

            foreach (Product P in List)
            {
                tb.Rows.Add(tr);

                TableCell tc1 = new TableCell();

                Image image = new Image();
                image.ImageUrl = P.URL;
                image.Width = 250;
                image.Height = 150;

                HyperLink HL = new HyperLink();
                String name = P.Name;
                HL.Text = P.Name;
                HL.ID = P.Id.ToString();
                HL.NavigateUrl = "ProductDetails.aspx?Id=" + P.Id;
               
                HyperLink Preview = new HyperLink();

                Preview.Text = "SELECT";
                Preview.NavigateUrl = "Preview.aspx?Id=" + P.Id;


                HyperLink Update = new HyperLink();

                Update.Text = "UPDATE";
                Update.NavigateUrl = "Update.aspx?Id="+P.Id+"&Name="+ P.Name+ "&Price="+ P.Price+ "&URL="+ P.URL+"&Description=" + P.Description;


                HyperLink Delete = new HyperLink();

                Delete.Text = "DELETE";
                Delete.NavigateUrl = "Delete.aspx?Id=" + P.Id;


                tc1.Controls.Add(image);
                tc1.Controls.Add(HL);
                tc1.Controls.Add(Preview);
                tc1.Controls.Add(Update);
                tc1.Controls.Add(Delete);
               
                tr.Cells.Add(tc1);
                LengthOfList++;

                if (LengthOfList % 2 == 0)
                {
                    tr = new TableRow();
                    
                }
            }

            PlaceHolderforProductTable.Controls.Add(tb);


        }
    }
}



       