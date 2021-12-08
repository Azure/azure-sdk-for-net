// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal class CompositeEntityArgumentBindingProvider : ITableEntityArgumentBindingProvider
    {
        private readonly IEnumerable<ITableEntityArgumentBindingProvider> _providers;

        public CompositeEntityArgumentBindingProvider(params ITableEntityArgumentBindingProvider[] providers)
        {
            _providers = providers;
        }

        public IArgumentBinding<TableEntityContext> TryCreate(ParameterInfo parameter)
        {
            foreach (ITableEntityArgumentBindingProvider provider in _providers)
            {
                IArgumentBinding<TableEntityContext> binding = provider.TryCreate(parameter);

                if (binding != null)
                {
                    return binding;
                }
            }

            return null;
        }
    }
}
