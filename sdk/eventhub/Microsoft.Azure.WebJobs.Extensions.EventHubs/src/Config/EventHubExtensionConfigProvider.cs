// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Configuration;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    [Extension("EventHubs", configurationSection: "EventHubs")]
    internal class EventHubExtensionConfigProvider : IExtensionConfigProvider
    {
        private IConfiguration _config;
        private readonly IOptions<EventHubOptions> _options;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConverterManager _converterManager;
        private readonly INameResolver _nameResolver;
        private readonly IWebJobsExtensionConfiguration<EventHubExtensionConfigProvider> _configuration;

        public EventHubExtensionConfigProvider(IConfiguration config, IOptions<EventHubOptions> options, ILoggerFactory loggerFactory,
            IConverterManager converterManager, INameResolver nameResolver, IWebJobsExtensionConfiguration<EventHubExtensionConfigProvider> configuration)
        {
            _config = config;
            _options = options;
            _loggerFactory = loggerFactory;
            _converterManager = converterManager;
            _nameResolver = nameResolver;
            _configuration = configuration;
        }

        internal Action<ExceptionReceivedEventArgs> ExceptionHandler { get; set; }

        private void ExceptionReceivedHandler(ExceptionReceivedEventArgs args)
        {
            ExceptionHandler?.Invoke(args);
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _options.Value.SetExceptionHandler(ExceptionReceivedHandler);
            _configuration.ConfigurationSection.Bind(_options);

            context
                .AddConverter<string, EventData>(ConvertStringToEventData)
                .AddConverter<EventData, string>(ConvertEventDataToString)
                .AddConverter<byte[], EventData>(ConvertBytes2EventData)
                .AddConverter<EventData, byte[]>(ConvertEventDataToBytes)
                .AddOpenConverter<OpenType.Poco, EventData>(ConvertPocoToEventData);

            // register our trigger binding provider
            var triggerBindingProvider = new EventHubTriggerAttributeBindingProvider(_config, _nameResolver, _converterManager, _options, _loggerFactory);
            context.AddBindingRule<EventHubTriggerAttribute>()
                .BindToTrigger(triggerBindingProvider);

            // register our binding provider
            context.AddBindingRule<EventHubAttribute>()
                .BindToCollector(BuildFromAttribute);

            context.AddBindingRule<EventHubAttribute>()
                .BindToInput(attribute =>
            {
                return _options.Value.GetEventHubProducerClient(attribute.EventHubName, attribute.Connection);
            });

            ExceptionHandler = (e =>
            {
                LogExceptionReceivedEvent(e, _loggerFactory);
            });
        }

        internal static void LogExceptionReceivedEvent(ExceptionReceivedEventArgs e, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory?.CreateLogger(LogCategories.Executor);
            string message = $"EventProcessorHost error (Action='{e.Action}', HostName='{e.Hostname}', PartitionId='{e.PartitionId}').";

            Utility.LogException(e.Exception, message, logger);
        }

        private static LogLevel GetLogLevel(Exception ex)
        {
            var ehex = ex as EventHubsException;
            if (!(ex is OperationCanceledException) && (ehex == null || !ehex.IsTransient))
            {
                // any non-transient exceptions or unknown exception types
                // we want to log as errors
                return LogLevel.Error;
            }
            else
            {
                // transient messaging errors we log as info so we have a record
                // of them, but we don't treat them as actual errors
                return LogLevel.Information;
            }
        }

        private IAsyncCollector<EventData> BuildFromAttribute(EventHubAttribute attribute)
        {
            EventHubProducerClient client = _options.Value.GetEventHubProducerClient(attribute.EventHubName, attribute.Connection);
            return new EventHubAsyncCollector(new EventHubProducerClientImpl(client, _loggerFactory));
        }

        private static string ConvertEventDataToString(EventData x)
            => Encoding.UTF8.GetString(ConvertEventDataToBytes(x));

        private static EventData ConvertBytes2EventData(byte[] input)
            => new EventData(input);

        private static byte[] ConvertEventDataToBytes(EventData input)
            => input.Body.ToArray();

        private static EventData ConvertStringToEventData(string input)
            => ConvertBytes2EventData(Encoding.UTF8.GetBytes(input));

        private static Task<object> ConvertPocoToEventData(object arg, Attribute attrResolved, ValueBindingContext context)
        {
            return Task.FromResult<object>(ConvertStringToEventData(JsonConvert.SerializeObject(arg)));
        }
    }
}
