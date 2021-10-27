// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
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