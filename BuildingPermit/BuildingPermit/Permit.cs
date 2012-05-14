/*
 * Programmer:      John Reasor
 * Date:            5-14-2012
 * Description:     Class for Permit Information
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        }
        public void load(string conStr)
        {

        }
    }
}
