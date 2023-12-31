using TestApi.Web.Core.Helper;
using TestApi.Web.Service.Interface;
using TestApi.Web.Service.Model;

namespace TestApi.Web.Service.Service
{
    public class MovieService: IMovieService
    {
        private readonly DapperHelper _dapperHelper;

        public MovieService(DapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<int> CreateMovieAsync(Movie movie)
        {
            using (var transaction = _dapperHelper.BeginTransaction())
            {
                try
                {
                    string insertSql = @"
                    INSERT INTO Movies (Title, Description, Director, Year)
                    VALUES (@Title, @Description, @Director, @Year);
                    SELECT SCOPE_IDENTITY();";

                    int movieId = await _dapperHelper.CreateAsync(insertSql, new
                    {
                        movie.Title,
                        movie.Description,
                        movie.Director,
                        movie.Year
                    }, transaction);

                    _dapperHelper.Commit();

                    return movieId;
                }
                catch (Exception ex)
                {
                    _dapperHelper.Rollback();
                    throw new Exception(ex.Message); 
                }
            }
        }

        public async Task<IList<Movie>> GetMoviesAsync()
        {
            string sql = "SELECT * FROM Movies";
            return await _dapperHelper.QueryAsync<Movie>(sql);
        }

        public async Task<Movie> GetMovieAsync(int movieId)
        {
            string sql = "SELECT * FROM Movies WHERE Id = @Id";
            return await _dapperHelper.QueryOneAsync<Movie>(sql, new { Id = movieId });
        }

        public async Task<int> UpdateMovieAsync(int id, UpdateMovieReq movie)
        {
            using var transaction = _dapperHelper.BeginTransaction();
            try
            {
                string updateSql = @"
                    UPDATE Movies
                    SET Title = @Title, Description = @Description, Director = @Director, Year = @Year
                    WHERE Id = @Id;";

                int affectedRows = await _dapperHelper.UpdateAsync(updateSql, new
                {
                    movie.Title,
                    movie.Description,
                    movie.Director,
                    movie.Year,
                    id
                }, transaction);

                _dapperHelper.Commit();

                return affectedRows;
            }
            catch (Exception ex)
            {
                _dapperHelper.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteMovieAsync(int movieId)
        {
            using var transaction = _dapperHelper.BeginTransaction();
            try
            {
                string deleteSql = "DELETE FROM Movies WHERE Id = @Id";
                int affectedRows = await _dapperHelper.DeleteAsync(deleteSql, new { Id = movieId }, transaction);
                _dapperHelper.Commit();
                return affectedRows;
            }
            catch (Exception ex) {
                _dapperHelper.Rollback(); 
                throw new Exception(ex.Message); 
            }
        }
    }

}
