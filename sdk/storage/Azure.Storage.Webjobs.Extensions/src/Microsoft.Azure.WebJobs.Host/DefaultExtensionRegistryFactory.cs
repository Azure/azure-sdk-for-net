// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host
{
    public class DefaultExtensionRegistryFactory : IExtensionRegistryFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IEnumerable<IExtensionConfigProvider> _registeredExtensions;
        private readonly IConverterManager _converterManager;
        private readonly IWebHookProvider _webHookProvider;
        private readonly INameResolver _nameResolver;

        public DefaultExtensionRegistryFactory(IEnumerable<IExtensionConfigProvider> registeredExtensions, IConverterManager converterManager,
             IConfiguration configuration, INameResolver nameResolver, IWebHookProvider webHookProvider = null)
        {
            _configuration = configuration;
            _registeredExtensions = registeredExtensions;
            _converterManager = converterManager;
            _webHookProvider = webHookProvider;
            _nameResolver = nameResolver;
        }

        public IExtensionRegistry Create()
        {
            IExtensionRegistry registry = new DefaultExtensionRegistry();

            ExtensionConfigContext context = new ExtensionConfigContext(_configuration, _nameResolver, _converterManager, _webHookProvider, registry);            

            foreach (IExtensionConfigProvider extension in _registeredExtensions)
            {
                registry.RegisterExtension<IExtensionConfigProvider>(extension);
                context.Current = extension;
                extension.Initialize(context);
            }

            context.ApplyRules();

            return registry;
        }
    }
}
