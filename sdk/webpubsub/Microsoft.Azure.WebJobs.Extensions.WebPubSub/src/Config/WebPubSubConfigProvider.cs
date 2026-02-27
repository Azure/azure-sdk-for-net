// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [Extension("WebPubSub", "webpubsub")]
    internal class WebPubSubConfigProvider : IExtensionConfigProvider, IAsyncConverter<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;
        private readonly ILogger _logger;
        private readonly IWebPubSubTriggerDispatcher _dispatcher;
        private readonly IWebPubSubServiceClientFactory _clientFactory;
        private readonly IOptionsMonitor<WebPubSubServiceAccessOptions> _accessOptions;
        private readonly WebPubSubServiceAccessFactory _accessFactory;

        public WebPubSubConfigProvider(
            INameResolver nameResolver,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IOptionsMonitor<WebPubSubServiceAccessOptions> accessOptions,
            IWebPubSubServiceClientFactory clientFactory,
            WebPubSubServiceAccessFactory accessFactory)
        {
            _logger = loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("WebPubSub"));
            _nameResolver = nameResolver;
            _configuration = configuration;
            _accessOptions = accessOptions;
            _dispatcher = new WebPubSubTriggerDispatcher(_logger, _accessOptions.CurrentValue);
            _clientFactory = clientFactory;
            _accessFactory = accessFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Exception webhookException = null;
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                var url = context.GetWebhookHandler();
#pragma warning restore CS0618 // Type or member is obsolete
                _logger.LogInformation($"Registered Web PubSub negotiate Endpoint = {url?.GetLeftPart(UriPartial.Path)}");
            }
            catch (Exception ex)
            {
                // disable trigger.
                webhookException = ex;
            }

            // register JsonConverters
            RegisterJsonConverter();

            // bindings
            context
                .AddConverter<WebPubSubConnection, JObject>(JObject.FromObject)
                .AddConverter<WebPubSubContext, JObject>(JObject.FromObject)
                .AddConverter<JObject, WebPubSubAction>(ConvertToWebPubSubOperation)
                .AddConverter<JArray, WebPubSubAction[]>(ConvertToWebPubSubOperationArray);

            // Trigger binding
            context.AddBindingRule<WebPubSubTriggerAttribute>()
                .BindToTrigger(new WebPubSubTriggerBindingProvider(_dispatcher, _nameResolver, _accessOptions.CurrentValue, webhookException, _accessFactory));

            // Input binding
            var webpubsubConnectionAttributeRule = context.AddBindingRule<WebPubSubConnectionAttribute>();
            webpubsubConnectionAttributeRule.AddValidator(ValidateWebPubSubConnectionAttributeBinding);
            webpubsubConnectionAttributeRule.BindToInput(GetClientConnection);

            var webPubSubRequestAttributeRule = context.AddBindingRule<WebPubSubContextAttribute>();
            webPubSubRequestAttributeRule.Bind(new WebPubSubContextBindingProvider(_nameResolver, _configuration, _accessOptions.CurrentValue, _accessFactory));

            // Output binding
            var webPubSubAttributeRule = context.AddBindingRule<WebPubSubAttribute>();
            webPubSubAttributeRule.AddValidator(ValidateWebPubSubAttributeBinding);
            webPubSubAttributeRule.BindToCollector(CreateCollector);

            _logger.LogInformation("Azure Web PubSub binding initialized");
        }

        public Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            return _dispatcher.ExecuteAsync(input, cancellationToken);
        }

        internal WebPubSubService GetService(WebPubSubAttribute attribute)
        {
            var client = _clientFactory.Create(
                attribute.Connection,
                attribute.Hub);
            return new WebPubSubService(client);
        }

        private void ValidateWebPubSubAttributeBinding(WebPubSubAttribute attribute, Type type)
        {
            ValidateWebPubSubConnectionCore(attribute.Connection, attribute.Hub, "WebPubSub");
        }

        private void ValidateWebPubSubConnectionAttributeBinding(WebPubSubConnectionAttribute attribute, Type type)
        {
            ValidateWebPubSubConnectionCore(attribute.Connection, attribute.Hub, "WebPubSubConnection");
        }

        private void ValidateWebPubSubConnectionCore(string attributeConnection, string attributeHub, string extensionType)
        {
            var webPubSubAccessExists = true;
            if (attributeConnection == null)
            {
                if (_accessOptions.CurrentValue.WebPubSubAccess == null)
                {
                    webPubSubAccessExists = false;
                }
            }
            else
            {
                if (!WebPubSubServiceAccessUtil.CanCreateFromIConfiguration(_configuration.GetSection(attributeConnection)))
                {
                    webPubSubAccessExists = false;
                }
            }
            if (!webPubSubAccessExists)
            {
                throw new InvalidOperationException(
                 $"Connection must be specified through one of the following:" + Environment.NewLine +
                $"  * Set '{extensionType}.Connection' property to the name of a config section that contains a Web PubSub connection." + Environment.NewLine +
                $"  * Set a Web PubSub connection under '{Constants.WebPubSubConnectionStringName}'.");
            }

            if ((attributeHub ?? _accessOptions.CurrentValue.Hub) is null)
            {
                throw new InvalidOperationException($"Resolved 'Hub' value is null for extension '{extensionType}'.");
            }
        }

        private IAsyncCollector<WebPubSubAction> CreateCollector(WebPubSubAttribute attribute)
        {
            return new WebPubSubAsyncCollector(GetService(attribute));
        }

        private WebPubSubConnection GetClientConnection(WebPubSubConnectionAttribute attribute)
        {
            var client = _clientFactory.Create(
                attribute.Connection,
                attribute.Hub);
            var service = new WebPubSubService(client);
            return service.GetClientConnection(attribute.UserId, clientProtocol: attribute.ClientProtocol);
        }

        internal static void RegisterJsonConverter()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new BinaryDataJsonConverter(),
                    new ConnectionStatesNewtonsoftConverter(),
                    new WebPubSubDataTypeJsonConverter(),
                    new WebPubSubEventTypeJsonConverter(),
                    new WebPubSubTriggerAcceptedClientProtocolsJsonConverter(),
                },
            };
        }

        internal static WebPubSubAction ConvertToWebPubSubOperation(JObject input)
        {
            if (input.TryGetValue("actionName", StringComparison.OrdinalIgnoreCase, out var kind))
            {
                var opeartions = typeof(WebPubSubAction).Assembly.GetTypes().Where(t => t.BaseType == typeof(WebPubSubAction));
                foreach (var item in opeartions)
                {
                    if (TryToWebPubSubOperation(input, kind.ToString() + "Action", item, out var operation))
                    {
                        return operation;
                    }
                }
            }
            throw new ArgumentException($"Not supported WebPubSubOperation: {kind}.");
        }

        internal static WebPubSubAction[] ConvertToWebPubSubOperationArray(JArray input)
        {
            var result = new List<WebPubSubAction>();
            foreach (var item in input)
            {
                result.Add(ConvertToWebPubSubOperation((JObject)item));
            }
            return result.ToArray();
        }

        private static bool TryToWebPubSubOperation(JObject input, string actionName, Type operationType, out WebPubSubAction operation)
        {
            // message events need check dataType.
            if (actionName.StartsWith("Send", StringComparison.OrdinalIgnoreCase))
            {
                CheckDataType(input);
            }
            if (actionName.Equals(operationType.Name, StringComparison.OrdinalIgnoreCase))
            {
                operation = input.ToObject(operationType) as WebPubSubAction;
                return true;
            }
            operation = null;
            return false;
        }

        // Binary data accepts ArrayBuffer only, script language checks.
        private static void CheckDataType(JObject input)
        {
            if (input.TryGetValue("dataType", StringComparison.OrdinalIgnoreCase, out var value))
            {
                var dataType = value.ToObject<WebPubSubDataType>();

                input.TryGetValue("data", StringComparison.OrdinalIgnoreCase, out var data);

                if (dataType == WebPubSubDataType.Binary &&
                    !(data["type"] != null && data["type"].ToString().Equals("Buffer", StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException("WebPubSubDataType is binary, please use ArrayBuffer as message data type.");
                }
            }
        }
    }
}
