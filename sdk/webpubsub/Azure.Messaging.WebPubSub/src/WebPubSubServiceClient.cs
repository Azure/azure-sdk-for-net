// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Azure.Messaging.WebPubSub
{
    public partial class WebPubSubServiceClient
    {
        internal virtual async Task<Response> GenerateClientTokenImplAsync(string userId = null, IEnumerable<string> role = null, int? minutesToExpire = null, RequestContext context = null)
        {
            try
            {
                using HttpMessage message = CreateGenerateClientTokenImplRequest(userId, role, minutesToExpire, null, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        internal virtual Response GenerateClientTokenImpl(string userId = null, IEnumerable<string> role = null, int? minutesToExpire = null, RequestContext context = null)
        {
            try
            {
                using HttpMessage message = CreateGenerateClientTokenImplRequest(userId, role, minutesToExpire, null, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch
            {
                throw;
            }
        }
    }
}
