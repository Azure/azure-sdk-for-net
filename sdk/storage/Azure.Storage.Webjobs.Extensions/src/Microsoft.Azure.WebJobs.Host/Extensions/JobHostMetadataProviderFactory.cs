// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Indexers;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class JobHostMetadataProviderFactory : IJobHostMetadataProviderFactory
    {
        private readonly IFunctionIndexProvider _functionIndexProvider;
        private readonly IExtensionRegistry _extensionRegistry;
        private readonly IBindingProvider _bindingProvider;
        private readonly IConverterManager _converterManager;

        public JobHostMetadataProviderFactory(IFunctionIndexProvider functionIndexProvider, IExtensionRegistry extensionRegistry, CompositeBindingProvider bindingProvider, IConverterManager converterManager)
        {
            _functionIndexProvider = functionIndexProvider;
            _extensionRegistry = extensionRegistry;
            _bindingProvider = bindingProvider;
            _converterManager = converterManager;
        }

        public IJobHostMetadataProvider Create()
        {
            var provider = new JobHostMetadataProvider(_functionIndexProvider, _extensionRegistry, _bindingProvider, _converterManager);
            provider.Initialize();
            return provider;
        }
    }
}
