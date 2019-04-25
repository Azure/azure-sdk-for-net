// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Diagnostics.Tracing;

    /// <summary>
    /// EventSource for Microsoft-Azure-EventHubs-Processor traces.
    /// 
    /// When defining Start/Stop tasks, the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// 
    /// Do not explicity include the Guid here, since EventSource has a mechanism to automatically
    /// map to an EventSource Guid based on the Name (Microsoft-Azure-EventHubs-Processor).
    /// </summary>
    [EventSource(Name = "Microsoft-Azure-EventHubs-Processor")]
    internal class ProcessorEventSource : EventSource
    {
        public static ProcessorEventSource Log { get; } = new ProcessorEventSource();

        ProcessorEventSource() { }

        //
        // 1-50 reserved for EventProcessorHost traces
        //
        [Event(1, Level = EventLevel.Informational, Message = "{0}: created. EventHub: {1}.")]
        public void EventProcessorHostCreated(string hostId, string path)
        {
            if (IsEnabled())
            {
                WriteEvent(1, hostId, path);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "{0}: closing.")]
        public void EventProcessorHostCloseStart(string hostId)
        {
            if (IsEnabled())
            {
                WriteEvent(2, hostId);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "{0}: closed.")]
        public void EventProcessorHostCloseStop(string hostId)
        {
            if (IsEnabled())
            {
                WriteEvent(3, hostId);
            }
        }

        [Event(4, Level = EventLevel.Error, Message = "{0}: close failed: {1}.")]
        public void EventProcessorHostCloseError(string hostId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(4, hostId, exception);
            }
        }

        [Event(5, Level = EventLevel.Informational, Message = "{0}: opening. Factory:{1}.")]
        public void EventProcessorHostOpenStart(string hostId, string factoryType)
        {
            if (IsEnabled())
            {
                WriteEvent(5, hostId, factoryType ?? string.Empty);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "{0}: opened.")]
        public void EventProcessorHostOpenStop(string hostId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, hostId);
            }
        }

        [Event(7, Level = EventLevel.Error, Message = "{0}: open failed: {1}.")]
        public void EventProcessorHostOpenError(string hostId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(7, hostId, exception);
            }
        }

        [Event(8, Level = EventLevel.Informational, Message = "{0}: {1}")]
        public void EventProcessorHostInfo(string hostId, string details)
        {
            if (IsEnabled())
            {
                WriteEvent(8, hostId, details);
            }
        }

        [Event(9, Level = EventLevel.Warning, Message = "{0}: Warning: {1}. {2}")]
        public void EventProcessorHostWarning(string hostId, string details, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(9, hostId, details, exception ?? string.Empty);
            }
        }

        [Event(10, Level = EventLevel.Error, Message = "{0}: Error: {1}. {2}")]
        public void EventProcessorHostError(string hostId, string details, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(10, hostId, details, exception ?? string.Empty);
            }
        }

        //
        // 51-100 reserved for PartitionPump traces
        //
        [Event(51, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Pump closing. Reason:{2}.")]
        public void PartitionPumpCloseStart(string hostId, string partitionId, string reason)
        {
            if (IsEnabled())
            {
                WriteEvent(51, hostId, partitionId, reason);
            }
        }

        [Event(52, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Pump closed.")]
        public void PartitionPumpCloseStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(52, hostId, partitionId);
            }
        }

        [Event(53, Level = EventLevel.Error, Message = "{0}: Partition {1}: Pump close error: {2}.")]
        public void PartitionPumpCloseError(string hostId, string partitionId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(53, hostId, partitionId, exception ?? string.Empty);
            }
        }

        [Event(54, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Saving checkpoint at Offset:{2}/SequenceNumber:{3}.")]
        public void PartitionPumpCheckpointStart(string hostId, string partitionId, string offset, long sequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(54, hostId, partitionId, offset ?? string.Empty, sequenceNumber);
            }
        }

        [Event(55, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Done saving checkpoint.")]
        public void PartitionPumpCheckpointStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(55, hostId, partitionId);
            }
        }

        [Event(56, Level = EventLevel.Error, Message = "{0}: Partition {1}: Error saving checkpoint: {2}.")]
        public void PartitionPumpCheckpointError(string hostId, string partitionId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(56, hostId, partitionId, exception ?? string.Empty);
            }
        }

        [Event(57, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Creating EventHubClient and PartitionReceiver with Epoch:{2} StartAt:{3}.")]
        public void PartitionPumpCreateClientsStart(string hostId, string partitionId, long epoch, string startAt)
        {
            if (IsEnabled())
            {
                WriteEvent(57, hostId, partitionId, epoch, startAt ?? string.Empty);
            }
        }

        [Event(58, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Done creating EventHubClient and PartitionReceiver.")]
        public void PartitionPumpCreateClientsStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(58, hostId, partitionId);
            }
        }

        [Event(59, Level = EventLevel.Informational, Message = "{0}: Partition {1}: IEventProcessor opening. Type: {2}.")]
        public void PartitionPumpInvokeProcessorOpenStart(string hostId, string partitionId, string processorType)
        {
            if (IsEnabled())
            {
                WriteEvent(59, hostId, partitionId, processorType);
            }
        }

        [Event(60, Level = EventLevel.Informational, Message = "{0}: Partition {1}: IEventProcessor opened.")]
        public void PartitionPumpInvokeProcessorOpenStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(60, hostId, partitionId);
            }
        }

        [Event(61, Level = EventLevel.Informational, Message = "{0}: Partition {1}: IEventProcessor closing. Reason: {2}")]
        public void PartitionPumpInvokeProcessorCloseStart(string hostId, string partitionId, string reason)
        {
            if (IsEnabled())
            {
                WriteEvent(61, hostId, partitionId, reason);
            }
        }

        [Event(62, Level = EventLevel.Informational, Message = "{0}: Partition {1}: IEventProcessor closed.")]
        public void PartitionPumpInvokeProcessorCloseStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(62, hostId, partitionId);
            }
        }

        [Event(63, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Invoking IEventProcessor.ProcessEventsAsync with {2} event(s).")]
        public void PartitionPumpInvokeProcessorEventsStart(string hostId, string partitionId, int eventCount)
        {
            if (IsEnabled())
            {
                WriteEvent(63, hostId, partitionId, eventCount);
            }
        }

        [Event(64, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Done invoking IEventProcessor.ProcessEventsAsync.")]
        public void PartitionPumpInvokeProcessorEventsStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(64, hostId, partitionId);
            }
        }

        [Event(65, Level = EventLevel.Error, Message = "{0}: Partition {1}: Error invoking IEventProcessor.ProcessEventsAsync: {2}")]
        public void PartitionPumpInvokeProcessorEventsError(string hostId, string partitionId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(65, hostId, partitionId, exception);
            }
        }

        [Event(66, Level = EventLevel.Informational, Message = "{0}: Partition {1}: {2}")]
        public void PartitionPumpInfo(string hostId, string partitionId, string details)
        {
            if (IsEnabled())
            {
                WriteEvent(66, hostId, partitionId, details);
            }
        }

        [Event(67, Level = EventLevel.Warning, Message = "{0}: Partition {1}: Warning: {2} {3}")]
        public void PartitionPumpWarning(string hostId, string partitionId, string details, string exception = null)
        {
            if (IsEnabled())
            {
                WriteEvent(67, hostId, partitionId, details, exception ?? string.Empty);
            }
        }

        [Event(68, Level = EventLevel.Error, Message = "{0}: Partition {1}: Error: {2} {3}")]
        public void PartitionPumpError(string hostId, string partitionId, string details, string exception = null)
        {
            if (IsEnabled())
            {
                WriteEvent(68, hostId, partitionId, details, exception ?? string.Empty);
            }
        }

        [Event(69, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Attempting to steal lease")]
        public void PartitionPumpStealLeaseStart(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(69, hostId, partitionId);
            }
        }

        [Event(70, Level = EventLevel.Informational, Message = "{0}: Partition {1}: Steal lease succeeded")]
        public void PartitionPumpStealLeaseStop(string hostId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(70, hostId, partitionId);
            }
        }

        //
        // 101-150 reserved for AzureStorageManager traces
        //
        [Event(101, Level = EventLevel.Informational, Message = "{0}: Partition {1}: AzureStorage: {2}")]
        public void AzureStorageManagerInfo(string hostId, string partitionId, string details)
        {
            if (IsEnabled())
            {
                WriteEvent(101, hostId, partitionId, details);
            }
        }

        [Event(102, Level = EventLevel.Warning, Message = "{0}: Partition {1}: AzureStorage Warning: {2} {3}")]
        public void AzureStorageManagerWarning(string hostId, string partitionId, string details, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(102, hostId, partitionId, details, exception ?? string.Empty);
            }
        }

        [Event(103, Level = EventLevel.Error, Message = "{0}: Partition {1}: AzureStorage Error: {2} {3}")]
        public void AzureStorageManagerError(string hostId, string partitionId, string details, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(103, hostId, partitionId, details, exception);
            }
        }

        // TODO: Add Keywords if desired.
        //public class Keywords   // This is a bitvector
        //{
        //    public const EventKeywords Amqp = (EventKeywords)0x0001;
        //    public const EventKeywords Debug = (EventKeywords)0x0002;
        //}
    }
}
