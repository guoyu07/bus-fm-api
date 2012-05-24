// Copyright (c) 2004-2008 MySQL AB, 2008-2009 Sun Microsystems, Inc.
//
// MySQL Connector/NET is licensed under the terms of the GPLv2
// <http://www.gnu.org/licenses/old-licenses/gpl-2.0.html>, like most 
// MySQL Connectors. There are special exceptions to the terms and 
// conditions of the GPLv2 as it is applied to this software, see the 
// FLOSS License Exception
// <http://www.mysql.com/about/legal/licensing/foss-exception.html>.
//
// This program is free software; you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published 
// by the Free Software Foundation; version 2 of the License.
//
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
//
// You should have received a copy of the GNU General Public License along 
// with this program; if not, write to the Free Software Foundation, Inc., 
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace DBHelper
{


    /// <summary>
    /// Helper class that makes it easier to work with the provider.
    /// </summary>
    public sealed class SqlHelper
    {
        private static string connectionString = System.Configuration.ConfigurationManager.AppSettings["mysql"];

        /// <summary>
        /// Executes a single command against a MySQL database.  A new <see cref="MySqlConnection"/> is created
        /// using the <see cref="MySqlConnection.ConnectionString"/> given.
        /// </summary>
        /// <param name="commandText">SQL command to be executed</param>
        /// <param name="parms">Array of <see cref="MySqlParameter"/> objects to use with the command.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, params MySqlParameter[] parms)
        {
                return MySqlHelper.ExecuteNonQuery(connectionString,commandText, parms);
        }

        /// <summary>
        /// Executes a single SQL command and returns the first row of the resultset.  A new MySqlConnection object
        /// is created, opened, and closed during this method.
        /// </summary>
        /// <param name="commandText">Command to execute</param>
        /// <param name="parms">Parameters to use for the command</param>
        /// <returns>DataRow containing the first row of the resultset</returns>
        public static DataRow ExecuteDataRow(string commandText, params MySqlParameter[] parms)
        {
            return MySqlHelper.ExecuteDataRow(connectionString,commandText,parms);
        }

        /// <summary>
        /// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
        /// A new MySqlConnection object is created, opened, and closed during this method.
        /// </summary>
        /// <param name="commandText">Command to execute</param>
        /// <returns><see cref="DataSet"/> containing the resultset</returns>
        public static DataSet ExecuteDataset( string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return MySqlHelper.ExecuteDataset(connectionString, commandText, null);
        }

        /// <summary>
        /// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
        /// A new MySqlConnection object is created, opened, and closed during this method.
        /// </summary>
        /// <param name="connectionString">Settings to be used for the connection</param>
        /// <param name="commandText">Command to execute</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns><see cref="DataSet"/> containing the resultset</returns>
        public static DataSet ExecuteDataset(string commandText, params MySqlParameter[] commandParameters)
        {
                return MySqlHelper.ExecuteDataset(connectionString, commandText, commandParameters);
        }
        
        /// <summary>
        /// Updates the given table with data from the given <see cref="DataSet"/>
        /// </summary>
        /// <param name="commandText">Command text to use for the update</param>
        /// <param name="ds"><see cref="DataSet"/> containing the new data to use in the update</param>
        /// <param name="tablename">Tablename in the dataset to update</param>
        public static void UpdateDataSet(string commandText, DataSet ds, string tablename)
        {
            MySqlHelper.UpdateDataSet(connectionString, commandText, ds, tablename);
        }

        /// <summary>
        /// Executes a single command against a MySQL database.
        /// </summary>
        /// <param name="commandText">Command text to use</param>
        /// <returns><see cref="MySqlDataReader"/> object ready to read the results of the command</returns>
        public static MySqlDataReader ExecuteReader(string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return MySqlHelper.ExecuteReader(connectionString, commandText, (MySqlParameter[])null);
        }
        /// <summary>
        /// Executes a single command against a MySQL database.
        /// </summary>
        /// <param name="commandText">Command text to use</param>
        /// <param name="commandParameters">Array of <see cref="MySqlParameter"/> objects to use with the command</param>
        /// <returns><see cref="MySqlDataReader"/> object ready to read the results of the command</returns>
        public static MySqlDataReader ExecuteReader(string commandText, params MySqlParameter[] commandParameters)
        {
            return MySqlHelper.ExecuteReader(connectionString, commandText, commandParameters);
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="commandText">Command text to use for the update</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(string commandText)
        {
            return MySqlHelper.ExecuteScalar(connectionString, commandText, (MySqlParameter[])null);
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="commandText">Command text to use for the command</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(string commandText, params MySqlParameter[] commandParameters)
        {
                return MySqlHelper.ExecuteScalar(connectionString, commandText, commandParameters);
        }
    }
}
