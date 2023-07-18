﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DTO
{
    internal class Food
    {

        private int id;
        private string name;
        private string idcategory;
        private double price;

        public Food(int id, string name, string idcategory, double price)
        {
            this.Id= id;
            this.Name = name;
            this.Idcategory = idcategory;
            this.Price= price;
        }

        public int Id { get => id; set => id = value; }
        public string Name{ get => name; set => name = value; }
        public string Idcategory{ get => idcategory; set => idcategory= value; }
        public double Price { get => price; set => price = value; }

        public Food(DataRow row)  
        {

            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Idcategory = row["idCategory"].ToString();
            this.Price = (double)Convert.ToDouble(row["price"].ToString());
        }
    }
}