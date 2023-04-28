// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace CoreWCF.AzureQueueStorage.Tests.Helpers
{
    public static class ServiceHelper
    {
        public static IWebHostBuilder CreateWebHostBuilder<TStartup>(ITestOutputHelper outputHelper)
            where TStartup : class
        {
            return WebHost.CreateDefaultBuilder(Array.Empty<string>())
#if DEBUG
                .ConfigureLogging((logging) =>
                {
                    logging.AddProvider(new XunitLoggerProvider(outputHelper, nameof(CreateWebHostBuilder)));
                    logging.AddFilter("Default", LogLevel.Debug);
                    logging.AddFilter("Microsoft", LogLevel.Debug);
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
#endif // DEBUG
                .UseStartup<TStartup>();
        }
    }
}
