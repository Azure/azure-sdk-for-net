// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Xunit;

    public class CheckpointingTests
    {
        [Fact]
        [DisplayTestMethodName]
        void CheckpointBatchTest()
        {
            TestState state = new TestState();
            state.Initialize("checkpointing", 1, 0);
            state.Processor = new CheckpointingProcessor(state.Options);

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

            // EXPECTED RESULT: Normal processing. Last event processed is also the end of the batch
            // and hence the final checkpoint. Save for next stage validaiton.
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);

            EventData checkpointedEvent = state.Processor.LastEvent;
            Assert.NotNull(checkpointedEvent);
            Assert.True(checkpointedEvent.SystemProperties.SequenceNumber > 0L,
                $"Unexpected sequence number {checkpointedEvent.SystemProperties.SequenceNumber}");

            state.Processor = new CheckpointingProcessor(state.Options);

            sfp = new ServiceFabricProcessor(
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

            state.RunForNBatches(1, 10);

            state.WaitRun();

            // EXPECTED RESULT: Normal processing. The sequence number of the first event processed in
            // this stage should be one higher than the sequence number of the last event processed in
            // the previous stage.
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);

            EventData restartEvent = ((CheckpointingProcessor)state.Processor).FirstEvent;
            Assert.NotNull(restartEvent);

            Assert.True((restartEvent.SystemProperties.SequenceNumber - checkpointedEvent.SystemProperties.SequenceNumber) == 1,
                $"Unexpected change in sequence number from {checkpointedEvent.SystemProperties.SequenceNumber} to {restartEvent.SystemProperties.SequenceNumber}");
        }

        [Fact]
        [DisplayTestMethodName]
        void CheckpointEventTest()
        {
            TestState state = new TestState();
            state.Initialize("checkpointing", 1, 0);
            const long checkpointAt = 57L;
            state.Processor = new CheckpointingProcessor(state.Options, checkpointAt);

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

            // EXPECTED RESULT: Normal processing. This case checkpoints specific events. Validate that the
            // last event processed has a higher sequence number than the checkpointed event.
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);

            EventData checkpointedEvent = ((CheckpointingProcessor)state.Processor).CheckpointedEvent;
            Assert.NotNull(checkpointedEvent);
            Assert.True(checkpointedEvent.SystemProperties.SequenceNumber == checkpointAt,
                $"Checkpointed event has seq {checkpointedEvent.SystemProperties.SequenceNumber}, expected {checkpointAt}");

            EventData lastEvent = state.Processor.LastEvent;
            Assert.NotNull(lastEvent);
            Assert.True(lastEvent.SystemProperties.SequenceNumber > checkpointedEvent.SystemProperties.SequenceNumber,
                $"Unexpected sequence number {lastEvent.SystemProperties.SequenceNumber}");

            state.Processor = new CheckpointingProcessor(state.Options);

            sfp = new ServiceFabricProcessor(
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

            state.RunForNBatches(1, 10);

            state.WaitRun();

            // EXPECTED RESULT: Normal processing. The sequence number of the first event processed in
            // this stage should be one higher than the sequence number of the event checkpointed in
            // the previous stage.
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);

            EventData restartEvent = ((CheckpointingProcessor)state.Processor).FirstEvent;
            Assert.NotNull(restartEvent);

            Assert.True((restartEvent.SystemProperties.SequenceNumber - checkpointedEvent.SystemProperties.SequenceNumber) == 1,
                $"Unexpected change in sequence number from {checkpointedEvent.SystemProperties.SequenceNumber} to {restartEvent.SystemProperties.SequenceNumber}");
        }

        class CheckpointingProcessor : TestProcessor
        {
            private readonly long checkpointAt;

            public CheckpointingProcessor(EventProcessorOptions options, long checkpointAt = -1L) : base(options)
            {
                this.CheckpointedEvent = null;
                this.checkpointAt = checkpointAt;
            }

            public EventData CheckpointedEvent { get; private set; }

            public override Task ProcessEventsAsync(CancellationToken cancellationToken, PartitionContext context, IEnumerable<EventData> events)
            {
                Task retval = base.ProcessEventsAsync(cancellationToken, context, events);

                if (this.checkpointAt == -1L)
                {
                    retval = context.CheckpointAsync();
                }
                else
                {
                    foreach (EventData e in events)
                    {
                        if (e.SystemProperties.SequenceNumber == checkpointAt)
                        {
                            this.CheckpointedEvent = e;
                            retval = context.CheckpointAsync(e);
                        }
                    }
                }
                return retval;
            }
        }
    }
}
