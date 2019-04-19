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

    class TestProcessor : IEventProcessor
    {
        private string partitionId;
        private string eventHub;
        private string consumerGroup;

        private readonly EventProcessorOptions options;

        public enum ErrorLocation { OnOpen, OnEvents, OnError, OnClose };

        public TestProcessor(EventProcessorOptions options)
        {
            this.Injector = null;

            this.IsOpened = false;
            this.IsClosed = false;
            this.TotalBatches = 0;
            this.LastBatchEvents = -1;
            this.TotalEvents = 0;
            this.LastError = null;
            this.FirstEvent = null;
            this.LastEvent = null;
            this.TotalErrors = 0;
            this.LatestContext = null;

            this.options = options;
        }

        public ErrorInjector Injector { get; set; }

        public bool IsOpened { get; private set; }

        public bool IsClosed { get; private set; }

        public int TotalBatches { get; private set; }

        public int LastBatchEvents { get; private set; }

        public int TotalEvents { get; private set; }

        public Exception LastError { get; private set; }

        public EventData FirstEvent { get; private set; }

        public EventData LastEvent { get; private set; }

        public int TotalErrors { get; private set; }

        public PartitionContext LatestContext { get; private set; }

        public override Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Assert.True(this.IsOpened, "Closing when not opened"); // open MUST come before close
            Assert.False(this.IsClosed, "Double close"); // close MUST NOT be called multiple times

            ValidateContext(context);
            // reason is an enum, can't be invalid

            this.Injector?.Inject(ErrorLocation.OnClose);

            this.IsClosed = true;

            return Task.CompletedTask;
        }

        public override Task OpenAsync(CancellationToken cancellationToken, PartitionContext context)
        {
            Assert.False(this.IsOpened, "Double open"); // open MUST NOT be called multiple times
            Assert.False(this.IsClosed, "Open after close"); // open MUST NOT be called on a closed object

            // cancellationToken is value type, can't be null
            Assert.NotNull(context);
            this.LatestContext = context;

            this.Injector?.Inject(ErrorLocation.OnOpen);

            this.IsOpened = true;

            // set up for later validation
            this.partitionId = context.PartitionId;
            this.eventHub = context.EventHubPath;
            this.consumerGroup = context.ConsumerGroupName;

            return Task.CompletedTask;
        }

        public override Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Assert.True(this.IsOpened, "ProcessError when not open"); // object MUST be open
            Assert.False(this.IsClosed, "ProcessError after close"); // object MUST NOT be closed

            ValidateContext(context);
            Assert.NotNull(error);

            this.LastError = error;
            this.TotalErrors++;

            this.Injector?.Inject(ErrorLocation.OnError);

            return Task.CompletedTask;
        }

        public override Task ProcessEventsAsync(CancellationToken cancellationToken, PartitionContext context, IEnumerable<EventData> events)
        {
            Assert.True(this.IsOpened, "ProcessEvents when not open"); // object MUST be open to process
            Assert.False(this.IsClosed, "ProcessEvents after close"); // object MUST NOT be closed when processing

            // cancellationToken is value type, can't be null
            ValidateContext(context);
            CountAndValidateBatch(events);

            this.Injector?.Inject(ErrorLocation.OnEvents);

            return Task.CompletedTask;
        }

        private void ValidateContext(PartitionContext context)
        {
            Assert.NotNull(context);

            this.LatestContext = context;

            // A given processor instance MUST always process the same hub+cg+partition.
            Assert.Equal(this.partitionId, context.PartitionId);
            Assert.Equal(this.eventHub, context.EventHubPath);
            Assert.Equal(this.consumerGroup, context.ConsumerGroupName);
        }

        private void CountAndValidateBatch(IEnumerable<EventData> events)
        {
            Assert.NotNull(events); // events MUST NOT be null -- empty can be valid, but null is a bug

            int count = 0;
            foreach (EventData e in events)
            {
                if (this.FirstEvent == null)
                {
                    this.FirstEvent = e;
                }
                this.LastEvent = e;
                count++;
            }

            Assert.True(count <= this.options.MaxBatchSize, "Batch too large"); // batch MUST NOT exceed user-set batch size
            if (this.options.InvokeProcessorAfterReceiveTimeout)
            {
                // count can only be 0 if options are set to call processor on receive timeout
                Assert.True(count >= 0, "Batch less than 0");
            }
            else
            {
                Assert.True(count >= 1, "Batch less than 1"); // otherwise, batch MUST contain at least one event
            }

            this.LastBatchEvents = count;
            this.TotalEvents += count;
            this.TotalBatches++;
        }

        internal class ErrorInjector
        {
            protected readonly List<ErrorLocation> locations;
            protected readonly Exception error;

            internal ErrorInjector(ErrorLocation errorAt, Exception error)
            {
                this.locations = new List<ErrorLocation>() { errorAt };
                this.error = error;
            }

            internal ErrorInjector(List<ErrorLocation> locations, Exception error)
            {
                this.locations = locations;
                this.error = error;
            }

            internal void Inject(ErrorLocation location)
            {
                if (this.locations.Contains(location))
                {
                    throw this.error;
                }
            }
        }
    }
}
