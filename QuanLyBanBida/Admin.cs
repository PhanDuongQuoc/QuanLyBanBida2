using Microsoft.SqlServer.Server;
using QuanLyBanBida.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBida
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

        }
        private string connect = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QuanLyQuanBidamaster;Integrated Security=True";
        private void txt_Category_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Category_Click(object sender, EventArgs e)
        {

        }

        private void txt_NameFood_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_NameFood_Click(object sender, EventArgs e)
        {

        }

        private void txt_FoodID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_FoodID_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbl_FoodPrice_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgv_Food_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbl_TableStatus_Click(object sender, EventArgs e)
        {

        }

        private void txt_TableName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //code xem dữ liệu khách hàng
        public void xemdulieukhachang()
        {
            SqlConnection conn = new SqlConnection(connect);
            string query = "select idcustomer as[Mã khách hàng],name as[Tên khách hàng],gender as[Giới tính],phonenumber as[Số điện thoại], daycheckin as[Ngày checkin],idcategorycustomer as[Loại khách hàng] from Customer";
            SqlDataAdapter adpater = new SqlDataAdapter(query, conn);
            DataSet dt = new DataSet();
            adpater.Fill(dt, "Customer");
            dtgv_InfoCustomer.DataSource = dt.Tables["Customer"];
        }
        private void btnxem_Click(object sender, EventArgs e)
        {
            xemdulieukhachang();
        }
        // thêm khách hàng 
        public bool KiemTraTonTai(string idcustomer)
        {
            SqlConnection conn = new SqlConnection(connect);
            string query = "SELECT COUNT(*) FROM Customer WHERE idcustomer = @idcustomer";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idcustomer", idcustomer);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count >0;
        }

        //Thêm khách hàng 
        public void themkhachang(string idcustomer, string name,string gender,string phonenumber,string daycheckin,string idcatgorycustomer) 
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
            catch(Exception ex) 
            {
                MessageBox.Show("Mã Khách hàng đã tồn tại");
            }
        }

   

     
        //ntu1 thêm khách hàng

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
        //nút xóa khách hàng

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

        //nút xóa thông tin khách hàng
        private void btnxoa_Click(object sender, EventArgs e)
        {
            string ma=txtmakh.Text;
            deletecustomer(ma);
            xemdulieukhachang();
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtgioitinh.Text = "";
            txtngaycheckin.Text = "";
            txtsdt.Text = "";
            txtloaikh.Text = "";
        }

        // cập nhật thông tin khách hàng 

        public void updatekhachanh(string idcustomer, string name, string gender, string phonenumber, string daycheckin, string idcategorycustomer) 
        {
            if (KiemTraTonTai(idcustomer)) 
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "update Customer set name=@name, gender=@gender,phonenumber=@phonenumber, daycheckin=@daycheckin,idcategorycustomer=@idcategorycustomer where idcustomer=@idcustomer";
                SqlCommand cmd=new SqlCommand(query, sqlConnection);
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

        //nút cập nhật thông tin khách hàng 

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

        // binding source thông thin khách hàng 
        BindingSource bs = null;
        public void databindingcustomer()
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            if (sqlConnection == null)
            {

                sqlConnection = new SqlConnection(connect);
            }
            string query = "select *from Customer";
            SqlDataAdapter adapter = new SqlDataAdapter(query,sqlConnection);
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

        public void kiemtrathongtinban()
        {
            SqlConnection conn = new SqlConnection(connect);


        }


        public void viewdatatable() 
        {
            SqlConnection sqlConnection=new SqlConnection(connect);
            string query = "select id as[ Mã bàn], name as[Tên bàn], status as[Trạng thái] from TableBida";
           SqlDataAdapter adpter=new SqlDataAdapter(query, sqlConnection);
            DataSet dt = new DataSet();

            adpter.Fill(dt,"TableBida");
            dtgv_Table.DataSource= dt.Tables["TableBida"];


        }

        public bool kiemtradulieutable( string id,string name) 
        {
            SqlConnection connection = new SqlConnection(connect);
            string query = "select COUNT(*)from TableBida where id=@id and name=@name";
            SqlCommand cmd =new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue ("@name", name);
            connection.Open();
            int count=(int)cmd.ExecuteScalar();
            connection.Close();
            return count > 0;
        }
        //kiem tra thông tin khách hàng 

        public void updatetable(string id,string name,string status) 
        {
            if (kiemtradulieutable(id, name)) 
            {
                SqlConnection connection = new SqlConnection(connect);
                string query ="update TableBida set status=@status where id=@id and name=@name";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Cập nhật thành công !");
            }
            else 
            {
                MessageBox.Show("Dữ liệu bạn muốn cập nhật không tồn tại !");
            }

           
        }

        //chức năng cập nhật bàn 
        private void btn_EditTable_Click(object sender, EventArgs e)
        {
            string id = txt_idtable.Text;
           string name=txt_TableName.Text;
            string status=cb_TableStatus.Text;
            updatetable(id,name,status);
            viewdatatable();

        }

        // load lại bàn sau khi cập nhật hoặc thêm  
        private void btn_ViewTable_Click(object sender, EventArgs e)
        {
            viewdatatable();
        }


     // hiển thị danh sách tài khoản 

        public void viewlistaccount() 
        {
            SqlConnection sqlConnection=new SqlConnection(connect);
            string query = "select DisplayName as[ Tên tài khoản ], UserName as[Tên người dùng], PassWord as[mật khẩu],Type as[Loại tài khoản] from Account ";
            SqlDataAdapter adpter=new SqlDataAdapter(query, sqlConnection);
            DataSet dt = new DataSet();
            adpter.Fill(dt,"Account");
            dtgv_Account.DataSource = dt.Tables["Account"];


        }



      public bool kiemtrathongtintaikhoan(string username)
        {
            SqlConnection sqlConnection=new SqlConnection(connect);
            string query = "select count(*) from Account where UserName=@username";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@username", username);
            sqlConnection.Open();
            int count=(int)command.ExecuteScalar();
            sqlConnection.Close();
            return count > 0;
        }

        // Thêm tài khoản cho admin

        public void addAcount(string DisplayName,string UserName,string PassWord, string Type) 
        {
            if (kiemtrathongtintaikhoan(UserName)) 
            {
                MessageBox.Show("Tài khoản bạn muốn thêm hiện đã có !");
            }
            else 
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "insert into Account(DisplayName,UserName,PassWord,Type) values (@DisplayName,@UserName,@PassWord,@Type)";

                SqlCommand cmd=new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@DisplayName", DisplayName);
                cmd.Parameters.Add("@UserName", UserName);
                cmd.Parameters.Add("@PassWord", PassWord);
                cmd.Parameters.Add("@Type", Type);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close() ;
                MessageBox.Show("Thêm dữ iệu thành công !");
            }
        }
        // nhấp vào nút thêm tài khoản 
        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_DisplayName.Text) || string.IsNullOrEmpty(txt_nameaccount.Text)|| string.IsNullOrEmpty(txtPasswordaccount.Text) || string.IsNullOrEmpty(txt_AccountType.Text))
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

        //xóa thông tin tài khoản 
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
        //nút xóa thông tin tài khoản 
        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
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

        //cập nhật thông tin tài khoản 
        public void updateaccount(string DisplayName, string UserName, string PassWord, string Type) 
        {
            if (kiemtrathongtintaikhoan(UserName)) 
            {
                SqlConnection sqlConnection = new SqlConnection(connect);
                string query = "update Account set DisplayName=@Displayname, PassWord=@PassWord,Type=@Type where UserName=@UserName";
                SqlCommand cmd=new SqlCommand(query, sqlConnection);
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.AddWithValue("@DisplayName", DisplayName);
               cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue ("@Password", PassWord);
                cmd.Parameters.AddWithValue("@Type", Type);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close() ;
                MessageBox.Show("Tài khoản bạn cập nhật thành công !");


            }
            else 
            {
                MessageBox.Show("Tài khoàn bạn muốn cập nhật không có !");
            }
        }

        private void btn_EditAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nameaccount.Text)) 
            {
                MessageBox.Show("Bạn vui long nhập thông tin tài khoản cần cập nhật ! ");
            }
            else 
            {
                string display=txt_DisplayName.Text;
                string username = txt_nameaccount.Text;
                string password=txtPasswordaccount.Text;
                string type=int.Parse(txt_AccountType.Text).ToString();
                updateaccount(display, username, password, type);

                txt_DisplayName.Text = "";
                txt_nameaccount.Text = "";
                txtPasswordaccount.Text = "";
                txt_AccountType.Text = "";
            
                 txt_nameaccount.Focus();
                 viewlistaccount();

            }
            
        }
        // xem dữ liệu sau khi load danh sách tài khoản 

        private void btn_ViewAccount_Click(object sender, EventArgs e)
        {
            viewlistaccount();
        }
        //tìm tài khoản
        public void searchaccount(string DisplayName) 
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            string query = "SELECT * FROM Account WHERE DisplayName = @DisplayName ";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@DisplayName", DisplayName);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet dt = new DataSet();
            adapter.Fill(dt);

            // Đổ dữ liệu vào DataGridView
            dtgv_Account.DataSource = dt;

        }

        public void nutsearchacount() 
        {
            string username = txt_DisplayName.Text;
            searchaccount(username);

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            nutsearchacount();
        }

        //load lại tất cả thông tin sau khi cập nhật tất cả các chức năng
        private void fAdmin_Load(object sender, EventArgs e)
        {
            // load thông tin khách hàng 
            xemdulieukhachang();
            databindingcustomer();
            //load thông tin bàn
            viewdatatable();

            //load thông tin tài khoản 
            viewlistaccount();

        }

  









        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgv_InfoCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tp_InfoCustomer_Click(object sender, EventArgs e)
        {
            
        }

    
    }
}
