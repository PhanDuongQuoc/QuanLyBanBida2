﻿using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBida.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        {
            get { if(instance == null)instance = new BillInfoDAO(); return instance;}
            private set { BillInfoDAO.instance = value; }
        }


        /// <summary>
        /// phan duong quoc 12345678
        /// </summary>
        /// <param name="id"></param>asdfhjkjhgfdfhjk
        /// <returns></returns>
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> ListBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where idBill=" + id);

            foreach (DataRow item in data.Rows) 
            {
                BillInfo info = new BillInfo(item);
                ListBillInfo.Add(info);
            }
            return ListBillInfo;
        }

        public void addbillinfo(int id,int idbill,int idfood,int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_adddulieubillinfo2 @id ,@idBill  ,@idFood, @count", new object[] {1, idbill,idfood,count});
        }
    }
}
