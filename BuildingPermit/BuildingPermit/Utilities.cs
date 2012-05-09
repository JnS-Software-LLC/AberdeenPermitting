﻿/*
 * Programmer:      Deivydas Sunelaitis
 * Date:            3-20-2012
 * Description:     HEATING/AIR-CONDITIONING/MECHANICAL/PLUMBING/ELECTRICAL
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


public class Utilities
{
    //  HEATING/AIR-CONDITIONING/MECHANICAL
    private Boolean myGasLine;
    private Boolean myDuctWork;
    private string myNumSys;
    //  PLUMBING
    private string myTotNumBathrooms;
    private string myNumWaterClosets;
    private string myNumDishWasher;
    private string myNumWaterHeater;
    private string myTotNumFixtures;
    private string myNumShowers;
    private string myNumTubs;
    private string myNumWetBar;
    private string myNumSinks;
    private string myNumClothesWasher;
    private string myNumSpa;
    // ELECTRICAL
    private string myNumAmps;
    private Boolean myTempPole;
    private Boolean myIsIrrigated;
    private string myBuildingID;
    private string myNumDiscon;
    private string myEletricalID;
    private string myMechID;
    private string mySystemType;
    private string myTons;

    public string tons
    {
        get { return myTons; }
        set { myTons = value; }
    }

    public string systemType
    {
        get { return mySystemType; }
        set { mySystemType = value; }
    }

    public string mechID
    {
        get { return myMechID; }
        set { myMechID = value; }
    }

    public string eletricalID
    {
        get { return myEletricalID; }
        set { myEletricalID = value; }
    }


    public string discon
    {
        get { return myNumDiscon; }
        set { myNumDiscon = value; }
    }

    public string buildingID
    {
        get { return myBuildingID; }
        set { myBuildingID = value; }
    }

    public Boolean irrigation
    {
        get { return myIsIrrigated; }
        set { myIsIrrigated = value; }
    }

    //  HEATING/AIR-CONDITIONING/MECHANICAL
    /// <summary>
    /// gas line variable
    /// </summary>
    public Boolean gasLine
    {
        set { myGasLine = value; }
        get { return myGasLine; }
    }
    /// <summary>
    /// duck work variable
    /// </summary>
    public Boolean ductWork
    {
        get { return myDuctWork; }
        set { myDuctWork = value; }
    }

    /// <summary>
    /// number of air conditioning systems set
    /// </summary>
    public string setNumSys
    {
        get { return myNumSys; }

        set
        {

            if (value == null)
            {
                MessageBox.Show("Number of systems is needed for the permit fee calculation.");
            }
            else
            {

                if (isInt(value))
                {
                    myNumSys = value;
                }

                else
                {
                    MessageBox.Show("Number of systems must be a number.");
                }
            }
        }
    }


    //  PLUMBING
    /// <summary>
    /// number of bathrooms
    /// </summary>
    public string numBathrooms
    {
        get { return myTotNumBathrooms; }
        set { myTotNumBathrooms = value; }
    }
    /// <summary>
    /// number of water closets
    /// </summary>
    public string numWaterClosets
    {
        get { return myNumWaterClosets; }
        set { myNumWaterClosets = value; }
    }
    /// <summary>
    /// number of dish washers
    /// </summary>
    public string numDishWasher
    {
        get { return myNumDishWasher; }
        set { myNumDishWasher = value; }
    }
    /// <summary>
    /// number of water heaters
    /// </summary>
    public string numWaterHeater
    {
        get { return myNumWaterHeater; }
        set { myNumWaterHeater = value; }
    }

    /// <summary>
    /// number of total fixtures used in caculation set
    /// </summary>
    public string numFixtures
    {
        get { return myTotNumFixtures; }

        set
        {

            if (value == null)
            {
                MessageBox.Show("Number of fixtures are need for the permit fee calculation.");
            }
            else
            {


                if (isInt(value))
                {
                    myTotNumFixtures = value;
                }
                else
                {
                    MessageBox.Show("Number of fixtures must be a numbe.r");
                }
            }
        }
    }
    /// <summary>
    /// number of showers
    /// </summary>
    public string numShowers
    {
        get { return myNumShowers; }
        set { myNumShowers = value; }
    }
    /// <summary>
    /// number of tubs
    /// </summary>
    public string numTub
    {
        get { return myNumTubs; }
        set { myNumTubs = value; }
    }
    /// <summary>
    /// numbe rof wet bar small sink with frig.
    /// </summary>
    public string numWetBar
    {
        get { return myNumWetBar; }
        set { myNumWetBar = value; }
    }

    /// <summary>
    /// number of sinks
    /// </summary>
    public string numSinks
    {
        get { return myNumSinks; }
        set { myNumSinks = value; }
    }

    /// <summary>
    /// number of clothswashers
    /// </summary>
    public string numClothesWasher
    {
        get { return myNumClothesWasher; }
        set { myNumClothesWasher = value; }
    }

    /// <summary>
    /// number of spa's
    /// </summary>
    public string numSpa
    {
        get { return myNumSpa; }
        set { myNumSpa = value; }
    }

    // ELECTRICAL
    /// <summary>
    /// number of Amp's
    /// </summary>
    public string numAmps
    {
        get { return myNumAmps; }
        set { myNumAmps = value; }

    }

    /// <summary>
    /// Temppole variable
    /// </summary>
    public Boolean tempPole
    {
        get { return myTempPole; }
        set { myTempPole = value; }
    }
    /// <summary>
    /// valadation for input int's
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool isInt(string value)
    {
        int Num;

        return int.TryParse(value, out Num);

    }
    public Utilities()
    {

    }
    public void load(string conStr, string where)
    {

    }
    public void save(string conStr)
    {


        using (SqlConnection con = new SqlConnection(conStr))
        {
            try
            {
                con.Open();
                SqlCommand spCmd = new SqlCommand("AU_Eletrical", con);
                spCmd.CommandType = CommandType.StoredProcedure;
                spCmd.Parameters.Add("@in_ContactID", SqlDbType.Int);

                spCmd.Prepare();

                spCmd.Parameters["@in_ContactID"].Value = (contactCount + 1);

                SqlDataReader RDR = spCmd.ExecuteReader();
                RDR.Close();

                con.Open();
                spCmd = new SqlCommand("AU_Mechanical", con);
                spCmd.CommandType = CommandType.StoredProcedure;
                spCmd.Parameters.Add("@in_ContactID", SqlDbType.Int);

                spCmd.Prepare();

                spCmd.Parameters["@in_ContactID"].Value = (contactCount + 1);

                RDR = spCmd.ExecuteReader();
                RDR.Close();

                con.Open();
               spCmd = new SqlCommand("AU_Plumbing", con);
                spCmd.CommandType = CommandType.StoredProcedure;
                spCmd.Parameters.Add("@in_ContactID", SqlDbType.Int);

                spCmd.Prepare();

                spCmd.Parameters["@in_ContactID"].Value = (contactCount + 1);

                RDR = spCmd.ExecuteReader();
                RDR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}