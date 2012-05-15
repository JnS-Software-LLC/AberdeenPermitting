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

                            pf._setGCCompanyName = txtCompany.Text;
                            pf._setGCaberdeenLC = txtLicense.Text;
                            pf._setGCbuildingLicense = txtBuildingLicense.Text;
                            pf._setGCcity = txtCity.Text;
                            pf._setGCCompanyName2 = "";
                            pf._setGCemail = txtEmail.Text;
                            pf._setGCfirstName = txtFName.Text;
                            pf._setGCfirstPhone = txtPhone.Text;
                            pf._setGClastName = txtLName.Text;
                            pf._setGClicense = txtLicense.Text;
                            pf._setGClicenseExpDate = dtLicenseexpiration.Value;
                            pf._setGClicenseNumber = txtLicense.Text;
                            pf._setGCmiddleName = "";
                            pf._setGCproperty = false;
                            pf._setGCsecondPhone = txtCell.Text;
                            pf._setGCstate = txtState.Text;
                            pf._setGCstreetName = txtStreetName.Text;
                            pf._setGCstreetName2 = txtStreetName2.Text;
                            pf._setGCstreetNumber = txtStreetNumber.Text;
                            pf._setGCtype = combContractorsType.Text;
                            pf._setGCzip = txtZip.Text;
                            

                        }
                        else if (combContractorsType.Text == "Electrical")
                        {
                            pf._txtElectricalName = txtCompany.Text;
                            pf._txtElectricalLisenceNumber = txtBuildingLicense.Text;
                            pf._txtElectricalPhone = txtPhone.Text;

                            pf._setEletCompanyName = txtCompany.Text;
                            pf._setEletaberdeenLC = txtLicense.Text;
                            pf._setEletbuildingLicense = txtBuildingLicense.Text;
                            pf._setEletcity = txtCity.Text;
                            pf._setEletCompanyName2 = "";
                            pf._setEletemail = txtEmail.Text;
                            pf._setEletfirstName = txtFName.Text;
                            pf._setEletfirstPhone = txtPhone.Text;
                            pf._setEletlastName = txtLName.Text;
                            pf._setEletlicense = txtLicense.Text;
                            pf._setEletlicenseExpDate = dtLicenseexpiration.Value;
                            pf._setEletlicenseNumber = txtLicense.Text;
                            pf._setEletmiddleName = "";
                            pf._setEletproperty = false;
                            pf._setEletsecondPhone = txtCell.Text;
                            pf._setEletstate = txtState.Text;
                            pf._setEletstreetName = txtStreetName.Text;
                            pf._setEletstreetName2 = txtStreetName2.Text;
                            pf._setEletstreetNumber = txtStreetNumber.Text;
                            pf._setElettype = combContractorsType.Text;
                            pf._setEletzip = txtZip.Text;
                        }
                        else if (combContractorsType.Text == "Plumbing")
                        {
                            pf._txtPlumbingName = txtCompany.Text;
                            pf._txtPlumbingLisenceNumber = txtBuildingLicense.Text;
                            pf._txtPlumbingPhone = txtPhone.Text;

                            pf._setPLUMCompanyName = txtCompany.Text;
                            pf._setPLUMaberdeenLC = txtLicense.Text;
                            pf._setPLUMbuildingLicense = txtBuildingLicense.Text;
                            pf._setPLUMcity = txtCity.Text;
                            pf._setPLUMCompanyName2 = "";
                            pf._setPLUMemail = txtEmail.Text;
                            pf._setPLUMfirstName = txtFName.Text;
                            pf._setPLUMfirstPhone = txtPhone.Text;
                            pf._setPLUMlastName = txtLName.Text;
                            pf._setPLUMlicense = txtLicense.Text;
                            pf._setPLUMlicenseExpDate = dtLicenseexpiration.Value;
                            pf._setPLUMlicenseNumber = txtLicense.Text;
                            pf._setPLUMmiddleName = "";
                            pf._setPLUMproperty = false;
                            pf._setPLUMsecondPhone = txtCell.Text;
                            pf._setPLUMstate = txtState.Text;
                            pf._setPLUMstreetName = txtStreetName.Text;
                            pf._setPLUMstreetName2 = txtStreetName2.Text;
                            pf._setPLUMstreetNumber = txtStreetNumber.Text;
                            pf._setPLUMtype = combContractorsType.Text;
                            pf._setPLUMzip = txtZip.Text;
                        }
                        else if (combContractorsType.Text == "HVAC")
                        {
                            pf._txtMechanicalName = txtCompany.Text;
                            pf._txtMechanicalLisenceNumber = txtBuildingLicense.Text;
                            pf._txtMechanicalPhone = txtPhone.Text;

                            pf._setHVACCompanyName = txtCompany.Text;
                            pf._setHVACaberdeenLC = txtLicense.Text;
                            pf._setHVACbuildingLicense = txtBuildingLicense.Text;
                            pf._setHVACcity = txtCity.Text;
                            pf._setHVACCompanyName2 = "";
                            pf._setHVACemail = txtEmail.Text;
                            pf._setHVACfirstName = txtFName.Text;
                            pf._setHVACfirstPhone = txtPhone.Text;
                            pf._setHVAClastName = txtLName.Text;
                            pf._setHVAClicense = txtLicense.Text;
                            pf._setHVAClicenseExpDate = dtLicenseexpiration.Value;
                            pf._setHVAClicenseNumber = txtLicense.Text;
                            pf._setHVACmiddleName = "";
                            pf._setHVACproperty = false;
                            pf._setHVACsecondPhone = txtCell.Text;
                            pf._setHVACstate = txtState.Text;
                            pf._setHVACstreetName = txtStreetName.Text;
                            pf._setHVACstreetName2 = txtStreetName2.Text;
                            pf._setHVACstreetNumber = txtStreetNumber.Text;
                            pf._setHVACtype = combContractorsType.Text;
                            pf._setHVACzip = txtZip.Text;
                        }
                        else if (combContractorsType.Text == "GAS")
                        {
                            pf._txtGasName = txtCompany.Text;
                            pf._txtGasLisenceNumber = txtBuildingLicense.Text;
                            pf._txtGasPhone = txtPhone.Text;

                            pf._setGASCompanyName = txtCompany.Text;
                            pf._setGASaberdeenLC = txtLicense.Text;
                            pf._setGASbuildingLicense = txtBuildingLicense.Text;
                            pf._setGAScity = txtCity.Text;
                            pf._setGASCompanyName2 = "";
                            pf._setGASemail = txtEmail.Text;
                            pf._setGASfirstName = txtFName.Text;
                            pf._setGASfirstPhone = txtPhone.Text;
                            pf._setGASlastName = txtLName.Text;
                            pf._setGASlicense = txtLicense.Text;
                            pf._setGASlicenseExpDate = dtLicenseexpiration.Value;
                            pf._setGASlicenseNumber = txtLicense.Text;
                            pf._setGASmiddleName = "";
                            pf._setGASproperty = false;
                            pf._setGASsecondPhone = txtCell.Text;
                            pf._setGASstate = txtState.Text;
                            pf._setGASstreetName = txtStreetName.Text;
                            pf._setGASstreetName2 = txtStreetName2.Text;
                            pf._setGASstreetNumber = txtStreetNumber.Text;
                            pf._setGAStype = combContractorsType.Text;
                            pf._setGASzip = txtZip.Text;
                        }
                        else if (combContractorsType.Text == "Irrigation")
                        {
                            pf._txtIrrigationName = txtCompany.Text;
                            pf._txtIrrigationLisenceNumber = txtBuildingLicense.Text;
                            pf._txtIrrigationPhone = txtPhone.Text;

                            pf._setIRRCompanyName = txtCompany.Text;
                            pf._setIRRaberdeenLC = txtLicense.Text;
                            pf._setIRRbuildingLicense = txtBuildingLicense.Text;
                            pf._setIRRcity = txtCity.Text;
                            pf._setIRRCompanyName2 = "";
                            pf._setIRRemail = txtEmail.Text;
                            pf._setIRRfirstName = txtFName.Text;
                            pf._setIRRfirstPhone = txtPhone.Text;
                            pf._setIRRlastName = txtLName.Text;
                            pf._setIRRlicense = txtLicense.Text;
                            pf._setIRRlicenseExpDate = dtLicenseexpiration.Value;
                            pf._setIRRlicenseNumber = txtLicense.Text;
                            pf._setIRRmiddleName = "";
                            pf._setIRRproperty = false;
                            pf._setIRRsecondPhone = txtCell.Text;
                            pf._setIRRstate = txtState.Text;
                            pf._setIRRstreetName = txtStreetName.Text;
                            pf._setIRRstreetName2 = txtStreetName2.Text;
                            pf._setIRRstreetNumber = txtStreetNumber.Text;
                            pf._setIRRtype = combContractorsType.Text;
                            pf._setIRRzip = txtZip.Text;
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

