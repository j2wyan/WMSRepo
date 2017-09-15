using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WMS_V1.DL
{
  public class DATokui
    {
        public DataTable getTokuibyKana(string kana)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select B,C  from TokuisakiDaicho  where  D like '" + kana + "%'  ";
                SqlDataAdapter dadapter = new SqlDataAdapter(select_query, clsConn);
                DataSet dset = new DataSet();

                dadapter.Fill(dset, "table");
                dt = dset.Tables[0];
                clsConn.Close();

            }
            catch (Exception)
            {
                clsConn.Close();
            }
            return dt;
        }

        public DataTable getTokuiADAll()
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select distinct AD  from TokuisakiDaicho";
                SqlDataAdapter dadapter = new SqlDataAdapter(select_query, clsConn);
                DataSet dset = new DataSet();

                dadapter.Fill(dset, "table");
                dt = dset.Tables[0];
                clsConn.Close();

            }
            catch (Exception)
            {
                clsConn.Close();
            }
            return dt;
        }

        public DataTable getTantosahName()
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select distinct  C  from TANTOSHADAICHO";
                SqlDataAdapter dadapter = new SqlDataAdapter(select_query, clsConn);
                DataSet dset = new DataSet();

                dadapter.Fill(dset, "table");
                dt = dset.Tables[0];
                clsConn.Close();

            }
            catch (Exception)
            {
                clsConn.Close();
            }
            return dt;
        }

        public DataTable getTokuibyCode(string Code)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select *  from TokuisakiDaicho  where rtrim(ltrim(B))='" + Code + "'";
                SqlDataAdapter dadapter = new SqlDataAdapter(select_query, clsConn);
                DataSet dset = new DataSet();

                dadapter.Fill(dset, "table");
                dt = dset.Tables[0];
                clsConn.Close();

            }
            catch (Exception)
            {
                clsConn.Close();
            }
            return dt;
        }


     
    }
}
