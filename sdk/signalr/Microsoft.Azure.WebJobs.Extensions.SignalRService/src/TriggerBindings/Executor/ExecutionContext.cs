// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class ExecutionContext
    {
        public ITriggeredFunctionExecutor Executor { get; set; }
        public IOptionsMonitor<SignatureValidationOptions> SignatureValidationOptions { get; set; }
    }
}