using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Web.Service.Model;

namespace TestApi.Web.Service.Interface
{
    public interface IMovieService
    {
        /// <summary>
        /// 建立電影清單
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<int> CreateMovieAsync(Movie movie);

        /// <summary>
        /// 取得所有電影列表
        /// </summary>
        /// <returns></returns>
        Task<IList<Movie>> GetMoviesAsync();

        /// <summary>
        /// 取得電影
        /// </summary>
        /// <param name="movieId">id號碼</param>
        /// <returns></returns>
        Task<Movie> GetMovieAsync(int movieId);

        /// <summary>
        /// 更新電影
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<int> UpdateMovieAsync(int id, UpdateMovieReq movie);

        /// <summary>
        /// 刪除電影
        /// </summary>
        /// <param name="movieId">id號碼</param>
        /// <returns></returns>
        Task<int> DeleteMovieAsync(int movieId);

    }
}
