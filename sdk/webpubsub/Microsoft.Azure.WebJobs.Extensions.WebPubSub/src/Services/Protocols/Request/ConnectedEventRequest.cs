// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// ServiceRequest for connected event.
    /// </summary>
    public class ConnectedEventRequest : WebPubSubRequest
    {
        internal ConnectedEventRequest(ConnectionContext connectionContext)
            : base(connectionContext)
        {
        }
    }
}
