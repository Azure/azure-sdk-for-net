// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    /// <summary>
    /// The MessageSender can be used to send messages to Queues or Topics.
    /// </summary>
    /// <example>
    /// Create a new MessageSender to send to a Queue
    /// <code>
    /// IMessageSender messageSender = new MessageSender(
    ///     namespaceConnectionString,
    ///     queueName)
    /// </code>
    ///
    /// Send message
    /// <code>
    /// byte[] data = GetData();
    /// await messageSender.SendAsync(data);
    /// </code>
    /// </example>
    /// <seealso cref="MessageSender"/>
    /// <seealso cref="QueueClient"/>
    /// <seealso cref="TopicClient"/>
    public interface IMessageSender : ISenderClient
    {
    }
}