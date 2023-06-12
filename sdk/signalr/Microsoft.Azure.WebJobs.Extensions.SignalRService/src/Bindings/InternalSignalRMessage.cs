// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [JsonObject]
    internal class InternalSignalRMessage
    {
        public string connectionId { get; set; }
        public string userId { get; set; }
        public string groupName { get; set; }
        [JsonRequired]
        public string target { get; set; }
        public object[] arguments { get; set; }
        public ServiceEndpoint[] endpoints { get; set; }
    }
}
