// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class WebJobsEventHubTestBase
    {
        protected const string TestHubName = "%webjobstesthub%";
        protected const int Timeout = 30000;

        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        protected EventHubScope _eventHubScope;

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [SetUp]
        public async Task FixtureSetUp()
        {
            _eventHubScope = await EventHubScope.CreateAsync(2);
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test fixture after all
        ///   tests have run.  This method runs once for the entire fixture.
        /// </summary>
        ///
        [TearDown]
        public async Task FixtureTearDown()
        {
            await _eventHubScope.DisposeAsync();
        }

        protected void ConfigureTestEventHub(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Configure<EventHubOptions>(options =>
                {
                    options.AddSender(_eventHubScope.EventHubName, EventHubsTestEnvironment.Instance.EventHubsConnectionString);
                    options.AddReceiver(_eventHubScope.EventHubName, EventHubsTestEnvironment.Instance.EventHubsConnectionString);
                });
            });
        }

        protected (JobHost, IHost) BuildHost<T>(Action<IHostBuilder> configurationDelegate = null, Action<IHost> preStartCallback = null)
        {
            configurationDelegate ??= ConfigureTestEventHub;

            var hostBuilder = new HostBuilder();
            hostBuilder
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"webjobstesthub", _eventHubScope.EventHubName},
                        {"AzureWebJobsStorage", StorageTestEnvironment.Instance.StorageConnectionString}
                    });
                })
                .ConfigureDefaultTestHost<T>(b =>
                {
                    b.AddEventHubs(options =>
                    {
                        options.EventProcessorOptions.TrackLastEnqueuedEventProperties = true;
                        options.EventProcessorOptions.MaximumWaitTime = TimeSpan.FromSeconds(5);
                        options.CheckpointContainer = Guid.NewGuid().ToString("D").Substring(0, 13);
                    });
                })
                .ConfigureLogging(b =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);
                });
            configurationDelegate(hostBuilder);
            IHost host = hostBuilder.Build();

            preStartCallback?.Invoke(host);

            JobHost jobHost = host.GetJobHost();
            jobHost.StartAsync().GetAwaiter().GetResult();

            return (jobHost, host);
        }
    }
}