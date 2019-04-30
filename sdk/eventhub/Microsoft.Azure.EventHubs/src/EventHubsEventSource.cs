// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Diagnostics.Tracing;

    /// <summary>
    /// EventSource for Microsoft-Azure-EventHubs traces.
    /// 
    /// When defining Start/Stop tasks, the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// 
    /// Do not explicity include the Guid here, since EventSource has a mechanism to automatically
    /// map to an EventSource Guid based on the Name (Microsoft-Azure-EventHubs).
    /// </summary>
    [EventSource(Name = "Microsoft-Azure-EventHubs")]
    internal sealed class EventHubsEventSource : EventSource
    {
        public static EventHubsEventSource Log { get; } = new EventHubsEventSource();

        EventHubsEventSource() { }

        [Event(1, Level = EventLevel.Informational, Message = "Creating EventHubClient (Namespace '{0}'; EventHub '{1}').")]
        public void EventHubClientCreateStart(string nameSpace, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(1, nameSpace ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "{0}: created.")]
        public void EventHubClientCreateStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(2, clientId);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "{0}: SendAsync start. EventCount: {1}, PartitionKey: '{2}'")]
        public void EventSendStart(string clientId, int count, string partitionKey)
        {
            if (IsEnabled())
            {
                WriteEvent(3, clientId, count, partitionKey ?? string.Empty);
            }
        }

        [Event(4, Level = EventLevel.Informational, Message = "{0}: SendAsync done.")]
        public void EventSendStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(4, clientId);
            }
        }

        [Event(5, Level = EventLevel.Error, Message = "{0}: SendAsync Exception: {1}.")]
        public void EventSendException(string clientId, string error)
        {
            if (IsEnabled())
            {
                WriteEvent(5, clientId, error);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "{0}: ReceiveAsync start.")]
        public void EventReceiveStart(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, clientId);
            }
        }

        [Event(7, Level = EventLevel.Informational, Message = "{0}: ReceiveAsync done. EventCount: {1}.")]
        public void EventReceiveStop(string clientId, int count)
        {
            if (IsEnabled())
            {
                WriteEvent(7, clientId, count);
            }
        }

        [Event(8, Level = EventLevel.Error, Message = "{0}: ReceiveAsync Exception: {1}.")]
        public void EventReceiveException(string clientId, string error)
        {
            if (IsEnabled())
            {
                WriteEvent(8, clientId, error);
            }
        }

        [Event(9, Level = EventLevel.Informational, Message = "{0}: SetReceiveHandler start. Handler: {1}.")]
        public void SetReceiveHandlerStart(string clientId, string handler)
        {
            if (IsEnabled())
            {
                WriteEvent(9, clientId, handler ?? string.Empty);
            }
        }

        [Event(10, Level = EventLevel.Informational, Message = "{0}: SetReceiveHandler done.")]
        public void SetReceiveHandlerStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(10, clientId);
            }
        }

        [Event(11, Level = EventLevel.Error, Message = "Throwing Exception: {0}")]
        public void ThrowingExceptionError(string error)
        {
            if (IsEnabled())
            {
                WriteEvent(11, error);
            }
        }

        [Event(12, Level = EventLevel.Informational, Message = "{0}: created. {1}")]
        public void ClientCreated(string clientId, string details)
        {
            if (IsEnabled())
            {
                WriteEvent(12, clientId, details ?? string.Empty);
            }
        }
        
        [Event(13, Level = EventLevel.Informational, Message = "{0}: closing.")]
        public void ClientCloseStart(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(13, clientId);
            }
        }
        
        [Event(14, Level = EventLevel.Informational, Message = "{0}: closed.")]
        public void ClientCloseStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(14, clientId);
            }
        }

        [Event(15, Level = EventLevel.Informational, Message = "{0}: GetEventHubRuntimeInformation start.")]
        public void GetEventHubRuntimeInformationStart(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(15, clientId);
            }
        }

        [Event(16, Level = EventLevel.Informational, Message = "{0}: GetEventHubRuntimeInformation done.")]
        public void GetEventHubRuntimeInformationStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(16, clientId);
            }
        }

        [Event(17, Level = EventLevel.Error, Message = "{0}: GetEventHubRuntimeInformation Exception: {1}.")]
        public void GetEventHubRuntimeInformationException(string clientId, string error)
        {
            if (IsEnabled())
            {
                WriteEvent(17, clientId, error);
            }
        }

        [Event(18, Level = EventLevel.Informational, Message = "{0}: GetEventHubPartitionRuntimeInformation start on partition {1}.")]
        public void GetEventHubPartitionRuntimeInformationStart(string clientId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(18, clientId, partitionId);
            }
        }

        [Event(19, Level = EventLevel.Informational, Message = "{0}: GetEventHubPartitionRuntimeInformation done on partition {1}.")]
        public void GetEventHubPartitionRuntimeInformationStop(string clientId, string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(19, clientId, partitionId);
            }
        }

        [Event(20, Level = EventLevel.Error, Message = "{0}: GetEventHubPartitionRuntimeInformation Exception on partition {1}: {2}.")]
        public void GetEventHubPartitionRuntimeInformationException(string clientId, string partitionId, string error)
        {
            if (IsEnabled())
            {
                WriteEvent(20, clientId, partitionId, error);
            }
        }

        [Event(21, Level = EventLevel.Error, Message = "{0}: Receive handler exiting with exception on partition {1}: {2}.")]
        public void ReceiveHandlerExitingWithError(string clientId, string partitionId, string error)
        {
            if (IsEnabled())
            {
                WriteEvent(21, clientId, partitionId, error);
            }
        }

        //
        // 100-120 reserved for Plugins traces
        //
        [Event(100, Level = EventLevel.Verbose, Message = "User plugin {0} called on client {1}")]
        public void PluginCallStarted(string pluginName, string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(100, pluginName, clientId);
            }
        }

        [Event(101, Level = EventLevel.Verbose, Message = "User plugin {0} completed on client {1}")]
        public void PluginCallCompleted(string pluginName, string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(101, pluginName, clientId);
            }
        }

        [Event(102, Level = EventLevel.Error, Message = "Exception during {0} plugin execution. clientId: {1}, Exception {2}")]
        public void PluginCallFailed(string pluginName, string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(102, pluginName, clientId, exception);
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
