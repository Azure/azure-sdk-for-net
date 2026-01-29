// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.Listeners
{
    public class BlobListenerFactoryTests
    {
        [Test]
        public async Task CreateAsync_RegisterWithSharedBlobListenerAsync_UsesTargetBlobClient()
        {
            // Arrange
            // Storage account and container names
            string accountName1 = "fakeaccount1";
            string accountName2 = "fakeaccount2";
            string containerName1 = "fakecontainer1";
            string containerName2 = "fakecontainer2";

            // Mock BlobContainerClients
            var containerClient1 = new Mock<BlobContainerClient>(new Uri($"https://{accountName1}.blob.core.windows.net/{containerName1}"), null);
            containerClient1.Setup(x => x.Uri).Returns(new Uri($"https://{accountName1}.blob.core.windows.net/{containerName1}"));
            containerClient1.Setup(x => x.Name).Returns(containerName1);
            containerClient1.Setup(x => x.AccountName).Returns(accountName1);

            var containerClient2 = new Mock<BlobContainerClient>(new Uri($"https://{accountName1}.blob.core.windows.net/{containerName2}"), null);
            containerClient2.Setup(x => x.Uri).Returns(new Uri($"https://{accountName1}.blob.core.windows.net/{containerName2}"));
            containerClient2.Setup(x => x.Name).Returns(containerName2);
            containerClient2.Setup(x => x.AccountName).Returns(accountName2);

            var hostNamesContainerClient = new Mock<BlobContainerClient>(new Uri($"https://{accountName1}.blob.core.windows.net/{HostContainerNames.Hosts}"), null);
            hostNamesContainerClient.Setup(x => x.Uri).Returns(new Uri($"https://{accountName1}.blob.core.windows.net/{HostContainerNames.Hosts}"));
            hostNamesContainerClient.Setup(x => x.Name).Returns(HostContainerNames.Hosts);
            hostNamesContainerClient.Setup(x => x.AccountName).Returns(accountName1);

            // Mock BlobServiceClients
            var primaryClient = new Mock<BlobServiceClient>(new Uri($"https://{accountName1}.blob.core.windows.net/"), null);
            primaryClient.Setup(x => x.Uri).Returns(new Uri($"https://{accountName1}.blob.core.windows.net/"));
            primaryClient.Setup(x => x.AccountName).Returns(accountName1);
            primaryClient.Setup(x => x.GetBlobContainerClient(containerName1)).Returns(containerClient1.Object);
            primaryClient.Setup(x => x.GetBlobContainerClient(containerName2)).Returns(containerClient2.Object);
            primaryClient.Setup(x => x.GetBlobContainerClient(HostContainerNames.Hosts)).Returns(hostNamesContainerClient.Object);
            primaryClient.Setup(x => x.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(new BlobServiceProperties(), null));

            var targetClient = new Mock<BlobServiceClient>(new Uri($"https://{accountName2}.blob.core.windows.net/"), null);
            targetClient.Setup(x => x.Uri).Returns(new Uri($"https://{accountName2}.blob.core.windows.net/"));
            targetClient.Setup(x => x.AccountName).Returns(accountName2);
            targetClient.Setup(x => x.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(new BlobServiceProperties(), null));

            // Other dependencies
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
            var blobTriggerQueueWriterFactory = new BlobTriggerQueueWriterFactory(
                hostIdProvider.Object,
                queueServiceClientProvider,
                sharedQueueWatcher);
            var executor = new Mock<ITriggeredFunctionExecutor>();
            var input = new Mock<IBlobPathSource>();
            var singletonManager = new Mock<IHostSingletonManager>();
            var concurrencyManager = new Mock<ConcurrencyManager>();
            var drainModeManager = new Mock<IDrainModeManager>();
            var functionDescriptor = new FunctionDescriptor { Id = "id", ShortName = "shortname" };

            // Setup SharedContextProvider and Test Strategy
            var sharedContextProvider = new Mock<ISharedContextProvider>();
            var testStrategy = new TestBlobListenerStrategy();
            var sharedBlobListener = new SharedBlobListener(testStrategy, exceptionHandler.Object);
            sharedContextProvider.Setup(x => x.GetOrCreateInstance(It.IsAny<SharedBlobListenerFactory>()))
                .Returns(sharedBlobListener);

            // Setup SharedBlobQueueListener
            var sharedBlobQueueListener = new SharedBlobQueueListener(
                new Mock<IListener>().Object,
                new BlobQueueTriggerExecutor(BlobTriggerSource.LogsAndContainerScan,
                new Mock<IBlobWrittenWatcher>().Object, logger));
            sharedContextProvider.Setup(s => s.GetOrCreateInstance<SharedBlobQueueListener>(It.IsAny<SharedBlobQueueListenerFactory>()))
                .Returns(sharedBlobQueueListener);

            // Create the factory
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

            // Act
            await factory.CreateAsync(CancellationToken.None);

            // Assert
            // 1. The strategy should have registered the target client and container
            Assert.AreEqual(targetClient.Object, testStrategy.TargetServiceClient, "TargetServiceClient should be the target client.");
            Assert.AreEqual(containerClient1.Object, testStrategy.ContainerClient, "ContainerClient should be the primary container.");

            // 2. The BlobTriggerExecutor should use a BlobReceiptManager with the primary client
            var receiptManagerField = typeof(BlobTriggerExecutor).GetField("_receiptManager", BindingFlags.NonPublic | BindingFlags.Instance);
            var receiptManager = receiptManagerField.GetValue(testStrategy.Executor);
            var blobContainerClientField = typeof(BlobReceiptManager).GetField("_blobContainerClient", BindingFlags.NonPublic | BindingFlags.Instance);
            var resultPrimaryClient = blobContainerClientField.GetValue(receiptManager);

            // The BlobReceiptManager should use the hostNamesContainerClient (from the primary client)
            Assert.AreEqual(hostNamesContainerClient.Object, resultPrimaryClient, "BlobReceiptManager should use the primary container client.");
        }
    }
}
