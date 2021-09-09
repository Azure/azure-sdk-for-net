// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    public abstract class ServerlessMessage
    {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
    }

    public class InvocationMessage : ServerlessMessage
    {
        [JsonProperty(PropertyName = "invocationId")]
        public string InvocationId { get; set; }

        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

        [JsonProperty(PropertyName = "arguments")]
        public object[] Arguments { get; set; }
    }

    public class OpenConnectionMessage : ServerlessMessage
    {
    }

    public class CloseConnectionMessage : ServerlessMessage
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}