using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBida.DAO
{
     class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance 
        {
            get { if(instance == null)instance = new MenuDAO();return instance;}
            private set { instance = value; }
        }

        private MenuDAO() { }


        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "select f.name, bi.count, f.price, f.price * bi.count as totalPrice from dbo.BILL as b,dbo.Food as f,dbo.BillInfo as bi where bi.idBill=b.id and bi.idFood=f.id and b.idTable ="+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows) 
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
