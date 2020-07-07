// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Runtime
{
    internal class RuntimeBindingProvider : IBindingProvider
    {
        private readonly IContextGetter<IBindingProvider> _bindingProviderGetter;

        public RuntimeBindingProvider(IContextGetter<IBindingProvider> bindingProviderGetter)
        {
            if (bindingProviderGetter == null)
            {
                throw new ArgumentNullException("bindingProviderGetter");
            }

            _bindingProviderGetter = bindingProviderGetter;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;
            if (parameter.ParameterType != typeof(IBinder) &&
                parameter.ParameterType != typeof(Binder))
            {
                return Task.FromResult<IBinding>(null);
            }

            IBinding binding = new RuntimeBinding(context.Parameter, _bindingProviderGetter);
            return Task.FromResult(binding);
        }
    }
}
