// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// ServiceRequest for connected event.
    /// </summary>
    public sealed class ConnectedEventRequest : WebPubSubEventRequest
    {
        internal ConnectedEventRequest(WebPubSubConnectionContext connectionContext)
            : base(connectionContext)
        { }
    }
}
