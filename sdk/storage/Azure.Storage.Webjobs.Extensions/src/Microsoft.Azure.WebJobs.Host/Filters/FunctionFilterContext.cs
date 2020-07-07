// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Base context class for all function filter context objects.
    /// </summary>
    [Obsolete("Filters is in preview and there may be breaking changes in this area.")]
    public abstract class FunctionFilterContext
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="functionInstanceId">The instance ID for the function invocation.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="logger"><see cref="ILogger"/> that can be used by the filter to log information.</param>
        /// <param name="properties">The property bag that can be used to pass information between filters.</param>
        protected FunctionFilterContext(Guid functionInstanceId, string functionName, ILogger logger, IDictionary<string, object> properties)
        {
            if (string.IsNullOrEmpty(functionName))
            {
                throw new ArgumentNullException(nameof(functionName));
            }

            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            FunctionInstanceId = functionInstanceId;
            FunctionName = functionName;
            Logger = logger;
            Properties = properties;
        }

        /// <summary>
        /// Gets the function instance ID.
        /// </summary>
        public Guid FunctionInstanceId { get; }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public string FunctionName { get; }

        /// <summary>
        /// Gets the property bag that can be used to pass information between filters.
        /// </summary>
        public IDictionary<string, object> Properties { get; }

        /// <summary>
        /// Gets the <see cref="ILogger"/> that can be used by the filter to log information.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Gets or sets the <see cref="IJobInvoker"/>.
        /// </summary>
        internal IJobInvoker Invoker { get; set; }
    }
}