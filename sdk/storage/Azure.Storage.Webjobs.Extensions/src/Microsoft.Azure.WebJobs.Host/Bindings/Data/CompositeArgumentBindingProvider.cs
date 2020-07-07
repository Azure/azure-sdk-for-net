// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal class CompositeArgumentBindingProvider<TBindingData> : IDataArgumentBindingProvider<TBindingData>
    {
        private readonly IEnumerable<IDataArgumentBindingProvider<TBindingData>> _providers;

        public CompositeArgumentBindingProvider(params IDataArgumentBindingProvider<TBindingData>[] providers)
        {
            _providers = providers;
        }

        public IArgumentBinding<TBindingData> TryCreate(ParameterInfo parameter)
        {
            foreach (IDataArgumentBindingProvider<TBindingData> provider in _providers)
            {
                IArgumentBinding<TBindingData> binding = provider.TryCreate(parameter);

                if (binding != null)
                {
                    return binding;
                }
            }

            return null;
        }
    }
}
