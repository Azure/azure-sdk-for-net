// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SampleHost.Filters
{
    /// <summary>
    /// Sample exception filter that shows how declarative error handling logic
    /// can be integrated into the execution pipeline.
    /// </summary>
    public class ErrorHandlerAttribute : FunctionExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            // custom error handling logic could be written here
            // (e.g. write a queue message, send a notification, etc.)

            exceptionContext.Logger.LogError($"ErrorHandler called. Function '{exceptionContext.FunctionName}:{exceptionContext.FunctionInstanceId} failed.");

            return Task.CompletedTask;
        }
    }
}
