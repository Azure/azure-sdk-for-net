// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
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
    internal class BlobScaleHostEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
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
        public async Task BlobScaleHostEndToEndTest()
        {
            RandomNameResolver randomNameResolver = new RandomNameResolver();
            string containerName1 = randomNameResolver.ResolveInString(ContainerNameTemaplte1);
            BlobContainerClient client1 = _blobServiceClient.GetBlobContainerClient(containerName1);
            await client1.CreateIfNotExistsAsync();

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

            await client1.UploadBlobAsync("test1.txt", new BinaryData("test1"));
            await client1.UploadBlobAsync("test2.txt", new BinaryData("test2"));

            await TestHelpers.Await(async () =>
            {
                IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext() { WorkerCount = 0 });
                return scaleStatus.Vote == ScaleVote.ScaleOut && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.ScaleOut;
            });

            await TestHelpers.Await(async () =>
            {
                IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext() { WorkerCount = 1 });
                return scaleStatus.Vote == ScaleVote.ScaleIn && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.ScaleIn;
            });

            await TestHelpers.Await(async () =>
            {
                IScaleStatusProvider scaleStatusProvider = scaleHost.Services.GetService<IScaleStatusProvider>();

                var scaleStatus = await scaleStatusProvider.GetScaleStatusAsync(new ScaleStatusContext() { WorkerCount = 0 });
                return scaleStatus.Vote == ScaleVote.None && scaleStatus.FunctionScaleStatuses[Function1Name].Vote == ScaleVote.None;
            });
        }
    }
}
