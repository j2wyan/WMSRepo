using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WMS_V1.DL
{
    public class DAShoinDaicho
    {
        public DataTable getShoinDiachobyD(string D)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select * from [SHOHINDAICHO] where D like '" + D + "%'  ";
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

        public DataTable getShoinDiacho()
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select * from [SHOHINDAICHO]";
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

        public DataTable getShoinDiachobyDFromat2(string D)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select * from [SHOHINDAICHO] where C like '%" + D + "%'  ";
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


        public DataTable getShoinDiachobyBuriichi(string query)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select * from [SHOHINDAICHO]  " + query;
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


        public DataTable getShoinDiachobyB(string B)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select A.*,B.B SCode from [SHOHINDAICHO]  A  left join SOKODAICHO B on A.U=B.A   where A.B='" + B + "'";
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
