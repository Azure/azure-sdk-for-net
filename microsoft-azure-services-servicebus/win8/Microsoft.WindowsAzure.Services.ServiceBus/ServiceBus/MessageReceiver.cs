//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Services.ServiceBus.Http;
using Windows.Foundation;

namespace Microsoft.WindowsAzure.Services.ServiceBus
{
    /// <summary>
    /// A receiver class for brokered messages.
    /// </summary>
    /// <remarks>This class provides access for operating with brokered
    /// messages in queues or subscriptions.</remarks>
    public sealed class MessageReceiver
    {
        private ServiceConfiguration _config;               // SB configuration.
        private HttpChannel _channel;                       // HTTP processing channel.
        private string _path;                               // Local path of the message source.

        /// <summary>
        /// Initializes the receiver.
        /// </summary>
        /// <param name="config">SB configuration.</param>
        /// <param name="channel">Channel for processing HTTP requests.</param>
        /// <param name="path">Local path of the message source.</param>
        internal MessageReceiver(ServiceConfiguration config, HttpChannel channel, string path)
        {
            Debug.Assert(config != null);
            Debug.Assert(channel != null);
            Debug.Assert(!string.IsNullOrEmpty(path));

            _config = config;
            _channel = channel;
            _path = path;
        }

        /// <summary>
        /// Gets a message at the head of the queue/subscription and removes
        /// it.
        /// </summary>
        /// <param name="lockDuration">Lock duration</param>
        /// <returns>Received message.</returns>
        public IAsyncOperation<BrokeredMessageDescription> GetMessageAsync(TimeSpan lockDuration)
        {
            Uri uri = _config.GetTopMessageUri(_path, lockDuration);
            HttpRequest request = new HttpRequest(HttpMethod.Delete, uri);
            return _channel.SendAsyncInternal(request, HttpChannel.CheckNoContent)
                .ContinueWith(t => new BrokeredMessageDescription(t.Result))
                .AsAsyncOperation();
        }

        /// <summary>
        /// Peeks a message at the head of the queue/subscription and locks it 
        /// for the specified duration period. The message is guaranteed not
        /// to be delivered to other receivers during the lock duration.
        /// </summary>
        /// <param name="lockDuration">Lock duration.</param>
        /// <returns>Received message.</returns>
        public IAsyncOperation<BrokeredMessageDescription> PeekMessageAsync(TimeSpan lockDuration)
        {
            Uri uri = _config.GetTopMessageUri(_path, lockDuration);
            HttpRequest request = new HttpRequest(HttpMethod.Post, uri);
            return _channel.SendAsyncInternal(request, HttpChannel.CheckNoContent)
                .ContinueWith(t => new BrokeredMessageDescription(t.Result))
                .AsAsyncOperation();
        }

        /// <summary>
        /// Unlocks previously locked message making it available to all 
        /// readers.
        /// </summary>
        /// <param name="message">Message to unlock.</param>
        /// <returns>Result of the operation.</returns>
        public IAsyncAction AbandonMessageAsync(BrokeredMessageDescription message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            Uri uri = _config.GetLockedMessageUri(_path, message.SequenceNumber, message.LockToken);
            HttpRequest request = new HttpRequest(HttpMethod.Put, uri);
            return _channel.SendAsyncInternal(request).AsAsyncAction();
        }

        /// <summary>
        /// Deletes a previously locked message.
        /// </summary>
        /// <param name="message">Message to delete.</param>
        /// <returns>Result of the operation.</returns>
        public IAsyncAction DeleteMessageAsync(BrokeredMessageDescription message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            Uri uri = _config.GetLockedMessageUri(_path, message.SequenceNumber, message.LockToken);
            HttpRequest request = new HttpRequest(HttpMethod.Delete, uri);
            return _channel.SendAsyncInternal(request).AsAsyncAction();
        }
    }
}
