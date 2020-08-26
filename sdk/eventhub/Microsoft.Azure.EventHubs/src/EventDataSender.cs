// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
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
            this.ThrowIfClosed();

            var processedEvents = await this.ProcessEvents(eventDatas).ConfigureAwait(false);

            await this.OnSendAsync(processedEvents, partitionKey)
                .ConfigureAwait(false);
        }

        protected abstract Task OnSendAsync(IEnumerable<EventData> eventDatas, string partitionKey);

        internal static int ValidateEvents(IEnumerable<EventData> eventDatas)
        {
            int count;

            if (eventDatas == null || (count = eventDatas.Count()) == 0)
            {
                throw Fx.Exception.Argument(nameof(eventDatas), Resources.EventDataListIsNullOrEmpty);
            }

            return count;
        }

        async Task<EventData> ProcessEvent(EventData eventData)
        {
            if (this.RegisteredPlugins == null || this.RegisteredPlugins.Count == 0)
                return eventData;

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
    }
}