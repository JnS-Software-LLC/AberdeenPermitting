using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BuildingPermit
{
    public partial class BuildingPermitTabs : Form
    {
        public string conStr;
        public Boolean flagPermitNum = false;


        public static SqlDataReader queryDatabase(string queryString, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            con.Open();
            return cmd.ExecuteReader();
        }

        Building building = new Building();
        Utilities utilities = new Utilities();



        public BuildingPermitTabs()
        {
            InitializeComponent();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 1;

        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnPropertyContact_Click(object sender, EventArgs e)
        {
            Form frmContactInfo = new ContactInfo();
            frmContactInfo.Show();
        }

        private void btnApplicantContact_Click(object sender, EventArgs e)
        {
            Form frmContactInfo = new ContactInfo();
            frmContactInfo.Show();
        }

        private void btnOwnerContact_Click(object sender, EventArgs e)
        {
            Form frmContactInfo = new ContactInfo();
            frmContactInfo.Show();
        }

        private void btnFees_Click(object sender, EventArgs e)
        {
            Form frmFees = new Fees();
            frmFees.Show();

        }

        private void BuildingPermitTabs_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'aberdeenPermittingDataSet.Number_Amps_Fees_Query' table. You can move, or remove it, as needed.
            // this.number_Amps_Fees_QueryTableAdapter.Fill(this.aberdeenPermittingDataSet.Number_Amps_Fees_Query);
            conStr = @"Data Source=.\sqlexpress;Initial Catalog=AberdeenPermitting;User Id=Capstone;Password=Capstone2012;";

            FillComboBox(conStr);

        }

        private void txtSquareFeet_Leave(object sender, EventArgs e)
        {
            building.totalSF = txtSquareFeet.Text;

            if (building.totalSF == null)
            {
                txtSquareFeet.Focus();
                txtSquareFeet.BackColor = Color.Red;

            }
        }

        private void txtEstimatedCost_Leave(object sender, EventArgs e)
        {
            building.estimatedCost = txtEstimatedCost.Text;

            if (building.estimatedCost == null)
            {
                txtEstimatedCost.Focus();
                txtEstimatedCost.BackColor = Color.Red;

            }
        }

        private void txtNumStories_Leave(object sender, EventArgs e)
        {

            building.numStories = txtNumStories.Text;
            if (building.numStories == null)
            {
                txtNumStories.Focus();
                txtNumStories.BackColor = Color.Red;


            }

        }

        private void txtHeatedSF_Leave(object sender, EventArgs e)
        {
            building.heatedSF = txtHeatedSF.Text;

            if (building.heatedSF == null)
            {
                txtHeatedSF.Focus();
                txtHeatedSF.BackColor = Color.Red;

            }

        }

        private void txtPorchSF_Leave(object sender, EventArgs e)
        {
            building.porchSF = txtPorchSF.Text;
        }

        private void txtDeck_Leave(object sender, EventArgs e)
        {
            building.deckSF = txtDeck.Text;
        }

        private void txtGarageSF_Leave(object sender, EventArgs e)
        {
            building.garageSF = txtGarageSF.Text;

        }

        private void txtBasement_Leave(object sender, EventArgs e)
        {
            building.basementSF = txtBasement.Text;

        }

        private void txtSquareFeet_KeyDown(object sender, KeyEventArgs e)
        {
            txtSquareFeet.BackColor = Color.White;

        }

        private void txtEstimatedCost_KeyDown(object sender, KeyEventArgs e)
        {
            txtEstimatedCost.BackColor = Color.White;

        }

        private void txtNumStories_KeyDown(object sender, KeyEventArgs e)
        {
            txtNumStories.BackColor = Color.White;

        }

        private void txtHeatedSF_KeyDown(object sender, KeyEventArgs e)
        {
            txtHeatedSF.BackColor = Color.White;

        }

        private void cmboConstructionType_Leave(object sender, EventArgs e)
        {
            building.buildingType = cmboConstructionType.Text;
        }

        private void txtNumSystems_Leave(object sender, EventArgs e)
        {
            utilities.setNumSys = txtNumSystems.Text;
        }

        private void txtNumBathrooms_Leave(object sender, EventArgs e)
        {
            utilities.numBathrooms = txtNumBathrooms.Text;
        }

        private void txtNumWaterClosets_Leave(object sender, EventArgs e)
        {
            utilities.numWaterClosets = txtNumWaterClosets.Text;
        }

        private void txtNumDishwashers_Leave(object sender, EventArgs e)
        {
            utilities.numDishWasher = txtNumDishwashers.Text;
        }

        private void txtNumWaterHeaters_Leave(object sender, EventArgs e)
        {
            utilities.numWaterHeater = txtNumWaterHeaters.Text;
        }

        private void txtNumFixtures_Leave(object sender, EventArgs e)
        {
            utilities.numFixtures = txtNumFixtures.Text;
        }

        private void txtNumShowers_Leave(object sender, EventArgs e)
        {
            utilities.numShowers = txtNumShowers.Text;
        }

        private void txtNumTubs_Leave(object sender, EventArgs e)
        {
            utilities.numTub = txtNumTubs.Text;
        }

        private void txtNumWetBars_Leave(object sender, EventArgs e)
        {
            utilities.numWetBar = txtNumWetBars.Text;
        }

        private void txtNumSinks_Leave(object sender, EventArgs e)
        {
            utilities.numSinks = txtNumSinks.Text;
        }

        private void txtNumClothesWashers_Leave(object sender, EventArgs e)
        {
            utilities.numClothesWasher = txtNumClothesWashers.Text;
        }

        private void txtNumSpas_Leave(object sender, EventArgs e)
        {
            utilities.numSpa = txtNumSpas.Text;
        }

        private void cmboNumAmps_Leave(object sender, EventArgs e)
        {
            utilities.numAmps = cmboNumAmps.Text;
        }

        private void txtProperty_TextChanged(object sender, EventArgs e)
        {

        }

        private void FillComboBox(string conStr)
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                String procedure = "getNumAmps";

                try
                {

                    con.Open();
                    SqlCommand spCmd;

                    spCmd = new SqlCommand(procedure, con);
                    spCmd.CommandType = CommandType.StoredProcedure;


                    SqlDataReader RDR = spCmd.ExecuteReader();

                    foreach (var item in RDR)
                    {
                        cmboNumAmps.Items.Add(item);
                    }

                    cmboNumAmps.Text = "--Choose Number of Amps--";

                    RDR.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnContractorContact_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnElectricalContact_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnPlumbingContact_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnMechanicalContact_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btngasContact_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnIrrigationContact_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnSearchApplicant_Click(object sender, EventArgs e)
        {
            Form frmNameLookup = new NameLookup();
            frmNameLookup.Show();
        }

        private void btnAddApplicant_Click(object sender, EventArgs e)
        {
            Form frmContactInfo = new ContactInfo();
            frmContactInfo.Show();
        }

        private void btnSearchProperty_Click(object sender, EventArgs e)
        {
            Form frmPropertyLookup = new frmPropertyLookup();
            frmPropertyLookup.Show();
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            Form frmPropertyAdd = new PropertyAdd();
            frmPropertyAdd.Show();
        }

        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            Form frmNameLookup = new NameLookup();
            frmNameLookup.Show();
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            Form frmContactInfo = new ContactInfo();
            frmContactInfo.Show();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnContractorSearch_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnElecSubSearch_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnPlumSubSearch_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnMecSubSearch_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnGasSubSearch_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnIrriSubSearch_Click(object sender, EventArgs e)
        {
            Form frmContractorLookup = new ContractorLookup();
            frmContractorLookup.Show();
        }

        private void btnContractorAdd_Click(object sender, EventArgs e)
        {
            Form frmContractorAdd = new ContractorAdd();
            frmContractorAdd.Show();
        }

        private void btnElecSubAdd_Click(object sender, EventArgs e)
        {
            Form frmContractorAdd = new ContractorAdd();
            frmContractorAdd.Show();
        }

        private void btnPlumSubAdd_Click(object sender, EventArgs e)
        {
            Form frmContractorAdd = new ContractorAdd();
            frmContractorAdd.Show();
        }

        private void btnMecSubAdd_Click(object sender, EventArgs e)
        {
            Form frmContractorAdd = new ContractorAdd();
            frmContractorAdd.Show();
        }

        private void btnGasSubAdd_Click(object sender, EventArgs e)
        {
            Form frmContractorAdd = new ContractorAdd();
            frmContractorAdd.Show();
        }

        private void btnIrriSubAdd_Click(object sender, EventArgs e)
        {
            Form frmContractorAdd = new ContractorAdd();
            frmContractorAdd.Show();
        }

        private void btnSearchPermitNum_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {

                try
                {
                    con.Open();
                    SqlCommand spCmd;
                    spCmd = new SqlCommand("getPermit", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    SqlDataReader RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {
                                    if (RDR.GetName(i) == "PermitDate")
                                    {
                                        dtIssueDate.Text = RDR["PermitDate"].ToString();
                                    }
                                    if (RDR.GetName(i) == "Notes")
                                    {
                                        txtNotes.Text = (string)RDR["Notes"];
                                    }
                                }


                            } 
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getBuilding", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {
                                    if (RDR.GetName(i) == "TypeOfConst")
                                    {
                                        cmboConstructionType.Text = (string)RDR["TypeOfConst"];
                                    }
                                    if (RDR.GetName(i) == "ProposedUse")
                                    {
                                        cmboProposedUse.Text = (string)RDR["ProposedUse"];
                                    }
                                    if (RDR.GetName(i) == "HeatedSF")
                                    {
                                        txtHeatedSF.Text = (string)RDR["HeatedSF"];
                                    }
                                    if (RDR.GetName(i) == "NumberOfStories")
                                    {
                                        txtNumStories.Text = (string)RDR["NumberOfStories"];
                                    }
                                    if (RDR.GetName(i) == "GarageSF")
                                    {
                                        txtGarageSF.Text = (string)RDR["GarageSF"];
                                    }
                                    if (RDR.GetName(i) == "PorchSF")
                                    {
                                        txtPorchSF.Text = (string)RDR["PorchSF"];
                                    }

                                    if (RDR.GetName(i) == "DeckSF")
                                    {
                                        txtDeck.Text = (string)RDR["DeckSF"];
                                    }

                                    if (RDR.GetName(i) == "BasementSF")
                                    {
                                        txtBasement.Text = (string)RDR["BasementSF"];
                                    }
                                    if (RDR.GetName(i) == "EstCostOfConst")
                                    {
                                        txtEstimatedCost.Text = (string)RDR["EstCostOfConst"];
                                    }
                                    if (RDR.GetName(i) == "ProposedUse")
                                    {
                                        cmboProposedUse.Text = (string)RDR["ProposedUse"];
                                    }
                                    if (RDR.GetName(i) == "InstallInsulation")
                                    {
                                        cboxDuctwork.Checked = (bool)RDR["InstallInsulation"];
                                    }
                                    if (RDR.GetName(i) == "TotalSF")
                                    {
                                        txtSquareFeet.Text = (string)RDR["TotalSF"];
                                    }
                                       
                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

              

                    spCmd = new SqlCommand("getContact", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

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
                                        txtOwner.Text = (string)RDR["CompName"];
                                        txtApplicant.Text = txtOwner.Text;
                                    }
                                    if (RDR.GetName(i) == "FirstPhone")
                                    {
                                        txtOwnerPhone.Text = (string)RDR["FirstPhone"];
                                        txtApplicantPhone.Text = txtOwnerPhone.Text;
                                    }
                                    if (RDR.GetName(i) == "SecondPhone")
                                    {
                                        txtOwnerCell.Text = (string)RDR["SecondPhone"];
                                        txtCell.Text = txtOwnerCell.Text;
                                    }
                                    if (RDR.GetName(i) == "Address")
                                    {
                                        txtProperty.Text = (string)RDR["Address"];
                                    }
                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getContractors", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {
                                    if (RDR.GetName(i) == "Type")
                                        {
                                            if ((string)RDR["Type"] == "HVAC")
                                            {
                                                txtMechanicalName.Text = (string)RDR["CompName"];
                                                txtMechanicalPhone.Text = (string)RDR["FirstPhone"];
                                                txtMechanicalLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "General Contractor")
                                            {
                                                txtContractorName.Text = (string)RDR["CompName"];
                                                txtContractorPhone.Text = (string)RDR["FirstPhone"];
                                                txtContractorLiscence.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "Electrical")
                                            {
                                                txtElectricalName.Text = (string)RDR["CompName"];
                                                txtElectricalPhone.Text = (string)RDR["FirstPhone"];
                                                txtElectricalLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "Plumbing")
                                            {
                                                txtPlumbingName.Text = (string)RDR["CompName"];
                                                txtPlumbingPhone.Text = (string)RDR["FirstPhone"];
                                                txtPlumbingLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "GAS")
                                            {
                                                txtGasName.Text = (string)RDR["CompName"];
                                                txtGasPhone.Text = (string)RDR["FirstPhone"];
                                                txtGasLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "Irrigation")
                                            {
                                                txtIrrigationName.Text = (string)RDR["CompName"];
                                                txtIrrigationPhone.Text = (string)RDR["FirstPhone"];
                                                txtIrrigationLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                        }
                                    if (RDR.GetName(i) == "AberdeenLC")
                                    {
                                        txtApplicationNumber.Text = (string)RDR["AberdeenLC"];
                                    }
                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getElectrical", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {
                                    
                                        if (RDR.GetName(i) == "NumAmps")
                                        {
                                            cmboNumAmps.Items.Clear();
                                            cmboNumAmps.Text = (string)RDR["NumAmps"];
                                            

                                        }
                                        if (RDR.GetName(i) == "TempPole")
                                        {
                                            cboxTempPole.Checked = (bool)RDR["TempPole"];
                                        }
                                   
                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getElectrical", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {
                                    if (RDR.GetName(i) == "Type")
                                    {
                                        if (RDR.GetName(i) == "NumAmps")
                                        {
                                            cmboNumAmps.Items.Clear();
                                            cmboNumAmps.Text = (string)RDR["NumAmps"];

                                        }
                                        if (RDR.GetName(i) == "TempPole")
                                        {
                                            cboxTempPole.Checked = (bool)RDR["TempPole"];
                                        }
                                    }
                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getMechanical", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {

                                    if (RDR.GetName(i) == "NumSystems")
                                    {
                                        txtNumSystems.Text = (string)RDR["NumSystems"];
                                    }
                                    if (RDR.GetName(i) == "SystemType")
                                    {
                                        cmboSystemType.Text = (string)RDR["SystemType"];
                                    }
                                    if (RDR.GetName(i) == "Tons")
                                    {
                                        txtSystemTons.Text = (string)RDR["Tons"];
                                    }
                                    if (RDR.GetName(i) == "GasLine")
                                    {
                                        cboxGasLine.Checked = (bool)RDR["GasLIne"];
                                    }

                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getParcel", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {

                                    if (RDR.GetName(i) == "Address")
                                    {
                                        txtProperty.Text = (string)RDR["Address"];
                                    }
                                    if (RDR.GetName(i) == "LotNum")
                                    {
                                        txtLotNumber.Text = (string)RDR["LotNum"];
                                    }
                                    if (RDR.GetName(i) == "LRK")
                                    {
                                        txtLRKNumber.Text = (string)RDR["LRK"];
                                    }
                                    if (RDR.GetName(i) == "ZoningDist")
                                    {
                                        txtZoningDistrict.Text = (string)RDR["ZoningDist"];
                                    }


                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();

                    spCmd = new SqlCommand("getPlumbing", con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = txtPermitNumber.Text;

                    RDR = spCmd.ExecuteReader();

                    while (RDR.Read())
                    {
                        if (RDR.HasRows)
                        {
                            for (int i = 0; i < RDR.FieldCount; i++)
                            {
                                if (!RDR.IsDBNull(i))
                                {
                                    if (RDR.GetName(i) == "TotNumFixtures")
                                    {
                                        txtNumFixtures.Text = (string)RDR["TotNumFixtures"];
                                    }
                                    if (RDR.GetName(i) == "TotNumBathrooms")
                                    {
                                        txtNumBathrooms.Text = (string)RDR["TotNumBathrooms"];
                                    }
                                    if (RDR.GetName(i) == "NumSinks")
                                    {
                                        txtNumSinks.Text = (string)RDR["NumSinks"];
                                    }
                                    if (RDR.GetName(i) == "NumWaterCloset")
                                    {
                                        txtNumWaterClosets.Text = (string)RDR["NumWaterCloset"];
                                    }
                                    if (RDR.GetName(i) == "NumShowers")
                                    {
                                        txtNumShowers.Text = (string)RDR["NumShowers"];
                                    }
                                    if (RDR.GetName(i) == "NumTubs")
                                    {
                                        txtNumTubs.Text = (string)RDR["NumTubs"];
                                    }
                                    if (RDR.GetName(i) == "NumClothesWashers")
                                    {
                                        txtNumClothesWashers.Text = (string)RDR["NumClothesWashers"];
                                    }
                                    if (RDR.GetName(i) == "NumWetBars")
                                    {
                                        txtNumWetBars.Text = (string)RDR["NumWetBars"];
                                    }
                                    if (RDR.GetName(i) == "NumSpas")
                                    {
                                        txtNumSpas.Text = (string)RDR["NumSpas"];
                                    }
                                    if (RDR.GetName(i) == "NumWaterHeater")
                                    {
                                        txtNumWaterHeaters.Text = (string)RDR["NumWaterHeater"];
                                    }
                                    if (RDR.GetName(i) == "NumDishWashers")
                                    {
                                        txtNumDishwashers.Text = (string)RDR["NumDishWashers"];
                                    }
                                   


                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows found");
                        }

                    }

                    RDR.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           

        }

        public string _txtOwner { set { txtOwner.Text = value; } }
        public string _txtLotNumber { set { txtLotNumber.Text = value; } }
        public string _txtLRKNumber { set { txtLRKNumber.Text = value; } }
        public string _txtZoningDistrict { set { txtZoningDistrict.Text = value; } }
        public string _txtReatSetback { set { txtReatSetback.Text = value; } }
        public string _txtFrontSetback { set { txtFrontSetback.Text = value; } }
        public string _txtSideSetback { set { txtSideSetback.Text = value; } }
        public string _txtOwnerPhone { set { txtOwnerPhone.Text = value; } }
        public string _txtOwnerCell { set { txtOwnerCell.Text = value; } }
        public string _txtProperty { set { txtProperty.Text = value; } }

        private void btnCancelNotes_Click(object sender, EventArgs e)
        {
            //Clear the text field
            txtNotes.Clear();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            conStr = @"Data Source=.\sqlexpress;Initial Catalog=AberdeenPermitting;User Id=Capstone;Password=Capstone2012;";

            building.save(conStr);
            //utilities.save(conStr);

        }

        private void clearAllFieldsForPermitNum()
        {
            //Reset all fields except the permit number for repopulating fields
            txtApplicant.Clear();
            txtApplicantPhone.Clear();
            txtApplicationNumber.Clear();
            txtBalance.Clear();
            txtBasement.Clear();
            txtCell.Clear();
            txtContractorEmail.Clear();
            txtContractorLiscence.Clear();
            txtContractorName.Clear();
            txtContractorPhone.Clear();
            txtDeck.Clear();
            txtElectricalLisenceNumber.Clear();
            txtElectricalName.Clear();
            txtElectricalPhone.Clear();
            txtEstimatedCost.Clear();
            txtFrontSetback.Clear();
            txtGarageSF.Clear();
            txtGasLisenceNumber.Clear();
            txtGasName.Clear();
            txtGasPhone.Clear();
            txtHeatedSF.Clear();
            txtIrrigationLisenceNumber.Clear();
            txtIrrigationName.Clear();
            txtIrrigationPhone.Clear();
            txtLotNumber.Clear();
            txtLRKNumber.Clear();
            txtMechanicalLisenceNumber.Clear();
            txtMechanicalName.Clear();
            txtMechanicalPhone.Clear();
            txtNotes.Clear();
            txtNumBathrooms.Clear();
            txtNumClothesWashers.Clear();
            txtNumDishwashers.Clear();
            txtNumFixtures.Clear();
            txtNumShowers.Clear();
            txtNumSinks.Clear();
            txtNumSpas.Clear();
            txtNumStories.Clear();
            txtNumSystems.Clear();
            txtNumTubs.Clear();
            txtNumWaterClosets.Clear();
            txtNumWetBars.Clear();
            txtOwner.Clear();
            txtOwnerCell.Clear();
            txtOwnerPhone.Clear();
            txtPlumbingLisenceNumber.Clear();
            txtPlumbingName.Clear();
            txtPlumbingPhone.Clear();
            txtPorchSF.Clear();
            txtProperty.Clear();
            txtSiteManagerName.Clear();
            txtSiteManagerPhone.Clear();
            txtSquareFeet.Clear();
            txtSystemTons.Clear();
            txtReatSetback.Clear();
            txtSideSetback.Clear();
            txtZoningDistrict.Clear();

            cmboConstructionType.SelectedIndex = -1;
            cmboCurrentUse.SelectedIndex = -1;
            cmboNumAmps.SelectedIndex = -1;
            cmboOccupancyType.SelectedIndex = -1;
            cmboProposedUse.SelectedIndex = -1;
            cmboStatus.SelectedIndex = -1;
            cmboSystemType.SelectedIndex = -1;

            cboxDuctwork.Checked = false;
            cboxGasLine.Checked = false;


        }


    }
}
