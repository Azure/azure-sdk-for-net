// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    // $$$ Get rid of this. 
    internal class DefaultTriggerBindingFactory
    {
        private readonly IExtensionRegistry _extensions;

        public DefaultTriggerBindingFactory(
            IExtensionRegistry extensions)
        {
            _extensions = extensions;
        }
        public ITriggerBindingProvider Create()
        {
            var innerProviders = new List<ITriggerBindingProvider>();


            // add any registered extension binding providers
            foreach (ITriggerBindingProvider provider in _extensions.GetExtensions(typeof(ITriggerBindingProvider)))
            {
                innerProviders.Add(provider);
            }

            return new CompositeTriggerBindingProvider(innerProviders);
        }
    }
}
