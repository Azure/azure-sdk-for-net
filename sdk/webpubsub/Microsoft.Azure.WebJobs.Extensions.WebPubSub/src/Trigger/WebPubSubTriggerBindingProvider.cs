// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerBindingProvider : ITriggerBindingProvider
    {
        private readonly IWebPubSubTriggerDispatcher _dispatcher;
        private readonly WebPubSubOptions _options;
        private readonly Exception _webhookException;

        public WebPubSubTriggerBindingProvider(IWebPubSubTriggerDispatcher dispatcher, WebPubSubOptions options, Exception webhookException)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _webhookException = webhookException;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var parameterInfo = context.Parameter;
            var attribute = parameterInfo.GetCustomAttribute<WebPubSubTriggerAttribute>(false);
            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            if (_webhookException != null)
            {
                throw new NotSupportedException($"WebPubSubTrigger is disabled due to 'AzureWebJobsStorage' connection string is not set or invalid. {_webhookException}");
            }

            return Task.FromResult<ITriggerBinding>(new WebPubSubTriggerBinding(parameterInfo, attribute, _options, _dispatcher));
        }
    }
}
