using QuanLyBanBida.DAO;
using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            category_loai();
        }

        #region Method
        void Table()
        {
            flpTable.Controls.Clear();
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
                        btn.Image = Properties.Resources.ban;
                        break;
                    case "Có Người":
                        btn.BackColor = Color.DarkRed;
                        btn.Image = Properties.Resources.banconguoi;
                        break;
                    case "Đặt bàn": btn.BackColor = Color.GreenYellow;
                        btn.Image = Properties.Resources.bandat;
                        break;
                }
                flpTable.Controls.Add(btn);
                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                btn.Font = new Font("Time new roman", 7, FontStyle.Bold);

                // Căn giữa văn bản
                btn.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<Mennu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            double tongtien = 0;
            foreach(Mennu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                tongtien +=item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo usinglanguage=new CultureInfo("vi-VN");
            txttongtien.Text=tongtien.ToString("c",usinglanguage);
            Table();

        }

        #region Events
        //tác dụng: khi người dùn lick vào bàn nào thì bàn đó sẽ hiển thị tag của bàn đó 
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag=((sender as Button).Tag);
            ShowBill(tableID);
        }


        #endregion
        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dangxuat = MessageBox.Show("bạn có muốn dăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dangxuat == DialogResult.Yes) 
            {
                fLogin fLogin = new fLogin();
                fLogin.Show();
                this.Hide();
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

        void category_loai() 
        {
            List<Category> listcategory = CategoryDAO.Instance.Getlistcategory();
            cbCategory.DataSource= listcategory;
            cbCategory.DisplayMember = "name";
        }

        void listfoodcategoryid(int id) 
        {
            List<Food> listfood = FoodDAO.Instance.Getlistfood(id);
            cbfood.DataSource = listfood;
            cbfood.DisplayMember= "name";
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category select=cb.SelectedItem as Category;
            id=select.Id;

            listfoodcategoryid(id);
        }

        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            Table table=lsvBill.Tag as Table;
            
            int idbill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            int foodid = (cbfood.SelectedItem as Food).Id;
            int count=(int)nmFoodCount.Value;
            if (idbill == -1) 
            {
                BillDAO.Instance.addbill(table.ID);
                BillInfoDAO.Instance.addbillinfo(1, BillDAO.Instance.getmaxidbill(), foodid, count);
            }
            else
            {
                BillInfoDAO.Instance.addbillinfo(1,idbill, foodid, count);
            }

        }

        private void btn_Checkout_Click(object sender, EventArgs e)
        {
            Table table= lsvBill.Tag as Table;
            int idbill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nm_Discount.Value;
            if (idbill != -1)
            {
                if (MessageBox.Show("Bạn có muốn thanh toán hóa đơn:" + table.Name ,"Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) 
                {
                    BillDAO.Instance.kiemtrthanhtoan(idbill,discount);
                    ShowBill(table.ID);
                    
                    MessageBox.Show("bạn đã thanh toán thành công !", "Thông báo ", MessageBoxButtons.OK);
                    lsvBill.Items.Clear();
                    Table();

                }
            }
        }
    }
}
