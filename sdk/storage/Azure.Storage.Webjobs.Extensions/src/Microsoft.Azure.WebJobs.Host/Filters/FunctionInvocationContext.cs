// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Base context class for <see cref="IFunctionInvocationFilter"/> context objects.
    /// </summary>
    [Obsolete("Filters is in preview and there may be breaking changes in this area.")]
    public abstract class FunctionInvocationContext : FunctionFilterContext
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="arguments">The function arguments.</param>
        /// <param name="properties">The property bag that can be used to pass information between filters.</param>
        /// <param name="functionInstanceId">The instance ID for the function invocation.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="logger"><see cref="ILogger"/> that can be used by the filter to log information.</param>
        protected FunctionInvocationContext(IReadOnlyDictionary<string, object> arguments, IDictionary<string, object> properties, Guid functionInstanceId, string functionName, ILogger logger)
            : base(functionInstanceId, functionName, logger, properties)
        {
            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            Arguments = arguments;
        }

        /// <summary>
        /// Gets the function arguments keyed by parameter name.
        /// </summary>
        public IReadOnlyDictionary<string, object> Arguments { get; }
    }
}