// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    public class BlobTriggerEndToEndTests : LiveTestBase<WebJobsTestEnvironment>, IDisposable
    {
        private const string TestArtifactPrefix = "e2etests";

        private const string SingleTriggerContainerName = TestArtifactPrefix + "singletrigger-%rnd%";
        private const string PoisonTestContainerName = TestArtifactPrefix + "poison-%rnd%";
        private const string TestBlobName = "test";

        private const string BlobChainContainerName = TestArtifactPrefix + "blobchain-%rnd%";
        private const string BlobChainTriggerBlobName = "blob";
        private const string BlobChainTriggerBlobPath = BlobChainContainerName + "/" + BlobChainTriggerBlobName;
        private const string BlobChainCommittedQueueName = "committed";
        private const string BlobChainIntermediateBlobPath = BlobChainContainerName + "/" + "blob.middle";
        private const string BlobChainOutputBlobName = "blob.out";
        private const string BlobChainOutputBlobPath = BlobChainContainerName + "/" + BlobChainOutputBlobName;

        private readonly BlobContainerClient _testContainer;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly RandomNameResolver _nameResolver;

        private static object _syncLock = new object();

        public BlobTriggerEndToEndTests()
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
            _testContainer = _blobServiceClient.GetBlobContainerClient(_nameResolver.ResolveInString(SingleTriggerContainerName));
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
                    b.AddAzureStorageBlobs().AddAzureStorageQueues();
                    configure?.Invoke(b);
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobActivator>(activator);
                    services.AddSingleton<INameResolver>(_nameResolver);
                });
        }

        public class Poison_Program
        {
            public List<string> _poisonBlobMessagesPrimary = new List<string>();
            public List<string> _poisonBlobMessagesSecondary = new List<string>();

            public void BlobProcessorPrimary(
                [BlobTrigger(PoisonTestContainerName + "/{name}")] string input)
            {
                // throw to generate a poison blob message
                throw new Exception();
            }

            // process the poison queue for the primary storage account
            public void PoisonBlobQueueProcessorPrimary(
                [QueueTrigger("webjobs-blobtrigger-poison")] JObject message)
            {
                lock (_syncLock)
                {
                    string blobName = (string)message["BlobName"];
                    _poisonBlobMessagesPrimary.Add(blobName);
                }
            }

            public void BlobProcessorSecondary(
                [StorageAccount("SecondaryStorage")]
            [BlobTrigger(PoisonTestContainerName + "/{name}")] string input)
            {
                // throw to generate a poison blob message
                throw new Exception();
            }

            // process the poison queue for the secondary storage account
            public void PoisonBlobQueueProcessorSecondary(
                [StorageAccount("SecondaryStorage")]
            [QueueTrigger("webjobs-blobtrigger-poison")] JObject message)
            {
                lock (_syncLock)
                {
                    string blobName = (string)message["BlobName"];
                    _poisonBlobMessagesSecondary.Add(blobName);
                }
            }
        }

        public class BlobGetsProcessedOnlyOnce_SingleHost_Program
        {
            public int _timesProcessed;
            public ManualResetEvent _completedEvent;

            public void SingleBlobTrigger(
                [BlobTrigger(SingleTriggerContainerName + "/{name}")] string sleepTimeInSeconds)
            {
                Interlocked.Increment(ref _timesProcessed);

                int sleepTime = int.Parse(sleepTimeInSeconds) * 1000;
                Thread.Sleep(sleepTime);

                _completedEvent.Set();
            }
        }

        public class BlobChainTest_Program
        {
            public ManualResetEvent _completedEvent;

            public void BlobChainStepOne(
                [BlobTrigger(BlobChainTriggerBlobPath)] TextReader input,
                [Blob(BlobChainIntermediateBlobPath)] TextWriter output)
            {
                string content = input.ReadToEnd();
                output.Write(content);
            }

            public void BlobChainStepTwo(
                [BlobTrigger(BlobChainIntermediateBlobPath)] TextReader input,
                [Blob(BlobChainOutputBlobPath)] TextWriter output,
                [Queue(BlobChainCommittedQueueName)] out string committed)
            {
                string content = input.ReadToEnd();
                output.Write("*" + content + "*");
                committed = String.Empty;
            }

            public void BlobChainStepThree([QueueTrigger(BlobChainCommittedQueueName)] string ignore)
            {
                _completedEvent.Set();
            }
        }

        [Test]
        public async Task PoisonMessage_CreatedInPrimaryStorageAccount()
        {
            await PoisonMessage_CreatedInCorrectStorageAccount(TestEnvironment.PrimaryStorageAccountConnectionString, true);
        }

        [Test]
        public async Task PoisonMessage_CreatedInSecondaryStorageAccount()
        {
            await PoisonMessage_CreatedInCorrectStorageAccount(TestEnvironment.SecondaryStorageAccountConnectionString, false);
        }

        private async Task PoisonMessage_CreatedInCorrectStorageAccount(string connectionString, bool isPrimary)
        {
            var blobClient = new BlobServiceClient(connectionString);
            var containerName = _nameResolver.ResolveInString(PoisonTestContainerName);
            var container = blobClient.GetBlobContainerClient(containerName);
            await container.CreateAsync();

            var blobName = Guid.NewGuid().ToString();
            var blob = container.GetBlockBlobClient(blobName);
            await blob.UploadTextAsync("0");

            var prog = new Poison_Program();
            var host = NewBuilder(prog).Build();

            using (host)
            {
                host.Start();

                // wait for the poison message to be handled
                await TestHelpers.Await(() =>
                {
                    if (isPrimary)
                    {
                        return prog._poisonBlobMessagesPrimary.Contains(blobName);
                    }
                    else
                    {
                        return prog._poisonBlobMessagesSecondary.Contains(blobName);
                    }
                });
            }
        }

        [Test]
        public async Task BlobGetsProcessedOnlyOnce_SingleHost()
        {
            var blob = _testContainer.GetBlockBlobClient(TestBlobName);
            await blob.UploadTextAsync("0");

            int timeToProcess;

            var prog = new BlobGetsProcessedOnlyOnce_SingleHost_Program();

            // make sure they both have the same id
            var host = NewBuilder(prog, builder => builder.UseHostId(Guid.NewGuid().ToString("N")))
                .Build();

            // Process the blob first
            using (prog._completedEvent = new ManualResetEvent(initialState: false))
            using (host)
            {
                DateTime startTime = DateTime.Now;

                host.Start();
                Assert.True(prog._completedEvent.WaitOne(TimeSpan.FromSeconds(60)));

                timeToProcess = (int)(DateTime.Now - startTime).TotalMilliseconds;

                Assert.AreEqual(1, prog._timesProcessed);

                string[] loggerOutputLines = host.GetTestLoggerProvider().GetAllLogMessages()
                    .Where(p => p.FormattedMessage != null)
                    .SelectMany(p => p.FormattedMessage.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.None))
                    .ToArray();

                var executions = loggerOutputLines.Where(p => p.Contains("Executing"));
                Assert.AreEqual(1, executions.Count());
                StringAssert.StartsWith(string.Format("Executing 'BlobGetsProcessedOnlyOnce_SingleHost_Program.SingleBlobTrigger' (Reason='New blob detected: {0}/{1}', Id=", blob.BlobContainerName, blob.Name), executions.Single());

                await host.StopAsync();

                // Can't restart
                Assert.Throws<InvalidOperationException>(() => host.Start());
            }

            Assert.AreEqual(1, prog._timesProcessed);
        } // host

        [Test]
        public async Task BlobChainTest()
        {
            // write the initial trigger blob to start the chain
            var container = _blobServiceClient.GetBlobContainerClient(_nameResolver.ResolveInString(BlobChainContainerName));
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobClient(BlobChainTriggerBlobName);
            await blob.UploadTextAsync("0");

            var prog = new BlobChainTest_Program();
            var host = NewBuilder(prog).Build();

            using (prog._completedEvent = new ManualResetEvent(initialState: false))
            using (host)
            {
                host.Start();
                Assert.True(prog._completedEvent.WaitOne(TimeSpan.FromSeconds(60)));
            }
        }

        [Test]
        public async Task BlobGetsProcessedOnlyOnce_MultipleHosts()
        {
            await _testContainer
                .GetBlockBlobClient(TestBlobName)
                .UploadTextAsync("10");

            var prog = new BlobGetsProcessedOnlyOnce_SingleHost_Program();

            string hostId = Guid.NewGuid().ToString("N");
            var host1 = NewBuilder(prog, builder=>builder.UseHostId(hostId))
                .Build();
            var host2 = NewBuilder(prog, builder => builder.UseHostId(hostId))
                .Build();

            using (prog._completedEvent = new ManualResetEvent(initialState: false))
            using (host1)
            using (host2)
            {
                host1.Start();
                host2.Start();

                Assert.True(prog._completedEvent.WaitOne(TimeSpan.FromSeconds(60)));
            }

            Assert.AreEqual(1, prog._timesProcessed);
        }

        public void Dispose()
        {
            foreach (var testContainer in _blobServiceClient.GetBlobContainers(prefix: TestArtifactPrefix))
            {
                _blobServiceClient.GetBlobContainerClient(testContainer.Name).Delete();
            }
        }
    }
}
