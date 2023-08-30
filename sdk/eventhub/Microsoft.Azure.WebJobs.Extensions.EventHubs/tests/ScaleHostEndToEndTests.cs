// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.Host.EndToEndTests;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests
{
    [NonParallelizable]
    [LiveOnly(true)]
    public class ScaleHostEndToEndTests : WebJobsEventHubTestBase
    {
        private const string Function1Name = "Function1";
        private const string Function2Name = "Function2";

        private const string EventHubConnection1 = "EventHubConnection1";
        private const string EventHubConnection2 = "EventHubConnection2";

        /// <summary>
        ///   Performs the tasks needed to initialize each test.  This
        ///   method runs once for the each test prior to running it.
        /// </summary>
        ///
        [SetUp]
        public new async Task BaseSetUp()
        {
            _eventHubScope = await EventHubScope.CreateAsync(2, new List<string>() { "ConsumerGroup" });
        }

        public ScaleHostEndToEndTests() : base()
        {
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task ScaleHostEndToEndTest(bool tbsEnabled)
        {
            string hostJson =
            @"{
                ""azureWebJobs"" : {
                    ""extensions"": {
                        ""eventHubs"": {
                            ""targetUnprocessedEventThreshold"": 1
                        }
                    }
                }
            }";

            // Function1Name uses connection string
            // Function2Name uses AzureComponentFactory - simulating managed identity scenario in ScaleController
            string triggers = $@"{{
""triggers"": [
    {{
        ""name"": ""myQueueItem"",
        ""type"": ""eventHubsTrigger"",
        ""direction"": ""in"",
        ""eventHubName"": ""{_eventHubScope.EventHubName}"",
        ""consumerGroup"": ""{_eventHubScope.ConsumerGroups[0]}"",
        ""connection"": ""{EventHubConnection1}"",
        ""functionName"": ""{Function1Name}""
    }},
    {{
        ""name"": ""myQueueItem"",
        ""type"": ""serviceBusTrigger"",
        ""direction"": ""in"",
        ""eventHubName"": ""{_eventHubScope.EventHubName}"",
        ""consumerGroup"": ""{_eventHubScope.ConsumerGroups[1]}"",
        ""connection"": ""{EventHubConnection2}"",
        ""functionName"": ""{Function2Name}""
    }}
 ]}}";

            IHost host = new HostBuilder().ConfigureServices(services => services.AddAzureClientsCore()).Build();
            AzureComponentFactory defaultAzureComponentFactory = host.Services.GetService<AzureComponentFactory>();
            TestComponentFactory factoryWrapper = new TestComponentFactory(defaultAzureComponentFactory, EventHubsTestEnvironment.Instance.Credential);

            string hostId = "test-host";
            var loggerProvider = new TestLoggerProvider();

            IHostBuilder hostBuilder = new HostBuilder();
            hostBuilder.ConfigureLogging(configure =>
            {
                configure.SetMinimumLevel(LogLevel.Debug);
                configure.AddProvider(loggerProvider);
            });
            hostBuilder.ConfigureAppConfiguration((hostBuilderContext, config) =>
            {
                // Adding host.json here
                config.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(hostJson)));

                var settings = new Dictionary<string, string>()
                {
                    { $"{EventHubConnection1}", EventHubsTestEnvironment.Instance.EventHubsConnectionString },
                    { $"{EventHubConnection2}:fullyQualifiedNamespace", EventHubsTestEnvironment.Instance.FullyQualifiedNamespace },
                    { "AzureWebJobsStorage", StorageTestEnvironment.Instance.StorageConnectionString }
                };

                // Adding app setting
                config.AddInMemoryCollection(settings);
            })
            .ConfigureServices(services =>
            {
                services.AddAzureStorageScaleServices();

                FakeNameResolver nameResolver = new FakeNameResolver();
                nameResolver.Add(EventHubConnection1, EventHubsTestEnvironment.Instance.EventHubsConnectionString);
                nameResolver.Add(EventHubConnection2, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace);
                services.AddSingleton<INameResolver>(nameResolver);
            })
            .ConfigureWebJobsScale((context, builder) =>
            {
                builder.AddEventHubs();
                builder.UseHostId(hostId);

                foreach (var jtoken in JObject.Parse(triggers)["triggers"])
                {
                    TriggerMetadata metadata = new TriggerMetadata(jtoken as JObject);
                    if (metadata.FunctionName == Function2Name)
                    {
                        metadata.Properties[nameof(AzureComponentFactory)] = factoryWrapper;
                    }
                    builder.AddEventHubsScaleForTrigger(metadata);
                }
            },
            scaleOptions =>
            {
                scaleOptions.IsTargetScalingEnabled = tbsEnabled;
                scaleOptions.MetricsPurgeEnabled = false;
                scaleOptions.ScaleMetricsMaxAge = TimeSpan.FromMinutes(4);
                scaleOptions.IsRuntimeScalingEnabled = true;
                scaleOptions.ScaleMetricsSampleInterval = TimeSpan.FromSeconds(1);
            });

            IHost scaleHost = hostBuilder.Build();
            await scaleHost.StartAsync();

            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });

            var opstions = scaleHost.GetOptions<EventHubOptions>();
            var blobContainerClient = new BlobContainerClient(StorageTestEnvironment.Instance.StorageConnectionString, opstions.CheckpointContainer);
            var blobCheckpointStoreInternal1 = new BlobCheckpointStoreInternal(blobContainerClient, Function1Name, loggerProvider.CreateLogger("Test"));
            await blobCheckpointStoreInternal1.CreateIfNotExistsAsync(CancellationToken.None);
            var blobCheckpointStoreInternal2 = new BlobCheckpointStoreInternal(blobContainerClient, Function2Name, loggerProvider.CreateLogger("Test"));
            await blobCheckpointStoreInternal2.CreateIfNotExistsAsync(CancellationToken.None);

            try
            {
                await TestHelpers.Await(async () =>
                {
                    IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                    var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext());

                    bool scaledOut = false;
                    if (!tbsEnabled)
                    {
                        scaledOut = scaleStatus.Vote == ScaleVote.ScaleOut && scaleStatus.TargetWorkerCount == null
                         && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.ScaleOut
                         && scaleStatus.FunctionScaleStatuses[Function2Name].Vote == ScaleVote.ScaleOut;

                        if (scaledOut)
                        {
                            var logMessages = loggerProvider.GetAllLogMessages().Select(p => p.FormattedMessage).ToArray();
                            Assert.Contains("2 scale monitors to sample", logMessages);
                        }
                    }
                    else
                    {
                        scaledOut = scaleStatus.Vote == ScaleVote.ScaleOut && scaleStatus.TargetWorkerCount == 2
                         && scaleStatus.FunctionTargetScalerResults[Function1Name].TargetWorkerCount == 2
                         && scaleStatus.FunctionTargetScalerResults[Function2Name].TargetWorkerCount == 2;

                        if (scaledOut)
                        {
                            var logMessages = loggerProvider.GetAllLogMessages().Select(p => p.FormattedMessage).ToArray();
                            Assert.Contains("2 target scalers to sample", logMessages);
                        }
                    }

                    if (scaledOut)
                    {
                        var logMessages = loggerProvider.GetAllLogMessages().Select(p => p.FormattedMessage).ToArray();
                        Assert.IsNotEmpty(logMessages.Where(x => x.StartsWith("Runtime scale monitoring is enabled.")));
                        if (!tbsEnabled)
                        {
                            Assert.Contains("Scaling out based on votes", logMessages);
                        }
                    }

                    return scaledOut;
                }, pollingInterval: 2000, timeout: 180000, throwWhenDebugging: true);
            }
            catch (ApplicationException)
            {
                // Write scale logs to the output:
                var logMessages = loggerProvider.GetAllLogMessages().Where(x => x.Category.Contains("Scale")).Select(p => p.FormattedMessage).ToArray();
                foreach (var logMessage in logMessages)
                {
                    TestContext.WriteLine(logMessage);
                }
                throw;
            }
        }
    }
}
