// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Logging;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class ServiceBusTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly ServiceBusOptions _options;
        private readonly MessagingProvider _messagingProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConverterManager _converterManager;
        private readonly ServiceBusClientFactory _clientFactory;
        private readonly ILogger<ServiceBusTriggerAttributeBindingProvider> _logger;
        private readonly ConcurrencyManager _concurrencyManager;

        public ServiceBusTriggerAttributeBindingProvider(
            INameResolver nameResolver,
            ServiceBusOptions options,
            MessagingProvider messagingProvider,
            ILoggerFactory loggerFactory,
            IConverterManager converterManager,
            ServiceBusClientFactory clientFactory,
            ConcurrencyManager concurrencyManager)
        {
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _messagingProvider = messagingProvider ?? throw new ArgumentNullException(nameof(messagingProvider));
            _loggerFactory = loggerFactory;
            _converterManager = converterManager;
            _clientFactory = clientFactory;
            _logger = _loggerFactory.CreateLogger<ServiceBusTriggerAttributeBindingProvider>();
            _concurrencyManager = concurrencyManager;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;
            var attribute = TypeUtility.GetResolvedAttribute<ServiceBusTriggerAttribute>(parameter);

            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            attribute.Connection = _nameResolver.ResolveWholeString(attribute.Connection);
            string entityPath;
            ServiceBusEntityType serviceBusEntityType;
            if (attribute.QueueName != null)
            {
                var queueName = _nameResolver.ResolveWholeString(attribute.QueueName);
                entityPath = queueName;
                serviceBusEntityType = ServiceBusEntityType.Queue;
            }
            else
            {
                var topicName = _nameResolver.ResolveWholeString(attribute.TopicName);
                var subscriptionName = _nameResolver.ResolveWholeString(attribute.SubscriptionName);
                entityPath = EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName);
                serviceBusEntityType = ServiceBusEntityType.Topic;
            }

            Func<ListenerFactoryContext, bool, Task<IListener>> createListener =
            (factoryContext, singleDispatch) =>
            {
                // Set the default exception handler for background exceptions
                // if not already set.
                _options.ProcessErrorAsync ??= (e) =>
                {
                    LogExceptionReceivedEvent(e, factoryContext.Descriptor.ShortName, _loggerFactory);
                    return Task.CompletedTask;
                };
                var autoCompleteMessagesOptionEvaluatedValue = GetAutoCompleteMessagesOptionToUse(attribute, factoryContext.Descriptor.ShortName);
                IListener listener = new ServiceBusListener(factoryContext.Descriptor.Id, serviceBusEntityType, entityPath, attribute.IsSessionsEnabled, autoCompleteMessagesOptionEvaluatedValue, factoryContext.Executor, _options, attribute.Connection, _messagingProvider, _loggerFactory, singleDispatch, _clientFactory, _concurrencyManager);

                return Task.FromResult(listener);
            };

#pragma warning disable 618
            ITriggerBinding binding = BindingFactory.GetTriggerBinding(new ServiceBusTriggerBindingStrategy(), parameter, _converterManager, createListener);
#pragma warning restore 618

            return Task.FromResult<ITriggerBinding>(binding);
        }

        /// <summary>
        /// Gets 'AutoCompleteMessages' option value, either from the trigger attribute if it is set or from host options.
        /// </summary>
        /// <param name="attribute">The trigger attribute.</param>
        /// <param name="functionName">The function name.</param>
        private bool GetAutoCompleteMessagesOptionToUse(ServiceBusTriggerAttribute attribute, string functionName)
        {
            if (attribute.IsAutoCompleteMessagesOptionSet)
            {
                _logger.LogInformation($"The 'AutoCompleteMessages' option has been overriden to '{attribute.AutoCompleteMessages}' value for '{functionName}' function.");

                return attribute.AutoCompleteMessages;
            }

            return _options.AutoCompleteMessages;
        }

        internal static void LogExceptionReceivedEvent(ProcessErrorEventArgs e, string functionName, ILoggerFactory loggerFactory)
        {
            try
            {
                var errorSource = e.ErrorSource;
                var logger = loggerFactory?.CreateLogger(LogCategories.CreateFunctionCategory(functionName));
                //TODO new SDK does not expose client ID in event args or on clients
                string message = $"Message processing error (Action={errorSource}, EntityPath={e.EntityPath}, Endpoint={e.FullyQualifiedNamespace})";

                var logLevel = GetLogLevel(e.Exception);
                logger?.Log(logLevel, 0, message, e.Exception, (s, ex) => message);
            }
            catch (Exception)
            {
                // best effort logging
            }
        }

        private static LogLevel GetLogLevel(Exception ex)
        {
            var sbex = ex as ServiceBusException;
            if (!(ex is OperationCanceledException) && (sbex == null || !sbex.IsTransient))
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
    }
}
