//Programmer: Shay Deshner
//Date: 2/19/2015
//Assginment: Week 7 LINQ
//Professor: David Moore



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQ_example
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string index = GridView1.SelectedDataKey.Value.ToString();
           lblSelectedIndex.Text = index;
           Cache["SelectedRecord"] = index;
           Server.Transfer("StronglyTyped_DetailsView.aspx");
        }
    }
}
    
