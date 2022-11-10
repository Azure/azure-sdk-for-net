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
    /// WebPubSubClientCredential
    /// </summary>
    public class WebPubSubClientCredential
    {
        private readonly Func<CancellationToken, ValueTask<Uri>> _clientAccessUriProvider;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientAccessUri"></param>
        public WebPubSubClientCredential(Uri clientAccessUri): this(_ => new ValueTask<Uri>(clientAccessUri))
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientAccessUriProvider"></param>
        public WebPubSubClientCredential(Func<CancellationToken, ValueTask<Uri>> clientAccessUriProvider)
        {
            _clientAccessUriProvider = clientAccessUriProvider;
        }

        /// <summary>
        /// GetClientAccessUri
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ValueTask<Uri> GetClientAccessUriAsync(CancellationToken token = default)
        {
            return _clientAccessUriProvider.Invoke(token);
        }
    }
}
