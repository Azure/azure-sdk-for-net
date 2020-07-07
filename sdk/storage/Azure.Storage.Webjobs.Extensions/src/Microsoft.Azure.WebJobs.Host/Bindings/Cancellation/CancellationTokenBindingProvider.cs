// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Cancellation
{
    internal class CancellationTokenBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;

            if (parameter.ParameterType != typeof(CancellationToken))
            {
                return Task.FromResult<IBinding>(null);
            }

            IBinding binding = new CancellationTokenBinding(parameter.Name);
            return Task.FromResult(binding);
        }
    }
}
