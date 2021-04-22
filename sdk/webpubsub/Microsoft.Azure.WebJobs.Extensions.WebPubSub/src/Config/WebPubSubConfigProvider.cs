// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

#pragma warning disable CS0618 // Type or member is obsolete
            var url = context.GetWebhookHandler();
#pragma warning restore CS0618 // Type or member is obsolete
            _logger.LogInformation($"Registered Web PubSub negotiate Endpoint = {url?.GetLeftPart(UriPartial.Path)}");

            // bindings
            context
                .AddConverter<WebPubSubConnection, JObject>(JObject.FromObject)
                .AddConverter<JObject, WebPubSubEvent>(ConvertFromJObject<WebPubSubEvent>)
                .AddConverter<JObject, WebPubSubEvent[]>(ConvertFromJObject<WebPubSubEvent[]>);

            // Trigger binding
            context.AddBindingRule<WebPubSubTriggerAttribute>()
                .BindToTrigger(new WebPubSubTriggerBindingProvider(_dispatcher, _options));

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

        private IAsyncCollector<WebPubSubEvent> CreateCollector(WebPubSubAttribute attribute)
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

        private static T ConvertFromJObject<T>(JObject input)
        {
            return input.ToObject<T>();
        }
    }
}
