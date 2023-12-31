using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Web.Service.Model
{
    public class Movie
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 標題
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 導演
        /// </summary>
        public string Director { get; set; } = string.Empty;

        /// <summary>
        /// 年分
        /// </summary>
        public int Year { get; set; }
    }
    public class UpdateMovieReq
    {

        /// <summary>
        /// 標題
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 導演
        /// </summary>
        public string Director { get; set; } = string.Empty;

        /// <summary>
        /// 年分
        /// </summary>
        public int Year { get; set; }
    }
}
