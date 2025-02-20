// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The WebPubSubClientCredential
    /// </summary>
    public class WebPubSubClientCredential
    {
        private readonly Func<CancellationToken, ValueTask<Uri>> _clientAccessUriProvider;

        /// <summary>
        /// Initialize a WebPubSubClientCredential instance
        /// </summary>
        /// <param name="clientAccessUri">The uri to be used to connect to the service</param>
        public WebPubSubClientCredential(Uri clientAccessUri): this(_ => new ValueTask<Uri>(clientAccessUri))
        {
        }

        /// <summary>
        /// Initialize a WebPubSubClientCredential instance
        /// </summary>
        /// <param name="clientAccessUriProvider">The uri to be used to connect to the service</param>
        public WebPubSubClientCredential(Func<CancellationToken, ValueTask<Uri>> clientAccessUriProvider)
        {
            _clientAccessUriProvider = clientAccessUriProvider;
        }

        /// <summary>
        /// Initialize a WebPubSubClientCredential instance for mock or derived class
        /// </summary>
        protected WebPubSubClientCredential()
        {
        }

        /// <summary>
        /// GetClientAccessUri
        /// </summary>
        /// <param name="token">The cancellation token used to cancel the operation.</param>
        /// <returns></returns>
        public virtual ValueTask<Uri> GetClientAccessUriAsync(CancellationToken token = default)
        {
            return _clientAccessUriProvider.Invoke(token);
        }
    }
}
