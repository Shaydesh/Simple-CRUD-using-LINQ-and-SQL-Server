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
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;

namespace LINQ_example
{
    public partial class StronglyTyped_DetailsView : System.Web.UI.Page
    {

        //If the page is not a post back load the infomration from the default page
        //else create a stongly typed dataset with LINQ
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                LoadFromDataGrid();
            }

            else
            {

                CustomerDataSetTableAdapters.CustomersTableAdapter customerTableAdapter =
                    new CustomerDataSetTableAdapters.CustomersTableAdapter();

                CustomerDataSet.CustomersDataTable customerDataTable =
                    new CustomerDataSet.CustomersDataTable();

                customerTableAdapter.Fill(customerDataTable);

                Session["DataTable"] = customerDataTable;

            }
        }



        protected void btnGetCustomer_Click(object sender, EventArgs e)
        {
            //This functions uses the the strongly typed DataSet created above and uses it set the 
            //values in the text boxes.  The advantage over SQL is less connection code and I can refer
            //to table rows using dot notation instead of strings, reducing errors.

            CustomerDataSet.CustomersDataTable customerDataTable =
                    (CustomerDataSet.CustomersDataTable)Session["DataTable"];

            var getRow = from Customers in customerDataTable
                         where Customers.CustomerID == Convert.ToInt32(txtCustomerID.Text)
                         select new
                         {
                             Customers.CustomerID,
                             Customers.FirstName,
                             Customers.LastName,
                             Customers.Gender,
                             Customers.City,
                             Customers.State
                         };
            try
            {
                var customerRecord = getRow.First();

                txtCustomerID.Text = customerRecord.CustomerID.ToString();
                txtFirstName.Text = customerRecord.FirstName.ToString();
                txtLastName.Text = customerRecord.LastName.ToString();
                txtGender.Text = customerRecord.Gender.ToString();
                txtCity.Text = customerRecord.City.ToString();
                txtState.Text = customerRecord.State.ToString();
            }

            catch (Exception ex)
            {
                litValidateMessage.Text = "Record does not exist with the Customer ID of" + " " + txtCustomerID.Text;

                if (string.IsNullOrEmpty(txtCustomerID.Text) == true)
                {
                    litValidateMessage.Text = "Must enter a value in the employee ID field";
                }
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //This function uses an LINQ to SQL class called customers and to connect my database through
            //the customer data context object.  Again, a lot less connection and sql builder code
            //needed to perform CRUD functions. Dot notation to refer to rows instead of strings reduces
            //errors.
            
                using (CustomersDataContext customer = new CustomersDataContext())
                    
                    if (string.IsNullOrEmpty(txtCustomerID.Text) == true)
                    {
                        litValidateMessage.Text = "All fields must have a value in order to Update";
                    }

                    else
                    {

                        {
                            var query = (from c in customer.Customers
                                         where c.CustomerID == Convert.ToInt32(txtCustomerID.Text)
                                         select c).First();

                            query.CustomerID = Convert.ToInt32(txtCustomerID.Text);
                            query.FirstName = txtFirstName.Text;
                            query.LastName = txtLastName.Text;
                            query.Gender = txtGender.Text;
                            query.City = txtCity.Text;
                            query.State = txtState.Text;

                            litValidateMessage.Text = "Record has been updated";

                        }

                        customer.SubmitChanges();
                        
                    }

            }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            //The delete function
            using (CustomersDataContext customer = new CustomersDataContext())
            {

               
                if (string.IsNullOrEmpty(txtCustomerID.Text) == true)
                {
                    litValidateMessage.Text = "All fields must have a value in order to delete";
                }
                else
                {
                    Customer deletedCust = customer.Customers.FirstOrDefault(c => c.CustomerID == Convert.ToInt32(txtCustomerID.Text));
                    customer.Customers.DeleteOnSubmit(deletedCust);
                    litValidateMessage.Text = "Record has been Deleted from the table";
                }

                customer.SubmitChanges();

            }

           
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //The Insert function
            using (CustomersDataContext customer = new CustomersDataContext())
            {

                if (string.IsNullOrEmpty(txtCustomerID.Text) == true)
                {
                    litValidateMessage.Text = "There must be a Primary Key value in order to insert";

                }

                else
                {

                    var Insert = (from c in customer.Customers
                                  where c.CustomerID == Convert.ToInt32(txtCustomerID.Text)
                                  select c);
                   
                    Customer InsertedCust = new Customer
                 {
                     CustomerID = Convert.ToInt32(txtCustomerID.Text),
                     FirstName = txtFirstName.Text,
                     LastName = txtLastName.Text,
                     Gender = txtGender.Text,
                     City = txtCity.Text,
                     State = txtState.Text
                 };

                    customer.Customers.InsertOnSubmit(InsertedCust);
                    litValidateMessage.Text = "Record has been Inserted into the Table";
                }


                try
                {
                    customer.SubmitChanges();
                }
                catch (Exception ex)
                {
                    litValidateMessage.Text = "Record did not submit. You probably violated a primary key constraint";
                }

            }



        }

        protected void btnDatabase_Click(object sender, EventArgs e)
            //This function transfers the page back to the Default page
        {
            Server.Transfer("Default.aspx");

        }

        public void LoadFromDataGrid()
        {
            //This function is called by the page load if page is not a post back in order to load
            //the selected record into my details view.  It creates a stronly typed dataset and loads the
            //values of a selected row into my fields.

            txtCustomerID.Text = (string)Cache["SelectedRecord"];
            Cache.Remove("SelectedRecord");

            CustomerDataSetTableAdapters.CustomersTableAdapter customerTableAdapter =
                   new CustomerDataSetTableAdapters.CustomersTableAdapter();

            CustomerDataSet.CustomersDataTable customerDataTable =
                new CustomerDataSet.CustomersDataTable();

            customerTableAdapter.Fill(customerDataTable);

            Session["DataTable"] = customerDataTable;

            var getRow = from Customers in customerDataTable
                         where Customers.CustomerID == Convert.ToInt32(txtCustomerID.Text)
                         select new
                         {
                             Customers.CustomerID,
                             Customers.FirstName,
                             Customers.LastName,
                             Customers.Gender,
                             Customers.City,
                             Customers.State
                         };
            try
            {
                var customerRecord = getRow.First();

                txtCustomerID.Text = customerRecord.CustomerID.ToString();
                txtFirstName.Text = customerRecord.FirstName.ToString();
                txtLastName.Text = customerRecord.LastName.ToString();
                txtGender.Text = customerRecord.Gender.ToString();
                txtCity.Text = customerRecord.City.ToString();
                txtState.Text = customerRecord.State.ToString();
            }

            catch (Exception ex)
            {
                litValidateMessage.Text = "Record does not exist with the Customer ID of" + " " + txtCustomerID.Text;

                if (string.IsNullOrEmpty(txtCustomerID.Text) == true)
                {
                    litValidateMessage.Text = "Must enter a value in the employee ID field";
                }

            }




        }

        protected void btnClear_Click(object sender, EventArgs e)
            //This function clears all fields
        {
            txtCustomerID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtGender.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
        }
    }
}