// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class ExecutionContext
    {
        public ITriggeredFunctionExecutor Executor { get; set; }

        public AccessKey[] AccessKeys { get; set; }
    }
}