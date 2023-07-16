using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DAO
{
    internal class CategoryDAO
    {

        private static CategoryDAO instance;


        public static CategoryDAO Instance 
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set { CategoryDAO.instance = value; }
        }


        private CategoryDAO() 
        {

        }

        public List<Category> Getlistcategory() 
        {
            List<Category> list = new List<Category>();

            string query = "select *from FoodCategory";
            DataTable data=DataProvider.Instance.ExecuteQuery(query);   
            foreach (DataRow dr in data.Rows)
            {
                Category category = new Category(dr);
                list.Add(category);
            }
            return list;

        }
    }
}
