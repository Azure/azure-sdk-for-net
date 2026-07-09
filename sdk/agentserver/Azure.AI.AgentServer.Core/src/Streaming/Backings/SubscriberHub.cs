// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Channels;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// Fans an emitted payload out to every attached subscriber. Each subscriber
/// owns an independent unbounded channel so a slow consumer never blocks the
/// producer or other consumers. All members are guarded by the caller's lock.
/// </summary>
internal sealed class SubscriberHub
{
    private readonly List<Channel<object>> _subscribers = new();

    /// <summary>Registers a new subscriber and returns its channel.</summary>
    public Channel<object> Add()
    {
        var channel = Channel.CreateUnbounded<object>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false,
        });
        _subscribers.Add(channel);
        return channel;
    }

    /// <summary>Unregisters a subscriber (does not complete its channel).</summary>
    public void Remove(Channel<object> channel) => _subscribers.Remove(channel);

    /// <summary>Writes the payload to every attached subscriber.</summary>
    public void Publish(object payload)
    {
        foreach (Channel<object> channel in _subscribers)
        {
            channel.Writer.TryWrite(payload);
        }
    }

    /// <summary>Completes every subscriber channel so in-flight iterators drain then end.</summary>
    public void CompleteAll()
    {
        foreach (Channel<object> channel in _subscribers)
        {
            channel.Writer.TryComplete();
        }

        _subscribers.Clear();
    }
}
