TestApi.Web.sln                          → 整體解決方案 (Solution)
│
├── TestApi.Web.Core                    → 核心層：放置共用工具與輔助程式
│   ├── Helper/
│   │   ├── DapperHelper.cs            → 封裝 Dapper 操作的資料庫輔助類別
│   │   └── MessageBox.cs              → 訊息顯示與處理輔助類別
│   └── TestApi.Web.Core.csproj        → Core 專案檔
│
├── TestApi.Web.Service                 → 服務層：商業邏輯與資料處理
│   ├── Interface/                      → 定義服務層的介面 (例如 IService)
│   ├── Model/                          → 定義資料模型或 DTO
│   ├── Service/                        → 服務實作 (例如 MovieService)
│   └── TestApi.Web.Service.csproj     → Service 專案檔
│
├── TestApi.Web                         → 表層 (API)：主要對外 API 接口
│   ├── Controllers/
│   │   ├── BaseApiController.cs       → API 共用基底控制器
│   │   └── MoviesController.cs        → 處理電影相關 API 的控制器
│   ├── Properties/
│   │   └── launchSettings.json        → 設定 API 啟動環境 (VS 調試用途)
│   ├── Program.cs                     → ASP.NET Core 程式進入點
│   ├── appsettings.json               → 全域設定檔（例如連線字串）
│   ├── appsettings.Development.json   → 開發環境設定檔
│   └── TestApi.Web.csproj             → Web 專案檔
