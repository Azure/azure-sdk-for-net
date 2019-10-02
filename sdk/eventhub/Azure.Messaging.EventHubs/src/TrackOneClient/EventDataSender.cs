// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackOne
{
    internal abstract class EventDataSender : ClientEntity
    {
        protected EventDataSender(EventHubClient eventHubClient, string partitionId)
            : base(nameof(EventDataSender) + StringUtility.GetRandomString())
        {
            EventHubClient = eventHubClient;
            PartitionId = partitionId;
            RetryPolicy = eventHubClient.RetryPolicy.Clone();
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

            var activePartitionRouting = string.IsNullOrEmpty(partitionKey) ?
                PartitionId :
                partitionKey;

            EventHubsEventSource.Log.EventSendStart(ClientId, count, partitionKey);

            Task sendTask;
            try
            {
                IEnumerable<EventData> processedEvents = await ProcessEvents(eventDatas).ConfigureAwait(false);

                sendTask = OnSendAsync(processedEvents, partitionKey);
                await sendTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                EventHubsEventSource.Log.EventSendException(ClientId, exception.ToString());
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventSendStop(ClientId);
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

        private async Task<EventData> ProcessEvent(EventData eventData)
        {
            if (RegisteredPlugins == null || RegisteredPlugins.Count == 0)
            {
                return eventData;
            }

            EventData processedEvent = eventData;
            foreach (Core.EventHubsPlugin plugin in RegisteredPlugins.Values)
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

        private async Task<IEnumerable<EventData>> ProcessEvents(IEnumerable<EventData> eventDatas)
        {
            if (RegisteredPlugins.Count < 1)
            {
                return eventDatas;
            }

            var processedEventList = new List<EventData>();
            foreach (EventData eventData in eventDatas)
            {
                EventData processedMessage = await ProcessEvent(eventData)
                    .ConfigureAwait(false);
                processedEventList.Add(processedMessage);
            }

            return processedEventList;
        }

        internal long MaxMessageSize { get; set; }

        internal virtual ValueTask EnsureLinkAsync() => new ValueTask();
    }
}
