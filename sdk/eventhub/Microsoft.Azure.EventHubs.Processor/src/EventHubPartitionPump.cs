// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class EventHubPartitionPump : PartitionPump
    {
        EventHubClient eventHubClient;
        PartitionReceiver partitionReceiver;
        PartitionReceiveHandler partitionReceiveHandler;

        public EventHubPartitionPump(EventProcessorHost host, Lease lease)
            : base(host, lease)
        {
        }

        protected override async Task OnOpenAsync()
        {
            bool openedOK = false;
            int retryCount = 0;
            Exception lastException = null;
            do
            {
                try
                {
                    await OpenClientsAsync().ConfigureAwait(false);
                    openedOK = true;
                }
                catch (Exception e)
                {
                    lastException = e;
                    ProcessorEventSource.Log.PartitionPumpWarning(
                        this.Host.HostName, this.PartitionContext.PartitionId, "Failure creating client or receiver, retrying", e.ToString());

                    // Don't retry if we already lost the lease.
                    if (e is ReceiverDisconnectedException)
                    {
                        break;
                    }

                    retryCount++;
                }
            }
            while (!openedOK && (retryCount < 5));

            if (!openedOK)
            {
                // IEventProcessor.onOpen is called from the base PartitionPump and must have returned in order for execution to reach here, 
                // so we can report this error to it instead of the general error handler.
                await this.Processor.ProcessErrorAsync(this.PartitionContext, lastException).ConfigureAwait(false);
                this.PumpStatus = PartitionPumpStatus.OpenFailed;
            }

            if (this.PumpStatus == PartitionPumpStatus.Opening)
            {
                this.partitionReceiveHandler = new PartitionReceiveHandler(this);
                // IEventProcessor.OnOpen is called from the base PartitionPump and must have returned in order for execution to reach here, 
                // meaning it is safe to set the handler and start calling IEventProcessor.OnEvents.
                // Set the status to running before setting the client handler, so the IEventProcessor.OnEvents can never race and see status != running.
                this.PumpStatus = PartitionPumpStatus.Running;
                this.partitionReceiver.SetReceiveHandler(
                    this.partitionReceiveHandler,
                    this.Host.EventProcessorOptions.InvokeProcessorAfterReceiveTimeout);
            }

            if (this.PumpStatus == PartitionPumpStatus.OpenFailed)
            {
                this.PumpStatus = PartitionPumpStatus.Closing;
                await this.CleanUpClientsAsync().ConfigureAwait(false);
                this.PumpStatus = PartitionPumpStatus.Closed;
            }
        }

        async Task OpenClientsAsync() // throws EventHubsException, IOException, InterruptedException, ExecutionException
        {
            // Create new clients
            EventPosition eventPosition = await this.PartitionContext.GetInitialOffsetAsync().ConfigureAwait(false);
            long epoch = this.Lease.Epoch;
            ProcessorEventSource.Log.PartitionPumpCreateClientsStart(this.Host.HostName, this.PartitionContext.PartitionId, epoch,
                $"Offset:{eventPosition.Offset}, SequenceNumber:{eventPosition.SequenceNumber}, DateTime:{eventPosition.EnqueuedTimeUtc}");
            this.eventHubClient = this.Host.CreateEventHubClient();
            this.eventHubClient.WebProxy = this.Host.EventProcessorOptions.WebProxy;

            var receiverOptions = new ReceiverOptions()
            {
                // Enable receiver metrics?
                EnableReceiverRuntimeMetric = this.Host.EventProcessorOptions.EnableReceiverRuntimeMetric
            };

            // Create new receiver and set options
            this.partitionReceiver = this.eventHubClient.CreateEpochReceiver(
                this.PartitionContext.ConsumerGroupName,
                this.PartitionContext.PartitionId,
                eventPosition,
                epoch,
                receiverOptions);

            this.partitionReceiver.PrefetchCount = this.Host.EventProcessorOptions.PrefetchCount;

            ProcessorEventSource.Log.PartitionPumpCreateClientsStop(this.Host.HostName, this.PartitionContext.PartitionId);
        }

        async Task CleanUpClientsAsync() // swallows all exceptions
        {
            if (this.partitionReceiver != null)
            {
                // Taking the lock means that there is no ProcessEventsAsync call in progress.
                Task closeTask;
                using (await this.ProcessingAsyncLock.LockAsync().ConfigureAwait(false))
                {
                    // Calling PartitionReceiver.CloseAsync will gracefully close the IPartitionReceiveHandler we have installed.
                    ProcessorEventSource.Log.PartitionPumpInfo(this.Host.HostName, this.PartitionContext.PartitionId, "Closing PartitionReceiver");
                    closeTask = this.partitionReceiver.CloseAsync();
                }

                await closeTask.ConfigureAwait(false);
                this.partitionReceiver = null;
            }

            if (this.eventHubClient != null)
            {
                ProcessorEventSource.Log.PartitionPumpInfo(this.Host.HostName, this.PartitionContext.PartitionId, "Closing EventHubClient");
                await this.eventHubClient.CloseAsync().ConfigureAwait(false);
                this.eventHubClient = null;
            }
        }

        protected override Task OnClosingAsync(CloseReason reason)
        {
            // Close the EH clients. Errors are swallowed, nothing we could do about them anyway.
            return CleanUpClientsAsync();
        }

        class PartitionReceiveHandler : IPartitionReceiveHandler
        {
            readonly EventHubPartitionPump eventHubPartitionPump;

            public PartitionReceiveHandler(EventHubPartitionPump eventHubPartitionPump)
            {
                this.eventHubPartitionPump = eventHubPartitionPump;
                this.MaxBatchSize = eventHubPartitionPump.Host.EventProcessorOptions.MaxBatchSize;
            }

            public int MaxBatchSize { get; set; }

            public Task ProcessEventsAsync(IEnumerable<EventData> events)
            {
                // This method is called on the thread that the EH client uses to run the pump.
                // There is one pump per EventHubClient. Since each PartitionPump creates a new EventHubClient,
                // using that thread to call OnEvents does no harm. Even if OnEvents is slow, the pump will
                // get control back each time OnEvents returns, and be able to receive a new batch of messages
                // with which to make the next OnEvents call. The pump gains nothing by running faster than OnEvents.
                return this.eventHubPartitionPump.ProcessEventsAsync(events);
            }

            public async Task ProcessErrorAsync(Exception error)
            {
                bool faultPump;

                if (error == null)
                {
                    error = new Exception("No error info supplied by EventHub client");
                }

                if (error is ReceiverDisconnectedException)
                {
                    // Trace as warning since ReceiverDisconnectedException is part of lease stealing logic.
                    ProcessorEventSource.Log.PartitionPumpWarning(
                        this.eventHubPartitionPump.Host.HostName, this.eventHubPartitionPump.PartitionContext.PartitionId,
                        "EventHub client disconnected, probably another host took the partition", error.Message);

                    // Shutdown the message pump when receiver is disconnected.
                    faultPump = true;
                }
                else
                {
                    ProcessorEventSource.Log.PartitionPumpError(
                        this.eventHubPartitionPump.Host.HostName, this.eventHubPartitionPump.PartitionContext.PartitionId, "EventHub client error:", error.ToString());

                    // No need to fault the pump, we expect receiver to recover on its own.
                    faultPump = false;
                }

                try
                {
                    // We would like to deliver all errors in the pump to error handler.
                    await this.eventHubPartitionPump.ProcessErrorAsync(error).ConfigureAwait(false);
                }
                finally
                {
                    // Fault pump only when needed.
                    if (faultPump)
                    {
                        this.eventHubPartitionPump.PumpStatus = PartitionPumpStatus.Errored;
                    }
                }
            }
        }
    }
}
