/*
 * Programmer:      John Reasor
 * Date:            5-11-2012
 * Description:     Class for Parcel Information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingPermit
{
    class Parcel
    {
        /// <summary>
        /// clas variables
        /// </summary>
        private string myParcelID;
        private string myAddress;
        private string myCity;
        private string myState;
        private string myZip;
        private string myDeedBook;
        private string myDeedPage;
        private int myLotNum;
        private string mySize;
        private decimal myValue;
        private string myZoningDist;
        private string myTaxAcre;
        private string myDeedAcre;
        private int myContactID;
        private string myLRK;

        /// <summary>
        /// LRK number 
        /// </summary>
        public string lrk
        {
            get { return myLRK; }
            set { myLRK = value; }
        }
        
        /// <summary>
        /// Contact ID number for Parcel Owner if new will be number of existing Owners plus one
        /// </summary>
        public int contactID
        {
            get { return myContactID; }
            set { myContactID = value; }
        }
        
       /// <summary>
       /// DeedAcre
       /// </summary>
        public string deedAcre
        {
            get { return myDeedAcre; }
            set { myDeedAcre = value; }
        }
        
        /// <summary>
        /// Tax Acres
        /// </summary>
        public string taxAcre
        {
            get { return myTaxAcre; }
            set { myTaxAcre = value; }
        }
        

        /// <summary>
        /// Zoining Dist
        /// </summary>
        public string zoningDist
        {
            get { return myZoningDist; }
            set { myZoningDist = value; }
        }
        
        /// <summary>
        /// Total value of construction
        /// </summary>
        public decimal value
        {
            get { return myValue; }
            set { myValue = value; }
        }
        
        /// <summary>
        /// general size of construction
        /// </summary>
        public string size
        {
            get { return mySize; }
            set { mySize = value; }
        }
        
        /// <summary>
        /// Lot Number
        /// </summary>
        public int lotNum
        {
            get { return myLotNum; }
            set { myLotNum = value; }
        }
        
        /// <summary>
        /// Recorded Deed Page
        /// </summary>
        public string deedPage
        {
            get { return myDeedPage; }
            set { myDeedPage = value; }
        }
        
        /// <summary>
        /// recored Deed Book
        /// </summary>
        public string deedBook
        {
            get { return myDeedBook; }
            set { myDeedBook = value; }
        }
        
        /// <summary>
        /// Parcel Zip
        /// </summary>
        public string zip
        {
            get { return myZip; }
            set { myZip = value; }
        }
        
        /// <summary>
        /// Parcel State
        /// </summary>
        public string state
        {
            get { return myState; }
            set { myState = value; }
        }
        
        /// <summary>
        /// Parcel City
        /// </summary>
        public string city
        {
            get { return myCity; }
            set { myCity = value; }
        }
        
        /// <summary>
        /// Number and Street Address or Parcel Description
        /// </summary>
        public string address
        {
            get { return myAddress; }
            set { myAddress = value; }
        }
        
        /// <summary>
        /// Parcel ID if new will be number of existing Parcel plus one
        /// </summary>
        public string parcelID
        {
            get { return myParcelID; }
            set { myParcelID = value; }
        }
        
        /// <summary>
        /// save data fro parcel class to database
        /// </summary>
        /// <param name="conStr"></param>
        public void save(string conStr)
        {

        }
        /// <summary>
        /// load data from databse to parcel class
        /// </summary>
        /// <param name="conStr"></param>
        public void load(string conStr)
        {

        }
    }
}
