﻿/*
 * Programmer:      John Reasor
 * Date:            3-14-2012
 * Description:     Class for Building Information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


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

    public Boolean basementExist
    {
        get { return myBasementBool; }
        set { myBasementBool = value; }
    }
    

    public string dimensions {
        get { return myDimensions; }
        set { myDimensions = value;  }
    
    }
    public int permitId {
        get { return myPermitID; }
        set { myPermitID = value;  } 
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

    public void load(string conStr, string where) {
        string query = "Select TypeOfConst, estCostOfConst, Dimensions, TotalSF,  heatedsf, PorchSF, numberOfstories, DeckSF, garageSF, BasementSF, basement from Building WHERE " + where;
        using (SqlConnection connection = new SqlConnection(conStr))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader RDR = command.ExecuteReader();
            try
            {
                if (RDR.HasRows) {
                    while (RDR.Read())
                    {
                        this.myBuildingType = (string)RDR["TypeOfConst"];
                        this.myEstimatedCost = (string)RDR["estCostOfConst"];
                        this.myDimensions = (string)RDR["Dimensions"];
                        this.myTotalSF = (string)RDR["TotalSF"];
                        this.myHeatedSF = (string)RDR["heatedsf"];
                        this.myPorchSF = (string)RDR["PorchSF"];
                        this.myNumStories = (string)RDR["numberOfstories"];
                        this.myDeckSF = (string)RDR["DeckSF"];
                        this.myGarageSF = (string)RDR["garageSF"];
                        this.myBasementSF = (string)RDR["BasementSF"];
                        this.myBasementBool = (bool)RDR["basement"]; 


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RDR.Close();
            }
        }
    }

    public void save(string conStr)
    {
     
        string query = String.Format("Insert Into Building " +
            " (TypeOfConst, estCostOfConst, Dimensions, TotalSF," +
            " heatedsf, PorchSF, numberOfstories, DeckSF, garageSF, BasementSF,basement, permitID)" +
            " Values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10},{11} ); ",
            this.myBuildingType, this.myEstimatedCost, this.myDimensions, Convert.ToInt16(this.myTotalSF),
            Convert.ToInt16(this.myHeatedSF), this.myPorchSF, this.myNumStories, this.myDeckSF, this.myGarageSF,
            this.myBasementSF,this.myBasementBool, this.myPermitID);

        using (SqlConnection connection = new SqlConnection(conStr))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            
            try
            {
                SqlDataReader sqlReader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //sqlReader.Close();
            }
        }
    }

}

