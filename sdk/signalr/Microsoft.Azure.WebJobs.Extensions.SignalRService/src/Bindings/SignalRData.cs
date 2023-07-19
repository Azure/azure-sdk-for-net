// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRData
    {
        public string Target { get; set; }
        public object[] Arguments { get; set; }
        public ServiceEndpoint[] Endpoints { get; set; }
    }
}