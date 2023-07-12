using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DTO
{
     public class Menu
    {
        private string foodName;
        private int count;
        private float price ;
        private float totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Menu(string foodName, int count, float price, float totalPrice)
        {
            FoodName = foodName;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            FoodName = row["foodName"].ToString();
            Count = (int)row["count"];
            Price = (float)row["price"];
            TotalPrice = (float)row["totalPrice"];
        }
    }
}
