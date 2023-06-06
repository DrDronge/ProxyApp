using ProxyApp.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyApp
{
    public partial class AddBlockedForm : Form
    {
        public AddBlockedForm()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBlockedCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBlockedAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(domainNameTextBox.Text) && !String.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                Proxy.AddNewWebsite(domainNameTextBox.Text, categoryTextBox.Text);

            }
            else if (!String.IsNullOrWhiteSpace(domainNameTextBox.Text) && String.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                Proxy.AddNewWebsite(domainNameTextBox.Text);
            }
            else
            {
                throw new Exception("No domain name inserted");
            }
            this.Close();

        }
    }
}
