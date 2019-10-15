﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    class ConexionMatriz
    {
        public static SqlConnection ObtenerConexion(string serverName)
        {
            
           SqlConnection con=new SqlConnection("Data Source=" + System.Environment.MachineName + "; Initial Catalog = LENGUAJE2; Server=" + System.Environment.MachineName + "\\"+serverName+" ;Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            // SqlConnection con = new SqlConnection(@"Data Source=localhost; Initial Catalog = LENGUAJE; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            con.Open();
            return (con);
        }
        public static bool ProbarConexion(string serverName)
        {
            SqlConnection con = new SqlConnection("Data Source=" + System.Environment.MachineName + "; Initial Catalog = LENGUAJE2; Server=" + System.Environment.MachineName + "\\" + serverName + " ;Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            try
            {
                con.Open();
                if(con.State==System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                   
            }
            catch
            {
                return false;
            }
        }
    }
}
