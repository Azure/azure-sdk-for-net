// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Web PubSub service request.
    /// </summary>
    public abstract class ServiceRequest
    {
        /// <summary>
        /// ConnectionContext.
        /// </summary>
        public ConnectionContext ConnectionContext { get; set;}

        /// <summary>
        /// Request name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Create instance of ServiceRequest.
        /// </summary>
        /// <param name="context"></param>
        public ServiceRequest(ConnectionContext context)
        {
            ConnectionContext = context;
        }
    }
}
