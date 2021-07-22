// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [Extension("WebPubSub", "webpubsub")]
    internal class WebPubSubConfigProvider : IExtensionConfigProvider, IAsyncConverter<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;
        private readonly ILogger _logger;
        private readonly WebPubSubOptions _options;
        private readonly IWebPubSubTriggerDispatcher _dispatcher;

        public WebPubSubConfigProvider(
            IOptions<WebPubSubOptions> options,
            INameResolver nameResolver,
            ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _options = options.Value;
            _logger = loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("WebPubSub"));
            _nameResolver = nameResolver;
            _configuration = configuration;
            _dispatcher = new WebPubSubTriggerDispatcher(_logger);
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
                AddSettings(_options.ConnectionString);
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
                .AddConverter<JObject, WebPubSubOperation>(ConvertToWebPubSubOperation)
                .AddConverter<JArray, WebPubSubOperation[]>(ConvertToWebPubSubOperationArray);

            // Trigger binding
            context.AddBindingRule<WebPubSubTriggerAttribute>()
                .BindToTrigger(new WebPubSubTriggerBindingProvider(_dispatcher, _nameResolver, _options, webhookException));

            var webpubsubConnectionAttributeRule = context.AddBindingRule<WebPubSubConnectionAttribute>();
            webpubsubConnectionAttributeRule.AddValidator(ValidateWebPubSubConnectionAttributeBinding);
            webpubsubConnectionAttributeRule.BindToInput(GetClientConnection);

            var webPubSubAttributeRule = context.AddBindingRule<WebPubSubAttribute>();
            webPubSubAttributeRule.AddValidator(ValidateWebPubSubAttributeBinding);
            webPubSubAttributeRule.BindToCollector(CreateCollector);

            _logger.LogInformation("Azure Web PubSub binding initialized");
        }

        public Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            return _dispatcher.ExecuteAsync(input, _options.AllowedHosts, _options.AccessKeys, cancellationToken);
        }

        private void ValidateWebPubSubConnectionAttributeBinding(WebPubSubConnectionAttribute attribute, Type type)
        {
            ValidateConnectionString(
                attribute.ConnectionStringSetting,
                $"{nameof(WebPubSubConnectionAttribute)}.{nameof(WebPubSubConnectionAttribute.ConnectionStringSetting)}");
        }

        private void ValidateWebPubSubAttributeBinding(WebPubSubAttribute attribute, Type type)
        {
            ValidateConnectionString(
                attribute.ConnectionStringSetting,
                $"{nameof(WebPubSubAttribute)}.{nameof(WebPubSubAttribute.ConnectionStringSetting)}");
        }

        internal WebPubSubService GetService(WebPubSubAttribute attribute)
        {
            var connectionString = Utilities.FirstOrDefault(attribute.ConnectionStringSetting, _options.ConnectionString);
            var hubName = Utilities.FirstOrDefault(attribute.Hub, _options.Hub);
            return new WebPubSubService(connectionString, hubName);
        }

        private IAsyncCollector<WebPubSubOperation> CreateCollector(WebPubSubAttribute attribute)
        {
            return new WebPubSubAsyncCollector(GetService(attribute));
        }

        private WebPubSubConnection GetClientConnection(WebPubSubConnectionAttribute attribute)
        {
            var hub = Utilities.FirstOrDefault(attribute.Hub, _options.Hub);
            var service = new WebPubSubService(attribute.ConnectionStringSetting, hub);
            return service.GetClientConnection(attribute.UserId);
        }

        private void ValidateConnectionString(string attributeConnectionString, string attributeConnectionStringName)
        {
            AddSettings(attributeConnectionString);
            var connectionString = Utilities.FirstOrDefault(attributeConnectionString, _options.ConnectionString);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"The Service connection string must be set either via an '{Constants.WebPubSubConnectionStringName}' app setting, via an '{Constants.WebPubSubConnectionStringName}' environment variable, or directly in code via {nameof(WebPubSubOptions)}.{nameof(WebPubSubOptions.ConnectionString)} or {attributeConnectionStringName}.");
            }
        }

        private void AddSettings(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                var item = new ServiceConfigParser(connectionString);
                _options.AllowedHosts.Add(item.Endpoint.Host);
                _options.AccessKeys.Add(item.AccessKey);
            }
        }

        internal static void RegisterJsonConverter()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new BinaryDataJsonConverter()
                }
            };
        }

        internal static WebPubSubOperation ConvertToWebPubSubOperation(JObject input)
        {
            if (input.TryGetValue("operationKind", StringComparison.OrdinalIgnoreCase, out var kind))
            {
                if (kind.ToString().Equals(nameof(SendToAll), StringComparison.OrdinalIgnoreCase))
                {
                    CheckDataType(input);
                    return input.ToObject<SendToAll>();
                }
                else if (kind.ToString().Equals(nameof(SendToConnection), StringComparison.OrdinalIgnoreCase))
                {
                    CheckDataType(input);
                    return input.ToObject<SendToConnection>();
                }
                else if (kind.ToString().Equals(nameof(SendToUser), StringComparison.OrdinalIgnoreCase))
                {
                    CheckDataType(input);
                    return input.ToObject<SendToUser>();
                }
                else if (kind.ToString().Equals(nameof(SendToGroup), StringComparison.OrdinalIgnoreCase))
                {
                    CheckDataType(input);
                    return input.ToObject<SendToGroup>();
                }
                else if (kind.ToString().Equals(nameof(AddUserToGroup), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<AddUserToGroup>();
                }
                else if (kind.ToString().Equals(nameof(RemoveUserFromGroup), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<RemoveUserFromGroup>();
                }
                else if (kind.ToString().Equals(nameof(RemoveUserFromAllGroups), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<RemoveUserFromAllGroups>();
                }
                else if (kind.ToString().Equals(nameof(AddConnectionToGroup), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<AddConnectionToGroup>();
                }
                else if (kind.ToString().Equals(nameof(RemoveConnectionFromGroup), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<RemoveConnectionFromGroup>();
                }
                else if (kind.ToString().Equals(nameof(CloseClientConnection), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<CloseClientConnection>();
                }
                else if (kind.ToString().Equals(nameof(GrantGroupPermission), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<GrantGroupPermission>();
                }
                else if (kind.ToString().Equals(nameof(RevokeGroupPermission), StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToObject<RevokeGroupPermission>();
                }
            }
            return input.ToObject<WebPubSubOperation>();
        }

        internal static WebPubSubOperation[] ConvertToWebPubSubOperationArray(JArray input)
        {
            var result = new List<WebPubSubOperation>();
            foreach (var item in input)
            {
                result.Add(ConvertToWebPubSubOperation((JObject)item));
            }
            return result.ToArray();
        }

        // Binary data accepts ArrayBuffer only.
        private static void CheckDataType(JObject input)
        {
            if (input.TryGetValue("dataType", StringComparison.OrdinalIgnoreCase, out var value))
            {
                var dataType = value.ToObject<MessageDataType>();

                input.TryGetValue("message", StringComparison.OrdinalIgnoreCase, out var message);

                if (dataType == MessageDataType.Binary &&
                    !(message["type"] != null && message["type"].ToString().Equals("Buffer", StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException("MessageDataType is binary, please use ArrayBuffer as message type.");
                }
            }
        }
    }
}
