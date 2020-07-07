// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Defines a filter that will be called as part of the function invocation pipeline
    /// immediately before and after the job function is invoked.
    /// </summary>
    [Obsolete("Filters is in preview and there may be breaking changes in this area.")]
    public interface IFunctionInvocationFilter : IFunctionFilter
    {
        /// <summary>
        /// Called before the target job function is invoked.
        /// </summary>
        /// <param name="executingContext">The execution context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A <see cref="Task"/> representing the filter execution.</returns>
        Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken);

        /// <summary>
        /// Called after the target job function is invoked.
        /// </summary>
        /// <param name="executedContext">The execution context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A <see cref="Task"/> representing the filter execution.</returns>
        Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken);
    }
}