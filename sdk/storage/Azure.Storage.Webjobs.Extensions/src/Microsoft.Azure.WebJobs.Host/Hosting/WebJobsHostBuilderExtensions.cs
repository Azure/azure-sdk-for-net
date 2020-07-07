// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    public static class WebJobsHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWebJobs(this IHostBuilder builder)
        {
            return builder.ConfigureWebJobs(o => { }, o => { });
        }

        public static IHostBuilder ConfigureWebJobs(this IHostBuilder builder, Action<IWebJobsBuilder> configure)
        {
            return builder.ConfigureWebJobs(configure, o => { });
        }

        public static IHostBuilder ConfigureWebJobs(this IHostBuilder builder, Action<IWebJobsBuilder> configure, Action<JobHostOptions> configureOptions)
        {
            return builder.ConfigureWebJobs((context, b) => configure(b), configureOptions);
        }

        public static IHostBuilder ConfigureWebJobs(this IHostBuilder builder, Action<HostBuilderContext, IWebJobsBuilder> configure)
        {
            return builder.ConfigureWebJobs(configure, o => { });
        }

        public static IHostBuilder ConfigureWebJobs(this IHostBuilder builder, Action<HostBuilderContext, IWebJobsBuilder> configure, Action<JobHostOptions> configureOptions)
        {
            return ConfigureWebJobs(builder, configure, configureOptions, (c, b) => { });
        }

        public static IHostBuilder ConfigureWebJobs(this IHostBuilder builder, Action<HostBuilderContext, IWebJobsBuilder> configure,
            Action<JobHostOptions> configureOptions, Action<HostBuilderContext, IWebJobsConfigurationBuilder> configureAppConfiguration)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();

                configureAppConfiguration?.Invoke(context, new WebJobsConfigurationBuilder(config));
            });

            builder.ConfigureServices((context, services) =>
            {
                IWebJobsBuilder webJobsBuilder = services.AddWebJobs(configureOptions);
                configure?.Invoke(context, webJobsBuilder);

                services.TryAddEnumerable(ServiceDescriptor.Singleton<IHostedService, JobHostService>());
            });

            return builder;
        }
    }
}