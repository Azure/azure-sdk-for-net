// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    internal sealed class EventGridAsyncCollector : IAsyncCollector<object>
    {
        // use EventGridPublisherClient for mocking test
        private readonly EventGridPublisherClient _client;
        private readonly object _syncroot = new object();

        private IList<object> _eventsToSend = new List<object>();

        public EventGridAsyncCollector(EventGridPublisherClient client)
        {
            _client = client;
        }

        public Task AddAsync(object item, CancellationToken cancellationToken = default(CancellationToken))
        {
            lock (_syncroot)
            {
                // Don't let FlushAsync take place while we're doing this
                _eventsToSend.Add(item);
            }

            return Task.CompletedTask;
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IList<object> events;
            var newEventList = new List<object>();
            lock (_syncroot)
            {
                // swap the events to send out with a new list; locking so 'AddAsync' doesn't take place while we do this
                events = _eventsToSend;
                _eventsToSend = newEventList;
            }

            if (events.Any())
            {
                // determine the schema by inspecting the first event (a topic can only support a single schema)
                var firstEvent = events.First();
                switch (firstEvent)
                {
                    case string:
                        await SendAsync(events, evt => new BinaryData((string)evt), cancellationToken)
                            .ConfigureAwait(false);
                        break;
                    case BinaryData:
                        await SendAsync(events, evt => (BinaryData) evt, cancellationToken)
                            .ConfigureAwait(false);
                        break;
                    case byte[]:
                        await SendAsync(events, evt => new BinaryData((byte[])evt), cancellationToken)
                            .ConfigureAwait(false);
                        break;
                    case JObject:
                        await SendAsync(events, evt => new BinaryData(((JObject)evt).ToString()), cancellationToken)
                            .ConfigureAwait(false);
                        break;
                    case EventGridEvent:
                    {
                        List<EventGridEvent> egEvents = new(events.Count);
                        foreach (object evt in events)
                        {
                            egEvents.Add((EventGridEvent) evt);
                        }
                        await _client.SendEventsAsync(egEvents, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                    case CloudEvent:
                    {
                        List<CloudEvent> cloudEvents = new(events.Count);
                        foreach (object evt in events)
                        {
                            cloudEvents.Add((CloudEvent) evt);
                        }
                        await _client.SendEventsAsync(cloudEvents, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                    default:
                        throw new InvalidOperationException(
                            $"{firstEvent?.GetType().ToString()} is not a valid event type.");
                }
            }
        }

        private async Task SendAsync(IList<object> events, Func<object, BinaryData> binaryDataFactory, CancellationToken cancellationToken)
        {
            bool isEventGridEvent = false;
            try
            {
                // test the first event to determine CloudEvent vs EventGridEvent
                // both event types are NOT supported in same list
                EventGridEvent.Parse(binaryDataFactory(events.First()));
                isEventGridEvent = true;
            }
            catch (ArgumentException)
            {
            }
            if (isEventGridEvent)
            {
                List<EventGridEvent> egEvents = new(events.Count);
                foreach (object evt in events)
                {
                    egEvents.Add(EventGridEvent.Parse(binaryDataFactory(evt)));
                }

                await _client.SendEventsAsync(egEvents, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                List<CloudEvent> cloudEvents = new(events.Count);
                foreach (object evt in events)
                {
                    cloudEvents.Add(CloudEvent.Parse(binaryDataFactory(evt)));
                }

                await _client.SendEventsAsync(cloudEvents, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}