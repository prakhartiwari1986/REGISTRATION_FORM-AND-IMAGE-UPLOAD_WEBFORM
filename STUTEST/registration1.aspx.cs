using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace STUTEST
{
    public partial class registration1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pt"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sd;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
               
            }
        }

        public void show()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblregistration",con);
            sd = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sd.Fill(dt);
            con.Close();
            gvreg.DataSource = dt;
            gvreg.DataBind();

        }
        public void clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassward.Text = "";
            rblgender.ClearSelection();
            btnsubmit.Text = "Submit";

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                string PT = DateTime.Now.Ticks.ToString()+ Path.GetFileName(fuimg.PostedFile.FileName);
                fuimg.SaveAs(Server.MapPath("img" + "\\" + PT));

                con.Open();
                cmd = new SqlCommand("insert into tblregistration (rname,remail,rpassward,rgender,rimage) values ('" + txtname.Text + "','" + txtemail.Text + "','" + txtpassward.Text + "','" + rblgender.SelectedValue + "','" + PT + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
                clear();
            }
            else if(btnsubmit.Text == "Update")
            {
                string PT = Path.GetFileName(fuimg.PostedFile.FileName);
                if (PT == "")
                {
                    con.Open();
                    cmd = new SqlCommand("update  tblregistration set rname='" + txtname.Text + "',remail='" + txtemail.Text + "',rpassward='" + txtpassward.Text + "',rgender='" + rblgender.SelectedValue + "',rimage='" + PT + "'where rid='" + ViewState["abc"] + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    show();
                    clear();


                }
                else
                {
                    PT = DateTime.Now.Ticks.ToString() + PT;
                    fuimg.SaveAs(Server.MapPath("img" + "\\" + PT));
                    File.Delete(Server.MapPath("img" + "\\" + ViewState["II"]));

                    con.Open();
                    cmd = new SqlCommand("update  tblregistration set rname='" + txtname.Text + "',remail='" + txtemail.Text + "',rpassward='" + txtpassward.Text + "',rgender='" + rblgender.SelectedValue + "',rimage='" + PT + "'where rid='" + ViewState["abc"] + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    show();
                    clear();
                }
            }
        }

        protected void gvreg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="A")
            {
                string[] arr=e.CommandArgument.ToString().Split(',');
                con.Open();
                cmd = new SqlCommand("delete from tblregistration where rid='"+arr[0]+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
                File.Delete(Server.MapPath("img" + "\\" + arr[1]));   
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                cmd = new SqlCommand("select * from tblregistration where rid='" + e.CommandArgument + "'", con);
                sd = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sd.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["rname"].ToString();
                txtemail.Text = dt.Rows[0]["remail"].ToString();
                txtpassward.Text = dt.Rows[0]["rpassward"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["rgender"].ToString();
                ViewState["II"]=dt.Rows[0]["rimage"].ToString();
                ViewState["abc"] = e.CommandArgument;
                btnsubmit.Text = "Update";
            }
        }
    }
    }
