using Econtact.eContactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }

        contactClass c = new contactClass();

        private void txtBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get the value form the input fields
            c.FirstName = txtBoxFirstName.Text;
            c.LastName = txtBoxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;

            // Inserting Data into Database uing the method
            bool success = c.Insert(c);
            
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("New Contact Successfully Inserted");

                // Clear the all inputs fields
                Clear();
            }
            else
            {
                //Failed to Add Contact
                MessageBox.Show("Failed to add New Contact. Try Again.");
            }
            // Load Data on Data Grid View
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void txtBoxContactID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            // Load Data on Data Grid View
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to Clear Fields
        public void Clear()
        {
            txtBoxContactID.Text = "";
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxContactNumber.Text = "";
            txtBoxAddress.Text = "";
            cmbGender.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the Data from textBoxes
            c.ContactID = int.Parse(txtBoxContactID.Text);
            c.FirstName = txtBoxFirstName.Text;
            c.LastName = txtBoxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;

            // Update Data in Database
            bool success = c.Update(c);
            if(success==true)
            {
                // Updated Successfully
                MessageBox.Show("Contact has been successfully Updated.");
                // Load Data on Data Grid View
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                // Method to Clear Fields
                Clear();
            }
            else
            {
                // Failed to Update
                MessageBox.Show("Failed to Update Contact.Try Again.");
            }
            
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the Data From Data Grid View and Load it to the textboxes respectively 
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            txtBoxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the all inputs fields
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the Contact ID fromt the Application 
            c.ContactID = Convert.ToInt32(txtBoxContactID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                // Successfully Deleted
                MessageBox.Show("Contact successfully deleted.");
                // Refresh Data GridView
                // Load Data on Data GRidview
                DataTable dt = c.Select(); 
                dgvContactList.DataSource = dt;
                // Clear the all inputs fields
                Clear();
            }
            else
            {
                // Failed to Delete
                MessageBox.Show("Failed to Delete Dontact. Try Again.");
            }
        }
    }
}
