// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
#pragma warning disable CS0618 // Type or member is obsolete
    public abstract class SignalRFilterAttribute : FunctionInvocationFilterAttribute
    {
        public override Task OnExecutingAsync(FunctionExecutingContext executingContext,
            CancellationToken cancellationToken)
        {
            if (executingContext.Arguments.FirstOrDefault().Value is InvocationContext invocationContext)
            {
                return FilterAsync(invocationContext, cancellationToken);
            }
            // Should not hit the Exception.
            throw new InvalidOperationException($"{nameof(FunctionExceptionContext)} doesn't contain {nameof(InvocationContext)}.");
        }

        /// <summary>
        /// Executed before the Function method being executed.
        /// Throwing exceptions can terminate the Function execution and response the invocation failure.
        /// </summary>
        public abstract Task FilterAsync(InvocationContext invocationContext, CancellationToken cancellationToken);
    }

#pragma warning restore CS0618 // Type or member is obsolete
}