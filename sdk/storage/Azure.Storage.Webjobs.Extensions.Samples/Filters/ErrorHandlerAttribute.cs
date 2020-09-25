// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
#pragma warning disable CS0618 // Type or member is obsolete
    public class ErrorHandlerAttribute : FunctionExceptionFilterAttribute
#pragma warning restore CS0618 // Type or member is obsolete
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public override Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            // custom error handling logic could be written here
            // (e.g. write a queue message, send a notification, etc.)

            exceptionContext.Logger.LogError($"ErrorHandler called. Function '{exceptionContext.FunctionName}:{exceptionContext.FunctionInstanceId} failed.");

            return Task.CompletedTask;
        }
    }
}
