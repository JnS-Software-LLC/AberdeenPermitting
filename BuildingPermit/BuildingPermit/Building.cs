﻿/*
 * Programmer:      John Reasor
 * Date:            3-14-2012
 * Description:     Class for Building Information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


public class Building
{
    /// <summary>
    /// private variables for building class
    /// </summary>
    private string myBuildingType;
    private string myEstimatedCost;
    private string myTotalSF;
    private string myHeatedSF;
    private string myPorchSF;
    private string myNumStories;
    private string myDeckSF;
    private string myGarageSF;
    private string myBasementSF;
    private string myDimensions;
    private int myPermitID;
    private Boolean myBasementBool;
    private string myBuildingID;
    private string myPorpsedUse;
    private bool myInstallInstulation;
    private bool myPrivateWell;
    private bool myTownSewer;
    private bool myTownWater;
    private bool mymySeptImprovement;

    public bool septImprovement
    {
        get { return mymySeptImprovement; }
        set { mymySeptImprovement = value; }
    }

    public bool townWater
    {
        get { return myTownWater; }
        set { myTownWater = value; }
    }

    public bool townSewer
    {
        get { return myTownSewer; }
        set { myTownSewer = value; }
    }

    public bool privateWell
    {
        get { return myPrivateWell; }
        set { myPrivateWell = value; }
    }

    public bool installInstalation
    {
        get { return myInstallInstulation; }
        set { myInstallInstulation = value; }
    }


    public string proposedUse
    {
        get { return myPorpsedUse; }
        set { myPorpsedUse = value; }
    }

    public string buildingID
    {
        get { return myBuildingID; }
        set { myBuildingID = value; }
    }

    public Boolean basementExist
    {
        get { return myBasementBool; }
        set { myBasementBool = value; }
    }


    public string dimensions
    {
        get { return myDimensions; }
        set { myDimensions = value; }

    }
    public int permitId
    {
        get { return myPermitID; }
        set { myPermitID = value; }
    }
    /// <summary>
    /// Basement Sf Property
    /// </summary>
    /// 
    public string basementSF
    {
        get { return myBasementSF; }

        set
        {

            if (value == null || value == "")
            {

            }
            else
            {
                if (isInt(value))
                {
                    myBasementSF = value.Trim();
                    myBasementBool = true;
                }
                else
                {
                    MessageBox.Show("Basement Square Feet must be a number");
                }
            }
        }
    }

    /// <summary>
    /// Garage Sf Property
    /// </summary>
    public string garageSF
    {
        get { return myGarageSF; }
        set
        {
            if (value == null || value == "")
            {

            }
            else
            {
                if (isInt(value))
                {
                    myGarageSF = value;
                }
                else
                {
                    MessageBox.Show("Garage Square Feet must be a number");
                }
            }
        }
    }

    /// <summary>
    /// Deck Sf Property
    /// </summary>
    public string deckSF
    {
        get { return myDeckSF; }

        set
        {
            if (value == null || value == "")
            {

            }
            else
            {
                if (isInt(value))
                {
                    myDeckSF = value;
                }
                else
                {
                    MessageBox.Show("Deck Square Feet must be a number");
                }
            }
        }
    }
    /// <summary>
    /// Number of stories
    /// </summary>
    public string numStories
    {
        get { return myNumStories; }

        set
        {
            if (value == null || value == "")
            {

                MessageBox.Show("Number of stories is a required field.");
            }
            else
            {
                if (isInt(value))
                {
                    myNumStories = value;
                }
                else
                {
                    MessageBox.Show("Number of stories must be a number");
                }
            }
        }
    }

    /// <summary>
    /// Porch Sf Property
    /// </summary>
    public string porchSF
    {
        get { return myPorchSF; }

        set
        {
            if (value == null || value == "")
            {

            }
            else
            {
                if (isInt(value))
                {
                    myPorchSF = value;
                }
                else
                {
                    MessageBox.Show("Porch Square Feet must be a number");
                }
            }

        }
    }

    /// <summary>
    /// Heated SF Property
    /// </summary>
    public string heatedSF
    {
        get { return myHeatedSF; }

        set
        {
            if (value == null || value == "")
            {
                MessageBox.Show("Heated square feet is a required field.");
            }
            else
            {
                if (isInt(value))
                {
                    myHeatedSF = value;
                }
                else
                {
                    MessageBox.Show("Heated Square Feet must be a number");
                }
            }
        }
    }

    /// <summary>
    /// Total SF Property
    /// </summary>
    public string totalSF
    {
        get { return myTotalSF; }
        set
        {

            if (value == null || value == "")
            {
                MessageBox.Show("Total Square Feet is a required field.");

            }
            else
            {

                if (isInt(value))
                {
                    myTotalSF = value;

                }
                else
                {
                    MessageBox.Show("Total Square Feet and must be a number");
                }
            }

        }
    }

    /// <summary>
    /// Set Estimating Cost Property
    /// </summary>
    public string estimatedCost
    {
        get { return myEstimatedCost; }

        set
        {
            if (value == null || value == "")
            {
                MessageBox.Show("Estimated cost is a required field.");
            }
            else
            {
                if (isDouble(value))
                {
                    myEstimatedCost = value;
                }
                else
                {
                    MessageBox.Show("Estimated cost must be a dollar amount, numbers only.");
                }
            }

        }
    }

    /// <summary>
    /// Building Type Property
    /// </summary>
    public string buildingType
    {
        get { return myBuildingType; }
        set { myBuildingType = value; }
    }

    /// <summary>
    /// constructor
    /// </summary>
    public Building()
    {

    }

    /// <summary>
    /// validation for input int's
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool isInt(string value)
    {
        int Num;

        return int.TryParse(value, out Num);
    }
    /// <summary>
    /// validation for input double's
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool isDouble(string value)
    {
        double Num;

        return double.TryParse(value, out Num);
    }



    public void save(string conStr)
    {



        using (SqlConnection con = new SqlConnection(conStr))
        {
            try
            {
                con.Open();
                SqlCommand spCmd;
                spCmd = new SqlCommand("AU_Building", con);
                spCmd.CommandType = CommandType.StoredProcedure;
                spCmd.Parameters.Add("@in_BuildingID", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_TypeOfConst", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_ProposedUse", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_Dimensions", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_HeatedSF", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_NumberOfStories", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_GarageSF", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_Basement", SqlDbType.Bit);
                spCmd.Parameters.Add("@in_PorchSF", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_DeckSF", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_InstallINsulation", SqlDbType.Bit);
                spCmd.Parameters.Add("@in_EstCostOfConst", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_privateWell", SqlDbType.Bit);
                spCmd.Parameters.Add("@in_TownSewer", SqlDbType.Bit);
                spCmd.Parameters.Add("@in_townWater", SqlDbType.Bit);
                spCmd.Parameters.Add("@in_SeptImprovePermit", SqlDbType.Bit);
                spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_TotalSF", SqlDbType.VarChar);
                spCmd.Parameters.Add("@in_BasementSF", SqlDbType.VarChar);

                spCmd.Prepare();
                spCmd.Parameters["@in_BuildingID"].Value = this.buildingID;
                spCmd.Parameters["@in_TypeOFConst"].Value = this.buildingType;
                spCmd.Parameters["@in_ProposedUse"].Value = this.proposedUse;
                spCmd.Parameters["@in_Dimensions"].Value = this.dimensions;
                spCmd.Parameters["@in_HeatedSF"].Value = this.heatedSF;
                spCmd.Parameters["@in_NumberOfStories"].Value = this.numStories;
                spCmd.Parameters["@in_GarageSF"].Value = this.garageSF;
                spCmd.Parameters["@in_Basement"].Value = this.basementExist;
                spCmd.Parameters["@in_PorchSF"].Value = this.porchSF;
                spCmd.Parameters["@in-DeckSF"].Value = this.deckSF;
                spCmd.Parameters["@in_InstallINsulation"].Value = this.installInstalation;
                spCmd.Parameters["@in_EstCostOfConst"].Value = this.estimatedCost;
                spCmd.Parameters["@in_privateWell"].Value = this.privateWell;
                spCmd.Parameters["@in_TownSewer"].Value = this.townSewer;
                spCmd.Parameters["@in_townWater"].Value = this.townWater;
                spCmd.Parameters["@in_SepImproveMentPermit"].Value = this.septImprovement;
                spCmd.Parameters["@in_PermitID"].Value = this.permitId;
                spCmd.Parameters["@in_TotalSF"].Value = this.totalSF;
                spCmd.Parameters["@in_BasementSF"].Value = this.basementSF;

                SqlDataReader RDR = spCmd.ExecuteReader();

                RDR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
    

}

