// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    /// <summary>
    /// A message represents a hub method invocation from SignalR clients.
    /// </summary>
    public class InvocationMessage : ServerlessMessage
    {
        /// <summary>
        /// The unique id of the invocation.
        /// </summary>
        [JsonProperty(PropertyName = "invocationId")]
        public string InvocationId { get; set; }

        /// <summary>
        /// The name of the method to call.
        /// </summary>
        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

        /// <summary>
        /// The argument list of the invocation.
        /// </summary>
        [JsonProperty(PropertyName = "arguments")]
        [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Breaking change")]
        public object[] Arguments { get; set; }
    }
}