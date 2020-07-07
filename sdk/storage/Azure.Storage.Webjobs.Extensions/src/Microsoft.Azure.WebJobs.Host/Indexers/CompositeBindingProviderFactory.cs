// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Runtime;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    /// <summary>
    /// Produces a CompositeBindingProvider that's a collection of all <see cref="IBindingProvider"/>
    /// This pulls from: 
    /// <list>
    /// <item>Normal extensions in <see cref="IExtensionConfigProvider"/></item>
    /// <item>Anything registered via DI, which includes a set of builtins.</item>
    /// <item>A <see cref="RuntimeBindingProvider"/> for binding to <see cref="IBinder"/></item>
    /// </list>
    /// </summary>
    internal sealed class CompositeBindingProviderFactory
    {
        private readonly IExtensionRegistry _extensions;
        private readonly IBindingProvider[] _existingProviders;

        public CompositeBindingProviderFactory(
            IEnumerable<IBindingProvider> existingProviders,
            IExtensionRegistry extensions)
        {
            _existingProviders = existingProviders.ToArray();
            _extensions = extensions;
        }
        
        public CompositeBindingProvider Create()
        {
            List<IBindingProvider> innerProviders = new List<IBindingProvider>();
                     
            // add any registered extension binding providers
            // Queue and Table bindings were added as an extension, so those rules get included here.  
            foreach (IBindingProvider provider in _extensions.GetExtensions(typeof(IBindingProvider)))
            {
                innerProviders.Add(provider);
            }                       

            ContextAccessor<IBindingProvider> bindingProviderAccessor = new ContextAccessor<IBindingProvider>();
            innerProviders.Add(new RuntimeBindingProvider(bindingProviderAccessor)); // for IBinder, Binder

            // Pull existing ones already directly registered with DI 
            innerProviders.AddRange(_existingProviders);

            var bindingProvider = new CompositeBindingProvider(innerProviders);
            bindingProviderAccessor.SetValue(bindingProvider);
            return bindingProvider;
        }
    }
}
