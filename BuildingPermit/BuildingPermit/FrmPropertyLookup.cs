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
                            if (RDR.HasRows)
                            {
                                if (!RDR.IsDBNull(0))
                                {
                                    cmbPropertyResults.Items.Add((string)RDR["address"]);
                                }
                            }
                            else
                            {
                                cmbPropertyResults.Items.Add("No record found");
                            }
                        }



                        if (cmbPropertyResults.Items.Count > 1)
                        {
                            cmbPropertyResults.Text = "--Choose a parcel--"; 
                        }
                        else
                        {
                            cmbPropertyResults.SelectedIndex = 0;
                        }


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
                            if (RDR.HasRows)
                            {
                                if (!RDR.IsDBNull(0))
                                {
                                    cmbPropertyResults.Items.Add((string)RDR["address"]);
                                }
                            }
                            else
                            {
                                cmbPropertyResults.Items.Add("No record found");
                            }
                        }




                        if (cmbPropertyResults.Items.Count > 1)
                        {
                            cmbPropertyResults.Text = "--Choose a parcel--";
                        }
                        else
                        {
                            cmbPropertyResults.SelectedIndex = 0;
                        }


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
                            if (RDR.HasRows )
                            {
                                if (!RDR.IsDBNull(0))
                                {
                                    cmbPropertyResults.Items.Add((string)RDR["address"]); 
                                }
                            }
                            else
                            {
                                cmbPropertyResults.Items.Add("No record found");
                            }
                        }



                        if (cmbPropertyResults.Items.Count > 1)
                        {
                            cmbPropertyResults.Text = "--Choose a parcel--";
                        }
                        else
                        {
                            cmbPropertyResults.SelectedIndex = 0;
                        }


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
            using (SqlConnection con = new SqlConnection(conStr))
            {
                String procedure = "getOwnerandParcel";
                BuildingPermitTabs pf = (BuildingPermitTabs)Application.OpenForms[1];
                    try
                    {

                        con.Open();
                        SqlCommand spCmd;
                        spCmd = new SqlCommand(procedure, con);
                        spCmd.CommandType = CommandType.StoredProcedure;
                        spCmd.Parameters.Add("@in_address", SqlDbType.VarChar);
                        spCmd.Prepare();
                        spCmd.Parameters["@in_address"].Value =cmbPropertyResults.SelectedText;


                        SqlDataReader RDR = spCmd.ExecuteReader();

                        while (RDR.Read())
                        {
                            if (RDR.HasRows )
                            {
                                if (!RDR.IsDBNull(0))
                                {
                                    for (int i = 0; i < RDR.FieldCount; i++)
                                    {
                                      
                                            if (RDR.GetName(i) == "CompName")
                                            {
                                                pf._txtOwner = (string)RDR["CompName"];

                                            }
                                            if (RDR.GetName(i) == "FirstPhone")
                                            {
                                                pf._txtOwnerPhone = (string)RDR["FirstPhone"];

                                            }
                                            if (RDR.GetName(i) == "SecondPhone")
                                            {
                                                pf._txtOwnerCell = (string)RDR["SecondPhone"];

                                            }
                                            if (RDR.GetName(i) == "Address")
                                            {
                                                pf._txtProperty = (string)RDR["Address"];
                                            }
                                            if (RDR.GetName(i) == "LotNum")
                                            {
                                                pf._txtLotNumber = (string)RDR["LotNum"];
                                            }
                                            if (RDR.GetName(i) == "LRK")
                                            {
                                                pf._txtLRKNumber = (string)RDR["LRK"];
                                            }  
                                        
                                    }
                                  
                                }
                            }
                            else
                            {
                                cmbPropertyResults.Items.Add("No record found");
                            }
                        }



                        if (cmbPropertyResults.Items.Count > 1)
                        {
                            cmbPropertyResults.Text = "--Choose a parcel--";
                        }
                        else
                        {
                            cmbPropertyResults.SelectedIndex = 0;
                        }


                        RDR.Close();
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            
                  

          

        }

    }
}
