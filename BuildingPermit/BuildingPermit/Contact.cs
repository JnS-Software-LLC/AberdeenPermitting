/*
 * Programmer:      Alan Ball
 * Date:            ??-??-????
 * Description:     Class for Contact Information
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;




public class Contact
{
    private string myCompanyName, myCompanyName2, myFirstName, myMiddleName, myLastName
       , myLicense, myFirstPhone, mySecondPhone, myEmail, myBuildingLicense, myStreetNumber, myStreetName
       , myType, myStreetName2, myCity, myState, myZip;

    private Boolean myPropOwner;
    private DateTime myLicenseExpDate;
    private string myPermitID;

    public string permitID
    {
        get { return myPermitID; }
        set { myPermitID = value; }
    }
    
   

    public DateTime licenseExpDate
    {
        get { return myLicenseExpDate; }
        set { myLicenseExpDate = value; }
    }

    public Boolean property
    {
        get { return myPropOwner; }
        set { myPropOwner = value; }
    }

    public string companyName
    {
        get { return myCompanyName; }
        set { myCompanyName = value; }
    }

    public string companyName2
    {
        get { return myCompanyName2; }
        set { myCompanyName2 = value; }
    }
    public string firstName
    {
        get { return myFirstName; }
        set { myFirstName = value; }
    }
    public string middleName
    {
        get { return myMiddleName; }
        set { myMiddleName = value; }
    }
    public string lastName
    {
        get { return myLastName; }
        set { myLastName = value; }
    }
    public string license
    {
        get { return myLicense; }
        set { myLicense = value; }
    }
    public string firstPhone
    {
        get { return myFirstPhone; }
        set { myFirstPhone = value; }
    }
    public string secondPhone
    {
        get { return mySecondPhone; }
        set { mySecondPhone = value; }
    }
    public string email
    {
        get { return myEmail; }
        set { myEmail = value; }
    }
    public string buildingLicense
    {
        get { return myBuildingLicense; }
        set { myBuildingLicense = value; }
    }
    public string streetNumber
    {
        get { return myStreetNumber; }
        set { myStreetNumber = value; }
    }
    public string streetName
    {
        get { return myStreetName; }
        set { myStreetName = value; }
    }
    public string streetName2
    {
        get { return myStreetName2; }
        set { myStreetName2 = value; }
    }
    public string city
    {
        get { return myCity; }
        set { myCity = value; }
    }
    public string state
    {
        get { return myState; }
        set { myState = value; }
    }
    public string type
    {
        get { return myType; }
        set { myType = value; }
    }
    public string zip
    {
        get { return myZip; }
        set { myZip = value; }
    }
    public Contact()
    {
    }

    /// <summary>
    /// Save Method for Contact Class
    /// </summary>
    /// <param name="conStr"></param>
    public void save(string conStr)
    {
        int contactCount = 0;
        Boolean exist = false;

        using (SqlConnection con = new SqlConnection(conStr))
        {

            string query = String.Format("SELECT count(ContactID) as 'contactCount' FROM contact; ");

            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sqlReader = com.ExecuteReader();

            try
            {
                while (sqlReader.Read())
                {
                    if (sqlReader.HasRows)
                    {
                        contactCount = (int)sqlReader["contactCount"];
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlReader.Close();
            }

            con.Close();

           
            try
            {

                query = String.Format("SELECT count(*) FROM contact WHERE CompName = '" + this.companyName.ToString() + "';");

                con.Open();

                com = new SqlCommand(query, con);
                
                sqlReader = com.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    exist = true;
                }
                else
                {
                    exist = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlReader.Close();
            }

            con.Close();

            if (exist)
            {
                try
                {
                    con.Open();
                    SqlCommand spCmd;
                    spCmd = new SqlCommand("AU_Contact", con);
                    spCmd.CommandType = CommandType.StoredProcedure;


                    spCmd.Parameters.Add("@in_CompName", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_CompName2", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Fname", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Lname", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_FirstPhone", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_SecondPhone", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Address", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_City", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_State", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Zip", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Email", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_PropOwner", SqlDbType.Bit);

                    spCmd.Prepare();


                    spCmd.Parameters["@in_CompName"].Value = this.companyName.ToString();
                    spCmd.Parameters["@in_CompName2"].Value = null;
                    spCmd.Parameters["@in_Fname"].Value = this.firstName.ToString();
                    spCmd.Parameters["@in_Lname"].Value = this.lastName.ToString();
                    spCmd.Parameters["@in_FirstPhone"].Value = this.firstPhone.ToString();
                    spCmd.Parameters["@in_SecondPhone"].Value = this.secondPhone.ToString();
                    spCmd.Parameters["@in_Address"].Value = this.streetNumber.ToString() + " " + this.streetName.ToString() + " " + this.streetName2.ToString();
                    spCmd.Parameters["@in_City"].Value = this.city.ToString();
                    spCmd.Parameters["@in_State"].Value = this.state.ToString();
                    spCmd.Parameters["@in_Zip"].Value = this.zip.ToString();
                    spCmd.Parameters["@in_Email"].Value = this.email.ToString();
                    spCmd.Parameters["@in_PropOwner"].Value = this.property.ToString();

                    SqlDataReader RDR = spCmd.ExecuteReader();

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
                try
                {
                    con.Open();
                    SqlCommand spCmd;
                    spCmd = new SqlCommand("AU_Contact", con);
                    spCmd.CommandType = CommandType.StoredProcedure;

                    spCmd.Parameters.Add("@in_ContactID", SqlDbType.Int);
                    spCmd.Parameters.Add("@in_CompName", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_CompName2", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Fname", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Lname", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_FirstPhone", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_SecondPhone", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Address", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_City", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_State", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Zip", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Email", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_PropOwner", SqlDbType.Bit);

                    spCmd.Prepare();

                    spCmd.Parameters["@in_ContactID"].Value = (contactCount + 1);
                    spCmd.Parameters["@in_CompName"].Value = this.companyName.ToString();
                    spCmd.Parameters["@in_CompName2"].Value = this.companyName2.ToString();
                    spCmd.Parameters["@in_Fname"].Value = this.firstName.ToString();
                    spCmd.Parameters["@in_Lname"].Value = this.lastName.ToString();
                    spCmd.Parameters["@in_FirstPhone"].Value = this.firstPhone.ToString();
                    spCmd.Parameters["@in_SecondPhone"].Value = this.secondPhone.ToString();
                    spCmd.Parameters["@in_Address"].Value = this.streetNumber.ToString() + " " + this.streetName.ToString() + " " + this.streetName2.ToString();
                    spCmd.Parameters["@in_City"].Value = this.city.ToString();
                    spCmd.Parameters["@in_State"].Value = this.state.ToString();
                    spCmd.Parameters["@in_Zip"].Value = this.zip.ToString();
                    spCmd.Parameters["@in_Email"].Value = this.email.ToString();
                    spCmd.Parameters["@in_PropOwner"].Value = this.property.ToString();

                    SqlDataReader RDR = spCmd.ExecuteReader();

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

    /// <summary>
    /// load database to contact 
    /// </summary>
    /// <param name="conStr"></param>
    public void load(string conStr)
    {

    }


}

