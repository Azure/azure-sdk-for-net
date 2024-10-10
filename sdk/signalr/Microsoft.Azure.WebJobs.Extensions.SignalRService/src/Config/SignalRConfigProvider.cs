// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [Extension("SignalR", "signalr")]
    internal class SignalRConfigProvider : IExtensionConfigProvider, IAsyncConverter<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly IServiceManagerStore _serviceManagerStore;
        private readonly INameResolver _nameResolver;
        private readonly ILogger _logger;
        private readonly ISignalRTriggerDispatcher _dispatcher;
        private readonly InputBindingProvider _inputBindingProvider;

        public SignalRConfigProvider(
            INameResolver nameResolver,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IServiceManagerStore serviceManagerStore,
            ISecurityTokenValidator securityTokenValidator = null,
            ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer = null)
        {
            _logger = loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("SignalR"));
            _nameResolver = nameResolver;
            _serviceManagerStore = serviceManagerStore;
            _dispatcher = new SignalRTriggerDispatcher();
            _inputBindingProvider = new InputBindingProvider(configuration, nameResolver, securityTokenValidator, signalRConnectionInfoConfigurer);
        }

        // GetWebhookHandler() need the Obsolete
        [Obsolete("preview")]
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            StaticServiceHubContextStore.ServiceManagerStore = _serviceManagerStore;

            Exception webhookException = null;
            try
            {
                var url = context.GetWebhookHandler();
                _logger.LogInformation($"Registered SignalR trigger Endpoint = {url?.GetLeftPart(UriPartial.Path)}");
            }
            catch (Exception ex)
            {
                webhookException = ex;
            }

            context.AddConverter<string, JObject>(JObject.FromObject)
                   .AddConverter<SignalRConnectionInfo, JObject>(JObject.FromObject)
                   .AddConverter<JObject, SignalRMessage>(input => input.ToObject<SignalRMessage>())
                   .AddConverter<JObject, SignalRGroupAction>(input => input.ToObject<SignalRGroupAction>());

            // Trigger binding rule
            var triggerBindingRule = context.AddBindingRule<SignalRTriggerAttribute>();
            triggerBindingRule.AddConverter<InvocationContext, JObject>(JObject.FromObject);
            triggerBindingRule.BindToTrigger(new SignalRTriggerBindingProvider(_dispatcher, _nameResolver, _serviceManagerStore, webhookException));

            // Non-trigger binding rule
            var signalRConnectionInfoAttributeRule = context.AddBindingRule<SignalRConnectionInfoAttribute>();
            signalRConnectionInfoAttributeRule.Bind(_inputBindingProvider);

            var securityTokenValidationAttributeRule = context.AddBindingRule<SecurityTokenValidationAttribute>();
            securityTokenValidationAttributeRule.Bind(_inputBindingProvider);

            _ = context.AddBindingRule<SignalRNegotiationAttribute>()
                .AddConverter<NegotiationContext, JObject>(JObject.FromObject)
                .BindToInput(new NegotiationContextAsyncConverter(_serviceManagerStore));

            _ = context.AddBindingRule<SignalREndpointsAttribute>()
                   .AddConverter<ServiceEndpoint[], JArray>(endpoints => JArray.FromObject(endpoints, JTokenExtensions.JsonSerializers))
                   .BindToInput(new SignalREndpointsAsyncConverter(_serviceManagerStore));

            var signalRAttributeRule = context.AddBindingRule<SignalRAttribute>();
            signalRAttributeRule.BindToCollector<SignalROpenType>(typeof(SignalRAsyncCollectorBuilder<>), _serviceManagerStore);

            _logger.LogInformation("SignalRService binding initialized");
        }

        public Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            return _dispatcher.ExecuteAsync(input, cancellationToken);
        }

        private class SignalROpenType : OpenType.Poco
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return false;
                }

                if (type.FullName == "System.Object")
                {
                    return true;
                }

                return base.IsMatch(type, context);
            }
        }
    }
}