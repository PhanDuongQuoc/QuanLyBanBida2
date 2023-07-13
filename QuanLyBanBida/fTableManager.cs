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
using static System.Windows.Forms.ListViewItem;

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
                btn.Click += Btn_Click;
                btn.Tag= item;
                switch (item.Status)
                {
                    case "Trong":
                        btn.BackColor = Color.White;
                        /*btn.Image = Properties.Resources;*/
                        break;
                    case "Có Người":
                        btn.BackColor = Color.DarkRed;
                       /* btn.Image = Properties.Resources.TrongIcon;*/
                        break;
                    case "Đặt bàn": btn.BackColor = Color.GreenYellow;
                        /*btn.Image = Properties.Resources.TrongIcon;*/
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<Mennu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            foreach(Mennu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                lsvBill.Items.Add(lsvItem);
            }

        }

        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowBill(tableID);
        }
        #endregion
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

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }
    }
}
