using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuildingPermit
{
    
    public partial class ContactInfo : Form
    {

       

        public ContactInfo()
        {
            InitializeComponent();
            

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            //string xml; 
           Contact contact = new Contact();

            contact.companyName = txtCompany.Text;
            contact.firstName = txtFName.Text;
            contact.middleName = txtMName.Text;
            contact.lastName = txtLName.Text;
            contact.liscence = txtLicense.Text;
            contact.phone = txtPhone.Text;
            contact.cell = txtCell.Text;
            contact.email = txtEmail.Text;
            contact.buildingLiscence = txtBuildingLicense.Text;
            contact.streetNumber = txtStreetNumber.Text; 
            contact.streetName = txtStreetName.Text;
            contact.type = txtType.Text;
            contact.streetName2 = txtStreetName2.Text;
            contact.city = txtCity.Text;
            contact.state = txtState.Text;
            contact.zip = txtZip.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"Contact.xml");
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(contact.GetType());
            x.Serialize(file, contact);
            file.Close();
=======
            string xml; 
            Contact Contact = new Contact();
            Contact.companyName = txtCompany.Text;
            Contact.firstName = txtFName.Text;
            Contact.middleName = txtMName.Text;
            Contact.lastName = txtLName.Text;
            Contact.liscence = txtLicense.Text;
            Contact.phone = txtPhone.Text;
            Contact.cell = txtCell.Text;
            Contact.email = txtEmail.Text;
            Contact.buildingLiscence = txtBuildingLicense.Text;
            Contact.streetNumber = txtStreetNumber.Text; 
            Contact.streetName = txtStreetName.Text;
            Contact.type = txtType.Text;
            Contact.streetName2 = txtStreetName2.Text;
            Contact.city = txtCity.Text;
            Contact.state = txtState.Text;
            Contact.zip = txtZip.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\xml.txt");
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Contact.GetType());
            x.Serialize(file, Contact); 
            
>>>>>>> 2f7005ec1fdd658cb40aa6de19e4dbb6d798924c
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
