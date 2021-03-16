// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    public class EventGridBlobTriggerEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private const string TestArtifactPrefix = "e2etests";
        private const string EventGridContainerName = TestArtifactPrefix + "eventgrid-%rnd%";
        private const string TestBlobName = "test";
        private readonly string _resolvedContainerName;

        private readonly BlobContainerClient _testContainer;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly RandomNameResolver _nameResolver;

        private const string RegistrationRequest =
 @"[{
  ""id"": ""09473e51-90aa-4a7b-88f1-039ea0d7ee64"",
  ""topic"": ""/subscriptions/[subId]/resourceGroups/EventGrid/providers/Microsoft.Storage/StorageAccounts/alrodegtest"",
  ""subject"": """",
  ""data"": {
    ""validationCode"": ""F83B17BA-898A-4309-8F89-8BB2B3A06D02"",
    ""validationUrl"": ""https://[region].eventgrid.azure.net:553/eventsubscriptions/eg1/validate?id=F83B17BA-898A-4309-8F89-8BB2B3A06D02&t=2020-12-08T02:28:30.6463986Z&apiVersion=2020-04-01-preview&token=AEvNcDi9Gonj83RQEK4owr6zXA31QPzppkc7BwlvBeI%3d""
  },
  ""eventType"": ""Microsoft.EventGrid.SubscriptionValidationEvent"",
  ""eventTime"": ""2020-12-08T02:28:30.6463986Z"",
  ""metadataVersion"": ""1"",
  ""dataVersion"": ""2""
}]";

        private const string NotificationRequest =
@"[{
    ""topic"":""/subscriptions/[subId]/resourceGroups/EventGrid/providers/Microsoft.Storage/storageAccounts/alrodegtest"",
    ""subject"":""/blobServices/default/containers/sample-workitems/blobs/blob.txt"",
    ""eventType"":""Microsoft.Storage.BlobCreated"",
    ""id"":""e5c50ef5-f01e-0017-048b-d20b04066601"",
    ""data"":{
    ""api"":""PutBlob"",
    ""clientRequestId"":""8dd38cbd-67e6-473e-a64c-e4d715ed0a52"",
    ""requestId"":""e5c50ef5-f01e-0017-048b-d20b04000000"",
    ""eTag"":""0x8D8A0A2FA6E70FF"",
    ""contentType"":""application/octet-stream"",
    ""contentLength"":1,
    ""blobType"":""BlockBlob"",
    ""url"":""https://test.blob.core.windows.net/[blobPathPlaceHolder]"",
    ""sequencer"":""000000000000000000000000000089AE00000000018dd658"",
    ""storageDiagnostics"":{
    ""batchId"":""aea96df5-b006-0006-008b-d291b0000000""
    }
    },
    ""dataVersion"":"""",
    ""metadataVersion"":""1"",
    ""eventTime"":""2020-12-15T02:41:51.9623179Z""
    }
]";

        public EventGridBlobTriggerEndToEndTests()
        {
            _nameResolver = new RandomNameResolver();

            // pull from a default host
            var host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddAzureStorageBlobs().AddAzureStorageQueues();
                })
                .Build();
            _blobServiceClient = new BlobServiceClient(TestEnvironment.PrimaryStorageAccountConnectionString);
            _resolvedContainerName = _nameResolver.ResolveInString(EventGridContainerName);
            _testContainer = _blobServiceClient.GetBlobContainerClient(_resolvedContainerName);
            Assert.False(_testContainer.ExistsAsync().Result);
            _testContainer.CreateAsync().Wait();
        }

        public IHostBuilder NewBuilder<TProgram>(TProgram program, Action<IWebJobsBuilder> configure = null)
        {
            var activator = new FakeActivator();
            activator.Add(program);

            return new HostBuilder()
                .ConfigureDefaultTestHost<TProgram>(b =>
                {
                    IWebJobsBuilder builder = b.AddAzureStorageBlobs().AddAzureStorageQueues();
                    var ss = builder.Services.BuildServiceProvider();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobActivator>(activator);
                    services.AddSingleton<INameResolver>(_nameResolver);
                });
        }

        [Test]
        public async Task EventGridRequest_Subscription_Succeeded()
        {
            var prog = new EventGrid_Program();
            var host = NewBuilder(prog).Build();

            using (host)
            {
                host.Start();
                HttpResponseMessage response = await SendEventGridRequest(host, RegistrationRequest, "SubscriptionValidation");
                Assert.True(response.StatusCode == HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task EventGridRequest_Notification_Succeeded()
        {
            var blob = _testContainer.GetBlockBlobClient(TestBlobName);
            await blob.UploadTextAsync("0");

            var prog = new EventGrid_Program();
            var host = NewBuilder(prog).Build();

            using (prog._completedEvent = new ManualResetEvent(initialState: false))
            using (host)
            {
                host.Start();
                HttpResponseMessage response = await SendEventGridRequest(host, NotificationRequest.Replace("[blobPathPlaceHolder]", _resolvedContainerName + "/" + TestBlobName), "Notification");
                Assert.True(response.StatusCode == HttpStatusCode.Accepted);
                Assert.True(prog._completedEvent.WaitOne(TimeSpan.FromSeconds(60)));
            }
        }

        [Test]
        public async Task PageBlob_NotSupported()
        {
            var prog = new EventGrid_PageBlob();
            var host = NewBuilder(prog).Build();

            using (host)
            {
                host.Start();
                await Task.Delay(5000); // Wait util all logs a re populated
                var log = host.GetTestLoggerProvider().GetAllLogMessages()
                    .FirstOrDefault(x => x.Level == Microsoft.Extensions.Logging.LogLevel.Error && x.FormattedMessage == $"PageBlobClient is not supported with {nameof(BlobTriggerSource.EventGrid)}");
                Assert.IsNotNull(log);
            }
        }

        private async Task<HttpResponseMessage> SendEventGridRequest(IHost host, string content, string eventType)
        {
            var configProvidersEnumerator = host.Services.GetServices(typeof(IExtensionConfigProvider)).GetEnumerator();
            while (configProvidersEnumerator.MoveNext())
            {
                if (configProvidersEnumerator.Current is IAsyncConverter<HttpRequestMessage, HttpResponseMessage> convertor)
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://test?functionName=EventGridBlobTrigger");
                    request.Content = new StringContent(content);
                    request.Headers.Add("Aeg-Event-Type", eventType);
                    return await convertor.ConvertAsync(request, CancellationToken.None);
                }
            }

            throw new Exception("IAsyncConverter was not found");
        }

        public class EventGrid_Program
        {
            public ManualResetEvent _completedEvent;

            [FunctionName("EventGridBlobTrigger")]
            public void EventGridBlobTrigger(
                [BlobTrigger(EventGridContainerName + "/{name}", Source = BlobTriggerSource.EventGrid)] string input)
            {
                _completedEvent.Set();
            }
        }

        public class EventGrid_PageBlob
        {
            [FunctionName("EventGridBlobTrigger")]
            public void EventGridBlobTrigger(
                [BlobTrigger(EventGridContainerName + "/{name}", Source = BlobTriggerSource.EventGrid)] PageBlobClient input)
            {
            }
        }
    }
}
