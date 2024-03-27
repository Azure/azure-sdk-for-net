// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers
{
    public static class ServiceHelper
    {
        public static IWebHostBuilder CreateWebHostBuilder<TStartup>()
            where TStartup : class
        {
            return WebHost.CreateDefaultBuilder(Array.Empty<string>())
#if DEBUG
                .ConfigureLogging((logging) =>
                {
                    logging.AddFilter("Default", LogLevel.Debug);
                    logging.AddFilter("Microsoft", LogLevel.Debug);
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
#endif // DEBUG
                .UseStartup<TStartup>();
        }
    }
}
