using Dapper;
using System.Data.SqlClient;

namespace TestApi.Web.Core.Helper
{
    public class DapperHelper 
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public string? SqlConnection { get; set; }

        public DapperHelper(string? sqlConnectionTemp = null)
        {
            SqlConnection = sqlConnectionTemp;
            _connection = new SqlConnection(SqlConnection);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// 讀取: 單項資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<T> ReadOneRecordAsync<T>(string sql, DynamicParameters parameters)
        {
            var result = await _connection.QueryFirstAsync<T>(sql, parameters, _transaction);
            return result;
        }

        /// <summary>
        /// 讀取: 多項資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IList<T>> ReadRecordsAsync<T>(string sql, DynamicParameters parameters)
        {
            var result = await _connection.QueryAsync<T>(sql, parameters, _transaction);
            return result.ToList();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(string sql, DynamicParameters parameters)
        {
            var result = await _connection.ExecuteAsync(sql, parameters, _transaction);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(string sql, DynamicParameters parameters)
        {
            var result = await _connection.ExecuteAsync(sql, parameters, _transaction);
            return result;
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string sql, DynamicParameters parameters)
        {
            var result = await _connection.ExecuteAsync(sql, parameters, _transaction);
            return result;
        }

        /// <summary>
        /// 交易: 提交
        /// </summary>
        public void Commit()
        {
            _transaction?.Commit();
        }

        /// <summary>
        /// 交易: 回捲,駁回
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
        }

        /// <summary>
        /// 交易: 釋放資源,關閉連接
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Close();
        }
    }
}
