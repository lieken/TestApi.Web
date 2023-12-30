using Dapper;

namespace TestApi.Web.Service.Interface
{
    public interface IDatabaseService
    {
        Task<T> GetOneRecordAsync<T>(string sql, DynamicParameters parameters);
        Task<IList<T>> GetRecordsAsync<T>(string sql, DynamicParameters parameters);
        Task<int> CreateAsync(string sql, DynamicParameters parameters);
        Task<int> UpdateAsync(string sql, DynamicParameters parameters);
        Task<int> DeleteAsync(string sql, DynamicParameters parameters);
        void Commit();
        void Rollback();
        void Dispose();
    }
}
