using Dapper;
using TestApi.Web.Core.Helper;
using TestApi.Web.Service.Interface;

namespace TestApi.Web.Service.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DapperHelper _dapperHelper;

        public DatabaseService(DapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper ?? throw new ArgumentNullException(nameof(dapperHelper));
        }


        public async Task<T> GetOneRecordAsync<T>(string sql, DynamicParameters parameters)
        {
            return await _dapperHelper.ReadOneRecordAsync<T>(sql, parameters);
        }

        public async Task<IList<T>> GetRecordsAsync<T>(string sql, DynamicParameters parameters)
        {
            return await _dapperHelper.ReadRecordsAsync<T>(sql, parameters);
        }

        public async Task<int> CreateAsync(string sql, DynamicParameters parameters)
        {
            return await _dapperHelper.CreateAsync(sql, parameters);
        }

        public async Task<int> UpdateAsync(string sql, DynamicParameters parameters)
        {
            return await _dapperHelper.UpdateAsync(sql, parameters);
        }

        public async Task<int> DeleteAsync(string sql, DynamicParameters parameters)
        {
            return await _dapperHelper.DeleteAsync(sql, parameters);
        }

        public void Commit()
        {
            _dapperHelper.Commit();
        }

        public void Rollback()
        {
            _dapperHelper.Rollback();
        }

        public void Dispose()
        {
            _dapperHelper.Dispose();
        }
    }
}
