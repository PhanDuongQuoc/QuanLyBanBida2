using QuanLyBanBida.DAO;
using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBida
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            Table();
        }

        #region Method
        void Table()
        {
            List<Table> tableList = TableDAO.Instance.TableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;

                switch (item.Status)
                {
                    case "Trong":
                        btn.BackColor = Color.White;
                        break;
                    default: btn.BackColor = Color.GreenYellow;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }
        #endregion

        #region Events
        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dangxuat = MessageBox.Show("bạn có muốn dăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dangxuat == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
        #endregion

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
