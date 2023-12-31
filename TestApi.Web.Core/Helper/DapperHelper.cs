using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TestApi.Web.Core.Helper
{
    public class DapperHelper 
    {
        private IDbTransaction _dbTransaction;
        private readonly IDbConnection _dbConnection;

        public string? SqlConnection { get; set; }

        public DapperHelper(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
            _dbConnection.Open();
        }

        public async Task<int> CreateAsync(string sql, object parameters, IDbTransaction transaction = null)
        {
            return await _dbConnection.ExecuteAsync(sql, parameters, transaction);
        }

        public async Task<int> UpdateAsync(string sql, object parameters, IDbTransaction transaction = null)
        {
            return await _dbConnection.ExecuteAsync(sql, parameters, transaction);
        }

        public async Task<int> DeleteAsync(string sql, object parameters, IDbTransaction transaction = null)
        {
            return await _dbConnection.ExecuteAsync(sql, parameters, transaction);
        }

        public async Task<IList<T>> QueryAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null)
        {
            var result = await _dbConnection.QueryAsync<T>(sql, parameters, transaction);
            return result.ToList();
        }

        public async Task<T> QueryOneAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, parameters, transaction);
        }

        /// <summary>
        /// 交易: 開始
        /// </summary>
        public IDbTransaction BeginTransaction()
        {
            _dbTransaction = _dbConnection.BeginTransaction();
            return _dbTransaction;
        }

        /// <summary>
        /// 交易: 提交
        /// </summary>
        public void Commit()
        {
            _dbTransaction?.Commit();
        }

        /// <summary>
        /// 交易: 回捲,駁回
        /// </summary>
        public void Rollback()
        {
            _dbTransaction?.Rollback();
        }

        /// <summary>
        /// 交易: 釋放資源,關閉連接
        /// </summary>
        public void Dispose()
        {
            _dbTransaction?.Dispose();
            _dbConnection?.Dispose();
        }
    }
}
