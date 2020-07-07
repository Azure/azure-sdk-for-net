// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Represents context data used by <see cref="ITriggerBindingProvider"/> in the creation of bindings.
    /// </summary>
    public class TriggerBindingProviderContext
    {
        private readonly ParameterInfo _parameter;
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="parameter">The parameter to be bound.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        public TriggerBindingProviderContext(ParameterInfo parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            _parameter = parameter;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// The parameter to be bound.
        /// </summary>
        public ParameterInfo Parameter
        {
            get { return _parameter; }
        }

        /// <summary>
        /// The <see cref="CancellationToken"/> to use.
        /// </summary>
        public CancellationToken CancellationToken
        {
            get { return _cancellationToken; }
        }
    }
}
