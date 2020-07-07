// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Base class for declarative function exception filters.
    /// </summary>
    [Obsolete("Filters is in preview and there may be breaking changes in this area.")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class FunctionExceptionFilterAttribute : Attribute, IFunctionExceptionFilter
    {
        /// <inheritdoc/>
        public abstract Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken);
    }
}