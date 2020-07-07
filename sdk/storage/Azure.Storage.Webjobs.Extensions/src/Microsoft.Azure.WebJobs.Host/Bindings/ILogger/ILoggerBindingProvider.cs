// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Binding provider handling bindings to <see cref="ILogger"/>.
    /// </summary>
    internal class ILoggerBindingProvider : IBindingProvider
    {
        private ILoggerFactory _loggerFactory;

        public ILoggerBindingProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;
            if (parameter.ParameterType != typeof(ILogger))
            {
                return Task.FromResult<IBinding>(null);
            }

            if (_loggerFactory == null)
            {
                throw new ArgumentException("A parameter of type ILogger cannot be used without a registered ILoggerFactory.");
            }

            IBinding binding = new ILoggerBinding(parameter, _loggerFactory);
            return Task.FromResult(binding);
        }
    }
}
