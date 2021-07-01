﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.ServiceBus.Config
{
    /// <summary>
    /// Extension configuration provider used to register ServiceBus triggers and binders
    /// </summary>
    [Extension("ServiceBus")]
    internal class ServiceBusExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ServiceBusOptions _options;
        private readonly MessagingProvider _messagingProvider;
        private readonly IConverterManager _converterManager;
        private readonly ServiceBusClientFactory _clientFactory;

        /// <summary>
        /// Creates a new <see cref="ServiceBusExtensionConfigProvider"/> instance.
        /// </summary>
        ///// <param name="options">The <see cref="ServiceBusOptions"></see> to use./></param>
        public ServiceBusExtensionConfigProvider(
            IOptions<ServiceBusOptions> options,
            MessagingProvider messagingProvider,
            INameResolver nameResolver,
            ILoggerFactory loggerFactory,
            IConverterManager converterManager,
            ServiceBusClientFactory clientFactory)
        {
            _options = options.Value;
            _messagingProvider = messagingProvider;
            _nameResolver = nameResolver;
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
            _converterManager = converterManager;
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets the <see cref="ServiceBusOptions"/>
        /// </summary>
        public ServiceBusOptions Options
        {
            get
            {
                return _options;
            }
        }

        /// <inheritdoc />
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Set the default exception handler for background exceptions
            // coming from MessageReceivers.
            Options.ExceptionHandler = (e) =>
            {
                LogExceptionReceivedEvent(e, _loggerFactory);
                return Task.CompletedTask;
            };

            context
                .AddConverter(new MessageToStringConverter())
                .AddConverter(new MessageToByteArrayConverter())
                .AddOpenConverter<ServiceBusReceivedMessage, OpenType.Poco>(typeof(MessageToPocoConverter<>), _options.JsonSerializerSettings);

            // register our trigger binding provider
            ServiceBusTriggerAttributeBindingProvider triggerBindingProvider = new ServiceBusTriggerAttributeBindingProvider(_nameResolver, _options, _messagingProvider, _loggerFactory, _converterManager, _clientFactory);
            context.AddBindingRule<ServiceBusTriggerAttribute>()
                .BindToTrigger(triggerBindingProvider);

            // register our binding provider
            ServiceBusAttributeBindingProvider bindingProvider = new ServiceBusAttributeBindingProvider(_nameResolver, _messagingProvider, _clientFactory);
            context.AddBindingRule<ServiceBusAttribute>().Bind(bindingProvider);
        }

        internal static void LogExceptionReceivedEvent(ProcessErrorEventArgs e, ILoggerFactory loggerFactory)
        {
            try
            {
                var errorSource = e.ErrorSource;
                var logger = loggerFactory?.CreateLogger(LogCategories.Executor);
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
