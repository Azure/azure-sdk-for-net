// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    /// <summary>
    /// The messages sent from Azure SignalR Service in serverless sceanarios.
    /// </summary>
    public abstract class ServerlessMessage
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
    }

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

    /// <summary>
    /// A message represents that a connection is opened.
    /// </summary>
    public class OpenConnectionMessage : ServerlessMessage
    {
    }

    /// <summary>
    /// A message represents that a connection is closed.
    /// </summary>
    public class CloseConnectionMessage : ServerlessMessage
    {
        /// <summary>
        /// The error indicates why the connection is closed.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}