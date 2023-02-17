// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET461
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Azure.Monitor.OpenTelemetry.Demo
{
    public partial class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
#endif
