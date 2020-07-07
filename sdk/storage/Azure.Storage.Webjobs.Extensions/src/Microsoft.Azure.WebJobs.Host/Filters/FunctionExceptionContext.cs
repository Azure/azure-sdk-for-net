// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Base context class for <see cref="IFunctionExceptionFilter.OnExceptionAsync(FunctionExceptionContext, System.Threading.CancellationToken)"/>.
    /// </summary>
    [Obsolete("Filters is in preview and there may be breaking changes in this area.")]
    public class FunctionExceptionContext : FunctionFilterContext
    {
        /// <summary>
        /// Constructs a new instance
        /// </summary>
        /// <param name="functionInstanceId">The instance ID for the function invocation.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="logger"><see cref="ILogger"/> that can be used by the filter to log information.</param>
        /// <param name="exceptionDispatchInfo">The <see cref="ExceptionDispatchInfo"/> for the exception.</param>
        /// <param name="properties">The property bag that can be used to pass information between filters.</param>
        public FunctionExceptionContext(Guid functionInstanceId, string functionName, ILogger logger, ExceptionDispatchInfo exceptionDispatchInfo, IDictionary<string, object> properties)
            : base(functionInstanceId, functionName, logger, properties)
        {
            if (exceptionDispatchInfo == null)
            {
                throw new ArgumentNullException(nameof(exceptionDispatchInfo));
            }

            ExceptionDispatchInfo = exceptionDispatchInfo;
        }

        /// <summary>
        /// Gets the <see cref="Exception"/> that caused the function invocation to fail.
        /// </summary>
        public Exception Exception
        {
            get
            {
                return ExceptionDispatchInfo.SourceException;
            }
        }

        /// <summary>
        /// Gets the <see cref="ExceptionDispatchInfo"/> for the exception.
        /// </summary>
        public ExceptionDispatchInfo ExceptionDispatchInfo { get; internal set; }
    }
}