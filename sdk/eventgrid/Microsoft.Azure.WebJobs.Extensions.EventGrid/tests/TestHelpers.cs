// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Config;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    internal static class TestHelpers
    {
        public static IHost NewHost<T>(EventGridExtensionConfigProvider ext = null, Dictionary<string, string> configuration = null, RecordedTestBase recording = null)
        {
            return NewHost<T>(ext == null ? null : provider => ext, configuration, recording);
        }

        public static IHost NewHost<T>(Func<IServiceProvider, EventGridExtensionConfigProvider> ext, Dictionary<string, string> configuration = null, RecordedTestBase recording = null)
        {
            var builder = new HostBuilder()
           .ConfigureServices(services =>
           {
               services.AddSingleton<ITypeLocator>(new FakeTypeLocator<T>());
               if (ext != null)
               {
                   services.AddSingleton<IExtensionConfigProvider>(ext);
               }

               services.AddSingleton<IExtensionConfigProvider>(new TestExtensionConfig());
           })
           .ConfigureWebJobs(webJobsBuilder =>
           {
               webJobsBuilder.AddEventGrid();
               webJobsBuilder.UseHostId(Guid.NewGuid().ToString("n"));
               if (recording is { Mode: RecordedTestMode.Record } or { Mode: RecordedTestMode.Playback })
               {
                   webJobsBuilder.Services.AddSingleton(recording);
                   webJobsBuilder.Services.AddSingleton<EventGridAsyncCollectorFactory, InstrumentedCollectorFactory>();
               }
           })
           .ConfigureLogging(logging =>
           {
               logging.ClearProviders();
               logging.AddProvider(new TestLoggerProvider());
           });

            if (configuration != null)
            {
                builder.ConfigureAppConfiguration(b =>
                {
                    b.AddInMemoryCollection(configuration);
                });
            }

            return builder.Build();
        }

        public static JobHost GetJobHost(this IHost host)
        {
            return host.Services.GetService<IJobHost>() as JobHost;
        }
    }
}