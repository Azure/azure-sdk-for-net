// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal sealed class DisconnectEventRequest
    {
        [JsonProperty("reason")]
        public string Reason { get; }
    }
}
