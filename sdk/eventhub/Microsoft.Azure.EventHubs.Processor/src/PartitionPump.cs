// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    abstract class PartitionPump
    {
        CancellationTokenSource cancellationTokenSource;

        protected PartitionPump(EventProcessorHost host, Lease lease)
        {
            this.Host = host;
            this.Lease = lease;
            this.ProcessingAsyncLock = new AsyncLock();
            this.PumpStatus = PartitionPumpStatus.Uninitialized;
        }

        protected EventProcessorHost Host { get; }

        protected internal Lease Lease { get; }

        protected IEventProcessor Processor { get; private set; }

        protected PartitionContext PartitionContext { get; private set; }

        protected AsyncLock ProcessingAsyncLock { get; }

        internal void SetLeaseToken(string newToken)
        {
            this.PartitionContext.Lease.Token = newToken;
        }

        public async Task OpenAsync()
        {
            this.PumpStatus = PartitionPumpStatus.Opening;

            this.cancellationTokenSource = new CancellationTokenSource();

            this.PartitionContext = new PartitionContext(
                this.Host, 
                this.Lease.PartitionId, 
                this.Host.EventHubPath, 
                this.Host.ConsumerGroupName, 
                this.cancellationTokenSource.Token);
            this.PartitionContext.Lease = this.Lease;

            if (this.PumpStatus == PartitionPumpStatus.Opening)
            {
                string action = EventProcessorHostActionStrings.CreatingEventProcessor;
                try
                {
                    this.Processor = this.Host.ProcessorFactory.CreateEventProcessor(this.PartitionContext);
                    action = EventProcessorHostActionStrings.OpeningEventProcessor;
                    ProcessorEventSource.Log.PartitionPumpInvokeProcessorOpenStart(this.Host.HostName, this.PartitionContext.PartitionId, this.Processor.GetType().ToString());
                    await this.Processor.OpenAsync(this.PartitionContext).ConfigureAwait(false);
                    ProcessorEventSource.Log.PartitionPumpInvokeProcessorOpenStop(this.Host.HostName, this.PartitionContext.PartitionId);
                }
                catch (Exception e)
                {
                    // If the processor won't create or open, only thing we can do here is pass the buck.
                    // Null it out so we don't try to operate on it further.
                    ProcessorEventSource.Log.PartitionPumpError(this.Host.HostName, this.PartitionContext.PartitionId, "Failed " + action, e.ToString());
                    this.Processor = null;
                    this.Host.EventProcessorOptions.NotifyOfException(this.Host.HostName, this.PartitionContext.PartitionId, e, action);
                    this.PumpStatus = PartitionPumpStatus.OpenFailed;
                }
            }

            if (this.PumpStatus == PartitionPumpStatus.Opening)
            {
                await this.OnOpenAsync().ConfigureAwait(false);
            }
        }

        protected abstract Task OnOpenAsync();

        protected internal PartitionPumpStatus PumpStatus { get; protected set; }

        internal bool IsClosing
        {
            get
            {
                return (this.PumpStatus == PartitionPumpStatus.Closing || this.PumpStatus == PartitionPumpStatus.Closed);
            }
        }

        public async Task CloseAsync(CloseReason reason)
        {
            ProcessorEventSource.Log.PartitionPumpCloseStart(this.Host.HostName, this.PartitionContext.PartitionId, reason.ToString());
            this.PumpStatus = PartitionPumpStatus.Closing;

            // Release lease as the first thing since closing receiver can take up to operation timeout.
            // This helps other available hosts discover lease available sooner.
            if (reason != CloseReason.LeaseLost)
            {
                // Since this pump is dead, release the lease.
                try
                {
                    await this.Host.LeaseManager.ReleaseLeaseAsync(this.PartitionContext.Lease).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    // Log and ignore any failure since expired lease will be picked by another host.
                    this.Host.EventProcessorOptions.NotifyOfException(this.Host.HostName, this.PartitionContext.PartitionId, e, EventProcessorHostActionStrings.ReleasingLease);
                }
            }

            try
            {
                this.cancellationTokenSource.Cancel();

                await this.OnClosingAsync(reason).ConfigureAwait(false);

                if (this.Processor != null)
                {
                    using (await this.ProcessingAsyncLock.LockAsync().ConfigureAwait(false))
                    {
                        // When we take the lock, any existing ProcessEventsAsync call has finished.
                        // Because the client has been closed, there will not be any more
                        // calls to onEvents in the future. Therefore we can safely call CloseAsync.
                        ProcessorEventSource.Log.PartitionPumpInvokeProcessorCloseStart(this.Host.HostName, this.PartitionContext.PartitionId, reason.ToString());
                        await this.Processor.CloseAsync(this.PartitionContext, reason).ConfigureAwait(false);
                        ProcessorEventSource.Log.PartitionPumpInvokeProcessorCloseStop(this.Host.HostName, this.PartitionContext.PartitionId);
                    }
                }
            }
            catch (Exception e)
            {
                ProcessorEventSource.Log.PartitionPumpCloseError(this.Host.HostName, this.PartitionContext.PartitionId, e.ToString());
                // If closing the processor has failed, the state of the processor is suspect.
                // Report the failure to the general error handler instead.
                this.Host.EventProcessorOptions.NotifyOfException(this.Host.HostName, this.PartitionContext.PartitionId, e, "Closing Event Processor");
            }

            this.PumpStatus = PartitionPumpStatus.Closed;
            ProcessorEventSource.Log.PartitionPumpCloseStop(this.Host.HostName, this.PartitionContext.PartitionId);
        }

        protected abstract Task OnClosingAsync(CloseReason reason);

        protected async Task ProcessEventsAsync(IEnumerable<EventData> events)
        {
            if (events == null)
            {
                events = Enumerable.Empty<EventData>();
            }

            // Synchronize to serialize calls to the processor.
            // The handler is not installed until after OpenAsync returns, so ProcessEventsAsync cannot conflict with OpenAsync.
            // There could be a conflict between ProcessEventsAsync and CloseAsync, however. All calls to CloseAsync are
            // protected by synchronizing too.
            using (await this.ProcessingAsyncLock.LockAsync().ConfigureAwait(false))
            {
                ProcessorEventSource.Log.PartitionPumpInvokeProcessorEventsStart(this.Host.HostName,
                    this.PartitionContext.PartitionId, events?.Count() ?? 0);
                try
                {
                    EventData last = events?.LastOrDefault();
                    if (last != null)
                    {
                        ProcessorEventSource.Log.PartitionPumpInfo(
                            this.Host.HostName,
                            this.PartitionContext.PartitionId,
                            "Updating offset in partition context with end of batch " + last.SystemProperties.Offset + "/" + last.SystemProperties.SequenceNumber);
                        this.PartitionContext.SetOffsetAndSequenceNumber(last);
                        if (this.Host.EventProcessorOptions.EnableReceiverRuntimeMetric)
                        {
                            this.PartitionContext.RuntimeInformation.Update(last);
                        }
                    }

                    await this.Processor.ProcessEventsAsync(this.PartitionContext, events).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    ProcessorEventSource.Log.PartitionPumpInvokeProcessorEventsError(this.Host.HostName, this.PartitionContext.PartitionId, e.ToString());
                    await this.ProcessErrorAsync(e).ConfigureAwait(false);
                }
                finally
                {
                    ProcessorEventSource.Log.PartitionPumpInvokeProcessorEventsStop(this.Host.HostName, this.PartitionContext.PartitionId);
                }
            }
        }

        protected Task ProcessErrorAsync(Exception error)
        {
            return this.Processor.ProcessErrorAsync(this.PartitionContext, error);
        }
    }
}