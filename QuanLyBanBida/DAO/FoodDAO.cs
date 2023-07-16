using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DAO
{
    internal class FoodDAO
    {
        public static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { FoodDAO.instance = value; }

        }


        public FoodDAO() 
        {

        }

      public List<Food> Getlistfood(int id) 
      {
            List<Food> list=new List<Food> ();

            string query = "select *from Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            
            {
                Food food = new Food(row);
                list.Add(food);
            }
            return list;

      }

        
    }
}
