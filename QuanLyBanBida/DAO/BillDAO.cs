using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if(instance == null)instance = new BillDAO();return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BILL WHERE idTable=" + id + " AND status = 0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id; // lấy id thành công
            }
            return -1; // thất bại = -1 
        }

        public void addbill(int id) 
        {
            DataProvider.Instance.ExecuteNonQuery("USP_chendulieuvaobill1 @idTable ", new object[] {id});
        }


        public int getmaxidbill() 
        {
            try 
            {
                return (int)DataProvider.Instance.ExecuteScala("select max(id) from bill");
            }
            catch 
            {
                return 1;
            }
        }


        public void kiemtrthanhtoan(int id,int discount)
        {
            string query = "update dbo.Bill set status=1,"+"discount="+discount+" where id=" + id;
            DataProvider.Instance.ExecuteQuery(query);
        }

    }
}
