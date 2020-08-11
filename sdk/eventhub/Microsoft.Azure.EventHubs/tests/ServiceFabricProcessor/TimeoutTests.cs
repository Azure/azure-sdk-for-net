// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Xunit;

    public class TimeoutTests
    {
        [Fact]
        [DisplayTestMethodName]
        public void TimeoutSuppressTest()
        {
            TestState state = new TestState();
            state.Initialize("timeoutsuppress", 1, 0);
            state.Options.ReceiveTimeout = TimeSpan.FromMilliseconds(10);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options)
            {
                MockMode = state.PartitionLister,
                EventHubClientFactory = new TimeoutEventHubClientFactoryMock(1)
            };

            state.PrepareToRun();
            state.StartRun(sfp);

            state.VerifyNormalStartup(10);

            Thread.Sleep((int)state.Options.ReceiveTimeout.TotalMilliseconds * 10); // sleep to allow some timeouts

            state.DoNormalShutdown(10);
            state.WaitRun();

            // EXPECTED RESULT: Normal processing. Because calls on receive timeout are suppressed, batches should be 0.
            Assert.True(state.Processor.TotalBatches == 0, $"ProcessEvents was called {state.Processor.TotalBatches} times");
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact(Skip ="Intermittent failures.  Tracked by #12930")]
        [DisplayTestMethodName]
        public void TimeoutInvokeTest()
        {
            TestState state = new TestState();
            state.Initialize("timeoutinvoke", 1, 0);
            state.Options.ReceiveTimeout = TimeSpan.FromMilliseconds(10);
            state.Options.InvokeProcessorAfterReceiveTimeout = true;

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options)
            {
                MockMode = state.PartitionLister,
                EventHubClientFactory = new TimeoutEventHubClientFactoryMock(1)
            };

            state.PrepareToRun();
            state.StartRun(sfp);

            state.VerifyNormalStartup(10);

            state.CountNBatches(1, 10);

            state.DoNormalShutdown(10);
            state.WaitRun();

            // EXPECTED RESULT: Normal processing. Calls on receive timeout are enabled, so batches should be nonzero.
            Assert.True(state.Processor.TotalBatches > 0, "ProcessEvents was not called");
            Assert.True(state.Processor.TotalEvents == 0, $"ProcessEvents got {state.Processor.TotalEvents} events");
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        private class TimeoutPartitionReceiverMock : EventHubMocks.PartitionReceiverMock
        {
            internal TimeoutPartitionReceiverMock(string partitionId, long sequenceNumber, CancellationToken token, TimeSpan pumpTimeout) :
                base(partitionId, sequenceNumber, token, pumpTimeout, null, null)
            {
            }

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maxEventCount, TimeSpan waitTime)
            {
                Thread.Sleep(waitTime);
                return Task.FromResult<IEnumerable<EventData>>(null);
            }
        }

        private class TimeoutEventHubClientMock : EventHubMocks.EventHubClientMock
        {
            internal TimeoutEventHubClientMock(int partitionCount, EventHubsConnectionStringBuilder csb) : base(partitionCount, csb, null)
            {
            }

            public override EventHubWrappers.IPartitionReceiver CreateEpochReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long epoch, ReceiverOptions receiverOptions)
            {
                long startSeq = CalculateStartSeq(eventPosition);
                return new TimeoutPartitionReceiverMock(partitionId, startSeq, this.token, this.csb.OperationTimeout);
            }
        }

        private class TimeoutEventHubClientFactoryMock : EventHubWrappers.IEventHubClientFactory
        {
            private readonly int partitionCount;

            internal TimeoutEventHubClientFactoryMock(int partitionCount)
            {
                this.partitionCount = partitionCount;
            }

            /// <summary>
            /// Dispense a mock instance operating on a fake event hub with name taken from the connection string.
            /// </summary>
            /// <param name="connectionString"></param>
            /// <param name="receiveTimeout"></param>
            /// <returns></returns>
            public virtual EventHubWrappers.IEventHubClient Create(string connectionString, TimeSpan receiveTimeout)
            {
                EventHubsConnectionStringBuilder csb = new EventHubsConnectionStringBuilder(connectionString);
                csb.OperationTimeout = receiveTimeout;
                return new TimeoutEventHubClientMock(this.partitionCount, csb);
            }
        }
    }
}
