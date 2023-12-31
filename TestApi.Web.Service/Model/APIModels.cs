using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Web.Service.Model
{
    public class APIReqHeader
    {
        /// <summary>
        /// 使用者Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 公司代號
        /// </summary>
        public string? Dept { get; set; }
        /// <summary>
        /// 使用者ID
        /// </summary>
        public string? UserNo { get; set; }
    }

    public class APIResHeader
    {
        /// <summary>
        /// 訊息代號
        /// </summary>
        public string? MessageCode { get; set; }
        /// <summary>
        /// 訊息內容
        /// </summary>
        public string? Message { get; set; }
    }

    public class APIReq
    {
        /// <summary>
        /// 標頭
        /// </summary>
        public APIReqHeader? Header { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public dynamic? Payload { get; set; }
    }

    public class APIRes
    {
        /// <summary>
        /// 標頭
        /// </summary>
        public APIResHeader? Header { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public DataSource? Payload { get; set; }
    }

    public class DataSource
    {
        /// <summary>
        /// 資料筆數
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// 資料內容
        /// </summary>
        public dynamic? Data { get; set; }
    }
}
