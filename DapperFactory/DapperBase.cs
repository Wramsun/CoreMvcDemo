using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace DapperFactory
{
    public class DapperBase : IDapper
    {
        private IDbConnection _conn;
        private string _connectionString;

        public DapperBase(string connectionString)
        {
            _connectionString = connectionString;
        }



        private IDbConnection IDbConnection
        {
            get { return _conn = new SqlConnection(_connectionString); }
        }

        #region SELECT
        public List<T> GetList<T>(string sqlString, object param = null, CommandType? commandType = CommandType.Text, int? commandTimeout = 180)
        {
            var list = new List<T>();

            using (var db = IDbConnection as DbConnection)
            {
                IEnumerable<T> ts = null;
                if (null == param)
                {
                    ts = db.Query<T>(sqlString, null, null, true, commandTimeout, commandType);
                }
                else
                {
                    ts = db.Query<T>(sqlString, param, null, true, commandTimeout, commandType);
                }
                if (null != ts)
                {
                    list = ts.AsList();
                }
            }

            return list;
        }

        public List<T> GetList<T>(string sqlString)
        {
            return GetList<T>(sqlString, null, CommandType.Text);
        }

        public List<T> GetList<T>(string sqlString, object param)
        {
            if (null == param)
            {
                return GetList<T>(sqlString);
            }

            return GetList<T>(sqlString, param);
        }
        #endregion

        #region INSERT
        public bool Insert(string sqlString, object param = null, CommandType commandType = CommandType.Text, int? commandTimeOut = 5)
        {
            return ExecuteNonQuery(sqlString, param, commandType, commandTimeOut);
        }

        public bool Insert<T>(string sqlString, List<T> list, CommandType commandType = CommandType.Text, int? commandTimeOut = 5)
        {
            var intResult = 0;

            if (null != list && 0 < list.Count)
            {
                using (var db = IDbConnection as DbConnection)
                {
                    intResult = db.Execute(sqlString, list, null, commandTimeOut, commandType);
                }
            }

            return intResult > 0;
        }
        #endregion

        #region UPDATE
        public bool Update(string sqlString, object param, CommandType commandType = CommandType.Text, int? commandTimeOut = 5)
        {
            return ExecuteNonQuery(sqlString, param, commandType, commandTimeOut);
        }
        #endregion

        #region DELETE
        public bool Delete(string sqlString, object param, CommandType commandType = CommandType.Text, int? commandTimeOut = 5)
        {
            return ExecuteNonQuery(sqlString, param, commandType, commandTimeOut);
        }
        #endregion

        #region Private Methods
        private bool ExecuteNonQuery(string sqlString, object param, CommandType commandType = CommandType.Text, int? commandTimeOut = 5)
        {
            var intResult = 0;
            using (var db = IDbConnection as DbConnection)
            {
                if (null == param)
                {
                    intResult = db.Execute(sqlString, null, null, commandTimeOut, commandType);

                }
                else
                {
                    intResult = db.Execute(sqlString, param, null, commandTimeOut, commandType);
                }
            }

            return intResult > 0;
        }
        #endregion
    }
}
