// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading.Channels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    /// The streaming producer is responsible for sending <see cref="EventData"/> instances to a
    /// given Event Hub. The instances are added to queue and then batched and sent in the background.
    /// When adding events to the queue, options can be specified to determine which partition the
    /// event gets sent to.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The difference between the <see cref="StreamingProducer"/> and the <see cref="EventHubProducerClient"/>
    /// is that the <see cref="StreamingProducer"/> batches events from a queue, rather than requiring the
    /// application to batch events before sending. The <see cref="StreamingProducer"/> utilizes timeouts.
    /// </para>
    ///
    /// <para>
    /// The <see cref="StreamingProducer"/> is safe to cache and use for the lifetime of an application,
    /// which is the recommended approach.
    /// </para>
    /// </remarks>
    public class StreamingProducer
    {
        private IAsyncEnumerable<EventData> _channel;
        private Channel<EventData> _interiorChannel;

        private Boolean _isStarted;
        private CancellationToken finished;

        /// <summary>
        /// Creates a new streaming producer.
        /// </summary>
        public StreamingProducer()
        {
            _interiorChannel = Channel.CreateBounded<EventData>(new BoundedChannelOptions(100));
            _isStarted = false;
            finished = new CancellationToken();
        }

        private void _startStreamingProducer()
        {
            if (!_isStarted)
            {
                _isStarted = true;
                var time = TimeSpan.FromMilliseconds(250);

                _channel = ChannelReaderExtensions.EnumerateChannel(_interiorChannel.Reader, time, finished);
                var reader = BackgroundReader();
            }
        }

        private async Task BackgroundReader()
        {
            while (await _channel.GetAsyncEnumerator().MoveNextAsync().ConfigureAwait(false))
            {
                var enumChannel = _channel.GetAsyncEnumerator();
                var eventData = enumChannel.Current;
                Console.WriteLine($"The current event is: {eventData}");
            }
        }

        /// <summary>
        /// Adds an event data to be sent.
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public async Task Add(EventData eventData)
        {
            await _interiorChannel.Writer.WriteAsync(eventData).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to add an event data to be sent.
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Boolean TryAdd(EventData eventData)
        {
            return _interiorChannel.Writer.TryWrite(eventData);
        }
    }
}
