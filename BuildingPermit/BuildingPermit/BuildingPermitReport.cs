using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace BuildingPermit
{
    public partial class BuildingPermitReport : Form
    {

        String permitID, applicantName, propAddress, compName, taxID, firstPhone, secondPhone, lrkNumber, lotNumber, occupType, currUse, zonDistrict, frontSetback, rearSetback, sideSetback, propUse, sqFeet, estCost, typeOfConstruction, heatedSF, porchSF, stories, deckSF, garageSF, basement, numSystems, gasLine, numbBathrooms, totNumbFixt, toilets, showerTubs, clothesWasher;
        Building building = new Building();
        String conStr = @"Data Source=.\sqlexpress;Initial Catalog=AberdeenPermitting;User Id=Capstone;Password=Capstone2012;";
        public BuildingPermitReport()
        {
            InitializeComponent();
        }



        private void BuildingPermitReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.SetDisplayMode(DisplayMode.Normal);

            permitID = "1";

            ReportParameter p1 = new ReportParameter("permitID", permitID);
            
           
            ReportParameter p4 = new ReportParameter("compName", compName);
            ReportParameter p5 = new ReportParameter("taxID", taxID);
            
            
            
            
            ReportParameter p10 = new ReportParameter("occupType", occupType);
            ReportParameter p11 = new ReportParameter("currUse", currUse);
            
            ReportParameter p13 = new ReportParameter("frontSetback", frontSetback);
            ReportParameter p14 = new ReportParameter("rearSetback", rearSetback);
            ReportParameter p15 = new ReportParameter("sideSetback", sideSetback);
            //ReportParameter p16 = new ReportParameter("propUse", propUse);
            
            
            
            
           
            
            
            
            
            
            ReportParameter p27 = new ReportParameter("gasLine", gasLine);
            ReportParameter p28 = new ReportParameter("numBathrooms", numbBathrooms);
            ReportParameter p29 = new ReportParameter("totNumbFixt", totNumbFixt);
            ReportParameter p30 = new ReportParameter("toilets", toilets);
            ReportParameter p31 = new ReportParameter("showerTubs", showerTubs);
            ReportParameter p32 = new ReportParameter("clothesWasher", clothesWasher);

            //Start here
            using (SqlConnection con = new SqlConnection(conStr))
            {
                String procedure = "SearchForPermit";

                try
                {

                    con.Open();
                    SqlCommand spCmd;
                    spCmd = new SqlCommand(procedure, con);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Prepare();
                    spCmd.Parameters["@in_PermitID"].Value = 1;


                    SqlDataReader RDR = spCmd.ExecuteReader(CommandBehavior.KeyInfo);



                    while (RDR.NextResult())
                    {
                        while (RDR.Read())
                        {
                            if (RDR.HasRows)
                            {


                                for (int i = 0; i < RDR.FieldCount; i++)
                                {
                                    Console.WriteLine(RDR.GetName(i));
                                    Console.WriteLine(RDR.GetValue(i));
                                    if (RDR[RDR.GetName(i)] != null)
                                    {
                                        if (RDR.GetName(i) == "CompName")
                                        {
                                            applicantName = (string)RDR["CompName"];
                                            
                                        }
                                        if (RDR.GetName(i) == "FirstPhone")
                                        {
                                            firstPhone = (string)RDR["FirstPhone"];
                                            
                                        }
                                        if (RDR.GetName(i) == "SecondPhone")
                                        {
                                            secondPhone = (string)RDR["SecondPhone"];
                                            
                                        }
                                        if (RDR.GetName(i) == "Address")
                                        {
                                            propAddress = (string)RDR["Address"];
                                            

                                        }
                                        if (RDR.GetName(i) == "LotNum")
                                        {
                                            lotNumber = (string)RDR["LotNum"];
                                            

                                        }
                                        if (RDR.GetName(i) == "LRK")
                                        {
                                            lrkNumber = (string)RDR["LRK"];
                                            
                                        }
                                        if (RDR.GetName(i) == "ZoningDist")
                                        {
                                            zonDistrict = (string)RDR["ZoningDist"];
                                            
                                        }
                                        if (RDR.GetName(i) == "ProposedUse")
                                        {
                                            propUse = (string)RDR["ProposedUse"];
                                            
                                        }
                                        if (RDR.GetName(i) == "TotalSF")
                                        {
                                            sqFeet = (string)RDR["TotalSF"];
                                            

                                        }
                                        if (RDR.GetName(i) == "EstCostOfConst")
                                        {
                                            estCost = (string)RDR["EstCostOfConst"];
                                            

                                        }
                                        if (RDR.GetName(i) == "TypeOfConst")
                                        {
                                            typeOfConstruction = (string)RDR["TypeOfConst"];
                                            

                                        }
                                        if (RDR.GetName(i) == "HeatedSF")
                                        {
                                            heatedSF = (string)RDR["HeatedSF"];
                                            

                                        }
                                        if (RDR.GetName(i) == "PorchSF")
                                        {
                                            porchSF = (string)RDR["PorchSF"];
                                            

                                        }
                                        if (RDR.GetName(i) == "NumberOfStories")
                                        {
                                            stories = (string)RDR["NumberOfStories"];
                         
                                        }
                                        if (RDR.GetName(i) == "DeckSF")
                                        {
                                            deckSF = (string)RDR["DeckSF"];
                                            
                                        }
                                        if (RDR.GetName(i) == "GarageSF")
                                        {
                                            garageSF = (string)RDR["GarageSF"];
                                                                                      
                                        }
                                        if (RDR.GetName(i) == "BasementSF")
                                        {
                                            basement = (string)RDR["BasementSF"];
                                            
                                        }
                                        if (RDR.GetName(i) == "NumSystems")
                                        {
                                            numSystems = (string)RDR["NumSystems"];
                                            

                                        }
                                        /*if (RDR.GetName(i) == "SystemType")
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
                                        if (RDR.GetName(i) == "NumAmps")
                                        {
                                            if ((string)RDR["NumAmps"] == "Electrical 100 Amp Service (1 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 0;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 200 Amp Service (1 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 1;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 320 Amp Service (1 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 2;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 400 Amp Service (1 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 3;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 600 Amp Service (1 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 4;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 600/+ Amp Service (1 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 5;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 200 Amp Service (3 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 6;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 400 Amp Service (3 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 7;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 600 Amp Service (3 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 8;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 800 Amp Service (3 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 9;
                                            }
                                            else if ((string)RDR["NumAmps"] == "Electrical 1000 Amp Service (3 Phase)")
                                            {
                                                cmboNumAmps.SelectedItem = 10;
                                            }

                                        }
                                        if (RDR.GetName(i) == "TempPole")
                                        {
                                            cboxTempPole.Checked = (bool)RDR["TempPole"];
                                        }
                                        if (RDR.GetName(i) == "AberdeenLC")
                                        {
                                            txtApplicationNumber.Text = (string)RDR["AberdeenLC"];
                                        }
                                        if (RDR.GetName(i) == "Notes")
                                        {
                                            txtNotes.Text = (string)RDR["Notes"];
                                        }
                                        if (RDR.GetName(i) == "Type")
                                        {
                                            if ((string)RDR["Type"] == "HVAC")
                                            {
                                                txtMechanicalName.Text = (string)RDR["CompName"];
                                                txtMechanicalPhone.Text = (string)RDR["PhoneNumber"];
                                                txtMechanicalLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "General Contractor")
                                            {
                                                txtContractorName.Text = (string)RDR["CompName"];
                                                txtContractorPhone.Text = (string)RDR["PhoneNumber"];
                                                txtContractorLiscence.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "Electrical")
                                            {
                                                txtElectricalName.Text = (string)RDR["CompName"];
                                                txtElectricalPhone.Text = (string)RDR["PhoneNumber"];
                                                txtElectricalLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "Plumbing")
                                            {
                                                txtPlumbingName.Text = (string)RDR["CompName"];
                                                txtPlumbingPhone.Text = (string)RDR["PhoneNumber"];
                                                txtPlumbingLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "GAS")
                                            {
                                                txtGasName.Text = (string)RDR["CompName"];
                                                txtGasPhone.Text = (string)RDR["PhoneNumber"];
                                                txtGasLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                            if ((string)RDR["Type"] == "Irrigation")
                                            {
                                                txtIrrigationName.Text = (string)RDR["CompName"];
                                                txtIrrigationPhone.Text = (string)RDR["PhoneNumber"];
                                                txtIrrigationLisenceNumber.Text = (string)RDR["LicenseNumber"];
                                            }
                                        }
                                        */
                                    }
                                }


                            }
                            else
                            {
                                Console.WriteLine("No Rows found");
                            }



                        }

                        RDR.NextResult();

                    }


                    RDR.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //End here
                ReportParameter p2 = new ReportParameter("applicantName", applicantName);
                ReportParameter p6 = new ReportParameter("firstPhone", firstPhone);
                ReportParameter p7 = new ReportParameter("secondPhone", secondPhone);
                ReportParameter p3 = new ReportParameter("propAddress", propAddress);
                ReportParameter p9 = new ReportParameter("lotNumber", lotNumber);
                ReportParameter p8 = new ReportParameter("lrkNumber", lrkNumber);
                ReportParameter p12 = new ReportParameter("zonDistrict", zonDistrict);
                ReportParameter p16 = new ReportParameter("propUse", propUse);
                ReportParameter p17 = new ReportParameter("sqFeet", sqFeet);
                ReportParameter p18 = new ReportParameter("estCost", estCost);
                ReportParameter p19 = new ReportParameter("typeOfConstruction", typeOfConstruction);
                ReportParameter p20 = new ReportParameter("heatedSF", heatedSF);
                ReportParameter p21 = new ReportParameter("porchSF", porchSF);
                ReportParameter p22 = new ReportParameter("stories", stories);
                ReportParameter p23 = new ReportParameter("deckSF", deckSF);
                ReportParameter p24 = new ReportParameter("garageSF", garageSF);
                ReportParameter p25 = new ReportParameter("basement", basement);
                ReportParameter p26 = new ReportParameter("numSystems", numSystems);


                this.reportViewer1.LocalReport.SetParameters(p1);
                this.reportViewer1.LocalReport.SetParameters(p2);
                this.reportViewer1.LocalReport.SetParameters(p3);
                this.reportViewer1.LocalReport.SetParameters(p4);
                this.reportViewer1.LocalReport.SetParameters(p5);
                this.reportViewer1.LocalReport.SetParameters(p6);
                this.reportViewer1.LocalReport.SetParameters(p7);
                this.reportViewer1.LocalReport.SetParameters(p8);
                this.reportViewer1.LocalReport.SetParameters(p9);
                this.reportViewer1.LocalReport.SetParameters(p10);
                this.reportViewer1.LocalReport.SetParameters(p11);
                this.reportViewer1.LocalReport.SetParameters(p12);
                this.reportViewer1.LocalReport.SetParameters(p13);
                this.reportViewer1.LocalReport.SetParameters(p14);
                this.reportViewer1.LocalReport.SetParameters(p15);
                this.reportViewer1.LocalReport.SetParameters(p16);
                this.reportViewer1.LocalReport.SetParameters(p17);
                this.reportViewer1.LocalReport.SetParameters(p18);
                this.reportViewer1.LocalReport.SetParameters(p19);
                this.reportViewer1.LocalReport.SetParameters(p20);
                this.reportViewer1.LocalReport.SetParameters(p21);
                this.reportViewer1.LocalReport.SetParameters(p22);
                this.reportViewer1.LocalReport.SetParameters(p23);
                this.reportViewer1.LocalReport.SetParameters(p24);
                this.reportViewer1.LocalReport.SetParameters(p25);
                this.reportViewer1.LocalReport.SetParameters(p26);
                this.reportViewer1.LocalReport.SetParameters(p27);
                this.reportViewer1.LocalReport.SetParameters(p28);
                this.reportViewer1.LocalReport.SetParameters(p29);
                this.reportViewer1.LocalReport.SetParameters(p30);
                this.reportViewer1.LocalReport.SetParameters(p31);
                this.reportViewer1.LocalReport.SetParameters(p32);


                this.reportViewer1.RefreshReport();
            }
        }
    }
}
