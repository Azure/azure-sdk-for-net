// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOTriggerBindingProvider : ITriggerBindingProvider
    {
        private readonly IWebPubSubForSocketIOTriggerDispatcher _dispatcher;
        private readonly INameResolver _nameResolver;
        private readonly SocketIOFunctionsOptions _options;
        private readonly Exception _webhookException;

        public WebPubSubForSocketIOTriggerBindingProvider(IWebPubSubForSocketIOTriggerDispatcher dispatcher, INameResolver nameResolver, SocketIOFunctionsOptions options, Exception webhookException)
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
            var attribute = parameterInfo.GetCustomAttribute<SocketIOTriggerAttribute>(false);
            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            if (_webhookException != null)
            {
                throw new NotSupportedException($"WebPubSubTrigger is disabled due to 'AzureWebJobsStorage' connection string is not set or invalid. {_webhookException}");
            }

            return Task.FromResult<ITriggerBinding>(new WebPubSubForSocketIOTriggerBinding(parameterInfo, GetResolvedAttribute(attribute, parameterInfo), _options, _dispatcher));
        }

        internal SocketIOTriggerAttribute GetResolvedAttribute(SocketIOTriggerAttribute attribute, ParameterInfo parameterInfo)
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

            var parameterNames = attribute.ParameterNames ?? Array.Empty<string>();
            var method = (MethodInfo)parameterInfo.Member;
            var parameterNamesFromAttribute = method.GetParameters().
                   Where(p => p.GetCustomAttribute<SocketIOParameterAttribute>(false) != null).
                   Select(p => p.Name).ToArray();

            if (parameterNamesFromAttribute.Length != 0 && parameterNames.Length != 0)
            {
                throw new ArgumentException(
                        $"{nameof(SocketIOTriggerAttribute)}.{nameof(SocketIOTriggerAttribute.ParameterNames)} and {nameof(SocketIOParameterAttribute)} can not be set in the same Function.");
            }

            parameterNames = parameterNamesFromAttribute.Length != 0 ? parameterNamesFromAttribute : parameterNames;

            return new SocketIOTriggerAttribute(
                hub,
                eventName,
                attribute.Namespace,
                parameterNames);
        }
    }
}
