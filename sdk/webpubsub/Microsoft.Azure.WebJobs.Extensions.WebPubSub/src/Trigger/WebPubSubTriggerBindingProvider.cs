// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerBindingProvider : ITriggerBindingProvider
    {
        private readonly IWebPubSubTriggerDispatcher _dispatcher;
        private readonly INameResolver _nameResolver;
        private readonly WebPubSubFunctionsOptions _options;
        private readonly Exception _webhookException;

        public WebPubSubTriggerBindingProvider(IWebPubSubTriggerDispatcher dispatcher, INameResolver nameResolver, WebPubSubFunctionsOptions options, Exception webhookException)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
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

            return Task.FromResult<ITriggerBinding>(new WebPubSubTriggerBinding(parameterInfo, GetResolvedAttribute(attribute), _options, _dispatcher));
        }

        internal WebPubSubTriggerAttribute GetResolvedAttribute(WebPubSubTriggerAttribute attribute)
        {
            // Try resolve and throw exception if not able to find one.
            if (!_nameResolver.TryResolveWholeString(attribute.Hub, out var hub))
            {
                throw new ArgumentException($"Failed to resolve substitute configure: {attribute.Hub}, please add.");
            }
            if (!_nameResolver.TryResolveWholeString(attribute.EventName, out var eventName))
            {
                throw new ArgumentException($"Failed to resolve substitute configure: {attribute.EventName}, please add.");
            }

            return new WebPubSubTriggerAttribute(
                hub,
                attribute.EventType,
                eventName,
                attribute.Connections)
            {
                ClientProtocols = attribute.ClientProtocols
            };
        }
    }
}
