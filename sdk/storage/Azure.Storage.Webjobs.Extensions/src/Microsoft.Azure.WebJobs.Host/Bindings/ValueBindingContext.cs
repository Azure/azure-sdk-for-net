// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Context for binding to a particular parameter value.
    /// </summary>
    public class ValueBindingContext
    {
        private readonly FunctionBindingContext _functionContext;
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="functionContext">The context for the parent function.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        public ValueBindingContext(FunctionBindingContext functionContext, CancellationToken cancellationToken)
        {
            _functionContext = functionContext;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// The function context.
        /// </summary>
        public FunctionBindingContext FunctionContext
        {
            get { return _functionContext; }
        }

        /// <summary>
        /// The instance ID of the function being bound to.
        /// </summary>
        public Guid FunctionInstanceId
        {
            get { return _functionContext.FunctionInstanceId; }
        }

        /// <summary>
        /// Gets the function <see cref="CancellationToken"/>.
        /// </summary>
        public CancellationToken FunctionCancellationToken
        {
            get { return _functionContext.FunctionCancellationToken; }
        }

        /// <summary>
        /// Gets the <see cref="CancellationToken"/> to use.
        /// </summary>
        public CancellationToken CancellationToken
        {
            get { return _cancellationToken; }
        }
    }
}
