// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Context class for <see cref="IFunctionInvocationFilter.OnExecutingAsync(FunctionExecutingContext, System.Threading.CancellationToken)"/>>.
    /// </summary>
    [Obsolete("Filters is in preview and there may be breaking changes in this area.")]
    public class FunctionExecutingContext : FunctionInvocationContext
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="arguments">The function arguments.</param>
        /// <param name="properties">The property bag that can be used to pass information between filters.</param>
        /// <param name="functionInstanceId">The instance ID for the function invocation.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="logger"><see cref="ILogger"/> that can be used by the filter to log information.</param>
        public FunctionExecutingContext(IReadOnlyDictionary<string, object> arguments, IDictionary<string, object> properties, Guid functionInstanceId, string functionName, ILogger logger)
            : base(arguments, properties, functionInstanceId, functionName, logger)
        {
        }
    }
}