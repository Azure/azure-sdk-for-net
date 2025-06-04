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
        private readonly WebPubSubFunctionsOptions _options;
        private readonly IWebPubSubTriggerDispatcher _dispatcher;

        public WebPubSubConfigProvider(
            IOptions<WebPubSubFunctionsOptions> options,
            INameResolver nameResolver,
            ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _options = options.Value;
            _logger = loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("WebPubSub"));
            _nameResolver = nameResolver;
            _configuration = configuration;
            _dispatcher = new WebPubSubTriggerDispatcher(_logger, _options);
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(_options.ConnectionString))
            {
                _options.ConnectionString = _nameResolver.Resolve(Constants.WebPubSubConnectionStringName);
            }

            if (string.IsNullOrEmpty(_options.Hub))
            {
                _options.Hub = _nameResolver.Resolve(Constants.HubNameStringName);
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
                .BindToTrigger(new WebPubSubTriggerBindingProvider(_dispatcher, _nameResolver, _options, webhookException));

            // Input binding
            var webpubsubConnectionAttributeRule = context.AddBindingRule<WebPubSubConnectionAttribute>();
            webpubsubConnectionAttributeRule.AddValidator(ValidateWebPubSubConnectionAttributeBinding);
            webpubsubConnectionAttributeRule.BindToInput(GetClientConnection);

            var webPubSubRequestAttributeRule = context.AddBindingRule<WebPubSubContextAttribute>();
            webPubSubRequestAttributeRule.Bind(new WebPubSubContextBindingProvider(_nameResolver, _configuration, _options));

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

        private void ValidateWebPubSubConnectionAttributeBinding(WebPubSubConnectionAttribute attribute, Type type)
        {
            ValidateConnectionString(
                attribute.Connection,
                $"{nameof(WebPubSubConnectionAttribute)}.{nameof(WebPubSubConnectionAttribute.Connection)}");
        }

        private void ValidateWebPubSubAttributeBinding(WebPubSubAttribute attribute, Type type)
        {
            ValidateConnectionString(
                attribute.Connection,
                $"{nameof(WebPubSubAttribute)}.{nameof(WebPubSubAttribute.Connection)}");
        }

        internal WebPubSubService GetService(WebPubSubAttribute attribute)
        {
            var connectionString = Utilities.FirstOrDefault(attribute.Connection, _options.ConnectionString);
            var hubName = Utilities.FirstOrDefault(attribute.Hub, _options.Hub);
            return new WebPubSubService(connectionString, hubName);
        }

        private IAsyncCollector<WebPubSubAction> CreateCollector(WebPubSubAttribute attribute)
        {
            return new WebPubSubAsyncCollector(GetService(attribute));
        }

        private WebPubSubConnection GetClientConnection(WebPubSubConnectionAttribute attribute)
        {
            var hub = Utilities.FirstOrDefault(attribute.Hub, _options.Hub);
            var service = new WebPubSubService(attribute.Connection, hub);
            return service.GetClientConnection(attribute.UserId, clientProtocol: attribute.ClientProtocol);
        }

        private void ValidateConnectionString(string attributeConnectionString, string attributeConnectionStringName)
        {
            var connectionString = Utilities.FirstOrDefault(attributeConnectionString, _options.ConnectionString);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"The Service connection string must be set either via an '{Constants.WebPubSubConnectionStringName}' app setting, via an '{Constants.WebPubSubConnectionStringName}' environment variable, or directly in code via {nameof(WebPubSubFunctionsOptions)}.{nameof(WebPubSubFunctionsOptions.ConnectionString)} or {attributeConnectionStringName}.");
            }
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
