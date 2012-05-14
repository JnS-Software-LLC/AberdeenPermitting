/*
 * Programmer:      John Reasor
 * Date:            5-14-2012
 * Description:     Class for Permit Information
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BuildingPermit
{
    class Permit
    {
        private string myPermitID;
        private DateTime mypermitDate;
        private string myInspectorID;
        private string myparcelID;
        private string myFeeTotal;
        private int myContactID;
        private string myBuildingID;
        private string myNotes;

        public string notes
        {
            get { return myNotes; }
            set { myNotes = value; }
        }
        
        public string buildingID
        {
            get { return myBuildingID; }
            set { myBuildingID = value; }
        }
        
        public int contactID
        {
            get { return myContactID; }
            set { myContactID = value; }
        }
        
        public string feeTotal
        {
            get { return myFeeTotal; }
            set { myFeeTotal = value; }
        }
        
        public string parcelID
        {
            get { return myparcelID; }
            set { myparcelID = value; }
        }
        
        public string inspectorID
        {
            get { return myInspectorID; }
            set { myInspectorID = value; }
        }
        

        public DateTime permitDate
        {
            get { return mypermitDate; }
            set { mypermitDate = value; }
        }
        
        public string permitID
        {
            get { return myPermitID; }
            set { myPermitID = value; }
        }
        
        public void save(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand spCmd;
                    spCmd = new SqlCommand("AU_Permit", con);
                    spCmd.CommandType = CommandType.StoredProcedure;

                    spCmd.Parameters.Add("@in_PermitID", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_PermitDate", SqlDbType.DateTime);
                    spCmd.Parameters.Add("@in_InspectorID", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_ParcelID", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_FeeTotal", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_ContactID", SqlDbType.Int);
                    spCmd.Parameters.Add("@in_BuildingID", SqlDbType.VarChar);
                    spCmd.Parameters.Add("@in_Notes", SqlDbType.VarChar);

                  

                    spCmd.Prepare();

                    spCmd.Parameters["@in_PermitID"].Value = this.permitID.ToString();
                    spCmd.Parameters["@in_PermitDate"].Value = this.permitDate.ToString();
                    spCmd.Parameters["@in_InspectorID"].Value = this.inspectorID.ToString();
                    spCmd.Parameters["@in_ParcelID"].Value = this.parcelID.ToString();
                    spCmd.Parameters["@in_FeeTotal"].Value = this.feeTotal.ToString();
                    spCmd.Parameters["@in_ContactID"].Value = this.contactID;
                    spCmd.Parameters["@in_BuildingID"].Value = this.buildingID.ToString();
                    spCmd.Parameters["@in_Notes"].Value = this.notes.ToString();
                   



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
        public void load(string conStr)
        {

        }
    }
}
