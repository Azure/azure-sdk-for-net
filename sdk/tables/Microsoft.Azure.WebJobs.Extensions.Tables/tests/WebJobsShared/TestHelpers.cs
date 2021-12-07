// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    internal static class TestHelpers
    {
        public static IHostBuilder ConfigureDefaultTestHost(this IHostBuilder builder, Action<IWebJobsBuilder> configureWebJobs, params Type[] types)
        {
            return builder.ConfigureWebJobs(configureWebJobs)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ITypeLocator>(new FakeTypeLocator(types));
                    // Register this to fail a test if a background exception is thrown
                    services.AddSingleton<IWebJobsExceptionHandlerFactory, TestExceptionHandlerFactory>();
                })
                .ConfigureTestLogger();
        }

        public static IHostBuilder ConfigureTestLogger(this IHostBuilder builder)
        {
            return builder.ConfigureLogging(logging =>
             {
                 logging.AddProvider(new TestLoggerProvider());
             });
        }
    }
}