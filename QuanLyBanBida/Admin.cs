using Microsoft.SqlServer.Server;
using QuanLyBanBida.DAO;
using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBida
{
    public partial class fAdmin : Form
    {
        private string connect = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyQuanBidaFinal1;Integrated Security=True";

        public void viewlistaccount()
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            string query = "select DisplayName as[ Tên tài khoản ], UserName as[Tên người dùng], PassWord as[mật khẩu],Type as[Loại tài khoản] from Account ";
            SqlDataAdapter adpter = new SqlDataAdapter(query, sqlConnection);
            DataSet dt = new DataSet();
            adpter.Fill(dt, "Account");
            dtgv_Account.DataSource = dt.Tables["Account"];


        }

        public bool kiemtrathongtintaikhoan(string username)
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            string query = "select count(*) from Account where UserName=@username";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@username", username);
            sqlConnection.Open();
            int count = (int)command.ExecuteScalar();
            sqlConnection.Close();
            return count > 0;
        }

        public void addAcount(string DisplayName, string UserName, string PassWord, string Type)
        {
            if (kiemtrathongtintaikhoan(UserName))
            {
                MessageBox.Show("Tài khoản bạn muốn thêm hiện đã có !");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "insert into Account(DisplayName,UserName,PassWord,Type) values (@DisplayName,@UserName,@PassWord,@Type)";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@DisplayName", DisplayName);
                cmd.Parameters.Add("@UserName", UserName);
                cmd.Parameters.Add("@PassWord", PassWord);
                cmd.Parameters.Add("@Type", Type);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Thêm dữ iệu thành công !");
            }
        }

        public void deletedataccount(string username)
        {
            if (kiemtrathongtintaikhoan(username))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "delete from Account where UserName=@username";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Bạn xóa tài khoản thành công !");

            }
            else
            {
                MessageBox.Show("Tài khoản bàn muốn xóa không có !");
            }
        }

        public void updateaccount(string DisplayName, string UserName, string PassWord, string Type)
        {
            if (kiemtrathongtintaikhoan(UserName))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "update Account set DisplayName=@Displayname, PassWord=@PassWord,Type=@Type where UserName=@UserName";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@DisplayName", DisplayName);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", PassWord);
                cmd.Parameters.AddWithValue("@Type", Type);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Tài khoản bạn cập nhật thành công !");


            }
            else
            {
                MessageBox.Show("Tài khoàn bạn muốn cập nhật không có !");
            }
        }




        public void xemdulieukhachang()
        {
            SqlConnection conn = new SqlConnection(connect);
            string query = "select idcustomer as[Mã khách hàng],name as[Tên khách hàng],gender as[Giới tính],phonenumber as[Số điện thoại], daycheckin as[Ngày checkin],idcategorycustomer as[Loại khách hàng] from Customer";
            SqlDataAdapter adpater = new SqlDataAdapter(query, conn);
            DataSet dt = new DataSet();
            adpater.Fill(dt, "Customer");
            dtgv_InfoCustomer.DataSource = dt.Tables["Customer"];
        }
        public bool KiemTraTonTai(string idcustomer)
        {
            SqlConnection conn = new SqlConnection(connect);
            string query = "SELECT COUNT(*) FROM Customer WHERE idcustomer = @idcustomer";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idcustomer", idcustomer);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count > 0;
        }
        public void themkhachang(string idcustomer, string name, string gender, string phonenumber, string daycheckin, string idcatgorycustomer)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connect);
                string query = "insert into Customer(idcustomer,name,gender,phonenumber, daycheckin,idcategorycustomer) values(@idcustomer,@name,@gender,@phonenumber, @daycheckin,@idcategorycustomer)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@idcustomer", idcustomer);
                cmd.Parameters.Add("@name", name);
                cmd.Parameters.Add("@gender", gender);
                cmd.Parameters.Add("@phonenumber", phonenumber);
                cmd.Parameters.Add("@daycheckin", daycheckin);
                cmd.Parameters.Add("@idcategorycustomer", idcatgorycustomer);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Bạn đã thêm thành công !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã Khách hàng đã tồn tại");
            }
        }

        void deletecustomer(string idcustomer)
        {
            if (KiemTraTonTai(idcustomer))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "delete from Customer where idcustomer=@idcustomer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idcustomer", idcustomer);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Bạn đã xóa dữ liệu thành công !");
            }
            else
            {
                MessageBox.Show("Khách hàng bạn muốn xóa không tồn tại !");
            }
        }

        public void updatekhachanh(string idcustomer, string name, string gender, string phonenumber, string daycheckin, string idcategorycustomer)
        {
            if (KiemTraTonTai(idcustomer))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "update Customer set name=@name, gender=@gender,phonenumber=@phonenumber, daycheckin=@daycheckin,idcategorycustomer=@idcategorycustomer where idcustomer=@idcustomer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idcustomer", idcustomer);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@phonenumber", phonenumber);
                cmd.Parameters.AddWithValue("@daycheckin", daycheckin);
                cmd.Parameters.AddWithValue("@idcategorycustomer", idcategorycustomer);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Bạn đã cập nhật thành công !");




            }
            else
            {
                MessageBox.Show("Khách hàng bạn muốn cập nhật không tồn tại !");
            }
        }


        BindingSource foodList = new BindingSource();

        BindingSource accountList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        void LoadData()
        {
            dtgv_Food.DataSource = foodList;
            dtgv_Account.DataSource = accountList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpk_FromDate.Value, dtpk_ToDate.Value);
            LoadListFood();
        //    LoadAccount();
            LoadCategoryIntoCombobox(cb_Category);
            AddFoodBinding();
        //    AddAccountBinding();
        }

 /*       void AddAccountBinding()
        {
            txt_nameaccount.DataBindings.Clear();
            txt_DisplayName.DataBindings.Clear();
            txt_AccountType.DataBindings.Clear();
            txt_nameaccount.DataBindings.Add(new Binding("Text", dtgv_Account.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txt_DisplayName.DataBindings.Add(new Binding("Text", dtgv_Account.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txt_AccountType.DataBindings.Add(new Binding("Text", dtgv_Account.DataSource, "Type", true, DataSourceUpdateMode.Never));
     
        }*/

       /* void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }*/
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpk_FromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpk_ToDate.Value = dtpk_FromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgv_Bill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void AddFoodBinding()
        {
            txt_NameFood.DataBindings.Add(new Binding("Text", dtgv_Food.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txt_idFood.DataBindings.Add(new Binding("Text", dtgv_Food.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nm_Price.DataBindings.Add(new Binding("Value", dtgv_Food.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

      /*  void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
*//*            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang sử dụng");
                return;
            }*//*
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }*/
        #endregion

        #region events

        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            /*string userName = txt_nameaccount.Text;
            string displayName = txt_DisplayName.Text;
            int type = (int)nm_Price.Value;

            AddAccount(userName, displayName, type);*/
            if (string.IsNullOrEmpty(txt_DisplayName.Text) || string.IsNullOrEmpty(txt_nameaccount.Text) || string.IsNullOrEmpty(txtPasswordaccount.Text) || string.IsNullOrEmpty(txt_AccountType.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin !");
            }
            else
            {
                string displayname = txt_DisplayName.Text;
                string username = txt_nameaccount.Text;
                string password = txtPasswordaccount.Text;
                string type = int.Parse(txt_AccountType.Text).ToString();
                addAcount(displayname, username, password, type);
                viewlistaccount();
                txt_DisplayName.Text = "";
                txt_nameaccount.Text = "";
                txtPasswordaccount.Text = "";
                txt_AccountType.Text = "";
            }
        }

        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            /* string userName = txt_nameaccount.Text;

             DeleteAccount(userName);*/
            if (string.IsNullOrEmpty(txt_nameaccount.Text))
            {
                MessageBox.Show("Bạn vui lòng nhập thông tin tài khoản cần xóa !");
            }
            else
            {
                string username = txt_nameaccount.Text;
                deletedataccount(username);
                txt_DisplayName.Text = "";
                txt_nameaccount.Text = "";
                txtPasswordaccount.Text = "";
                txt_AccountType.Text = "";

                txt_nameaccount.Focus();
                viewlistaccount();
            }
        }

        private void btn_EditAccount_Click(object sender, EventArgs e)
        {
            /* string userName = txt_nameaccount.Text;
             string displayName = txt_DisplayName.Text;
             int type = (int)nm_Price.Value;

             EditAccount(userName, displayName, type);*/
            if (string.IsNullOrEmpty(txt_nameaccount.Text))
            {
                MessageBox.Show("Bạn vui long nhập thông tin tài khoản cần cập nhật ! ");
            }
            else
            {
                string display = txt_DisplayName.Text;
                string username = txt_nameaccount.Text;
                string password = txtPasswordaccount.Text;
                string type = int.Parse(txt_AccountType.Text).ToString();
                updateaccount(display, username, password, type);

                txt_DisplayName.Text = "";
                txt_nameaccount.Text = "";
                txtPasswordaccount.Text = "";
                txt_AccountType.Text = "";

                txt_nameaccount.Focus();
                viewlistaccount();

            }
        }

        private void btn_ViewAccount_Click(object sender, EventArgs e)
        {
            //  LoadAccount();
            viewlistaccount();
        }

/*        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txt_nameaccount.Text;

            ResetPass(userName);
        }*/



        private void btn_SearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txt_SearchFoodName.Text);
        }


        private void txt_idFood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_Food.SelectedCells.Count > 0)
                {
                    int id = (int)dtgv_Food.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cb_Category.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cb_Category.Items)
                    {
                        if (item.Id == cateogory.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cb_Category.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            string name = txt_NameFood.Text;
            int categoryID = (cb_Category.SelectedItem as Category).Id;
            float price = (float)nm_Price.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btn_EditFood_Click(object sender, EventArgs e)
        {
            string name = txt_NameFood.Text;
            int categoryID = (cb_Category.SelectedItem as Category).Id;
            float price = (float)nm_Price.Value;
            int id = Convert.ToInt32(txt_idFood.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void btn_DeleteFood_Click (object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_idFood.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }
        private void btn_ShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btn_ViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpk_FromDate.Value, dtpk_ToDate.Value);
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btn_FristBillPage_Click(object sender, EventArgs e)
        {
            txt_PageBill.Text = "1";
        }

        private void btn_LastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpk_FromDate.Value, dtpk_ToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txt_PageBill.Text = lastPage.ToString();
        }

        private void txt_PageBill_TextChanged(object sender, EventArgs e)
        {
            dtgv_Bill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpk_FromDate.Value, dtpk_ToDate.Value, Convert.ToInt32(txt_PageBill.Text));
        }

        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txt_PageBill.Text);

            if (page > 1)
                page--;

            txt_PageBill.Text = page.ToString();
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txt_PageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpk_FromDate.Value, dtpk_ToDate.Value);

            if (page < sumRecord)
                page++;

            txt_PageBill.Text = page.ToString();
        }
        #endregion



        private void fAdmin_Load(object sender, EventArgs e)
        {
            /*           // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet2.USP_GetListBillByDateForReport' table. You can move, or remove it, as needed.
                       this.USP_GetListBillByDateForReportTableAdapte.Fill(this.QuanLyQuanCafeDataSet2.USP_GetListBillByDateForReport, dtpk_FromDate.Value, dtpk_ToDate.Value);

                       this.rpViewer.RefreshReport();*/
            xemdulieukhachang();
            databindingcustomer();
            //load thông tin bàn


            //load thông tin tài khoản 
            viewlistaccount();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            xemdulieukhachang();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakh.Text) || string.IsNullOrEmpty(txttenkh.Text) || string.IsNullOrEmpty(txtgioitinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu ");
            }
            else
            {
                string idcustomer = txtmakh.Text;
                string name = txttenkh.Text;
                string gender = txtgioitinh.Text;
                string phonenumber = txtsdt.Text;
                string daycheckin = txtngaycheckin.Text;
                string idcatgorycustomer = txtloaikh.Text;
                themkhachang(idcustomer, name, gender, phonenumber, daycheckin, idcatgorycustomer);
                xemdulieukhachang();
                txtmakh.Text = "";
                txttenkh.Text = "";
                txtgioitinh.Text = "";
                txtngaycheckin.Text = "";
                txtsdt.Text = "";
                txtloaikh.Text = "";


            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string ma = txtmakh.Text;
            deletecustomer(ma);
            xemdulieukhachang();
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtgioitinh.Text = "";
            txtngaycheckin.Text = "";
            txtsdt.Text = "";
            txtloaikh.Text = "";
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            string idcustomer = txtmakh.Text;
            string name = txttenkh.Text;
            string gender = txtgioitinh.Text;
            string phonenumber = txtsdt.Text;
            string daycheckin = txtngaycheckin.Text;
            string idcatgorycustomer = txtloaikh.Text;
            updatekhachanh(idcustomer, name, gender, phonenumber, daycheckin, idcatgorycustomer);
            xemdulieukhachang();
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtgioitinh.Text = "";
            txtngaycheckin.Text = "";
            txtsdt.Text = "";
            txtloaikh.Text = "";
        }

        BindingSource bs = null;
        public void databindingcustomer()
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            if (sqlConnection == null)
            {

                sqlConnection = new SqlConnection(connect);
            }
            string query = "select *from Customer";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet dt = new DataSet();
            adapter.Fill(dt, "Customer");
            bs = new BindingSource(dt, "Customer");
            txtmakh.DataBindings.Add("text", bs, "idcustomer");
            txttenkh.DataBindings.Add("text", bs, "name");
            txtgioitinh.DataBindings.Add("text", bs, "gender");
            txtsdt.DataBindings.Add("text", bs, "phonenumber");
            txtngaycheckin.DataBindings.Add("text", bs, "daycheckin");
            txtloaikh.DataBindings.Add("text", bs, "idcategorycustomer");

        }

        private void btnvedau_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
        }

        private void btnvecuoi_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
        }

        private void btnquatrai_Click(object sender, EventArgs e)
        {
            if (bs.Position > 0)
            {
                bs.Position--;

            }
        }

        private void btnquaphai_Click(object sender, EventArgs e)
        {
            if (bs.Position < bs.Count - 1)
            {
                bs.Position++;
            }
        }
    }
}
