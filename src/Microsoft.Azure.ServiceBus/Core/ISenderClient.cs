// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe Service Bus send functionality.
    /// </summary>
    public interface ISenderClient : IClientEntity
    {
        /// <summary>
        /// Sends a message to Service Bus.
        /// </summary>
        /// <param name="message">The <see cref="Message"/></param>
        /// <returns>An asynchronous operation</returns>
        Task SendAsync(Message message);

        /// <summary>
        /// Sends a list of messages to Service Bus.
        /// </summary>
        /// <param name="messageList">The list of messages</param>
        /// <returns>An asynchronous operation</returns>
        Task SendAsync(IList<Message> messageList);

        /// <summary>
        /// Schedules a message to appear on Service Bus.
        /// </summary>
        /// <param name="message">The <see cref="Message"/></param>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time that the message should be available for processing</param>
        /// <returns>An asynchronous operation</returns>
        Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc);

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="Message.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        /// <returns>An asynchronous operation</returns>
        Task CancelScheduledMessageAsync(long sequenceNumber);

        /// <summary>
        /// Gets a list of currently registered plugins for this sender.
        /// </summary>
        IList<ServiceBusPlugin> RegisteredPlugins { get; }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used for sending messages to Service Bus.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register</param>
        void RegisterPlugin(ServiceBusPlugin serviceBusPlugin);

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        void UnregisterPlugin(string serviceBusPluginName);
    }
}