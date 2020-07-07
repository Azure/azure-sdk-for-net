// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Context for runtime bindings performed via <see cref="IBinder"/>.
    /// </summary>
    internal class AmbientBindingContext
    {
        private readonly FunctionBindingContext _functionContext;
        private readonly IReadOnlyDictionary<string, object> _bindingData;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="functionContext">The <see cref="FunctionBindingContext"/>.</param>
        /// <param name="bindingData">The binding data.</param>
        public AmbientBindingContext(FunctionBindingContext functionContext, IReadOnlyDictionary<string, object> bindingData)
        {
            _functionContext = functionContext;
            _bindingData = bindingData;
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
        /// Gets the binding data.
        /// </summary>
        public IReadOnlyDictionary<string, object> BindingData
        {
            get { return _bindingData; }
        }
    }
}
