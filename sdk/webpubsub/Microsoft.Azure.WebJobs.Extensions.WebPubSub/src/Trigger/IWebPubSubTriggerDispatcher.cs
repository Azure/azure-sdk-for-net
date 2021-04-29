// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal interface IWebPubSubTriggerDispatcher
    {
        void AddListener(string key, WebPubSubListener listener);

        Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, HashSet<string> allowedHosts, HashSet<string> AccessTokens, CancellationToken token = default);
    }
}
