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
        private string conStr = @"Data Source=johnreasor-lt\sqlexpress;Initial Catalog=AberdeenPermitting;User Id=Capstone;Password=Capstone2012;";

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
                        spCmd.Parameters["@in_PropertyDescription"].Value = txtPropertyDescription.Text.Trim();


                        SqlDataReader RDR = spCmd.ExecuteReader();
                        if (RDR.HasRows)
                        {
                            while (RDR.Read())
                            {

                                if (!RDR.IsDBNull(0))
                                {
                                    cmbPropertyResults.Items.Add((string)RDR["address"]);
                                }

                            }

                        }
                        else
                        {
                            cmbPropertyResults.Items.Add("No record found");
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
                    spCmd.Parameters["@in_address"].Value = cmbPropertyResults.SelectedItem.ToString();


                    SqlDataReader RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {

                            for (int i = 0; i < RDR.FieldCount; i++)
                            {

                                if (!RDR.IsDBNull(i))
                                {
                                    if (RDR.GetName(i) == "CompName")
                                    {
                                        pf._txtOwner = (string)RDR["CompName"];
                                        pf._setcontactCompanyName = (string)RDR["CompName"];

                                    }
                                    if (RDR.GetName(i) == "CompName2")
                                    {

                                        pf._setcontactCompanyName2 = (string)RDR["CompName2"];

                                    }
                                    if (RDR.GetName(i) == "Fname" && !RDR["FName"].Equals(System.DBNull.Value))
                                    {

                                        pf._setcontactFName = (string)RDR["FName"];

                                    }
                                    if (RDR.GetName(i) == "LName" && !RDR["LName"].Equals(System.DBNull.Value))
                                    {

                                        pf._setcontactLName = (string)RDR["LName"];

                                    }
                                    if (RDR.GetName(i) == "FirstPhone")
                                    {
                                        pf._txtOwnerPhone = (string)RDR["FirstPhone"];
                                        pf._setcontactFPhone = (string)RDR["FirstPhone"];

                                    }
                                    if (RDR.GetName(i) == "SecondPhone")
                                    {
                                        pf._txtOwnerCell = (string)RDR["SecondPhone"];
                                        pf._setcontactsecondPhone = (string)RDR["SecondPhone"];

                                    }
                                    if (RDR.GetName(i) == "Address")
                                    {
                                        pf._txtProperty = (string)RDR["Address"];
                                        pf._setPropAddress = (string)RDR["Address"];
                                    }
                                    if (RDR.GetName(i) == "City")
                                    {

                                        if (!RDR["City"].Equals(System.DBNull.Value))
                                        {
                                            pf._setPropcity = (string)RDR["City"]; 
                                        }
                                    }
                                    if (RDR.GetName(i) == "State")
                                    {

                                        if (!RDR["State"].Equals(System.DBNull.Value))
                                        {
                                            pf._setPropstate = (string)RDR["State"]; 
                                        }
                                    }
                                    if (RDR.GetName(i) == "Zip")
                                    {

                                        if (!RDR["Zip"].Equals(System.DBNull.Value))
                                        {
                                            pf._setPropzip = (string)RDR["Zip"]; 
                                        }
                                    }
                                    if (RDR.GetName(i) == "Email")
                                    {
                                        pf._setcontactemail = (string)RDR["Email"];
                                    }
                                    if (RDR.GetName(i) == "PropOwner")
                                    {

                                        pf._setcontactproperty = (bool)RDR["PropOwner"];
                                    }
                                    if (RDR.GetName(i) == "LotNum")
                                    {
                                        pf._txtLotNumber = (string)RDR["LotNum"];
                                        pf._setProplotNum = (string)RDR["LotNum"];
                                    }
                                    if (RDR.GetName(i) == "LRK")
                                    {
                                        pf._txtLRKNumber = (string)RDR["LRK"];
                                        pf._setProplrk = (string)RDR["LRK"];
                                    }
                                    if (RDR.GetName(i) == "LRK")
                                    {
                                        pf._txtLRKNumber = (string)RDR["LRK"];
                                        pf._setProplrk = (string)RDR["LRK"];
                                    }
                                    if (RDR.GetName(i) == "ParcelID")
                                    {
                                       
                                        pf._setPropparcelID = (string)RDR["ParcelID"];
                                    }
                                    if (RDR.GetName(i) == "DeedBook")
                                    {

                                        pf._setPropdeedBook = (string)RDR["DeedBook"];
                                    }
                                    if (RDR.GetName(i) == "DeedPage")
                                    {

                                        pf._setPropdeedPage = (string)RDR["DeedPage"];
                                    }
                                    if (RDR.GetName(i) == "Value")
                                    {

                                        pf._setPropvalue = (Decimal)RDR["Value"];
                                    }
                                    if (RDR.GetName(i) == "ZoningDist")
                                    {

                                        pf._setPropzoningDist = (String)RDR["ZoningDist"];
                                    }
                                    if (RDR.GetName(i) == "TaxAcre")
                                    {

                                        pf._setProptaxAcre = RDR["TaxAcre"].ToString();
                                    }
                                    if (RDR.GetName(i) == "DeedAcre")
                                    {

                                        pf._setPropdeedAcre = (string)RDR["DeedAcre"];
                                    }
                                    if (RDR.GetName(i) == "ContactID")
                                    {

                                        pf._setPropcontactID = (int)RDR["ContactID"];
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




            this.Close();

        }

    }
}
