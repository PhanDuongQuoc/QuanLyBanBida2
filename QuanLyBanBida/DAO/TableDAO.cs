﻿using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance 
        {
            get {if(instance == null)instance = new TableDAO();return instance;}
            private set { instance = value;}
        }
        private TableDAO() { }

        public List<Table> TableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetTableList");

            foreach(DataRow item in data.Rows) 
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;// hallo
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;

    }
}
