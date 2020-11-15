using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace CollegeManagementSystem
{
    public partial class Mainpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["action"] != null)
                {
                    string id = Request.QueryString["id"];
                    string action = Request.QueryString["action"];
                    string FirstName = null;
                    string LastName = null;
                    string BirthDate = null;
                    string EmailAddr = null;
                    string Country = null;
                    con.Open();
                    cmd = new SqlCommand("select * from Students where Id='" + id + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        FirstName = dr["FirstName"].ToString();
                        LastName = dr["LastName"].ToString();
                        BirthDate = dr["BirthDate"].ToString();
                        EmailAddr = dr["EmailAddr"].ToString();
                        Country = dr["Country"].ToString();
                    }
                    con.Close();
                    if (action == "1")
                    {
                        con.Open();
                        cmd = new SqlCommand("delete from Students where id = '" + id + "'", con);
                        int checkD = cmd.ExecuteNonQuery();
                        if (checkD == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "deleted", "<script>alert('Student deleted!');" +
                                "location='Mainpage.aspx';</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "failed", "<script>alert(Failed!!!);</script>");
                        }
                        con.Close();
                    }
                    else if (action == "2")
                    {
                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = true;
                        Session["id"] = id;
                        txtName.Text = FirstName;
                        txtName2.Text = LastName;
                        txtbirth.Text = BirthDate;
                        txtEmail.Text = EmailAddr;
                        txtcountry.Text = Country;
                    }

                }
                con.Open();

                cmd = new SqlCommand("select * from Students", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    gridBook.DataSource = dr;
                    gridBook.DataBind();
                }
            }
            con.Close();
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");

            lblUserDetails.Text = "Username : " + Session["username"];

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Students values(@FirstName,@LastName,@BirthDate,@EmailAddr,@Country)", con);
            cmd.Parameters.Add("@FirstName", txtName.Text);
            cmd.Parameters.Add("@LastName", txtName2.Text);
            cmd.Parameters.Add("@BirthDate", txtbirth.Text);
            cmd.Parameters.Add("@EmailAddr", txtEmail.Text);
            cmd.Parameters.Add("@Country", txtcountry.Text);
            int count = cmd.ExecuteNonQuery();
            if (count == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "added", "<script>alert('Student Added successfully!' );" +
                    "location='Mainpage.aspx';</script>");
                txtName.Text = "";
                txtName2.Text = "";
                txtbirth.Text = "";
                txtEmail.Text = "";
                txtcountry.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "failed", "<script>alert('Failed! Please try again...!!!' );</script>");

            }
            con.Close();
        }

        protected void btnEdid_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update Student set FirstName=@FirstName, LastName=@LastName,BirthDate=@BirthDate, EmailAddr=@EmailAddr, Country=@Country where id = '" + Session["id"] + "'", con);
            cmd.Parameters.Add("@FirstName", txtName.Text);
            cmd.Parameters.Add("@LastName", txtName2.Text);
            cmd.Parameters.Add("@BirthDate", txtbirth.Text);
            cmd.Parameters.Add("@EmailAddr", txtEmail.Text);
            cmd.Parameters.Add("@Country", txtcountry.Text);
            int checkD = cmd.ExecuteNonQuery();
            if (checkD == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updated", "<script>alert('Contact updated!');location='Mainpage.aspx';</script>");
                txtName.Text = "";
                txtName2.Text = "";
                txtbirth.Text = "";
                txtEmail.Text = "";
                txtcountry.Text = "";
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                Session.Abandon();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updatefailed", "<script>alert('Failed!!!');</script>");
            }
            con.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}