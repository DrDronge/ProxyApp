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
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();
            RefreshList();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void RefreshList()
        {
            dgvBlocked.DataSource = null;
            dgvBlocked.Rows.Clear();
            List<WebsiteDTO> list = Proxy.GetBlockedSites();
            dgvBlocked.DataSource = list;
            dgvBlocked.ClearSelection();
            dgvBlocked.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvBlocked.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
            Proxy.RemoveWebsite(rowIndex);
            }
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showAddDialog();
            RefreshList();
        }
        private void showAddDialog()
        {
            Form AddDialog = new AddBlockedForm();
            AddDialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
