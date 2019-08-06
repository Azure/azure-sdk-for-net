// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TrackOne
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    abstract class EventDataSender : ClientEntity
    {
        protected EventDataSender(EventHubClient eventHubClient, string partitionId)
            : base(nameof(EventDataSender) + StringUtility.GetRandomString())
        {
            this.EventHubClient = eventHubClient;
            this.PartitionId = partitionId;
            this.RetryPolicy = eventHubClient.RetryPolicy.Clone();
        }

        protected EventHubClient EventHubClient { get; }

        protected string PartitionId { get; }

        public async Task SendAsync(IEnumerable<EventData> eventDatas, string partitionKey)
        {
            int count = ValidateEvents(eventDatas);

            if (count == 0)
            {
                return;
            }

            var activePartitionRouting = String.IsNullOrEmpty(partitionKey) ?
                this.PartitionId :
                partitionKey;

            EventHubsEventSource.Log.EventSendStart(this.ClientId, count, partitionKey);
            Activity activity = EventHubsDiagnosticSource.StartSendActivity(this.ClientId, this.EventHubClient.ConnectionStringBuilder, activePartitionRouting, eventDatas, count);

            Task sendTask = null;
            try
            {
                var processedEvents = await this.ProcessEvents(eventDatas).ConfigureAwait(false);

                sendTask = this.OnSendAsync(processedEvents, partitionKey);
                await sendTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                EventHubsEventSource.Log.EventSendException(this.ClientId, exception.ToString());
                EventHubsDiagnosticSource.FailSendActivity(activity, this.EventHubClient.ConnectionStringBuilder, activePartitionRouting, eventDatas, exception);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventSendStop(this.ClientId);
                EventHubsDiagnosticSource.StopSendActivity(activity, this.EventHubClient.ConnectionStringBuilder, activePartitionRouting, eventDatas, sendTask);
            }
        }

        protected abstract Task OnSendAsync(IEnumerable<EventData> eventDatas, string partitionKey);

        internal static int ValidateEvents(IEnumerable<EventData> eventDatas)
        {
            if (eventDatas == null)
            {
                throw Fx.Exception.Argument(nameof(eventDatas), Resources.EventDataListIsNullOrEmpty);
            }

            return eventDatas.Count();
        }

        async Task<EventData> ProcessEvent(EventData eventData)
        {
            if (this.RegisteredPlugins == null || this.RegisteredPlugins.Count == 0)
            {
                return eventData;
            }

            var processedEvent = eventData;
            foreach (var plugin in this.RegisteredPlugins.Values)
            {
                try
                {
                    EventHubsEventSource.Log.PluginCallStarted(plugin.Name, ClientId);
                    processedEvent = await plugin.BeforeEventSend(processedEvent).ConfigureAwait(false);
                    EventHubsEventSource.Log.PluginCallCompleted(plugin.Name, ClientId);
                }
                catch (Exception ex)
                {
                    EventHubsEventSource.Log.PluginCallFailed(plugin.Name, ClientId, ex);

                    if (!plugin.ShouldContinueOnException)
                    {
                        throw;
                    }
                }
            }
            return processedEvent;
        }

        async Task<IEnumerable<EventData>> ProcessEvents(IEnumerable<EventData> eventDatas)
        {
            if (this.RegisteredPlugins.Count < 1)
            {
                return eventDatas;
            }

            var processedEventList = new List<EventData>();
            foreach (var eventData in eventDatas)
            {
                var processedMessage = await this.ProcessEvent(eventData)
                    .ConfigureAwait(false);
                processedEventList.Add(processedMessage);
            }

            return processedEventList;
        }

        internal long MaxMessageSize { get; set; }

        internal virtual ValueTask EnsureLinkAsync() => new ValueTask();
    }
}