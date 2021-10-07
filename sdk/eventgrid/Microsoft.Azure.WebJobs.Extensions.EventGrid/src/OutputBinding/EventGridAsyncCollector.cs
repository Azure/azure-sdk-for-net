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
                if (firstEvent is string str)
                {
                    bool isEventGridEvent = false;
                    try
                    {
                        var ev = EventGridEvent.Parse(new BinaryData(str));
                        isEventGridEvent = true;
                    }
                    catch (ArgumentException)
                    {
                    }

                    if (isEventGridEvent)
                    {
                        List<EventGridEvent> egEvents = new();
                        foreach (string evt in events)
                        {
                            egEvents.Add(EventGridEvent.Parse(new BinaryData(evt)));
                        }

                        await _client.SendEventsAsync(egEvents, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        List<CloudEvent> cloudEvents = new();
                        foreach (string evt in events)
                        {
                            cloudEvents.Add(CloudEvent.Parse(new BinaryData(evt)));
                        }

                        await _client.SendEventsAsync(cloudEvents, cancellationToken).ConfigureAwait(false);
                    }
                }
                else if (firstEvent is JObject jObject)
                {
                    bool isEventGridEvent = false;
                    try
                    {
                        var ev = EventGridEvent.Parse(new BinaryData(jObject.ToString()));
                        isEventGridEvent = true;
                    }
                    catch (ArgumentException)
                    {
                    }

                    if (isEventGridEvent)
                    {
                        List<EventGridEvent> egEvents = new();
                        foreach (JObject evt in events)
                        {
                            egEvents.Add(EventGridEvent.Parse(new BinaryData(evt.ToString())));
                        }

                        await _client.SendEventsAsync(egEvents, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        List<CloudEvent> cloudEvents = new();
                        foreach (JObject evt in events)
                        {
                            cloudEvents.Add(CloudEvent.Parse(new BinaryData(evt.ToString())));
                        }

                        await _client.SendEventsAsync(cloudEvents, cancellationToken).ConfigureAwait(false);
                    }
                }
                else if (firstEvent is EventGridEvent)
                {
                    List<EventGridEvent> egEvents = new();
                    foreach (object evt in events)
                    {
                        egEvents.Add((EventGridEvent) evt);
                    }
                    await _client.SendEventsAsync(egEvents, cancellationToken).ConfigureAwait(false);
                }
                else if (firstEvent is CloudEvent)
                {
                    List<CloudEvent> cloudEvents = new();
                    foreach (object evt in events)
                    {
                        cloudEvents.Add((CloudEvent) evt);
                    }
                    await _client.SendEventsAsync(cloudEvents, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new InvalidOperationException(
                        $"{firstEvent?.GetType().ToString()} is not a valid event type.");
                }
            }
        }
    }
}