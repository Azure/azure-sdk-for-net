// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Shared.Protocol;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.Blobs.Listeners
{
    public class ScanBlobScanLogHybridPollingStrategyTests
    {
        private IWebJobsExceptionHandler _exceptionHandler = new TestExceptionHandler();
        private readonly TestLoggerProvider _loggerProvider = new TestLoggerProvider();
        private readonly ILogger<BlobListener> _logger;

        private Mock<CloudBlobClient> blobClientMock = new Mock<CloudBlobClient>(new Uri("https://fake.com/fakecontainer"), null);
        private Mock<CloudBlobContainer> blobContainerMock = new Mock<CloudBlobContainer>(new Uri("https://fake.com/fakecontainer"));
        private Mock<CloudBlobContainer> secondBlobContainerMock = new Mock<CloudBlobContainer>(new Uri("https://fake.com/fakecontainer2"));
        private ServiceProperties serviceProperties = new ServiceProperties(new LoggingProperties(), new MetricsProperties(), new MetricsProperties(), new CorsProperties());
        private StorageCredentials storageCredentials = new StorageCredentials("fakeaccount", "key1");
        private List<IListBlobItem> blobItems = new List<IListBlobItem>();
        private List<IListBlobItem> secondBlobItems = new List<IListBlobItem>();

        public ScanBlobScanLogHybridPollingStrategyTests()
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(_loggerProvider);
            _logger = loggerFactory.CreateLogger<BlobListener>();

            blobContainerMock.Object.SetInternalProperty("ServiceClient", blobClientMock.Object);
            secondBlobContainerMock.Object.SetInternalProperty("ServiceClient", blobClientMock.Object);
            blobClientMock.Setup(x => x.GetServicePropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(serviceProperties);
            blobClientMock.Object.SetInternalProperty("Credentials", storageCredentials);
            blobContainerMock.Setup(x => x.ListBlobsSegmentedAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<BlobListingDetails>(), It.IsAny<int?>(), It.IsAny<BlobContinuationToken>(), It.IsAny<BlobRequestOptions>(), It.IsAny<OperationContext>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) =>
                    {
                        int beginIndex = currentToken != null ? int.Parse(currentToken.NextMarker) : 0;
                        int count = blobItems.Count - beginIndex;
                        BlobContinuationToken continuationToken = null;
                        if (maxResults.HasValue && maxResults.Value < count)
                        {
                            count = maxResults.Value;
                            continuationToken = new BlobContinuationToken()
                            {
                                NextMarker = (beginIndex + count).ToString()
                            };
                        }
                        return Task.FromResult(new BlobResultSegment(blobItems.GetRange(beginIndex, count), continuationToken));
                    }
                );
            secondBlobContainerMock.Setup(x => x.ListBlobsSegmentedAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<BlobListingDetails>(), It.IsAny<int?>(), It.IsAny<BlobContinuationToken>(), It.IsAny<BlobRequestOptions>(), It.IsAny<OperationContext>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) =>
                    {
                        int beginIndex = currentToken != null ? int.Parse(currentToken.NextMarker) : 0;
                        int count = secondBlobItems.Count - beginIndex;
                        BlobContinuationToken continuationToken = null;
                        if (maxResults.HasValue && maxResults.Value < count)
                        {
                            count = maxResults.Value;
                            continuationToken = new BlobContinuationToken()
                            {
                                NextMarker = (beginIndex + count).ToString()
                            };
                        }
                        return Task.FromResult(new BlobResultSegment(secondBlobItems.GetRange(beginIndex, count), continuationToken));
                    }
                );
        }

        [Fact]
        public void ScanBlobScanLogHybridPollingStrategyTestBlobListener()
        {
            string containerName = Path.GetRandomFileName();
            var container = blobContainerMock.Object;
            container.SetInternalProperty("Name", containerName);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, _logger);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            product.Register(container, executor);
            product.Start();

            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);

            string expectedBlobName = CreateBlobAndUploadToContainer(container, blobItems);

            RunExecuterWithExpectedBlobs(new List<string>() { expectedBlobName }, product, executor);

            // Now run again; shouldn't show up.
            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);

            // Verify happy-path logging.
            var logMessages = _loggerProvider.GetAllLogMessages().ToArray();
            Assert.Equal(4, logMessages.Length);

            // 1 initialization log
            var initLog = logMessages.Single(m => m.EventId.Name == "InitializedScanInfo");
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Debug, initLog.Level);
            Assert.Equal(3, initLog.State.Count());
            Assert.Equal(containerName, initLog.GetStateValue<string>("containerName"));
            Assert.True(!string.IsNullOrWhiteSpace(initLog.GetStateValue<string>("latestScanInfo")));
            Assert.True(!string.IsNullOrWhiteSpace(initLog.GetStateValue<string>("{OriginalFormat}")));

            // 3 polling logs
            var pollLogs = logMessages.Where(m => m.EventId.Name == "PollBlobContainer").ToArray();
            Assert.Equal(3, pollLogs.Length);

            void ValidatePollingLog(LogMessage pollingLog, int expectedBlobCount)
            {
                Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Debug, pollingLog.Level);
                Assert.Equal(7, pollingLog.State.Count());
                Assert.Equal(containerName, pollingLog.GetStateValue<string>("containerName"));
                Assert.Equal(expectedBlobCount, pollingLog.GetStateValue<int>("blobCount"));
                Assert.True(!string.IsNullOrWhiteSpace(pollingLog.GetStateValue<string>("pollMinimumTime")));
                Assert.True(!string.IsNullOrWhiteSpace(pollingLog.GetStateValue<string>("clientRequestId")));
                Assert.True(pollingLog.GetStateValue<long>("pollLatency") >= 0);
                Assert.False(pollingLog.GetStateValue<bool>("hasContinuationToken"));
                Assert.True(!string.IsNullOrWhiteSpace(pollingLog.GetStateValue<string>("{OriginalFormat}")));
            }

            ValidatePollingLog(pollLogs[0], 0);
            ValidatePollingLog(pollLogs[1], 1);
            ValidatePollingLog(pollLogs[2], 1);
        }

        [Fact]
        public void TestBlobListenerWithContainerBiggerThanThreshold()
        {
            int testScanBlobLimitPerPoll = 1;
            string containerName = Path.GetRandomFileName();
            var container = blobContainerMock.Object;
            container.SetInternalProperty("Name", containerName);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(container, executor);
            product.Start();

            // populate with 5 blobs
            List<string> expectedNames = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                expectedNames.Add(CreateBlobAndUploadToContainer(container, blobItems));
            }

            RunExecuteWithMultiPollingInterval(expectedNames, product, executor, testScanBlobLimitPerPoll);

            // Now run again; shouldn't show up.
            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);
        }

        [Fact]
        public void TestBlobListenerWithMultipleContainers()
        {
            int testScanBlobLimitPerPoll = 6, containerCount = 2;
            string firstContainerName = Path.GetRandomFileName();
            string secondContainerName = Path.GetRandomFileName();
            var firstContainer = blobContainerMock.Object;
            firstContainer.SetInternalProperty("Name", firstContainerName);
            var secondContainer = secondBlobContainerMock.Object;
            secondContainer.SetInternalProperty("Name", secondContainerName);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(firstContainer, executor);
            product.Register(secondContainer, executor);
            product.Start();

            // populate first container with 5 blobs > page size and second with 2 blobs < page size
            // page size is going to be testScanBlobLimitPerPoll / number of container 6/2 = 3
            List<string> firstContainerExpectedNames = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                firstContainerExpectedNames.Add(CreateBlobAndUploadToContainer(firstContainer, blobItems));
            }

            RunExecuteWithMultiPollingInterval(firstContainerExpectedNames, product, executor, testScanBlobLimitPerPoll / containerCount);

            Thread.Sleep(10);

            List<string> secondContainerExpectedNames = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                secondContainerExpectedNames.Add(CreateBlobAndUploadToContainer(secondContainer, secondBlobItems));
            }

            RunExecuteWithMultiPollingInterval(secondContainerExpectedNames, product, executor, testScanBlobLimitPerPoll / containerCount);

            // Now run again; shouldn't show up.
            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);
        }

        [Fact]
        public void BlobPolling_IgnoresClockSkew()
        {
            int testScanBlobLimitPerPoll = 3;
            string containerName = Path.GetRandomFileName();
            var now = DateTimeOffset.UtcNow;
            var timeMap = new Dictionary<string, DateTimeOffset>();
            var container = blobContainerMock.Object;
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(container, executor);
            product.Start();

            List<string> expectedNames = new List<string>();
            expectedNames.Add(CreateBlobAndUploadToContainer(container, blobItems));
            timeMap[expectedNames.Single()] = now.AddSeconds(-60);
            RunExecuterWithExpectedBlobs(expectedNames, product, executor);

            expectedNames.Add(CreateBlobAndUploadToContainer(container, blobItems));
            timeMap[expectedNames.Last()] = now.AddSeconds(-59);

            // We should see the new item. We'll see 2 blobs, but only process 1 (due to receipt).
            RunExecuterWithExpectedBlobs(expectedNames, product, executor, 1);

            blobContainerMock.Verify
                (x => x.ListBlobsSegmentedAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<BlobListingDetails>(), It.IsAny<int?>(), It.IsAny<BlobContinuationToken>(), It.IsAny<BlobRequestOptions>(), It.IsAny<OperationContext>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            Assert.Equal(expectedNames, executor.BlobReceipts);
        }

        [Fact]
        public void BlobPolling_IncludesPreviousBatch()
        {
            // Blob timestamps are rounded to the nearest second, so make sure we continue to poll
            // the previous second to catch any blobs that came in slightly after our previous attempt.
            int testScanBlobLimitPerPoll = 3;
            string containerName = Path.GetRandomFileName();

            // Strip off milliseconds.
            var now = DateTimeOffset.UtcNow;
            now = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Offset);

            var container = blobContainerMock.Object;

            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(container, executor);
            product.Start();

            List<string> expectedNames = new List<string>();
            expectedNames.Add(CreateBlobAndUploadToContainer(container, blobItems, lastModified: now));

            RunExecuterWithExpectedBlobs(expectedNames, product, executor);

            expectedNames.Add(CreateBlobAndUploadToContainer(container, blobItems, lastModified: now));

            // We should see the new item. We'll see 2 blobs, but only process 1 (due to receipt).
            RunExecuterWithExpectedBlobs(expectedNames, product, executor, 1);

            blobContainerMock.Verify
                (x => x.ListBlobsSegmentedAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<BlobListingDetails>(), It.IsAny<int?>(), It.IsAny<BlobContinuationToken>(), It.IsAny<BlobRequestOptions>(), It.IsAny<OperationContext>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            Assert.Equal(expectedNames, executor.BlobReceipts);
        }

        [Fact]
        public async Task RegisterAsync_InitializesWithScanInfoManager()
        {
            if (Environment.Version.Major == 4)
            {
                // TODO: figure out why this doesn't work on .NET Framework
                return;
            }
            string containerName = Guid.NewGuid().ToString();
            var container = blobContainerMock.Object;
            TestBlobScanInfoManager scanInfoManager = new TestBlobScanInfoManager();
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(scanInfoManager, _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();

            // Create a few blobs.
            for (int i = 0; i < 5; i++)
            {
                CreateBlobAndUploadToContainer(container, blobItems);
            }

            await scanInfoManager.UpdateLatestScanAsync(storageCredentials.AccountName, containerName, DateTime.UtcNow);
            await product.RegisterAsync(container, executor, CancellationToken.None);

            // delay slightly so we guarantee a later timestamp
            await Task.Delay(10);

            var expectedNames = new List<string>();
            expectedNames.Add(CreateBlobAndUploadToContainer(container, blobItems));

            RunExecuterWithExpectedBlobs(expectedNames, product, executor);
        }

        [Fact]
        public async Task ExecuteAsync_UpdatesScanInfoManager()
        {
            int testScanBlobLimitPerPoll = 6;
            string firstContainerName = Guid.NewGuid().ToString();
            string secondContainerName = Guid.NewGuid().ToString();
            CloudBlobContainer firstContainer = blobContainerMock.Object;
            firstContainer.SetInternalProperty("Name", firstContainerName);
            CloudBlobContainer secondContainer = secondBlobContainerMock.Object;
            secondContainer.SetInternalProperty("Name", secondContainerName);
            TestBlobScanInfoManager testScanInfoManager = new TestBlobScanInfoManager();
            string accountName = storageCredentials.AccountName;
            testScanInfoManager.SetScanInfo(accountName, firstContainerName, DateTime.MinValue);
            testScanInfoManager.SetScanInfo(accountName, secondContainerName, DateTime.MinValue);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(testScanInfoManager, _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                  .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                  .SetValue(product, testScanBlobLimitPerPoll);

            await product.RegisterAsync(firstContainer, executor, CancellationToken.None);
            await product.RegisterAsync(secondContainer, executor, CancellationToken.None);

            var firstExpectedNames = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                firstExpectedNames.Add(CreateBlobAndUploadToContainer(firstContainer, blobItems));
            }
            RunExecuteWithMultiPollingInterval(firstExpectedNames, product, executor, testScanBlobLimitPerPoll / 2);

            // only expect the first container to have updated its scanInfo
            Assert.Equal(1, testScanInfoManager.UpdateCounts[accountName][firstContainerName]);
            int count;
            testScanInfoManager.UpdateCounts[accountName].TryGetValue(secondContainerName, out count);
            Assert.Equal(0, count);

            await Task.Delay(10);

            var secondExpectedNames = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                secondExpectedNames.Add(CreateBlobAndUploadToContainer(secondContainer, secondBlobItems));
            }
            RunExecuteWithMultiPollingInterval(secondExpectedNames, product, executor, testScanBlobLimitPerPoll / 2);

            // this time, only expect the second container to have updated its scanInfo
            Assert.Equal(1, testScanInfoManager.UpdateCounts[accountName][firstContainerName]);
            Assert.Equal(1, testScanInfoManager.UpdateCounts[accountName][secondContainerName]);
        }


        [Fact]
        public async Task ExecuteAsync_UpdatesScanInfo_WithEarliestFailure()
        {
            int testScanBlobLimitPerPoll = 6;
            string containerName = Guid.NewGuid().ToString();

            // we'll introduce multiple errors to make sure we take the earliest timestamp
            DateTime earliestErrorTime = DateTime.UtcNow;

            var container = blobContainerMock.Object;
            container.SetInternalProperty("Name", containerName);

            TestBlobScanInfoManager testScanInfoManager = new TestBlobScanInfoManager();
            string accountName = storageCredentials.AccountName;
            testScanInfoManager.SetScanInfo(accountName, containerName, DateTime.MinValue);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(testScanInfoManager, _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                  .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                  .SetValue(product, testScanBlobLimitPerPoll);

            await product.RegisterAsync(container, executor, CancellationToken.None);

            // Induce a failure to make sure the timestamp is earlier than the failure.
            var expectedNames = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                string name;
                if (i % 3 == 0)
                {
                    name = CreateBlobAndUploadToContainer(container, blobItems, "throw", earliestErrorTime.AddMinutes(i));
                }
                else
                {
                    name = CreateBlobAndUploadToContainer(container, blobItems, "test", earliestErrorTime.AddMinutes(10));
                }
                expectedNames.Add(name);
            }

            RunExecuteWithMultiPollingInterval(expectedNames, product, executor, testScanBlobLimitPerPoll);

            DateTime? storedTime = await testScanInfoManager.LoadLatestScanAsync(accountName, containerName);
            Assert.True(storedTime < earliestErrorTime);
            Assert.Equal(1, testScanInfoManager.UpdateCounts[accountName][containerName]);
            blobContainerMock.Verify
                (x => x.ListBlobsSegmentedAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<BlobListingDetails>(), It.IsAny<int?>(), It.IsAny<BlobContinuationToken>(), It.IsAny<BlobRequestOptions>(), It.IsAny<OperationContext>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2));
        }

        private void RunExecuterWithExpectedBlobsInternal(IDictionary<string, int> blobNameMap, IBlobListenerStrategy product, LambdaBlobTriggerExecutor executor, int expectedCount)
        {
            if (blobNameMap.Count == 0)
            {
                executor.ExecuteLambda = (_) =>
                {
                    throw new InvalidOperationException("shouldn't be any blobs in the container");
                };
                product.Execute().Wait.Wait();
            }
            else
            {
                int count = 0;
                executor.ExecuteLambda = (b) =>
                {
                    Assert.Contains(b.Name, blobNameMap.Keys);
                    blobNameMap[b.Name]++;

                    if (b.DownloadText() == "throw")
                    {
                        // only increment if it's the first time.
                        // other calls are re-tries.
                        if (blobNameMap[b.Name] == 1)
                        {
                            count++;
                        }
                        return false;
                    }
                    count++;
                    return true;
                };
                product.Execute();
                Assert.Equal(expectedCount, count);
            }
        }

        private void RunExecuterWithExpectedBlobs(List<string> blobNames, IBlobListenerStrategy product, LambdaBlobTriggerExecutor executor)
        {
            RunExecuterWithExpectedBlobs(blobNames, product, executor, blobNames.Count);
        }

        private void RunExecuterWithExpectedBlobs(List<string> blobNames, IBlobListenerStrategy product, LambdaBlobTriggerExecutor executor, int expectedCount)
        {
            var blobNameMap = blobNames.ToDictionary(n => n, n => 0);
            RunExecuterWithExpectedBlobsInternal(blobNameMap, product, executor, expectedCount);
        }


        private void RunExecuterWithExpectedBlobs(IDictionary<string, int> blobNameMap, IBlobListenerStrategy product, LambdaBlobTriggerExecutor executor)
        {
            RunExecuterWithExpectedBlobsInternal(blobNameMap, product, executor, blobNameMap.Count);
        }

        private void RunExecuteWithMultiPollingInterval(List<string> expectedBlobNames, IBlobListenerStrategy product, LambdaBlobTriggerExecutor executor, int expectedCount)
        {
            // a map so we can track retries in the event of failures
            Dictionary<string, int> blobNameMap = expectedBlobNames.ToDictionary(n => n, n => 0);

            // make sure it is processed in chunks of "expectedCount" size
            for (int i = 0; i < expectedBlobNames.Count; i += expectedCount)
            {
                RunExecuterWithExpectedBlobsInternal(blobNameMap, product, executor,
                    Math.Min(expectedCount, expectedBlobNames.Count - i));
            }
        }

        private string CreateBlobAndUploadToContainer(CloudBlobContainer container, List<IListBlobItem> blobItems, string blobContent = "test", DateTimeOffset lastModified = default)
        {
            string blobName = Path.GetRandomFileName().Replace(".", "");
            Mock<ICloudBlob> item = new Mock<ICloudBlob>();
            var blobProperties = new BlobProperties();
            if (lastModified == default)
            {
                blobProperties.SetLastModified(DateTimeOffset.UtcNow);
            }
            else
            {
                blobProperties.SetLastModified(lastModified);
            }
            item.Setup(x => x.Properties).Returns(blobProperties);
            item.Setup(x => x.Container).Returns(container);
            item.Setup(x => x.Name).Returns(blobName);
            item.Setup(x => x.OpenReadAsync(It.IsAny<CancellationToken>())).ReturnsAsync(
                () => new MemoryStream(Encoding.UTF8.GetBytes(blobContent)));
            blobItems.Add(item.Object);
            return blobName;
        }

        private class LambdaBlobTriggerExecutor : ITriggerExecutor<BlobTriggerExecutorContext>
        {
            public ICollection<string> _blobReceipts { get; } = new Collection<string>();

            public IEnumerable<string> BlobReceipts => _blobReceipts;

            public Func<ICloudBlob, bool> ExecuteLambda { get; set; }

            public Task<FunctionResult> ExecuteAsync(BlobTriggerExecutorContext value, CancellationToken cancellationToken)
            {
                bool succeeded = true;

                // Only invoke if it's a new blob.
                if (!_blobReceipts.Contains(value.Blob.Name))
                {
                    succeeded = ExecuteLambda.Invoke(value.Blob);

                    if (succeeded)
                    {
                        _blobReceipts.Add(value.Blob.Name);
                    }
                }

                FunctionResult result = new FunctionResult(succeeded);
                return Task.FromResult(result);
            }
        }

        private class TestBlobScanInfoManager : IBlobScanInfoManager
        {
            private IDictionary<string, IDictionary<string, DateTime>> _latestScans;

            public TestBlobScanInfoManager()
            {
                _latestScans = new Dictionary<string, IDictionary<string, DateTime>>();
                UpdateCounts = new Dictionary<string, IDictionary<string, int>>();
            }

            public IDictionary<string, IDictionary<string, int>> UpdateCounts { get; private set; }

            public Task<DateTime?> LoadLatestScanAsync(string storageAccountName, string containerName)
            {
                DateTime? value = null;
                IDictionary<string, DateTime> accounts;
                if (_latestScans.TryGetValue(storageAccountName, out accounts))
                {
                    DateTime latestScan;
                    if (accounts.TryGetValue(containerName, out latestScan))
                    {
                        value = latestScan;
                    }
                }

                return Task.FromResult(value);
            }

            public Task UpdateLatestScanAsync(string storageAccountName, string containerName, DateTime latestScan)
            {
                SetScanInfo(storageAccountName, containerName, latestScan);
                IncrementCount(storageAccountName, containerName);
                return Task.FromResult(0);
            }

            public void SetScanInfo(string storageAccountName, string containerName, DateTime latestScan)
            {
                IDictionary<string, DateTime> containers;

                if (!_latestScans.TryGetValue(storageAccountName, out containers))
                {
                    _latestScans[storageAccountName] = new Dictionary<string, DateTime>();
                    containers = _latestScans[storageAccountName];
                }

                containers[containerName] = latestScan;
            }

            private void IncrementCount(string storageAccountName, string containerName)
            {
                IDictionary<string, int> counts;
                if (!UpdateCounts.TryGetValue(storageAccountName, out counts))
                {
                    UpdateCounts[storageAccountName] = new Dictionary<string, int>();
                    counts = UpdateCounts[storageAccountName];
                }

                if (counts.ContainsKey(containerName))
                {
                    counts[containerName]++;
                }
                else
                {
                    counts[containerName] = 1;
                }
            }
        }
    }
}
