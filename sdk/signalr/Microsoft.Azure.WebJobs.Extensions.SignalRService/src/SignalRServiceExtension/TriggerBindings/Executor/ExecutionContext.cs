// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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