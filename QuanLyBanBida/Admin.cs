using Microsoft.SqlServer.Server;
using QuanLyBanBida.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public void databinding()
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
        private void fAdmin_Load(object sender, EventArgs e)
        {
            xemdulieukhachang();
            databinding();
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
