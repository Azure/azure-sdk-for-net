// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubContextBindingProvider : IBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly IConfiguration _configuration;
        private readonly WebPubSubServiceAccessOptions _options;
        private readonly WebPubSubServiceAccessFactory _accessFactory;
        private readonly ILogger _logger;

        public WebPubSubContextBindingProvider(INameResolver nameResolver, IConfiguration configuration, WebPubSubServiceAccessOptions options, WebPubSubServiceAccessFactory accessFactory, ILogger logger)
        {
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _accessFactory = accessFactory ?? throw new ArgumentNullException(nameof(accessFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;
            WebPubSubContextAttribute attribute = parameter.GetCustomAttribute<WebPubSubContextAttribute>(inherit: false);
            if (attribute == null)
            {
                return Task.FromResult<IBinding>(null);
            }

            return Task.FromResult<IBinding>(new WebPubSubContextBinding(context, _configuration, _nameResolver, _options, _accessFactory, _logger));
        }
    }
}
