// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebJobs.Host.Storage.Logging;

namespace Microsoft.Extensions.Hosting
{
    public static class StorageServiceCollectionExtensions
    {
        [Obsolete("Dashboard is being deprecated. Use AppInsights.")]
        public static IServiceCollection AddDashboardLogging(this IServiceCollection services)
        {
            services.TryAddSingleton<LoggerProviderFactory>();

            services.TryAddSingleton<IFunctionOutputLoggerProvider>(p => p.GetRequiredService<LoggerProviderFactory>().GetLoggerProvider<IFunctionOutputLoggerProvider>());
            services.TryAddSingleton<IFunctionOutputLogger>(p => p.GetRequiredService<IFunctionOutputLoggerProvider>().GetAsync(CancellationToken.None).GetAwaiter().GetResult());

            services.TryAddSingleton<IFunctionInstanceLoggerProvider>(p => p.GetRequiredService<LoggerProviderFactory>().GetLoggerProvider<IFunctionInstanceLoggerProvider>());
            services.TryAddSingleton<IFunctionInstanceLogger>(p => p.GetRequiredService<IFunctionInstanceLoggerProvider>().GetAsync(CancellationToken.None).GetAwaiter().GetResult());

            services.TryAddSingleton<IHostInstanceLoggerProvider>(p => p.GetRequiredService<LoggerProviderFactory>().GetLoggerProvider<IHostInstanceLoggerProvider>());
            services.TryAddSingleton<IHostInstanceLogger>(p => p.GetRequiredService<IHostInstanceLoggerProvider>().GetAsync(CancellationToken.None).GetAwaiter().GetResult());

            return services;
        }
    }
}
