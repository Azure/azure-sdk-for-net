// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Fabric;
    using System.Threading;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Microsoft.ServiceFabric.Data;
    using Microsoft.ServiceFabric.Data.Collections;
    using Xunit;

    public class SFPtestbase
    {
        public SFPtestbase()
        {
        }

        [Fact]
        [DisplayTestMethodName]
        void TestMockFabricPartitionLister()
        {
            TestState state = new TestState();
            state.Initialize("TestMockFabricPartitionLister", 1, 0);

            int setCount = 1;
            int setOrd = 0;
            IFabricPartitionLister mock = new MockPartitionLister(setCount, setOrd);
            int gotCount = mock.GetServiceFabricPartitionCount(state.ServiceUri).Result;
            Assert.True(gotCount == setCount, $"Returned count {gotCount} does not match original count {setCount}");
            int gotOrd = mock.GetServiceFabricPartitionOrdinal(state.ServicePartitionId).Result;
            Assert.True(gotOrd == setOrd, $"Returned ordinal {gotOrd} does not match original ordinal {setOrd}");
        }

        [Fact]
        [DisplayTestMethodName]
        void TestMockStatefulServicePartition()
        {
            IStatefulServicePartition mock = new MockStatefulServicePartition();
            List<LoadMetric> loadMetrics = new List<LoadMetric>();
            loadMetrics.Add(new LoadMetric("mockMetric", 42));
            mock.ReportLoad(loadMetrics);
        }

        [Fact]
        [DisplayTestMethodName]
        void TestMockTransaction()
        {
            ITransaction mock0 = new MockTransaction();
            ITransaction mock1 = new MockTransaction();

            long dummy = mock0.CommitSequenceNumber;
            long start = dummy;
            dummy = mock0.TransactionId;
            Assert.True(dummy == start, $"mock0.TransactionId is {dummy} not {start}");
            dummy = mock0.GetVisibilitySequenceNumberAsync().Result;
            Assert.True(dummy == start, $"mock0.GetVisibilitySequenceNumberAsync is {dummy} not {start}");
            dummy = mock1.CommitSequenceNumber;
            Assert.True(dummy == (start + 1), $"mock1.CommitSequenceNumber is {dummy} not {(start + 1)}");
            dummy = mock1.TransactionId;
            Assert.True(dummy == (start + 1), $"mock1.TransactionId is {dummy} not {(start + 1)}");
            dummy = mock1.GetVisibilitySequenceNumberAsync().Result;
            Assert.True(dummy == (start + 1), $"mock1.GetVisibilitySequenceNumberAsync is {dummy} not {(start + 1)}");

            mock0.Abort();
            mock0.Dispose();

            mock1.CommitAsync();
            mock1.Dispose();
        }

        [Fact]
        [DisplayTestMethodName]
        void TestMockReliableDictionary()
        {
            IReliableDictionary<string, Dictionary<string, object>> mock =
                new MockReliableDictionary<string, Dictionary<string, object>>();

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            TimeSpan timeout = TimeSpan.FromSeconds(10.0);
            ITransaction mockTx = new MockTransaction();

            Checkpoint ck1 = new Checkpoint("666", 1);
            mock.SetAsync(mockTx, "one", ck1.ToDictionary(), timeout, tokenSource.Token).Wait();
            Checkpoint ck2 = new Checkpoint("7777", 2);
            mock.SetAsync(mockTx, "two", ck2.ToDictionary(), timeout, tokenSource.Token).Wait();
            Checkpoint ck3 = new Checkpoint("88888", 3);
            mock.SetAsync(mockTx, "three", ck3.ToDictionary(), timeout, tokenSource.Token).Wait();

            ConditionalValue<Dictionary<string, object>> gotback;
            gotback = mock.TryGetValueAsync(mockTx, "nope", timeout, tokenSource.Token).Result;
            Assert.False(gotback.HasValue, "Found value for key 'nope'");

            gotback = mock.TryGetValueAsync(mockTx, "one", timeout, tokenSource.Token).Result;
            Assert.True(gotback.HasValue, "Did not find value for key 'one'");
            Checkpoint ck1back = Checkpoint.CreateFromDictionary(gotback.Value);
            Assert.Equal(ck1back.Offset, ck1.Offset);
            Assert.True(ck1back.SequenceNumber == ck1.SequenceNumber);
            gotback = mock.TryGetValueAsync(mockTx, "two", timeout, tokenSource.Token).Result;
            Assert.True(gotback.HasValue, "Did not find value for key 'two'");
            Checkpoint ck2back = Checkpoint.CreateFromDictionary(gotback.Value);
            Assert.Equal(ck2back.Offset, ck2.Offset);
            Assert.True(ck2back.SequenceNumber == ck2.SequenceNumber);
            gotback = mock.TryGetValueAsync(mockTx, "three", timeout, tokenSource.Token).Result;
            Assert.True(gotback.HasValue, "Did not find value for key 'three'");
            Checkpoint ck3back = Checkpoint.CreateFromDictionary(gotback.Value);
            Assert.Equal(ck3back.Offset, ck3.Offset);
            Assert.True(ck3back.SequenceNumber == ck3.SequenceNumber);
        }

        [Fact]
        [DisplayTestMethodName]
        void TestMockReliableStateManager()
        {
            IReliableStateManager mock = new MockReliableStateManager();

            ITransaction mockTx = mock.CreateTransaction();
            Assert.NotNull(mockTx);

            IReliableDictionary<string, Dictionary<string, object>> mockDict =
                mock.GetOrAddAsync<IReliableDictionary<string, Dictionary<string, object>>>("blah").Result;
            Assert.NotNull(mockDict);

            ConditionalValue<IReliableDictionary<string, Dictionary<string, object>>> dummy =
                mock.TryGetAsync<IReliableDictionary<string, Dictionary<string, object>>>("nope").Result;
            Assert.False(dummy.HasValue, "Found value for key 'nope'");

            dummy = mock.TryGetAsync<IReliableDictionary<string, Dictionary<string, object>>>("blah").Result;
            Assert.True(dummy.HasValue, "Did not find value for key 'blah'");
        }

        [Fact]
        [DisplayTestMethodName]
        void SmokeTest()
        {
            TestState state = new TestState();
            state.Initialize("smoke", 1, 0);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options);
            sfp.MockMode = state.PartitionLister;
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(1);

            state.PrepareToRun();
            state.StartRun(sfp);

            state.RunForNBatches(20, 10);

            state.WaitRun();

            // EXPECTED RESULT: Normal processing.
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        void PartitionCountEnforcement()
        {
            innerPartitionCountEnforcement(4, 16);
            innerPartitionCountEnforcement(4, 2);
        }

        private void innerPartitionCountEnforcement(int servicePartitions, int eventHubPartitions)
        {
            TestState state = new TestState();
            state.Initialize("partitioncountenforcement", servicePartitions, 0);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options);
            sfp.MockMode = state.PartitionLister;
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(eventHubPartitions);

            state.PrepareToRun();
            state.StartRun(sfp);

            int retries = 0;
            while (!state.HasShutDown && (retries < 10))
            {
                Thread.Sleep(1000);
                retries++;
            }

            // EXPECTED RESULT: EventProcessorConfigurationException, and IEventProcessor.OpenAsync is never called.
            Assert.True(state.HasShutDown, $"Shutdown notification did not occur after {retries} seconds");
            Assert.False(state.Processor.IsOpened, "Processor was opened");
            Assert.NotNull(state.ShutdownException);
            Assert.True(state.ShutdownException is EventProcessorConfigurationException,
                $"Unexpected exception type {state.ShutdownException.GetType().Name}");
            Assert.Equal($"Service partition count {servicePartitions} does not match event hub partition count {eventHubPartitions}",
                state.ShutdownException.Message);
        }
    }
}
