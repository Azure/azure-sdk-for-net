// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Scenario.Tests
{
    public class QueueScaleHostEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private const string TestArtifactsPrefix = "e2etest";
        private static AzureStorageEndToEndTests.TestFixture _fixture;
        private QueueServiceClient _queueServiceClient;

        private const string Function1Name = "Function1";
        private const string Function2Name = "Function2";

        private string QueueNameTemaplte1 = "queue1%rnd%";
        private string QueueNameTemaplte2 = "queue2%rnd%";

        private const string QueueConnection1 = "QueueConnection1";
        private const string QueueConnection2 = "QueueConnection2";

        [OneTimeSetUp]
        public void SetUp()
        {
            _fixture = new AzureStorageEndToEndTests.TestFixture(TestEnvironment);
            _queueServiceClient = _fixture.QueueServiceClient;
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task ScaleHostEndToEndTest(bool tbsEnabled)
        {
            RandomNameResolver randomNameResolver = new RandomNameResolver();
            string queueName1 = randomNameResolver.ResolveInString(QueueNameTemaplte1);
            string queueName2 = randomNameResolver.ResolveInString(QueueNameTemaplte2);
            QueueClient client1 = _queueServiceClient.GetQueueClient(queueName1);
            await client1.CreateIfNotExistsAsync();
            QueueClient client2 = _queueServiceClient.GetQueueClient(queueName2);
            await client2.CreateIfNotExistsAsync();

            string hostJson =
            @"{
                ""azureWebJobs"" : {
                    ""extensions"": {
                        ""queues"": {
                            ""batchSize"" :  1,
                            ""newBatchThreshold"": 0
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
                    ""type"": ""queueTrigger"",
                    ""direction"": ""in"",
                    ""queueName"": ""{queueName1}"",
                    ""connection"": ""{QueueConnection1}"",
                    ""functionName"": ""{Function1Name}""
                }},
                {{
                    ""name"": ""myQueueItem"",
                    ""type"": ""queueTrigger"",
                    ""direction"": ""in"",
                    ""queueName"": ""{queueName2}"",
                    ""connection"": ""{QueueConnection2}"",
                    ""functionName"": ""{Function2Name}""
                }}
             ]}}";

            IHost host = new HostBuilder().ConfigureServices(services => services.AddAzureClientsCore()).Build();
            AzureComponentFactory defaultAzureComponentFactory = host.Services.GetService<AzureComponentFactory>();

            var container = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>() { { QueueConnection1, TestEnvironment.PrimaryStorageAccountConnectionString } })
                .Build();
            //var credentials = defaultAzureComponentFactory.CreateTokenCredential(container.GetSection(QueueConnection1));
            TestComponentFactory factoryWrapper = new TestComponentFactory(defaultAzureComponentFactory, TestEnvironment.Credential);

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
                    { QueueConnection1, TestEnvironment.PrimaryStorageAccountConnectionString },
                    { $"{QueueConnection2}:queueServiceUri", _fixture.QueueServiceClient.Uri.AbsoluteUri }
                };

                // Adding app setting
                config.AddInMemoryCollection(settings);
            })
            .ConfigureServices(services =>
            {
                services.AddAzureStorageScaleServices();

                services.AddSingleton<INameResolver, FakeNameResolver>();
            })
            .ConfigureWebJobsScale((context, builder) =>
            {
                builder.AddAzureStorageQueues();
                builder.UseHostId(hostId);

                foreach (var jtoken in JObject.Parse(triggers)["triggers"])
                {
                    TriggerMetadata metadata = new TriggerMetadata(jtoken as JObject);
                    if (metadata.FunctionName == Function2Name)
                    {
                        metadata.Properties[nameof(AzureComponentFactory)] = factoryWrapper;
                    }
                    builder.AddAzureStorageQueuesScaleForTrigger(metadata);
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

            // add some messages to the queue
            await client1.SendMessageAsync("test");
            await client1.SendMessageAsync("test");
            await client2.SendMessageAsync("test");
            await client2.SendMessageAsync("test");
            await client2.SendMessageAsync("test");

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
                        scaledOut = scaleStatus.Vote == ScaleVote.ScaleOut && scaleStatus.TargetWorkerCount == 3
                         && scaleStatus.FunctionTargetScalerResults[Function1Name].TargetWorkerCount == 2
                         && scaleStatus.FunctionTargetScalerResults[Function2Name].TargetWorkerCount == 3;

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
                }, pollingInterval: 2000, timeout: 120000, throwWhenDebugging: true);
            }
            catch (Exception)
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
