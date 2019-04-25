// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System.Threading.Tasks;

    /// <summary>
    /// This class provides methods that can be overridden to manipulate messages for custom plugin functionality.
    /// </summary>
    public abstract class ServiceBusPlugin
    {
        /// <summary>
        /// Gets the name of the <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <remarks>This name is used to identify the plugin, and prevent a plugin from being registered multiple times.</remarks>
        public abstract string Name { get; }

        /// <summary>
        /// Determines whether or an exception in the plugin should prevent a send or receive operation.
        /// </summary>
        public virtual bool ShouldContinueOnException => false;

        /// <summary>
        /// This operation is called before a message is sent.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> to be modified by the plugin</param>
        /// <returns>The modified <see cref="Message"/></returns>
        public virtual Task<Message> BeforeMessageSend(Message message)
        {
            return Task.FromResult(message);
        }

        /// <summary>
        /// This operation is called after a message is received, but before it is returned to the <see cref="IMessageReceiver"/>.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> to be modified by the plugin</param>
        /// <returns>The modified <see cref="Message"/></returns>
        public virtual Task<Message> AfterMessageReceive(Message message)
        {
            return Task.FromResult(message);
        }
    }
}