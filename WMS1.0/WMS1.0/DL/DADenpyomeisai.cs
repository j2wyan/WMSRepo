﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WMS_V1.DL
{
  public  class DADenpyomeisai
    {
        public DataTable getdempyoMeisaibyC(long C)// C is uriagedenpyo key
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select  DM.*  , SD.B AS SOKONAME from DEMPYOMEISAI  DM left join  SOKODAICHO SD on DM.O=SD.A   where   C=" + C;
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
