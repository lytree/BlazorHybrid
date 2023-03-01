# BlazorHybrid
构建 Blazor Server, Blazor WASM, Blazor WPF和 MAUI Blazor App 模板

## 项目结构

- Platforms
  - BlazorMauiApp
    - .NET MAUI Blazor App project
  - BlazorServerApp
    - ASP.NET Core Blazor Server App project
  - BlazorWasmApp
    - ASP.NET Core Blazor WebAssembly project
  - BlazorWPFApp
    - ASP.NET Core Blazor WPF project
- BlazorShared
  - All razor components and shared C# code files

## 依赖
- [antblazor](https://antblazor.com/zh-CN/docs/introduce)
    - Ant Design 的 Blazor 实现
- [tailwindcss](https://tailwindcss.com/docs/installation)
    - 一个CSS的框架
- [ASP.NET Core Blazor](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/?WT.mc_id=DT-MVP-5003987&view=aspnetcore-7.0)
    - 一个使用 Blazor 生成交互式客户端 Web UI 的框架

## 开发
- 环境配置
    - tailwindcss-cli
    - .net 6或以上
- 运行
    - `tailwindcss -i .\BlazorShared\Style\atomic.css -o .\BlazorShared\wwwroot\css\atomic.css  --watch`

- 构建
    - `tailwindcss -i .\BlazorShared\Style\atomic.css -o .\BlazorShared\wwwroot\css\atomic.css  --minify`







