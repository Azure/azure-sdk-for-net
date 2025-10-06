// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class WebJobsEventHubTestBase
    {
        protected const string TestHubName = "%webjobstesthub%";
        protected static readonly int Timeout = (int)EventHubsTestEnvironment.Instance.TestExecutionTimeLimit.TotalMilliseconds;

        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        protected EventHubScope _eventHubScope;

        /// <summary>
        ///   Performs the tasks needed to initialize each test.  This
        ///   method runs once for the each test prior to running it.
        /// </summary>
        ///
        [SetUp]
        public async Task BaseSetUp()
        {
            _eventHubScope = await EventHubScope.CreateAsync(2);
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup tests after it has run.  This
        ///   method runs once for each test.
        /// </summary>
        ///
        [TearDown]
        public async Task BaseTearDown()
        {
            await _eventHubScope.DisposeAsync();
        }

        protected void ConfigureTestEventHub(IHostBuilder builder)
        {
            builder
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"webjobstesthub", _eventHubScope.EventHubName},
                        {"AzureWebJobsStorage", StorageTestEnvironment.Instance.StorageConnectionString},
                        {_eventHubScope.EventHubName, EventHubsTestEnvironment.Instance.EventHubsConnectionString}
                    });
                });
        }

        protected (JobHost JobHost, IHost Host) BuildHost<T>(Action<IHostBuilder> configurationDelegate = null, Action<IHost> preStartCallback = null)
        {
            configurationDelegate ??= ConfigureTestEventHub;

            var hostBuilder = new HostBuilder();
            hostBuilder
                .ConfigureServices(services =>
                {
                    services.AddAzureClients(clientBuilder =>
                    {
                        clientBuilder.UseCredential(EventHubsTestEnvironment.Instance.Credential);
                    });
                })
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"webjobstesthub", _eventHubScope.EventHubName},
                        {"AzureWebJobsStorage__accountName", StorageTestEnvironment.Instance.StorageAccountName}
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

        protected int GetRemainingTimeoutMilliseconds(TimeSpan elapsedTime) =>
            (int)(Timeout - elapsedTime.TotalMilliseconds);
    }
}