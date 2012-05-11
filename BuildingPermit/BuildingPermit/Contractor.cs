/*
 * Programmer:      John Reasor
 * Date:            5-9-2012
 * Description:     Class for Contractors Information, extences contact
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace BuildingPermit
{
    class Contractor : Contact
    {
        /// <summary>
        /// additional fields for contractors
        /// </summary>
        private string myAberdeenLC;
        private string myType;
        private string myLicenseNumber;


        /// <summary>
        /// contractors license number
        /// </summary>
        public string licenseNumber
        {
            get { return myLicenseNumber; }
            set { myLicenseNumber = value; }
        }

        /// <summary>
        /// contractors type, General, eletrical, mechanicial or plumbing
        /// </summary>
        public string type
        {
            get { return myType; }
            set { myType = value; }
        }

        /// <summary>
        /// Aberdeen Business License
        /// </summary>
        public string aberdeenLC
        {
            get { return myAberdeenLC; }
            set { myAberdeenLC = value; }
        }


        public Contractor()
        {

        }

        /// <summary>
        /// Save data to satabase from class
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
                    contactCount = (int)sqlReader["contactCount"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlReader.Close();
                }

                query = String.Format("SELECT count(*) FROM contact WHERE CompName = " + companyName + ";");

                com = new SqlCommand(query, con);
                con.Open();
                sqlReader = com.ExecuteReader();
                try
                {
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

                if (exist)
                {
                    try
                    {
                        con.Open();
                        SqlCommand spCmd;
                        spCmd = new SqlCommand("AU_Contractors", con);
                        spCmd.CommandType = CommandType.StoredProcedure;


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
                        spCmd.Parameters.Add("@in_LicenseExpDate", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Type", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_LicenseNumber", SqlDbType.VarChar);

                        spCmd.Prepare();


                        spCmd.Parameters["@in_CompName"].Value = this.companyName;
                        spCmd.Parameters["@in_Fname"].Value = this.firstName;
                        spCmd.Parameters["@in_Lname"].Value = this.lastName;
                        spCmd.Parameters["@in_FirstPhone"].Value = this.firstPhone;
                        spCmd.Parameters["@in_SecondPhone"].Value = this.secondPhone;
                        spCmd.Parameters["@in_Address"].Value = this.streetNumber + " " + this.streetName + " " + this.streetName2;
                        spCmd.Parameters["@in_City"].Value = this.city;
                        spCmd.Parameters["@in_State"].Value = this.state;
                        spCmd.Parameters["@in_Zip"].Value = this.zip;
                        spCmd.Parameters["@in_Email"].Value = this.email;
                        spCmd.Parameters["@in_AberdeenLC"].Value = this.aberdeenLC;
                        spCmd.Parameters["@in_LicenseExpDate"].Value = this.licenseExpDate;
                        spCmd.Parameters["@in_Type"].Value = this.type;
                        spCmd.Parameters["@in_LicenseNumber"].Value = this.licenseNumber;


                        SqlDataReader RDR = spCmd.ExecuteReader();
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
                        spCmd.Parameters.Add("@in_LicenseExpDate", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_Type", SqlDbType.VarChar);
                        spCmd.Parameters.Add("@in_LicenseNumber", SqlDbType.VarChar);

                        spCmd.Prepare();


                        spCmd.Parameters["@in_ContractorID"].Value = this.companyName;
                        spCmd.Parameters["@in_CompName"].Value = this.companyName;
                        spCmd.Parameters["@in_Fname"].Value = this.firstName;
                        spCmd.Parameters["@in_Lname"].Value = this.lastName;
                        spCmd.Parameters["@in_FirstPhone"].Value = this.firstPhone;
                        spCmd.Parameters["@in_SecondPhone"].Value = this.secondPhone;
                        spCmd.Parameters["@in_Address"].Value = this.streetNumber + " " + this.streetName + " " + this.streetName2;
                        spCmd.Parameters["@in_City"].Value = this.city;
                        spCmd.Parameters["@in_State"].Value = this.state;
                        spCmd.Parameters["@in_Zip"].Value = this.zip;
                        spCmd.Parameters["@in_Email"].Value = this.email;
                        spCmd.Parameters["@in_AberdeenLC"].Value = this.aberdeenLC;
                        spCmd.Parameters["@in_LicenseExpDate"].Value = this.licenseExpDate;
                        spCmd.Parameters["@in_Type"].Value = this.type;
                        spCmd.Parameters["@in_LicenseNumber"].Value = this.licenseNumber;

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

        /// <summary>
        /// load data from database to class
        /// </summary>
        /// <param name="conStr"></param>
        public void load(string conStr)
        {

        }
    }
}