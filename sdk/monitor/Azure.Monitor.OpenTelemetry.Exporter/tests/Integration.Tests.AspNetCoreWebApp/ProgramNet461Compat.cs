// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET461
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.AspNetCoreWebApp
{
    public partial class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
#endif
