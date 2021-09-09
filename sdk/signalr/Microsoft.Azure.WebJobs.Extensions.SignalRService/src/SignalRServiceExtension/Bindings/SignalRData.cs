// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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