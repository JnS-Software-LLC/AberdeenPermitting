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
    public partial class ContractorAdd : Form
    {
        public ContractorAdd()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BuildingPermitTabs pf = (BuildingPermitTabs)Application.OpenForms[1];
            Contractor GC = new Contractor();

                using(SqlConnection con = new SqlConnection(pf.conStr))
	        {
		
                    try
                    {
                        con.Open();
                        SqlCommand spCmd;
                        spCmd = new SqlCommand("AU_Contractors", con);
                        spCmd.CommandType = CommandType.StoredProcedure;

                
                        spCmd.Parameters.Add("@in_ContractorID", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_CompName", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Fname", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Lname", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_FirstPhone", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_SecondPhone", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Address", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_City", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_State", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Zip", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Email", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_AberdeenLC", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_LicenseExpDate", SqlDbType.DateTime);
                        spCmd.Parameters.Add("@in_Type", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_LicenseNumber", SqlDbType.VarChar);

                        spCmd.Prepare();


                
                        spCmd.Parameters["@in_ContractorID"].Value = this.txtBuildingLicense.Text;
                        spCmd.Parameters["@in_CompName"].Value = this.txtCompany.Text;
                        spCmd.Parameters["@in_Fname"].Value = this.txtFName.Text;
                        spCmd.Parameters["@in_Lname"].Value = this.txtLName.Text;
                        spCmd.Parameters["@in_FirstPhone"].Value = this.txtPhone.Text;
                        spCmd.Parameters["@in_SecondPhone"].Value = this.txtCell.Text;
                        spCmd.Parameters["@in_Address"].Value =this.txtStreetNumber.Text + " " + this.txtStreetName.Text + " " + this.txtStreetName2.Text;
                        spCmd.Parameters["@in_City"].Value = this.txtCity.Text;
                        spCmd.Parameters["@in_State"].Value = this.txtState.Text;
                        spCmd.Parameters["@in_Zip"].Value = this.txtZip.Text;
                        spCmd.Parameters["@in_Email"].Value = this.txtEmail.Text;
                        spCmd.Parameters["@in_AberdeenLC"].Value = this.txtLicense.Text;
                        spCmd.Parameters["@in_LicenseExpDate"].Value = this.dtLicenseexpiration.Value;
                        spCmd.Parameters["@in_Type"].Value = this.combContractorsType.Text;
                        spCmd.Parameters["@in_LicenseNumber"].Value = this.txtBuildingLicense.Text;

                        SqlDataReader RDR = spCmd.ExecuteReader();

                        RDR.Close();
                        con.Close();

                        if (combContractorsType.Text == "General Contractor")
                        {
                            pf._txtContractorName = txtCompany.Text;
                            pf._txtContractorLiscence = txtBuildingLicense.Text;
                            pf._txtContractorPhone = txtPhone.Text;
                            pf._txtContractorEmail = txtEmail.Text;
                        }
                        else if (combContractorsType.Text == "Electrical")
                        {
                            pf._txtElectricalName = txtCompany.Text;
                            pf._txtElectricalLisenceNumber = txtBuildingLicense.Text;
                            pf._txtElectricalPhone = txtPhone.Text;
                        }
                        else if (combContractorsType.Text == "Plumbing")
                        {
                            pf._txtPlumbingName = txtCompany.Text;
                            pf._txtPlumbingLisenceNumber = txtBuildingLicense.Text;
                            pf._txtPlumbingPhone = txtPhone.Text;
                        }
                        else if (combContractorsType.Text == "HVAC")
                        {
                            pf._txtMechanicalName = txtCompany.Text;
                            pf._txtMechanicalLisenceNumber = txtBuildingLicense.Text;
                            pf._txtMechanicalPhone = txtPhone.Text;
                        }
                        else if (combContractorsType.Text == "GAS")
                        {
                            pf._txtGasName = txtCompany.Text;
                            pf._txtGasLisenceNumber = txtBuildingLicense.Text;
                            pf._txtGasPhone = txtPhone.Text;
                        }
                        else if (combContractorsType.Text == "Irrigation")
                        {
                            pf._txtIrrigationName = txtCompany.Text;
                            pf._txtIrrigationLisenceNumber = txtBuildingLicense.Text;
                            pf._txtIrrigationPhone = txtPhone.Text;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
        }
                
                private void btnCancel_Click(object sender, EventArgs e)
                {
                    this.Close();
                } 
	        }
    }

