// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    internal class CompositeTriggerBindingProvider : ITriggerBindingProvider
    {
        private readonly IEnumerable<ITriggerBindingProvider> _providers;

        public CompositeTriggerBindingProvider(IEnumerable<ITriggerBindingProvider> providers)
        {
            _providers = providers;
        }

        public async Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            foreach (ITriggerBindingProvider provider in _providers)
            {
                ITriggerBinding binding = await provider.TryCreateAsync(context);

                if (binding != null)
                {
                    return binding;
                }
            }

            return null;
        }
    }
}
