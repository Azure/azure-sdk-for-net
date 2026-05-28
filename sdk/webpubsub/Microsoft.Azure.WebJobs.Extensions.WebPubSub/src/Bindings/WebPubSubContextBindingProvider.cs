// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubContextBindingProvider : IBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly IConfiguration _configuration;
        private readonly WebPubSubFunctionsOptions _options;

        public WebPubSubContextBindingProvider(INameResolver nameResolver, IConfiguration configuration, WebPubSubFunctionsOptions options)
        {
            _nameResolver = nameResolver;
            _configuration = configuration;
            _options = options;
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

            return Task.FromResult<IBinding>(new WebPubSubContextBinding(context, _configuration, _nameResolver, _options));
        }
    }
}
