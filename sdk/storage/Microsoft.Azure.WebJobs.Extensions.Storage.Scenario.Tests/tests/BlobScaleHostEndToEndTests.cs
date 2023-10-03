// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.Storage.Scenario.Tests.QueueScaleHostEndToEndTests;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Scenario.Tests
{
    public class BlobScaleHostEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private const string TestArtifactsPrefix = "e2etest";
        private static AzureStorageEndToEndTests.TestFixture _fixture;
        private BlobServiceClient _blobServiceClient;

        private const string Function1Name = "Function1";

        private string ContainerNameTemaplte1 = "container1%rnd%";

        private const string BlobConnection1 = "BlobConnection1";

        [OneTimeSetUp]
        public void SetUp()
        {
            _fixture = new AzureStorageEndToEndTests.TestFixture(TestEnvironment);
            _blobServiceClient = _fixture.BlobServiceClient;
        }

        [Test]
        [TestCase(true, Ignore = "true", IgnoreReason = "The test can take long time.")]
        [TestCase(false)]
        public async Task BlobScaleHostEndToEndTest(bool writeBlob)
        {
            RandomNameResolver randomNameResolver = new RandomNameResolver();
            string containerName = randomNameResolver.ResolveInString(ContainerNameTemaplte1);
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync();

            string hostJson =
            @"{
                ""azureWebJobs"" : {
                    ""extensions"": {
                        ""blobs"": {
                            ""maxDegreeOfParallelism"" :  1,
                        }
                    }
                }
            }";

            string triggers = $@"{{
    ""triggers"": [
    {{
        ""name"": ""myQueueItem"",
        ""type"": ""queueTrigger"",
        ""direction"": ""in"",
        ""path"": ""test"",
        ""connection"": ""{BlobConnection1}"",
        ""functionName"": ""{Function1Name}""
    }}
    ]}}";

            IHost host = new HostBuilder().ConfigureServices(services => services.AddAzureClientsCore()).Build();
            AzureComponentFactory defaultAzureComponentFactory = host.Services.GetService<AzureComponentFactory>();

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
                    { BlobConnection1, TestEnvironment.PrimaryStorageAccountConnectionString }
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
                builder.AddAzureStorageBlobs(); //it looks like we do not need this for blobs
                builder.UseHostId(hostId);

                foreach (var jtoken in JObject.Parse(triggers)["triggers"])
                {
                    TriggerMetadata metadata = new TriggerMetadata(jtoken as JObject);
                    builder.AddAzureStorageBlobsScaleForTrigger(metadata);
                }
            },
            scaleOptions =>
            {
                scaleOptions.IsTargetScalingEnabled = false;
                scaleOptions.MetricsPurgeEnabled = false;
                scaleOptions.ScaleMetricsMaxAge = TimeSpan.FromMinutes(4);
                scaleOptions.IsRuntimeScalingEnabled = true;
                scaleOptions.ScaleMetricsSampleInterval = TimeSpan.FromSeconds(1);
            });

            IHost scaleHost = hostBuilder.Build();
            await scaleHost.StartAsync();

            int timeout = (60 * 1000); // 1 minute
            if (writeBlob)
            {
                // Add new blobs
                await blobContainerClient.UploadBlobAsync("test1.txt", new BinaryData("test1"));
                await blobContainerClient.UploadBlobAsync("test2.txt", new BinaryData("test2"));
                timeout = (60 * 1000) * 60; // 20 minutes
            }
            else
            {
                SetRecentWrite(scaleHost, blobContainerClient, true);
            }

            // Wait until logs are populated and there is the "scale out" vote
            await TestHelpers.Await(async () =>
            {
                IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext() { WorkerCount = 0 });
                return scaleStatus.Vote == ScaleVote.ScaleOut && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.ScaleOut;
            }, timeout);

            if (!writeBlob)
            {
                SetRecentWrite(scaleHost, blobContainerClient, false);
            }

            // Emulate adding a worker, after adding the worker
            await TestHelpers.Await(async () =>
            {
                IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext() { WorkerCount = 1 });
                return scaleStatus.Vote == ScaleVote.ScaleIn && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.ScaleIn;
            }, timeout);

            // Emulate removing the worker
            await TestHelpers.Await(async () =>
            {
                IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext() { WorkerCount = 0 });
                return scaleStatus.Vote == ScaleVote.None && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.None;
            }, timeout);
        }

        private void SetRecentWrite(IHost scaleHost, BlobContainerClient blobContainerClient, bool setValue)
        {
            IScaleMonitor<ScaleMetrics> zeroToOneScaleMonitor = scaleHost.Services.GetService<IScaleMonitor<ScaleMetrics>>();
            var monitorProvider = scaleHost.Services.GetService<IScaleMonitorProvider>();
            IScaleMonitor scaleMonitor = monitorProvider.GetMonitor();
            FieldInfo field = scaleMonitor.GetType().GetField("_recentWrite", BindingFlags.NonPublic | BindingFlags.Instance);
            var ctor = field.FieldType.GetTypeInfo().GetConstructors(BindingFlags.Public | BindingFlags.Instance).First();
            var instance = setValue ? ctor.Invoke(new object[] { blobContainerClient, blobContainerClient.GetBlobBaseClient("test") }) : null;
            field.SetValue(scaleMonitor, instance);
        }
    }
}
