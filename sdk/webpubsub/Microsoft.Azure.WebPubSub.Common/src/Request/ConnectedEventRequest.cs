// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// ServiceRequest for connected event.
    /// </summary>
    public class ConnectedEventRequest : WebPubSubEventRequest
    {
        /// <summary>
        /// The connected event request
        /// </summary>
        /// <param name="context"></param>
        public ConnectedEventRequest(WebPubSubConnectionContext context)
            : base(context)
        { }
    }
}
