using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BuildingPermit
{
    public partial class frmPropertyLookup : Form
    {
        private string conStr = @"Data Source=.\sqlexpress;Initial Catalog=AberdeenPermitting;User Id=Capstone;Password=Capstone2012;";


        public static SqlDataReader queryDatabase(string queryString, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            con.Open();
            return cmd.ExecuteReader();
        }

        public frmPropertyLookup()
        {
            InitializeComponent();
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {

            cmbPropertyResults.Items.Clear();


            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (txtLRK.Text != null && txtLRK.Text != "")
                {
                    String procedure = "getParcelBasedonLRK";

                    try
                    {

                        con.Open();
                        SqlCommand spCmd;
                        spCmd = new SqlCommand(procedure, con);
                        spCmd.CommandType = CommandType.StoredProcedure;
                        spCmd.Parameters.Add("@in_LRK", SqlDbType.VarChar);
                        spCmd.Prepare();
                        spCmd.Parameters["@in_LRK"].Value = txtLRK.Text;


                        SqlDataReader RDR = spCmd.ExecuteReader();

                        while (RDR.Read())
                        {
                        cmbPropertyResults.Items.Add((string)RDR["address"]);
                        }

                      
                            cmbPropertyResults.Text = "--Choose a parcel--"; 
                      

                        RDR.Close();
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else if (txtPropertyDescription.Text != null & txtPropertyDescription.Text != "")
                {
                    String procedure = "getParcelBPropertyDescription";

                    try
                    {

                        con.Open();
                        SqlCommand spCmd;
                        spCmd = new SqlCommand(procedure, con);
                        spCmd.CommandType = CommandType.StoredProcedure;
                        spCmd.Parameters.Add("@in_PropertyDescription", SqlDbType.VarChar);
                        spCmd.Prepare();
                        spCmd.Parameters["@in_PropertyDescription"].Value = txtPropertyOwner.Text;


                        SqlDataReader RDR = spCmd.ExecuteReader();

                        while (RDR.Read())
                        {
                            cmbPropertyResults.Items.Add((string)RDR["address"]);
                        }


                        cmbPropertyResults.Text = "--Choose a parcel--";


                        RDR.Close();
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (txtPropertyOwner.Text != null & txtPropertyOwner.Text != "")
                {
                    String procedure = "getParcelBOwner";

                    try
                    {

                        con.Open();
                        SqlCommand spCmd;
                        spCmd = new SqlCommand(procedure, con);
                        spCmd.CommandType = CommandType.StoredProcedure;
                        spCmd.Parameters.Add("@in_Name", SqlDbType.VarChar);
                        spCmd.Prepare();
                        spCmd.Parameters["@in_Name"].Value = txtPropertyOwner.Text;


                        SqlDataReader RDR = spCmd.ExecuteReader();

                        while (RDR.Read())
                        {
                            cmbPropertyResults.Items.Add((string)RDR["address"]);
                        }


                        cmbPropertyResults.Text = "--Choose a parcel--";


                        RDR.Close();
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please input the LRK number, Property Description or the Owner name.");
                }


            }

        }

        private void btnPropertyAccept_Click(object sender, EventArgs e)
        {

        }

    }
}
