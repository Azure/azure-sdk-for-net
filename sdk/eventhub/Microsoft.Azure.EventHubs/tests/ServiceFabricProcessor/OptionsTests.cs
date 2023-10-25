// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Microsoft.ServiceFabric.Data;
    using Microsoft.ServiceFabric.Data.Collections;
    using Xunit;

    public class OptionsTests
    {
        [Fact(Skip ="Intermittent failures.  Tracked by #12929")]
        [DisplayTestMethodName]
        public void SimpleOptionsTest()
        {
            TestState state = new TestState();
            state.Initialize("SimpleOptions", 1, 0);
            const int testBatchSize = 42;
            Assert.False(state.Options.MaxBatchSize == testBatchSize); // make sure new value is not the same as the default
            state.Options.MaxBatchSize = testBatchSize;
            const int testPrefetchCount = 444;
            Assert.False(state.Options.PrefetchCount == testPrefetchCount);
            state.Options.PrefetchCount = testPrefetchCount;
            TimeSpan testReceiveTimeout = TimeSpan.FromSeconds(10.0);
            Assert.False(state.Options.ReceiveTimeout.Equals(testReceiveTimeout));
            state.Options.ReceiveTimeout = testReceiveTimeout;
            ReceiverOptions receiverOptions = new ReceiverOptions();
            Assert.Null(receiverOptions.Identifier);
            const string tag = "SimpleOptions";
            receiverOptions.Identifier = tag;
            state.Options.ClientReceiverOptions = receiverOptions;

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
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(1, tag);

            state.PrepareToRun();
            state.StartRun(sfp);

            state.VerifyNormalStartup(10);
            state.CountNBatches(5, 10);

            // EXPECTED RESULT: Normal processing. Validate that simple options MaxBatchSize, PrefetchCount, ReceiveTimeout,
            // and ClientReceiverOptions are passed through to EH API.
            Assert.True(EventHubMocks.PartitionReceiverMock.receivers.ContainsKey(tag), "Cannot find receiver");
            EventHubMocks.PartitionReceiverMock testReceiver = EventHubMocks.PartitionReceiverMock.receivers[tag];
            Assert.True(testReceiver.HandlerBatchSize == testBatchSize, $"Unexpected batch size {testReceiver.HandlerBatchSize}");
            Assert.True(testReceiver.PrefetchCount == testPrefetchCount, $"Unexpected prefetch count {testReceiver.PrefetchCount}");
            Assert.True(testReceiver.ReceiveTimeout.Equals(testReceiveTimeout),
                $"Unexpected receive timeout {testReceiver.ReceiveTimeout}");
            Assert.NotNull(testReceiver.Options);
            Assert.Equal(tag, testReceiver.Options.Identifier);

            // EnableReceiverRuntimeMetric is false by default. This case is a convenient opportunity to
            // verify that RuntimeInformation was not updated when the option is false.
            Assert.True(state.Processor.LatestContext.RuntimeInformation.LastSequenceNumber == -1L,
                $"RuntimeInformation.LastSequenceNumber is {state.Processor.LatestContext.RuntimeInformation.LastSequenceNumber}");

            state.DoNormalShutdown(10);

            state.WaitRun();

            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        public void UseInitialPositionProviderTest()
        {
            TestState state = new TestState();
            state.Initialize("UseInitialPositionProvider", 1, 0);
            const long firstSequenceNumber = 3456L;
            state.Options.InitialPositionProvider = (partitionId) => { return EventPosition.FromSequenceNumber(firstSequenceNumber); };

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

            // EXPECTED RESULT: Normal processing. Sequence number of first event processed should match that
            // supplied in the InitialPositionProvider.
            Assert.True(state.Processor.FirstEvent.SystemProperties.SequenceNumber == (firstSequenceNumber + 1L),
                $"Got unexpected first sequence number {state.Processor.FirstEvent.SystemProperties.SequenceNumber}");
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        public void IgnoreInitialPositionProviderTest()
        {
            TestState state = new TestState();
            state.Initialize("IgnoreInitialPositionProvider", 1, 0);
            const long ippSequenceNumber = 3456L;
            state.Options.InitialPositionProvider = (partitionId) => { return EventPosition.FromSequenceNumber(ippSequenceNumber); };

            // Fake up a checkpoint using code borrowed from ReliableDictionaryCheckpointManager
            IReliableDictionary<string, Dictionary<string, object>> store =
                state.StateManager.GetOrAddAsync<IReliableDictionary<string, Dictionary<string, object>>>("EventProcessorCheckpointDictionary").Result;
            const long checkpointSequenceNumber = 8888L;
            Checkpoint fake = new Checkpoint((checkpointSequenceNumber * 100L).ToString(), checkpointSequenceNumber);
            using (ITransaction tx = state.StateManager.CreateTransaction())
            {
                store.SetAsync(tx, "0", fake.ToDictionary(), TimeSpan.FromSeconds(5.0), CancellationToken.None).Wait();
                tx.CommitAsync().Wait();
            }

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

            // EXPECTED RESULT: Normal processing. Sequence number of first event processed should match that
            // supplied in the checkpoint, NOT the InitialPositionProvider.
            Assert.True(state.Processor.FirstEvent.SystemProperties.SequenceNumber == (checkpointSequenceNumber + 1L),
                $"Got unexpected first sequence number {state.Processor.FirstEvent.SystemProperties.SequenceNumber}");
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact(Skip="Causing instability in CI and nightly runs.  Issue: #7472")]
        [DisplayTestMethodName]
        public void RuntimeInformationTest()
        {
            TestState state = new TestState();
            state.Initialize("RuntimeInformation", 1, 0);
            state.Options.EnableReceiverRuntimeMetric = true;

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

            // EXPECTED RESULT: Normal processing. Verify that the RuntimeInformation property of the partition
            // context is updated.
            Assert.True(state.Processor.LatestContext.RuntimeInformation.LastSequenceNumber == state.Processor.LastEvent.SystemProperties.SequenceNumber);

            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }
    }
}
