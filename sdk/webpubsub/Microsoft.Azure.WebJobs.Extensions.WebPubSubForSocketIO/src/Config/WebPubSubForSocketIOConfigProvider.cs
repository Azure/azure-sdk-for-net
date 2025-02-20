// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Config;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    [Extension("SocketIO", "socketio")]
    internal class WebPubSubForSocketIOConfigProvider : IExtensionConfigProvider, IAsyncConverter<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;
        private readonly ILogger _logger;
        private readonly SocketIOFunctionsOptions _options;
        private readonly IWebPubSubForSocketIOTriggerDispatcher _dispatcher;
        private readonly SocketLifetimeStore _socketLifetimeStore;
        private readonly AzureComponentFactory _componentFactory;

        public WebPubSubForSocketIOConfigProvider(
            IOptions<SocketIOFunctionsOptions> options,
            INameResolver nameResolver,
            AzureComponentFactory componentFactory,
            ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _options = options.Value;
            _logger = loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("WebPubSubForSocketIO"));
            _nameResolver = nameResolver;
            _componentFactory = componentFactory;
            _configuration = configuration;
            _dispatcher = new WebPubSubForSocketIOTriggerDispatcher(_logger, _options);
            _socketLifetimeStore = new SocketLifetimeStore();
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(_options.ConnectionString))
            {
                _options.ConnectionString = _nameResolver.ResolveWholeString(Constants.SocketIOConnectionStringName);
            }

            _options.DefaultConnectionInfo = ResolveConnectionInfo(_options.ConnectionString);

            if (string.IsNullOrEmpty(_options.Hub))
            {
                _options.Hub = _nameResolver.Resolve(Constants.HubNameStringName);
            }

            Exception webhookException = null;
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete preview
                var url = context.GetWebhookHandler();
#pragma warning restore CS0618 // Type or member is obsolete preview
                _logger.LogInformation($"Registered Web PubSub for Socket.IO negotiate Endpoint = {url?.GetLeftPart(UriPartial.Path)}");
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
                .AddConverter<SocketIONegotiationResult, JObject>(JObject.FromObject)
                .AddConverter<JObject, SocketIOAction>(ConvertToSocketIOAction)
                .AddConverter<JArray, SocketIOAction[]>(ConvertToSocketIOActionArray);

            // Trigger binding
            context.AddBindingRule<SocketIOTriggerAttribute>()
                .BindToTrigger(new WebPubSubForSocketIOTriggerBindingProvider(_dispatcher, _nameResolver, _options, webhookException));

            // Input binding -- For negotiation token
            var socketIONegotiationAttributeRule = context.AddBindingRule<SocketIONegotiationAttribute>();
            socketIONegotiationAttributeRule.AddValidator(ValidateSocketIOConnectionAttributeBinding);
            socketIONegotiationAttributeRule.BindToInput(GetNegotiationResult);

            // Output binding
            var socketIOAttributeRule = context.AddBindingRule<SocketIOAttribute>();
            socketIOAttributeRule.AddValidator(ValidateSocketIOAttributeBinding);
            socketIOAttributeRule.BindToCollector(CreateCollector);

            _logger.LogInformation("Azure Web PubSub for Socket.IO binding initialized");
        }

        public Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            return _dispatcher.ExecuteAsync(input, cancellationToken);
        }

        private void ValidateSocketIOConnectionAttributeBinding(SocketIONegotiationAttribute attribute, Type type)
        {
            ValidateConnectionString(
                attribute.Connection,
                $"{nameof(SocketIONegotiationAttribute)}.{nameof(SocketIONegotiationAttribute.Connection)}");
        }

        private void ValidateSocketIOAttributeBinding(SocketIOAttribute attribute, Type type)
        {
            ValidateConnectionString(
                attribute.Connection,
                $"{nameof(SocketIOAttribute)}.{nameof(SocketIOAttribute.Connection)}");
        }

        internal WebPubSubForSocketIOService GetService(SocketIOAttribute attribute)
        {
            return GetService(attribute.Connection, attribute.Hub);
        }

        internal WebPubSubForSocketIOService GetService(string connection, string hubName)
        {
            var connectionFromConfig = _nameResolver.ResolveWholeString(connection);
            var connectionString = Utilities.FirstOrDefault(connectionFromConfig, _options.ConnectionString);

            var info = ResolveConnectionInfo(connectionString);
            hubName = Utilities.FirstOrDefault(hubName, _options.Hub);
            if (string.IsNullOrEmpty(hubName))
            {
                throw new ArgumentNullException($"Unable to resolve the value for property \"Hub\". Make sure the setting exists and has a valid value.");
            }

            if (info.KeyCredential != null)
            {
                return new WebPubSubForSocketIOService(info.Endpoint, info.KeyCredential, hubName);
            }
            else
            {
                return new WebPubSubForSocketIOService(info.Endpoint, info.TokenCredential, hubName);
            }
        }

        private SocketIOConnectionInfo ResolveConnectionInfo(string connection)
        {
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSection(connection);
            if (!connectionSection.Exists())
            {
                // Not found
                throw new InvalidOperationException($"SocketIO connection string '{connection}' does not exist. " +
                                                    $"Please set either '{connection}' to use access key based connection. " +
                                                    $"Or set `{connection}:credential`, `{connection}:clientId` and `{connection}:endpoint` to use identity-based connection. " +
                                                    $"See https://learn.microsoft.com/azure/azure-functions/functions-reference#common-properties-for-identity-based-connections for more details.");
            }
            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return new SocketIOConnectionInfo(connectionSection.Value);
            }

            var endpoint = connectionSection["endpoint"];
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new InvalidOperationException($"SocketIO connection should have an '{connection}:endpoint' propert when it uses identity-based authentication, or it should set `{connection}` setting to use access key based authentication.");
            }

            var credential = _componentFactory.CreateTokenCredential(connectionSection);
            return new SocketIOConnectionInfo(endpoint, credential);
        }

        private IAsyncCollector<SocketIOAction> CreateCollector(SocketIOAttribute attribute)
        {
            return new WebPubSubForSocketIOAsyncCollector(GetService(attribute), _socketLifetimeStore);
        }

        private SocketIONegotiationResult GetNegotiationResult(SocketIONegotiationAttribute attribute)
        {
            var service = GetService(attribute.Connection, attribute.Hub);
            return service.GetNegotiationResult(attribute.UserId);
        }

        private void ValidateConnectionString(string attributeConnectionString, string attributeConnectionStringName)
        {
            var connectionString = Utilities.FirstOrDefault(attributeConnectionString, _options.ConnectionString);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"The Service connection string must be set either via an '{Constants.SocketIOConnectionStringName}' app setting, via an '{Constants.SocketIOConnectionStringName}' environment variable, or directly in code via {nameof(SocketIOFunctionsOptions)}.{nameof(SocketIOFunctionsOptions.ConnectionString)} or {attributeConnectionStringName}.");
            }
        }

        internal static void RegisterJsonConverter()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new BinaryDataJsonConverter(),
                },
            };
        }

        internal static SocketIOAction ConvertToSocketIOAction(JObject input)
        {
            if (input.TryGetValue("actionName", StringComparison.OrdinalIgnoreCase, out var kind))
            {
                var opeartions = typeof(SocketIOAction).Assembly.GetTypes().Where(t => t.BaseType == typeof(SocketIOAction));
                foreach (var item in opeartions)
                {
                    if (TryToWebPubSubOperation(input, kind.ToString() + "Action", item, out var operation))
                    {
                        return operation;
                    }
                }
            }
            throw new ArgumentException($"Not supported SocketIOAction: {kind}.");
        }

        internal static SocketIOAction[] ConvertToSocketIOActionArray(JArray input)
        {
            var result = new List<SocketIOAction>();
            foreach (var item in input)
            {
                result.Add(ConvertToSocketIOAction((JObject)item));
            }
            return result.ToArray();
        }

        private static bool TryToWebPubSubOperation(JObject input, string actionName, Type operationType, out SocketIOAction operation)
        {
            if (actionName.Equals(operationType.Name, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    operation = input.ToObject(operationType) as SocketIOAction;
                    return true;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Failed to convert to {operationType.Name}.", ex);
                }
            }
            operation = null;
            return false;
        }
    }
}
