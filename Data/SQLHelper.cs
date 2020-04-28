﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    static class SqlHelper
    {


        public static string Connection { get; } = "Data Source= sql5047.site4now.net; Initial Catalog=DB_A5A769_yensan; User ID=DB_A5A769_yensan_admin; Password=yenifer12345;";
        /// <summary> 
        /// Set the connection, command, and then execute the command with non query. 
        /// </summary> 
        public static Int32 ExecuteNonQuery(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect  
                    // type is only for OLE DB.   
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary> 
        /// Set the connection, command, and then execute the command and only return one value. 
        /// </summary> 
        public static Object ExecuteScalar(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary> 
        /// Set the connection, command, and then execute the command with query and return the reader. 
        /// </summary> 
        public static SqlDataReader ExecuteReader(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the  
                // IDataReader is closed. 
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}

