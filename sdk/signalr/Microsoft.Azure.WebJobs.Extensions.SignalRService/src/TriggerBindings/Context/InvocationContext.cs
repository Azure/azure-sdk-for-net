// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// An object represents the context of a serverless message invocation.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is a DTO.")]
    public class InvocationContext
    {
        /// <summary>
        /// The arguments of invocation message.
        /// </summary>
        public object[] Arguments { get; set; }

        /// <summary>
        /// The error message of close connection event.
        /// Only close connection message can have this property, and it can be empty if connections close with no error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// The category of the message.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The event of the message.
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// The hub which message belongs to.
        /// </summary>
        public string Hub { get; set; }

        /// <summary>
        /// The connection-id of the client which send the message.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// The user identity of the client which send the message.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The headers of request.
        /// Headers with duplicated key will be joined by comma.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// The query of the request when client connect to the service.
        /// Queries with duplicated key will be joined by comma.
        /// </summary>
        public IDictionary<string, string> Query { get; set; }

        /// <summary>
        /// The claims of the client.
        /// If you multiple claims have the same key, only the first one will be reserved.
        /// </summary>
        public IDictionary<string, string> Claims { get; set; }

        internal ServiceHubContext HubContext { get; set; }
    }
}