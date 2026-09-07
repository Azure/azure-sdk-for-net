// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading.Channels;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// Fans an emitted item out to every attached subscriber. Each subscriber
/// owns an independent unbounded channel so a slow consumer never blocks the
/// producer or other consumers. All members are guarded by the caller's lock.
/// </summary>
internal sealed class SubscriberHub
{
    private readonly List<Channel<SseItem<string>>> _subscribers = new();

    /// <summary>Registers a new subscriber and returns its channel.</summary>
    public Channel<SseItem<string>> Add()
    {
        var channel = Channel.CreateUnbounded<SseItem<string>>(new UnboundedChannelOptions
        {
            SingleReader = true,

            // Every write (Publish/CompleteAll and the closed-stream TryComplete in
            // BeginSubscription) happens under the owning stream's lock, so there is never
            // more than one concurrent writer.
            SingleWriter = true,
        });
        _subscribers.Add(channel);
        return channel;
    }

    /// <summary>Unregisters a subscriber (does not complete its channel).</summary>
    public void Remove(Channel<SseItem<string>> channel) => _subscribers.Remove(channel);

    /// <summary>Writes the item to every attached subscriber.</summary>
    public void Publish(SseItem<string> item)
    {
        foreach (Channel<SseItem<string>> channel in _subscribers)
        {
            channel.Writer.TryWrite(item);
        }
    }

    /// <summary>Completes every subscriber channel so in-flight iterators drain then end.</summary>
    public void CompleteAll()
    {
        foreach (Channel<SseItem<string>> channel in _subscribers)
        {
            channel.Writer.TryComplete();
        }

        _subscribers.Clear();
    }
}
