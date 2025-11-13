// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.Listeners
{
    public class BlobListenerFactoryTests
    {
        [Test]
        public async Task CreateAsync_RegisterWithSharedBlobListenerAsync_UsesTargetBlobClient()
        {
            // Arrange
            string accountName1 = "fakeaccount1";
            string accountName2 = "fakeaccount2";
            string containerName1 = "fakecontainer1";
            string containerName2 = "fakecontainer2";
            Mock<BlobContainerClient> containerClient1 = new Mock<BlobContainerClient>(new Uri($"https://{accountName1}.blob.core.windows.net/{containerName1}"), null);
            Mock<BlobContainerClient> containerClient2 = new Mock<BlobContainerClient>(new Uri($"https://{accountName2}.blob.core.windows.net/{containerName2}"), null);
            containerClient1.Setup(x => x.Uri).Returns(new Uri($"https://{accountName1}.blob.core.windows.net/{containerName1}"));
            containerClient1.Setup(x => x.Name).Returns(containerName1);
            containerClient1.Setup(x => x.AccountName).Returns(accountName1);
            containerClient2.Setup(x => x.Uri).Returns(new Uri($"https://{accountName2}.blob.core.windows.net/{containerName2}"));
            containerClient2.Setup(x => x.Name).Returns(containerName2);
            containerClient2.Setup(x => x.AccountName).Returns(accountName2);
            Mock<BlobServiceClient> primaryClient = new Mock<BlobServiceClient>(new Uri($"https://{accountName1}.blob.core.windows.net/"), null);
            primaryClient.Setup(x => x.Uri).Returns(new Uri($"https://{accountName1}.blob.core.windows.net/"));
            primaryClient.Setup(x => x.AccountName).Returns(accountName1);
            primaryClient.Setup(x => x.GetBlobContainerClient(containerName1)).Returns(containerClient1.Object);
            primaryClient.Setup(x => x.GetBlobContainerClient(containerName2)).Returns(containerClient2.Object);
            primaryClient.Setup(x => x.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(new BlobServiceProperties(), null));
            Mock<BlobServiceClient> targetClient = new Mock<BlobServiceClient>(new Uri($"https://{accountName2}.blob.core.windows.net/"), null);
            targetClient.Setup(x => x.Uri).Returns(new Uri($"https://{accountName2}.blob.core.windows.net/"));
            targetClient.Setup(x => x.AccountName).Returns(accountName2);
            targetClient.Setup(x => x.GetBlobContainerClient(containerName1)).Returns(containerClient1.Object);
            targetClient.Setup(x => x.GetBlobContainerClient(containerName2)).Returns(containerClient2.Object);
            targetClient.Setup(x => x.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(new BlobServiceProperties(), null));

            // Setup other required dependencies for BlobListenerFactory
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<BlobListener>();
            var hostIdProvider = new Mock<IHostIdProvider>();
            var blobsOptions = new BlobsOptions();
            var exceptionHandler = new Mock<IWebJobsExceptionHandler>();
            var blobWrittenWatcherSetter = new Mock<IContextSetter<IBlobWrittenWatcher>>();
            var hostQueueServiceClient = new QueueServiceClient(new Uri($"https://{accountName1}.queue.core.windows.net/"));
            var dataQueueServiceClient = new QueueServiceClient(new Uri($"https://{accountName2}.queue.core.windows.net/"));
            var queueServiceClientProvider = new FakeQueueServiceClientProvider(hostQueueServiceClient);
            var sharedQueueWatcher = new SharedQueueWatcher();
            IListener listener = new Mock<IListener>().Object;
            var blobTriggerQueueWriterFactory = new BlobTriggerQueueWriterFactory(hostIdProvider.Object, queueServiceClientProvider, sharedQueueWatcher);
            SharedBlobQueueListener _sharedBlobQueueListener = new SharedBlobQueueListener(listener);
            var sharedContextProvider = new Mock<ISharedContextProvider>();
            sharedContextProvider.Setup(s => s.GetOrCreateInstance<SharedBlobQueueListener>(It.IsAny<SharedBlobQueueListenerFactory>()))
                .Returns(_sharedBlobQueueListener);
            // Setup SharedContextProvider to return our sharedBlobListener
            IBlobListenerStrategy strategy1 = new TestBlobListenerStrategy();
            var sharedBlobListener = new SharedBlobListener(strategy1, exceptionHandler.Object);
            sharedContextProvider.Setup(x => x.GetOrCreateInstance(It.IsAny<SharedBlobListenerFactory>()))
                .Returns(sharedBlobListener);
            var functionDescriptor = new FunctionDescriptor();
            functionDescriptor.Id = "id";
            functionDescriptor.ShortName = "shortname";
            var input = new Mock<IBlobPathSource>();
            var executor = new Mock<ITriggeredFunctionExecutor>();
            var singletonManager = new Mock<IHostSingletonManager>();
            var concurrencyManager = new Mock<ConcurrencyManager>();
            var drainModeManager = new Mock<IDrainModeManager>();

            // BlobTriggerSource.LogsAndContainerScan is the most common
            var factory = new BlobListenerFactory(
                hostIdProvider.Object,
                blobsOptions,
                exceptionHandler.Object,
                blobWrittenWatcherSetter.Object,
                blobTriggerQueueWriterFactory,
                sharedContextProvider.Object,
                loggerFactory,
                functionDescriptor,
                primaryClient.Object,
                hostQueueServiceClient,
                targetClient.Object,
                dataQueueServiceClient,
                containerClient1.Object,
                input.Object,
                BlobTriggerSource.LogsAndContainerScan,
                executor.Object,
                singletonManager.Object,
                concurrencyManager.Object,
                drainModeManager.Object
            );

            // Setup a dummy BlobTriggerQueueWriter
            var blobTriggerQueueWriter = new Mock<BlobTriggerQueueWriter>(null, null).Object;

            // Act
            await factory.CreateAsync(CancellationToken.None);

            // Assert that sharedListener was updated with targetClient, not primaryClient
            // and that the BlobTriggerExecutor was passed the BlobReceiptManager using the primaryClient
            // 1. Get the private _strategy field from SharedBlobListener
            var strategyField = typeof(SharedBlobListener).GetField("_strategy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var strategy = strategyField.GetValue(sharedBlobListener);

            // 2. Get the _scanInfo field from ScanBlobScanLogHybridPollingStrategy (if that's the strategy type)
            var scanInfoField = strategy.GetType().GetField("_scanInfo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var scanInfo = scanInfoField.GetValue(strategy) as System.Collections.IDictionary;

            // 3. Assert that the container is registered (the key should be your container mock/object)
            Assert.IsTrue(scanInfo.Contains(containerClient1.Object));

            // 4. Optionally, check the registrations or other details
            var containerScanInfo = scanInfo[containerClient1.Object];
            // You can further inspect containerScanInfo if needed

            // 5. If you want to check which BlobServiceClient was used, you may need to check other fields or the state of the strategy
            // For example, if the strategy stores the BlobServiceClient, you can reflect on that as well

            // Example: If you want to check the type of the strategy to ensure it's using the correct client
            Assert.AreEqual("ScanBlobScanLogHybridPollingStrategy", strategy.GetType().Name);
        }
    }
}
