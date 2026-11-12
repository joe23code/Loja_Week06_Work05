using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Week06_Work05
{
    public partial class UserProductListing : UserControl
    {
        public UserProductListing()
        {
            InitializeComponent();
        }

        string[] units = { "Piece", "Box", "Kilogram" };

        List<string> shopingList = new List<string>();
        private void UserProductListing_Load(object sender, EventArgs e)
        {
            cmbUnit.Items.AddRange(units);
            cmbUnit.SelectedIndex = 0;

            lbxItems.DataSource = shopingList;
        }
        private void updateGUI()
        {
            lbxItems.DataSource = null;
            lbxItems.DataSource = shopingList;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string item = txtDescription.Text;
            double amount = double.Parse(txtAmount.Text);
            string unit = cmbUnit.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(unit) && !string.IsNullOrEmpty(item) && !
                string.IsNullOrEmpty(amount.ToString()))
        {
                string row = $"{item}\t\t {amount} {unit}";
                shopingList.Add(row);
                updateGUI();

                MessageBox.Show("Item Added");
                txtAmount.Clear();
                txtDescription.Clear();
                cmbUnit.Refresh();
                txtDescription.Focus();



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbxItems.SelectedIndex;

            if (index == -1)
            {
                DialogResult deleteMessage = MessageBox.Show("Are you sure you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                MessageBox.Show(shopingList[index] + "deleted.");

                shopingList.RemoveAt(index);
                updateGUI();
            }
            else
            {
                lblPrompt.Text = "Please select an item to delete.";
                lblPrompt.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
