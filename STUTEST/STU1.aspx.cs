using
    System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace STUTEST
{
    public partial class STU1 : System.Web.UI.Page
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
                showcountry();
            }
        }

        public void show()
        {
            con.Open();
            cmd = new SqlCommand("select * from STU2 join tblcountry on stcountry=cid join tblstate on ststate=sid", con);
            sd = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sd.Fill(dt);
            con.Close();
            gvshow.DataSource = dt;
            gvshow.DataBind();

        }


        public void showcountry()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblcountry", con);
            sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void clear()
        {
            txtname.Text = "";
            rblstatus.ClearSelection();
            cblhobbies.ClearSelection();
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            btninsert.Text = "Save";

        }
        public void showstate()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblstate where cid='" + ddlcountry.SelectedValue + "'", con);
            sd = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            con.Close();
            ddlstate.DataValueField = "sid";
            ddlstate.DataTextField = "sname";
            ddlstate.DataSource = ds;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            string prakhar = "";
            for (int i = 0; i < cblhobbies.Items.Count; i++)
            {
                if (cblhobbies.Items[i].Selected == true)
                {
                    prakhar += cblhobbies.Items[i].Text + ",";
                }
            }
            prakhar = prakhar.TrimEnd(',');
            con.Open();
            if (btninsert.Text == "Save")
            {


                cmd = new SqlCommand("insert into STU2(stname,ststatus,sthobby,stcountry,ststate) values('" + txtname.Text + "','" + rblstatus.SelectedValue + "','" + prakhar + "','" + ddlcountry.SelectedValue + "','" + ddlstate.SelectedValue + "')", con);


            }
            else if (btninsert.Text == "Update")
            {

                cmd = new SqlCommand("update  STU2 set stname='" + txtname.Text + "',ststatus='" + rblstatus.SelectedValue + "',sthobby='" + prakhar + "',stcountry='" + ddlcountry.SelectedValue + "',ststate='" + ddlstate.SelectedValue + "'where stid='" + ViewState["abc"] + "'", con);


            }
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            clear();
        }

        protected void gvshow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                cmd = new SqlCommand("delete from STU2 where stid='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();

            }
            else if (e.CommandName == "B")
            {
                con.Open();
                cmd = new SqlCommand("select * from STU2 where stid='" + e.CommandArgument + "'", con);
                sd = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sd.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["stname"].ToString();
                rblstatus.SelectedValue = dt.Rows[0]["ststatus"].ToString();
                string[] arr = dt.Rows[0]["sthobby"].ToString().Split(',');
                cblhobbies.ClearSelection();
                for (int i = 0; i < cblhobbies.Items.Count; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (cblhobbies.Items[i].Text == arr[j])
                        {
                            cblhobbies.Items[i].Selected = true;
                        }
                    }
                }

                ddlcountry.SelectedValue = dt.Rows[0]["stcountry"].ToString();
                showstate();
                ddlstate.SelectedValue = dt.Rows[0]["ststate"].ToString();
                ViewState["abc"] = e.CommandArgument;
                btninsert.Text = "Update";
            }
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            showstate();
        }

    }
}