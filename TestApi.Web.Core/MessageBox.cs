using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Web.Core
{
    public class MessageBox
    {
        public struct MessageText
        {
            //成功
            public const string CorrectResult = "正確";

            //失敗
            public const string NoParam = "請根據文件輸入必要參數";
            public const string Unauthorized = "此工號未授權使用此資料庫";
            public const string InvalidDateOrder = "起始日期不能晚於結束日期";
            public const string InvalidDateRange = "起迄時間不能超過三個月";

            //警告
            public const string NoData = "查無資料";
            public const string UnexpectedDataCount = "回傳資料量不符預期";
        }

        public struct MessageCodes
        {
            //成功
            public const string CorrectResult = "Z00";

            //失敗           
            public const string ErrorResult = "E99";
            public const string NoParam = "E01";
            public const string InvalidDateOrder = "E02";
            public const string InvalidDateRange = "E03";

            //警告
            public const string NoData = "W01";
            public const string UnexpectedDataCount = "W02";
        }
    }
}
