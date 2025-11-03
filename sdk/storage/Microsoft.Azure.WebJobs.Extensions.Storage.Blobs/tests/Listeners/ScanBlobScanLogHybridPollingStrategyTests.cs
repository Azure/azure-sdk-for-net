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
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class ScanBlobScanLogHybridPollingStrategyTests
    {
        private const string ContainerName = "fakecontainer";
        private const string SecondContainerName = "fakecontainer2";
        private const string AccountName = "fakeaccount";
        private IWebJobsExceptionHandler _exceptionHandler;
        private TestLoggerProvider _loggerProvider;
        private ILogger<BlobListener> _logger;
        private Mock<BlobServiceClient> _blobClientMock;
        private Mock<BlobContainerClient> _blobContainerMock;
        private Mock<BlobContainerClient> _secondBlobContainerMock;
        private Mock<BlobContainerClient> _logsContainerMock;
        private BlobServiceProperties _serviceProperties;
        private List<BlobItem> _blobItems;
        private List<BlobItem> _secondBlobItems;

        [SetUp]
        public void Setup()
        {
            _exceptionHandler = new TestExceptionHandler();
            _loggerProvider = new TestLoggerProvider();
            _blobClientMock = new Mock<BlobServiceClient>(new Uri("https://fakeaccount.blob.core.windows.net/"), null);
            _blobContainerMock = new Mock<BlobContainerClient>(new Uri("https://fakeaccount.blob.core.windows.net/fakecontainer"), null);
            _secondBlobContainerMock = new Mock<BlobContainerClient>(new Uri("https://fakeaccount.blob.core.windows.net/fakecontainer2"), null);
            _logsContainerMock = new Mock<BlobContainerClient>(new Uri("https://fakeaccount.blob.core.windows.net/$logs"), null);
            _serviceProperties = new BlobServiceProperties();
            _blobItems = new List<BlobItem>();
            _secondBlobItems = new List<BlobItem>();
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(_loggerProvider);
            _logger = loggerFactory.CreateLogger<BlobListener>();
            _blobClientMock.Setup(x => x.Uri).Returns(new Uri("https://fakeaccount.blob.core.windows.net/"));
            _blobClientMock.Setup(x => x.AccountName).Returns(AccountName);
            _blobClientMock.Setup(x => x.GetBlobContainerClient("fakecontainer")).Returns(_blobContainerMock.Object);
            _blobClientMock.Setup(x => x.GetBlobContainerClient("fakecontainer2")).Returns(_secondBlobContainerMock.Object);
            _blobClientMock.Setup(x => x.GetBlobContainerClient("$logs")).Returns(_logsContainerMock.Object);
            _blobContainerMock.Setup(x => x.Uri).Returns(new Uri("https://fakeaccount.blob.core.windows.net/fakecontainer"));
            _blobContainerMock.Setup(x => x.Name).Returns(ContainerName);
            _blobContainerMock.Setup(x => x.AccountName).Returns(AccountName);
            _secondBlobContainerMock.Setup(x => x.Uri).Returns(new Uri("https://fakeaccount.blob.core.windows.net/fakecontainer2"));
            _secondBlobContainerMock.Setup(x => x.Name).Returns(SecondContainerName);
            _secondBlobContainerMock.Setup(x => x.AccountName).Returns(AccountName);
            _blobClientMock.Setup(x => x.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(_serviceProperties, null));
            _blobContainerMock.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    return new TestAsyncPageable<BlobItem>(_blobItems);
                });
            _blobContainerMock.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    return new TestAsyncPageable<BlobItem>(_blobItems);
                });
            _secondBlobContainerMock.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                 .Returns(() =>
                 {
                     return new TestAsyncPageable<BlobItem>(_secondBlobItems);
                 });
            _secondBlobContainerMock.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                 .Returns(() =>
                 {
                     return new TestAsyncPageable<BlobItem>(_secondBlobItems);
                 });
            _logsContainerMock.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                 .Returns(() =>
                 {
                     return new TestAsyncPageable<BlobItem>(new List<BlobItem>());
                 });
            _logsContainerMock.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                 .Returns(() =>
                 {
                     return new TestAsyncPageable<BlobItem>(new List<BlobItem>());
                 });
        }

        [Test]
         public void ScanBlobScanLogHybridPollingStrategyTestBlobListener()
        {
            var container = _blobContainerMock.Object;
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, _logger);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            product.Register(
                _blobClientMock.Object,
                container,
                executor);
            product.Start();

            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);

            string expectedBlobName = CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems);

            RunExecuterWithExpectedBlobs(new List<string>() { expectedBlobName }, product, executor);

            // Now run again; shouldn't show up.
            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);

            // Verify happy-path logging.
            var logMessages = _loggerProvider.GetAllLogMessages().ToArray();
            Assert.AreEqual(4, logMessages.Length);

            // 1 initialization log
            var initLog = logMessages.Single(m => m.EventId.Name == "InitializedScanInfo");
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Debug, initLog.Level);
            Assert.AreEqual(3, initLog.State.Count());
            Assert.AreEqual(ContainerName, initLog.GetStateValue<string>("containerName"));
            Assert.True(!string.IsNullOrWhiteSpace(initLog.GetStateValue<string>("latestScanInfo")));
            Assert.True(!string.IsNullOrWhiteSpace(initLog.GetStateValue<string>("{OriginalFormat}")));

            // 3 polling logs
            var pollLogs = logMessages.Where(m => m.EventId.Name == "PollBlobContainer").ToArray();
            Assert.AreEqual(3, pollLogs.Length);

            void ValidatePollingLog(LogMessage pollingLog, int expectedBlobCount)
            {
                Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Debug, pollingLog.Level);
                Assert.AreEqual(7, pollingLog.State.Count());
                Assert.AreEqual(ContainerName, pollingLog.GetStateValue<string>("containerName"));
                Assert.AreEqual(expectedBlobCount, pollingLog.GetStateValue<int>("blobCount"));
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

        [Test]
        public void TestBlobListenerWithContainerBiggerThanThreshold()
        {
            int testScanBlobLimitPerPoll = 1;
            var container = _blobContainerMock.Object;
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(
                _blobClientMock.Object,
                container,
                executor);
            product.Start();

            // populate with 5 blobs
            List<string> expectedNames = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                expectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems));
            }

            RunExecuteWithMultiPollingInterval(expectedNames, product, executor, testScanBlobLimitPerPoll);

            // Now run again; shouldn't show up.
            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);
        }

        [Test]
        public void TestBlobListenerWithMultipleContainers()
        {
            int testScanBlobLimitPerPoll = 6, containerCount = 2;
            var firstContainer = _blobContainerMock.Object;
            var secondContainer = _secondBlobContainerMock.Object;
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(
                _blobClientMock.Object,
                firstContainer,
                executor);
            product.Register(
                _blobClientMock.Object,
                secondContainer,
                executor);
            product.Start();

            // populate first container with 5 blobs > page size and second with 2 blobs < page size
            // page size is going to be testScanBlobLimitPerPoll / number of container 6/2 = 3
            List<string> firstContainerExpectedNames = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                firstContainerExpectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems));
            }

            RunExecuteWithMultiPollingInterval(firstContainerExpectedNames, product, executor, testScanBlobLimitPerPoll / containerCount);

            Thread.Sleep(10);

            List<string> secondContainerExpectedNames = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                secondContainerExpectedNames.Add(CreateBlobAndUploadToContainer(_secondBlobContainerMock, _secondBlobItems));
            }

            RunExecuteWithMultiPollingInterval(secondContainerExpectedNames, product, executor, testScanBlobLimitPerPoll / containerCount);

            // Now run again; shouldn't show up.
            RunExecuterWithExpectedBlobs(new List<string>(), product, executor);
        }

        [Test]
        public void BlobPolling_IgnoresClockSkew()
        {
            int testScanBlobLimitPerPoll = 3;
            var now = DateTimeOffset.UtcNow;
            var timeMap = new Dictionary<string, DateTimeOffset>();
            var container = _blobContainerMock.Object;
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(
                _blobClientMock.Object,
                container,
                executor);
            product.Start();

            List<string> expectedNames = new List<string>();
            expectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems));
            timeMap[expectedNames.Single()] = now.AddSeconds(-60);
            RunExecuterWithExpectedBlobs(expectedNames, product, executor);

            expectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems));
            timeMap[expectedNames.Last()] = now.AddSeconds(-59);

            // We should see the new item. We'll see 2 blobs, but only process 1 (due to receipt).
            RunExecuterWithExpectedBlobs(expectedNames, product, executor, 1);

            _blobContainerMock.Verify(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            Assert.AreEqual(expectedNames, executor.BlobReceipts);
        }

        [Test]
        public void BlobPolling_IncludesPreviousBatch()
        {
            // Blob timestamps are rounded to the nearest second, so make sure we continue to poll
            // the previous second to catch any blobs that came in slightly after our previous attempt.
            int testScanBlobLimitPerPoll = 3;
            string containerName = Path.GetRandomFileName();

            // Strip off milliseconds.
            var now = DateTimeOffset.UtcNow;
            now = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Offset);

            var container = _blobContainerMock.Object;

            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(new TestBlobScanInfoManager(), _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                   .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                   .SetValue(product, testScanBlobLimitPerPoll);

            product.Register(
                _blobClientMock.Object,
                container,
                executor);
            product.Start();

            List<string> expectedNames = new List<string>();
            expectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems, lastModified: now));

            RunExecuterWithExpectedBlobs(expectedNames, product, executor);

            expectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems, lastModified: now));

            // We should see the new item. We'll see 2 blobs, but only process 1 (due to receipt).
            RunExecuterWithExpectedBlobs(expectedNames, product, executor, 1);

            _blobContainerMock.Verify(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2));
            Assert.AreEqual(expectedNames, executor.BlobReceipts);
        }

        [Test]
        public async Task RegisterAsync_InitializesWithScanInfoManager()
        {
            var container = _blobContainerMock.Object;
            TestBlobScanInfoManager scanInfoManager = new TestBlobScanInfoManager();
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(scanInfoManager, _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();

            // Create a few blobs.
            for (int i = 0; i < 5; i++)
            {
                CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems);
            }

            // delay slightly so we guarantee a later timestamp
            await Task.Delay(10);

            await scanInfoManager.UpdateLatestScanAsync(AccountName, ContainerName, DateTime.UtcNow);
            await product.RegisterAsync(
                _blobClientMock.Object,
                container,
                executor,
                CancellationToken.None);

            // delay slightly so we guarantee a later timestamp
            await Task.Delay(10);

            var expectedNames = new List<string>();
            expectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems));

            RunExecuterWithExpectedBlobs(expectedNames, product, executor);
        }

        [Test]
        public async Task ExecuteAsync_UpdatesScanInfoManager()
        {
            int testScanBlobLimitPerPoll = 6;
            BlobContainerClient firstContainer = _blobContainerMock.Object;
            BlobContainerClient secondContainer = _secondBlobContainerMock.Object;
            TestBlobScanInfoManager testScanInfoManager = new TestBlobScanInfoManager();
            string accountName = AccountName;
            testScanInfoManager.SetScanInfo(accountName, ContainerName, DateTime.MinValue);
            testScanInfoManager.SetScanInfo(accountName, SecondContainerName, DateTime.MinValue);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(testScanInfoManager, _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                  .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                  .SetValue(product, testScanBlobLimitPerPoll);

            await product.RegisterAsync(
                _blobClientMock.Object,
                firstContainer,
                executor,
                CancellationToken.None);
            await product.RegisterAsync(
                _blobClientMock.Object,
                secondContainer,
                executor,
                CancellationToken.None);

            var firstExpectedNames = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                firstExpectedNames.Add(CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems));
            }
            RunExecuteWithMultiPollingInterval(firstExpectedNames, product, executor, testScanBlobLimitPerPoll / 2);

            // only expect the first container to have updated its scanInfo
            Assert.AreEqual(1, testScanInfoManager.UpdateCounts[accountName][ContainerName]);
            int count;
            testScanInfoManager.UpdateCounts[accountName].TryGetValue(SecondContainerName, out count);
            Assert.AreEqual(0, count);

            await Task.Delay(10);

            var secondExpectedNames = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                secondExpectedNames.Add(CreateBlobAndUploadToContainer(_secondBlobContainerMock, _secondBlobItems));
            }
            RunExecuteWithMultiPollingInterval(secondExpectedNames, product, executor, testScanBlobLimitPerPoll / 2);

            // this time, only expect the second container to have updated its scanInfo
            Assert.AreEqual(1, testScanInfoManager.UpdateCounts[accountName][ContainerName]);
            Assert.AreEqual(1, testScanInfoManager.UpdateCounts[accountName][SecondContainerName]);
        }

        [Test]
        public async Task ExecuteAsync_UpdatesScanInfo_WithEarliestFailure()
        {
            int testScanBlobLimitPerPoll = 6;

            // we'll introduce multiple errors to make sure we take the earliest timestamp
            DateTime earliestErrorTime = DateTime.UtcNow;

            var container = _blobContainerMock.Object;

            TestBlobScanInfoManager testScanInfoManager = new TestBlobScanInfoManager();
            string accountName = AccountName;
            testScanInfoManager.SetScanInfo(accountName, ContainerName, DateTime.MinValue);
            IBlobListenerStrategy product = new ScanBlobScanLogHybridPollingStrategy(testScanInfoManager, _exceptionHandler, NullLogger<BlobListener>.Instance);
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            typeof(ScanBlobScanLogHybridPollingStrategy)
                  .GetField("_scanBlobLimitPerPoll", BindingFlags.Instance | BindingFlags.NonPublic)
                  .SetValue(product, testScanBlobLimitPerPoll);

            await product.RegisterAsync(
                _blobClientMock.Object,
                container,
                executor,
                CancellationToken.None);

            // Induce a failure to make sure the timestamp is earlier than the failure.
            var expectedNames = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                string name;
                if (i % 3 == 0)
                {
                    name = CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems, "throw", earliestErrorTime.AddMinutes(i));
                }
                else
                {
                    name = CreateBlobAndUploadToContainer(_blobContainerMock, _blobItems, "test", earliestErrorTime.AddMinutes(10));
                }
                expectedNames.Add(name);
            }

            RunExecuteWithMultiPollingInterval(expectedNames, product, executor, testScanBlobLimitPerPoll);

            DateTime? storedTime = await testScanInfoManager.LoadLatestScanAsync(accountName, ContainerName);
            Assert.True(storedTime < earliestErrorTime);
            Assert.AreEqual(1, testScanInfoManager.UpdateCounts[accountName][ContainerName]);
            _blobContainerMock.Verify(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
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
                    CollectionAssert.Contains(blobNameMap.Keys, b.Name);
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
                Assert.AreEqual(expectedCount, count);
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

        private string CreateBlobAndUploadToContainer(Mock<BlobContainerClient> containerMock, List<BlobItem> blobItems, string blobContent = "test", DateTimeOffset lastModified = default)
        {
            string blobName = Path.GetRandomFileName().Replace(".", "");
            Mock<BlobBaseClient> item = new Mock<BlobBaseClient>();

            if (lastModified == default)
            {
                lastModified = DateTimeOffset.UtcNow;
            }
            var blobProperties = BlobsModelFactory.BlobProperties(lastModified: lastModified);

            item.Setup(x => x.GetPropertiesAsync(null, It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(blobProperties, null));
            item.Setup(x => x.Name).Returns(blobName);

            BlobItemProperties blobItemProperties = BlobsModelFactory.BlobItemProperties(true, lastModified: lastModified);
            BlobItem blobItem = BlobsModelFactory.BlobItem(
                name: blobName,
                properties: blobItemProperties
                );

            blobItems.Add(blobItem);

            Mock<BlobClient> blobClientMock = new Mock<BlobClient>();
            blobClientMock.Setup(x => x.Name).Returns(blobName);
            blobClientMock.Setup(x => x.Download(It.IsAny<CancellationToken>())).Returns( () =>
                Response.FromValue(BlobsModelFactory.BlobDownloadInfo(content: new MemoryStream(Encoding.UTF8.GetBytes(blobContent))), null));
            blobClientMock.Setup(x => x.GetProperties(It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(blobProperties, null));
            containerMock.Setup(x => x.GetBlobClient(blobName)).Returns(blobClientMock.Object);

            return blobName;
        }

        private class LambdaBlobTriggerExecutor : ITriggerExecutor<BlobTriggerExecutorContext>
        {
            public ICollection<string> _blobReceipts { get; } = new Collection<string>();

            public IEnumerable<string> BlobReceipts => _blobReceipts;

            public Func<BlobBaseClient, bool> ExecuteLambda { get; set; }

            public Task<FunctionResult> ExecuteAsync(BlobTriggerExecutorContext value, CancellationToken cancellationToken)
            {
                bool succeeded = true;

                // Only invoke if it's a new blob.
                if (!_blobReceipts.Contains(value.Blob.BlobClient.Name))
                {
                    succeeded = ExecuteLambda.Invoke(value.Blob.BlobClient);

                    if (succeeded)
                    {
                        _blobReceipts.Add(value.Blob.BlobClient.Name);
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
