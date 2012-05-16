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

        Building building = new Building();
        Contact contact = new Contact();
        Contact applicant = new Contact();
        Contact GCContact = new Contact();
        Contractor GC = new Contractor();
        Contractor HVAC = new Contractor();
        Contractor Elet = new Contractor();
        Contractor MECH = new Contractor();
        Contractor PLUM = new Contractor();
        Contractor GAS = new Contractor();
        Contractor IRR = new Contractor();
        Utilities utilities = new Utilities();
        Parcel parcel = new Parcel();
        Permit permit = new Permit();



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
            conStr = @"Data Source=johnreasor-lt\sqlexpress;Initial Catalog=AberdeenPermitting;User Id=Capstone;Password=Capstone2012;";

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
            cmboConstructionType.SelectedIndex = 0;
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
                                        permit.permitDate = (DateTime)RDR["PermitDate"];
                                    }
                                    if (RDR.GetName(i) == "Notes")
                                    {
                                        permit.notes = txtNotes.Text = (string)RDR["Notes"];
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
                                        building.buildingType = cmboConstructionType.Text = (string)RDR["TypeOfConst"];

                                    }
                                    if (RDR.GetName(i) == "ProposedUse")
                                    {
                                        building.proposedUse = cmboProposedUse.Text = (string)RDR["ProposedUse"];
                                    }
                                    if (RDR.GetName(i) == "HeatedSF")
                                    {
                                        building.heatedSF = txtHeatedSF.Text = (string)RDR["HeatedSF"];
                                    }
                                    if (RDR.GetName(i) == "NumberOfStories")
                                    {
                                        building.numStories = txtNumStories.Text = (string)RDR["NumberOfStories"];
                                    }
                                    if (RDR.GetName(i) == "GarageSF")
                                    {
                                        building.garageSF = txtGarageSF.Text = (string)RDR["GarageSF"];
                                    }
                                    if (RDR.GetName(i) == "PorchSF")
                                    {
                                        building.porchSF = txtPorchSF.Text = (string)RDR["PorchSF"];
                                    }

                                    if (RDR.GetName(i) == "DeckSF")
                                    {
                                        building.deckSF = txtDeck.Text = (string)RDR["DeckSF"];
                                    }

                                    if (RDR.GetName(i) == "BasementSF")
                                    {
                                        building.basementSF = txtBasement.Text = (string)RDR["BasementSF"];
                                    }
                                    if (RDR.GetName(i) == "EstCostOfConst")
                                    {
                                        building.estimatedCost = txtEstimatedCost.Text = (string)RDR["EstCostOfConst"];
                                    }
                                    if (RDR.GetName(i) == "ProposedUse")
                                    {
                                        building.proposedUse = cmboProposedUse.Text = (string)RDR["ProposedUse"];
                                    }
                                    if (RDR.GetName(i) == "InstallInsulation")
                                    {
                                        cboxDuctwork.Checked = (bool)RDR["InstallInsulation"];
                                    }
                                    if (RDR.GetName(i) == "TotalSF")
                                    {
                                        building.totalSF = txtSquareFeet.Text = (string)RDR["TotalSF"];
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
                                        contact.companyName = txtOwner.Text = (string)RDR["CompName"];

                                    }
                                    if (RDR.GetName(i) == "FirstPhone")
                                    {
                                        contact.firstPhone = txtOwnerPhone.Text = (string)RDR["FirstPhone"];

                                    }
                                    if (RDR.GetName(i) == "SecondPhone")
                                    {
                                        contact.secondPhone = txtOwnerCell.Text = (string)RDR["SecondPhone"];

                                    }
                                    if (RDR.GetName(i) == "Address")
                                    {
                                        parcel.address = txtProperty.Text = (string)RDR["Address"];
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
                                            MECH.companyName = txtMechanicalName.Text = (string)RDR["CompName"];
                                            MECH.firstPhone = txtMechanicalPhone.Text = (string)RDR["FirstPhone"];
                                            MECH.buildingLicense = txtMechanicalLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                        }
                                        if ((string)RDR["Type"] == "General Contractor")
                                        {
                                            GC.companyName = txtContractorName.Text = (string)RDR["CompName"];
                                            GC.firstPhone = txtContractorPhone.Text = (string)RDR["FirstPhone"];
                                            GC.buildingLicense = txtContractorLiscence.Text = (string)RDR["LicenseNumber"];
                                        }
                                        if ((string)RDR["Type"] == "Electrical")
                                        {
                                            Elet.companyName = txtElectricalName.Text = (string)RDR["CompName"];
                                            Elet.firstPhone = txtElectricalPhone.Text = (string)RDR["FirstPhone"];
                                            Elet.buildingLicense = txtElectricalLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                        }
                                        if ((string)RDR["Type"] == "Plumbing")
                                        {
                                            PLUM.companyName = txtPlumbingName.Text = (string)RDR["CompName"];
                                            PLUM.firstPhone = txtPlumbingPhone.Text = (string)RDR["FirstPhone"];
                                            PLUM.buildingLicense = txtPlumbingLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                        }
                                        if ((string)RDR["Type"] == "GAS")
                                        {
                                            GAS.companyName = txtGasName.Text = (string)RDR["CompName"];
                                            GAS.firstPhone = txtGasPhone.Text = (string)RDR["FirstPhone"];
                                            GAS.buildingLicense = txtGasLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                        }
                                        if ((string)RDR["Type"] == "Irrigation")
                                        {
                                            IRR.companyName = txtIrrigationName.Text = (string)RDR["CompName"];
                                            IRR.firstPhone = txtIrrigationPhone.Text = (string)RDR["FirstPhone"];
                                            IRR.buildingLicense = txtIrrigationLisenceNumber.Text = (string)RDR["LicenseNumber"];
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
                                        utilities.numAmps = cmboNumAmps.Text = (string)RDR["NumAmps"];


                                    }
                                    if (RDR.GetName(i) == "TempPole")
                                    {
                                        utilities.tempPole = cboxTempPole.Checked = (bool)RDR["TempPole"];
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
                                       utilities.setNumSys = txtNumSystems.Text = (string)RDR["NumSystems"];
                                    }
                                    if (RDR.GetName(i) == "SystemType")
                                    {
                                       utilities.systemType =  cmboSystemType.Text = (string)RDR["SystemType"];
                                    }
                                    if (RDR.GetName(i) == "Tons")
                                    {
                                       utilities.tons = txtSystemTons.Text = (string)RDR["Tons"];
                                    }
                                    if (RDR.GetName(i) == "GasLine")
                                    {
                                       utilities.gasLine = cboxGasLine.Checked = (bool)RDR["GasLIne"];
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
                                       parcel.address = txtProperty.Text = (string)RDR["Address"];
                                    }
                                    if (RDR.GetName(i) == "LotNum")
                                    {
                                      parcel.lotNum =  txtLotNumber.Text = (string)RDR["LotNum"];
                                    }
                                    if (RDR.GetName(i) == "LRK")
                                    {
                                       parcel.lrk = txtLRKNumber.Text = (string)RDR["LRK"];
                                    }
                                    if (RDR.GetName(i) == "ZoningDist")
                                    {
                                       parcel.zoningDist = txtZoningDistrict.Text = (string)RDR["ZoningDist"];
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
                                       utilities.numFixtures = txtNumFixtures.Text = (string)RDR["TotNumFixtures"];
                                    }
                                    if (RDR.GetName(i) == "TotNumBathrooms")
                                    {
                                       utilities.numBathrooms = txtNumBathrooms.Text = (string)RDR["TotNumBathrooms"];
                                    }
                                    if (RDR.GetName(i) == "NumSinks")
                                    {
                                       utilities.numSinks =  txtNumSinks.Text = (string)RDR["NumSinks"];
                                    }
                                    if (RDR.GetName(i) == "NumWaterCloset")
                                    {
                                       utilities.numWaterClosets = txtNumWaterClosets.Text = (string)RDR["NumWaterCloset"];
                                    }
                                    if (RDR.GetName(i) == "NumShowers")
                                    {
                                       utilities.numShowers = txtNumShowers.Text = (string)RDR["NumShowers"];
                                    }
                                    if (RDR.GetName(i) == "NumTubs")
                                    {
                                       utilities.numTub = txtNumTubs.Text = (string)RDR["NumTubs"];
                                    }
                                    if (RDR.GetName(i) == "NumClothesWashers")
                                    {
                                       utilities.numClothesWasher = txtNumClothesWashers.Text = (string)RDR["NumClothesWashers"];
                                    }
                                    if (RDR.GetName(i) == "NumWetBars")
                                    {
                                       utilities.numWetBar = txtNumWetBars.Text = (string)RDR["NumWetBars"];
                                    }
                                    if (RDR.GetName(i) == "NumSpas")
                                    {
                                       utilities.numSpa = txtNumSpas.Text = (string)RDR["NumSpas"];
                                    }
                                    if (RDR.GetName(i) == "NumWaterHeater")
                                    {
                                       utilities.numWaterHeater = txtNumWaterHeaters.Text = (string)RDR["NumWaterHeater"];
                                    }
                                    if (RDR.GetName(i) == "NumDishWashers")
                                    {
                                       utilities.numDishWasher = txtNumDishwashers.Text = (string)RDR["NumDishWashers"];
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


        /// <summary>
        /// access point for search and add forms
        /// </summary>
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
        public string _txtContractorName { set { txtContractorName.Text = value; } }
        public string _txtContractorLiscence { set { txtContractorLiscence.Text = value; } }
        public string _txtContractorPhone { set { txtContractorPhone.Text = value; } }
        public string _txtContractorEmail { set { txtContractorEmail.Text = value; } }
        public string _txtElectricalName { set { txtElectricalName.Text = value; } }
        public string _txtElectricalLisenceNumber { set { txtElectricalLisenceNumber.Text = value; } }
        public string _txtElectricalPhone { set { txtElectricalPhone.Text = value; } }
        public string _txtPlumbingName { set { txtPlumbingName.Text = value; } }
        public string _txtPlumbingLisenceNumber { set { txtPlumbingLisenceNumber.Text = value; } }
        public string _txtPlumbingPhone { set { txtPlumbingPhone.Text = value; } }
        public string _txtMechanicalName { set { txtMechanicalName.Text = value; } }
        public string _txtMechanicalLisenceNumber { set { txtMechanicalLisenceNumber.Text = value; } }
        public string _txtMechanicalPhone { set { txtMechanicalPhone.Text = value; } }
        public string _txtGasName { set { txtGasName.Text = value; } }
        public string _txtGasLisenceNumber { set { txtGasLisenceNumber.Text = value; } }
        public string _txtGasPhone { set { txtGasPhone.Text = value; } }
        public string _txtIrrigationName { set { txtIrrigationName.Text = value; } }
        public string _txtIrrigationLisenceNumber { set { txtIrrigationLisenceNumber.Text = value; } }
        public string _txtIrrigationPhone { set { txtIrrigationPhone.Text = value; } }

        /// <summary>
        /// Parcel access
        /// </summary>
        public string _setPropAddress { set { parcel.address = value; } }
        public string _setPropcity { set { parcel.city = value; } }
        public int _setPropcontactID { set { parcel.contactID = value; } }
        public string _setPropdeedAcre { set { parcel.deedAcre = value; } }
        public string _setPropdeedBook { set { parcel.deedBook = value; } }
        public string _setPropdeedPage { set { parcel.deedPage = value; } }
        public string _setProplotNum { set { parcel.lotNum = value; } }
        public string _setProplrk { set { parcel.lrk = value; } }
        public string _setPropparcelID { set { parcel.parcelID = value; } }
        public string _setPropsize { set { parcel.size = value; } }
        public string _setPropstate { set { parcel.state = value; } }
        public string _setProptaxAcre { set { parcel.taxAcre = value; } }
        public decimal _setPropvalue { set { parcel.value = value; } }
        public string _setPropzip { set { parcel.zip = value; } }
        public string _setPropzoningDist { set { parcel.zoningDist = value; } }


        /// <summary>
        /// contact access point 
        /// </summary>
        public string _setcontactCompanyName { set { contact.companyName = value; } }
        public string _setcontactCompanyName2 { set { contact.companyName2 = value; } }
        public string _setcontactbuildingLicense { set { contact.buildingLicense = value; } }
        public string _setcontactcity { set { contact.city = value; } }
        public string _setcontactemail { set { contact.email = value; } }
        public string _setcontactFName { set { contact.firstName = value; } }
        public string _setcontactFPhone { set { contact.firstPhone = value; } }
        public string _setcontactLName { set { contact.lastName = value; } }
        public string _setcontactlicense { set { contact.license = value; } }
        public DateTime _setcontactlicenseExpDate { set { contact.licenseExpDate = value; } }
        public string _setcontactmiddleName { set { contact.middleName = value; } }
        public string _setcontactpermitID { set { contact.permitID = value; } }
        public bool _setcontactproperty { set { contact.property = value; } }
        public string _setcontactsecondPhone { set { contact.secondPhone = value; } }
        public string _setcontactstate { set { contact.state = value; } }
        public string _setcontactstreetName { set { contact.streetName = value; } }
        public string _setcontactstreetName2 { set { contact.streetName2 = value; } }
        public string _setcontactstreetNumber { set { contact.streetNumber = value; } }
        public string _setcontacttype { set { contact.type = value; } }
        public string _setcontactzip { set { contact.zip = value; } }


        /// <summary>
        /// GC access point 
        /// </summary>
        public string _setGCCompanyName { set { GC.companyName = value; } }
        public string _setGCCompanyName2 { set { GC.companyName2 = value; } }
        public string _setGCaberdeenLC { set { GC.aberdeenLC = value; } }
        public string _setGCbuildingLicense { set { GC.buildingLicense = value; } }
        public string _setGCcity { set { GC.city = value; } }
        public string _setGCemail { set { GC.email = value; } }
        public string _setGCfirstName { set { GC.firstName = value; } }
        public string _setGCfirstPhone { set { GC.firstPhone = value; } }
        public string _setGClastName { set { GC.lastName = value; } }
        public string _setGClicense { set { GC.license = value; } }
        public DateTime _setGClicenseExpDate { set { GC.licenseExpDate = value; } }
        public string _setGClicenseNumber { set { GC.licenseNumber = value; } }
        public string _setGCmiddleName { set { GC.middleName = value; } }
        public string _setGCpermitID { set { GC.permitID = value; } }
        public bool _setGCproperty { set { GC.property = value; } }
        public string _setGCsecondPhone { set { GC.secondPhone = value; } }
        public string _setGCstate { set { GC.state = value; } }
        public string _setGCstreetName { set { GC.streetName = value; } }
        public string _setGCstreetName2 { set { GC.streetName2 = value; } }
        public string _setGCstreetNumber { set { GC.streetNumber = value; } }
        public string _setGCtype { set { GC.type = value; } }
        public string _setGCzip { set { GC.zip = value; } }


        /// <summary>
        /// ELET access point 
        /// </summary>
        public string _setEletCompanyName { set { Elet.companyName = value; } }
        public string _setEletCompanyName2 { set { Elet.companyName2 = value; } }
        public string _setEletaberdeenLC { set { Elet.aberdeenLC = value; } }
        public string _setEletbuildingLicense { set { Elet.buildingLicense = value; } }
        public string _setEletcity { set { Elet.city = value; } }
        public string _setEletemail { set { Elet.email = value; } }
        public string _setEletfirstName { set { Elet.firstName = value; } }
        public string _setEletfirstPhone { set { Elet.firstPhone = value; } }
        public string _setEletlastName { set { Elet.lastName = value; } }
        public string _setEletlicense { set { Elet.license = value; } }
        public DateTime _setEletlicenseExpDate { set { Elet.licenseExpDate = value; } }
        public string _setEletlicenseNumber { set { Elet.licenseNumber = value; } }
        public string _setEletmiddleName { set { Elet.middleName = value; } }
        public string _setEletpermitID { set { Elet.permitID = value; } }
        public bool _setEletproperty { set { Elet.property = value; } }
        public string _setEletsecondPhone { set { Elet.secondPhone = value; } }
        public string _setEletstate { set { Elet.state = value; } }
        public string _setEletstreetName { set { Elet.streetName = value; } }
        public string _setEletstreetName2 { set { Elet.streetName2 = value; } }
        public string _setEletstreetNumber { set { Elet.streetNumber = value; } }
        public string _setElettype { set { Elet.type = value; } }
        public string _setEletzip { set { Elet.zip = value; } }


        /// <summary>
        /// HVAC access point 
        /// </summary>
        public string _setHVACCompanyName { set { HVAC.companyName = value; } }
        public string _setHVACCompanyName2 { set { HVAC.companyName2 = value; } }
        public string _setHVACaberdeenLC { set { HVAC.aberdeenLC = value; } }
        public string _setHVACbuildingLicense { set { HVAC.buildingLicense = value; } }
        public string _setHVACcity { set { HVAC.city = value; } }
        public string _setHVACemail { set { HVAC.email = value; } }
        public string _setHVACfirstName { set { HVAC.firstName = value; } }
        public string _setHVACfirstPhone { set { HVAC.firstPhone = value; } }
        public string _setHVAClastName { set { HVAC.lastName = value; } }
        public string _setHVAClicense { set { HVAC.license = value; } }
        public DateTime _setHVAClicenseExpDate { set { HVAC.licenseExpDate = value; } }
        public string _setHVAClicenseNumber { set { HVAC.licenseNumber = value; } }
        public string _setHVACmiddleName { set { HVAC.middleName = value; } }
        public string _setHVACpermitID { set { HVAC.permitID = value; } }
        public bool _setHVACproperty { set { HVAC.property = value; } }
        public string _setHVACsecondPhone { set { HVAC.secondPhone = value; } }
        public string _setHVACstate { set { HVAC.state = value; } }
        public string _setHVACstreetName { set { HVAC.streetName = value; } }
        public string _setHVACstreetName2 { set { HVAC.streetName2 = value; } }
        public string _setHVACstreetNumber { set { HVAC.streetNumber = value; } }
        public string _setHVACtype { set { HVAC.type = value; } }
        public string _setHVACzip { set { HVAC.zip = value; } }

        /// <summary>
        /// MECH access point 
        /// </summary>
        public string _setMECHCompanyName { set { MECH.companyName = value; } }
        public string _setMECHCompanyName2 { set { MECH.companyName2 = value; } }
        public string _setMECHaberdeenLC { set { MECH.aberdeenLC = value; } }
        public string _setMECHbuildingLicense { set { MECH.buildingLicense = value; } }
        public string _setMECHcity { set { MECH.city = value; } }
        public string _setMECHemail { set { MECH.email = value; } }
        public string _setMECHfirstName { set { MECH.firstName = value; } }
        public string _setMECHfirstPhone { set { MECH.firstPhone = value; } }
        public string _setMECHlastName { set { MECH.lastName = value; } }
        public string _setMECHlicense { set { MECH.license = value; } }
        public DateTime _setMECHlicenseExpDate { set { MECH.licenseExpDate = value; } }
        public string _setMECHlicenseNumber { set { MECH.licenseNumber = value; } }
        public string _setMECHmiddleName { set { MECH.middleName = value; } }
        public string _setMECHpermitID { set { MECH.permitID = value; } }
        public bool _setMECHproperty { set { MECH.property = value; } }
        public string _setMECHsecondPhone { set { MECH.secondPhone = value; } }
        public string _setMECHstate { set { MECH.state = value; } }
        public string _setMECHstreetName { set { MECH.streetName = value; } }
        public string _setMECHstreetName2 { set { MECH.streetName2 = value; } }
        public string _setMECHstreetNumber { set { MECH.streetNumber = value; } }
        public string _setMECHtype { set { MECH.type = value; } }
        public string _setMECHzip { set { MECH.zip = value; } }

        /// <summary>
        /// PLUM access point 
        /// </summary>
        public string _setPLUMCompanyName { set { PLUM.companyName = value; } }
        public string _setPLUMCompanyName2 { set { PLUM.companyName2 = value; } }
        public string _setPLUMaberdeenLC { set { PLUM.aberdeenLC = value; } }
        public string _setPLUMbuildingLicense { set { PLUM.buildingLicense = value; } }
        public string _setPLUMcity { set { PLUM.city = value; } }
        public string _setPLUMemail { set { PLUM.email = value; } }
        public string _setPLUMfirstName { set { PLUM.firstName = value; } }
        public string _setPLUMfirstPhone { set { PLUM.firstPhone = value; } }
        public string _setPLUMlastName { set { PLUM.lastName = value; } }
        public string _setPLUMlicense { set { PLUM.license = value; } }
        public DateTime _setPLUMlicenseExpDate { set { PLUM.licenseExpDate = value; } }
        public string _setPLUMlicenseNumber { set { PLUM.licenseNumber = value; } }
        public string _setPLUMmiddleName { set { PLUM.middleName = value; } }
        public string _setPLUMpermitID { set { PLUM.permitID = value; } }
        public bool _setPLUMproperty { set { PLUM.property = value; } }
        public string _setPLUMsecondPhone { set { PLUM.secondPhone = value; } }
        public string _setPLUMstate { set { PLUM.state = value; } }
        public string _setPLUMstreetName { set { PLUM.streetName = value; } }
        public string _setPLUMstreetName2 { set { PLUM.streetName2 = value; } }
        public string _setPLUMstreetNumber { set { PLUM.streetNumber = value; } }
        public string _setPLUMtype { set { PLUM.type = value; } }
        public string _setPLUMzip { set { PLUM.zip = value; } }

        /// <summary>
        /// GAS access point 
        /// </summary>
        public string _setGASCompanyName { set { GAS.companyName = value; } }
        public string _setGASCompanyName2 { set { GAS.companyName2 = value; } }
        public string _setGASaberdeenLC { set { GAS.aberdeenLC = value; } }
        public string _setGASbuildingLicense { set { GAS.buildingLicense = value; } }
        public string _setGAScity { set { GAS.city = value; } }
        public string _setGASemail { set { GAS.email = value; } }
        public string _setGASfirstName { set { GAS.firstName = value; } }
        public string _setGASfirstPhone { set { GAS.firstPhone = value; } }
        public string _setGASlastName { set { GAS.lastName = value; } }
        public string _setGASlicense { set { GAS.license = value; } }
        public DateTime _setGASlicenseExpDate { set { GAS.licenseExpDate = value; } }
        public string _setGASlicenseNumber { set { GAS.licenseNumber = value; } }
        public string _setGASmiddleName { set { GAS.middleName = value; } }
        public string _setGASpermitID { set { GAS.permitID = value; } }
        public bool _setGASproperty { set { GAS.property = value; } }
        public string _setGASsecondPhone { set { GAS.secondPhone = value; } }
        public string _setGASstate { set { GAS.state = value; } }
        public string _setGASstreetName { set { GAS.streetName = value; } }
        public string _setGASstreetName2 { set { GAS.streetName2 = value; } }
        public string _setGASstreetNumber { set { GAS.streetNumber = value; } }
        public string _setGAStype { set { GAS.type = value; } }
        public string _setGASzip { set { GAS.zip = value; } }

        /// <summary>
        /// IRR access point 
        /// </summary>
        public string _setIRRCompanyName { set { IRR.companyName = value; } }
        public string _setIRRCompanyName2 { set { IRR.companyName2 = value; } }
        public string _setIRRaberdeenLC { set { IRR.aberdeenLC = value; } }
        public string _setIRRbuildingLicense { set { IRR.buildingLicense = value; } }
        public string _setIRRcity { set { IRR.city = value; } }
        public string _setIRRemail { set { IRR.email = value; } }
        public string _setIRRfirstName { set { IRR.firstName = value; } }
        public string _setIRRfirstPhone { set { IRR.firstPhone = value; } }
        public string _setIRRlastName { set { IRR.lastName = value; } }
        public string _setIRRlicense { set { IRR.license = value; } }
        public DateTime _setIRRlicenseExpDate { set { IRR.licenseExpDate = value; } }
        public string _setIRRlicenseNumber { set { IRR.licenseNumber = value; } }
        public string _setIRRmiddleName { set { IRR.middleName = value; } }
        public string _setIRRpermitID { set { IRR.permitID = value; } }
        public bool _setIRRproperty { set { IRR.property = value; } }
        public string _setIRRsecondPhone { set { IRR.secondPhone = value; } }
        public string _setIRRstate { set { IRR.state = value; } }
        public string _setIRRstreetName { set { IRR.streetName = value; } }
        public string _setIRRstreetName2 { set { IRR.streetName2 = value; } }
        public string _setIRRstreetNumber { set { IRR.streetNumber = value; } }
        public string _setIRRtype { set { IRR.type = value; } }
        public string _setIRRzip { set { IRR.zip = value; } }

        private void btnCancelNotes_Click(object sender, EventArgs e)
        {
            //Clear the text field
            txtNotes.Clear();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtBasement.Text == null && txtBasement.Text == "")
            {
                this.building.basementExist = false;
            }
            else
            {
                this.building.basementExist = true;
            }

            this.building.basementSF = txtBasement.Text;
            this.building.buildingType = cmboConstructionType.Text;
            this.building.deckSF = txtDeck.Text;
            this.building.estimatedCost = txtEstimatedCost.Text;
            this.building.garageSF = txtGarageSF.Text;
            this.building.heatedSF = txtHeatedSF.Text;
            this.building.lrk = txtLRKNumber.Text;
            this.building.numStories = txtNumStories.Text;
            this.building.permitId = txtPermitNumber.Text;
            this.building.porchSF = txtPorchSF.Text;
            this.building.proposedUse = cmboProposedUse.Text;
            this.building.totalSF = txtSquareFeet.Text;
            this.building.permitId = txtPermitNumber.Text;

            this.building.save(conStr);

            this.contact.companyName = txtOwner.Text;
            this.contact.firstPhone = txtOwnerPhone.Text;
            this.contact.secondPhone = txtCell.Text;
            this.contact.property = true;
            this.contact.permitID = txtPermitNumber.Text;

            this.contact.save(conStr);

            this.utilities.buildingID = this.building.buildingID;

            if (cboxGasLine.Checked)
            {
                this.utilities.gasLine = true;
            }
            else
            {
                this.utilities.gasLine = false;
            }

            this.utilities.numAmps = cmboNumAmps.SelectedText;
            this.utilities.numBathrooms = txtNumBathrooms.Text;
            this.utilities.numClothesWasher = txtNumClothesWashers.Text;
            this.utilities.numDishWasher = txtNumDishwashers.Text;
            this.utilities.numFixtures = txtNumFixtures.Text;
            this.utilities.numShowers = txtNumShowers.Text;
            this.utilities.numSinks = txtNumSinks.Text;
            this.utilities.numSpa = txtNumSpas.Text;
            this.utilities.numTub = txtNumTubs.Text;
            this.utilities.numWaterClosets = txtNumWaterClosets.Text;
            this.utilities.numWaterHeater = txtNumWaterHeaters.Text;
            this.utilities.numWetBar = txtNumWetBars.Text;
            this.utilities.systemType = cmboSystemType.SelectedText;

            if (cboxTempPole.Checked)
            {
                this.utilities.tempPole = true;
            }
            else
            {
                this.utilities.tempPole = false;
            }

            this.utilities.tons = txtSystemTons.Text;

            this.utilities.save(conStr);

           
            this.GC.companyName = txtContractorName.Text;
            this.GC.firstPhone = txtContractorPhone.Text;
            this.GC.license = txtContractorLiscence.Text;
            this.GC.permitID = txtPermitNumber.Text;
            this.GC.property = false;

            this.GC.save(conStr);

            this.GCContact.companyName = txtSiteManagerName.Text;
            this.GCContact.firstPhone = txtSiteManagerPhone.Text;
            this.GCContact.email = txtContractorEmail.Text;
            this.GCContact.permitID = txtPermitNumber.Text;
            this.GCContact.property = false;

            this.GCContact.save(conStr);

            this.Elet.companyName = txtElectricalName.Text;
            this.Elet.firstPhone = txtElectricalPhone.Text;
            this.Elet.license = txtElectricalLisenceNumber.Text;
            this.Elet.property = false;

            this.Elet.save(conStr);

            this.PLUM.companyName = txtPlumbingName.Text;
            this.PLUM.firstPhone = txtPlumbingPhone.Text;
            this.PLUM.license = txtPlumbingLisenceNumber.Text;
            this.PLUM.property = false;

            this.PLUM.save(conStr);

            this.MECH.companyName = txtMechanicalName.Text;
            this.MECH.firstPhone = txtMechanicalPhone.Text;
            this.MECH.license = txtMechanicalLisenceNumber.Text;
            this.MECH.property = false;

            this.MECH.save(conStr);

            this.GAS.companyName = txtGasName.Text;
            this.GAS.firstPhone = txtGasPhone.Text;
            this.GAS.license = txtGasLisenceNumber.Text;
            this.GAS.property = false;

            this.GAS.save(conStr);

            this.IRR.companyName = txtIrrigationName.Text;
            this.IRR.firstPhone = txtIrrigationPhone.Text;
            this.IRR.license = txtIrrigationLisenceNumber.Text;
            this.IRR.property = false;

            this.IRR.save(conStr);

            this.applicant.companyName = txtApplicant.Text;
            this.applicant.firstPhone = txtApplicant.Text;
            this.applicant.secondPhone = txtCell.Text;
            this.applicant.property = false;


            this.applicant.save(conStr);

            this.parcel.address = txtProperty.Text;
            this.parcel.lotNum = txtLotNumber.Text;
            this.parcel.lrk = txtLRKNumber.Text;
            this.parcel.zoningDist = txtZoningDistrict.Text;

            this.parcel.save(conStr);

            this.permit.buildingID = this.building.buildingID;
            this.permit.feeTotal = txtBalance.Text;
            this.permit.notes = txtNotes.Text;
            this.permit.parcelID = this.parcel.parcelID;
            this.permit.permitDate = dtIssueDate.Value;

            this.permit.save(conStr);

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
