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
        int MouseX = 0, MouseY = 0;
        int MouseInX, MouseInY;
        bool MousePressed = false;
        
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
            try
            {
                int rowIndex = dgvBlocked.CurrentCell.RowIndex;
                if (rowIndex >= 0)
                {
                    Proxy.RemoveWebsite(rowIndex);
                }
                RefreshList();
            }
            catch
            {
                MessageBox.Show("Vælg en hjemmeside før du kan fjerne den");
            }
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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                MouseX = MousePosition.X - MouseInX;
                MouseY = MousePosition.Y - MouseInY;

                this.SetDesktopLocation(MouseX, MouseY);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Proxy.StartProxyListener();
            }else if (!checkBox1.Checked)
            {
                Proxy.StopProxyListener();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            MousePressed = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseInX = MousePosition.X - Bounds.X;
            MouseInY = MousePosition.Y - Bounds.Y;
            MousePressed = true;
        }
    }
}
