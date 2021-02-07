// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
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
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ServiceBusOptions _options;
        private readonly MessagingProvider _messagingProvider;
        private readonly IConverterManager _converterManager;

        /// <summary>
        /// Creates a new <see cref="ServiceBusExtensionConfigProvider"/> instance.
        /// </summary>
        ///// <param name="options">The <see cref="ServiceBusOptions"></see> to use./></param>
        public ServiceBusExtensionConfigProvider(IOptions<ServiceBusOptions> options,
            MessagingProvider messagingProvider,
            INameResolver nameResolver,
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IConverterManager converterManager)
        {
            _options = options.Value;
            _messagingProvider = messagingProvider;
            _nameResolver = nameResolver;
            _configuration = configuration;
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
            _converterManager = converterManager;
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
            };

            context
                .AddConverter<Message, string>(new MessageToStringConverter())
                .AddConverter<Message, byte[]>(new MessageToByteArrayConverter())
                .AddOpenConverter<Message, OpenType.Poco>(typeof(MessageToPocoConverter<>));

            // register our trigger binding provider
            ServiceBusTriggerAttributeBindingProvider triggerBindingProvider = new ServiceBusTriggerAttributeBindingProvider(_nameResolver, _options, _messagingProvider, _configuration, _loggerFactory, _converterManager);
            context.AddBindingRule<ServiceBusTriggerAttribute>()
                .BindToTrigger(triggerBindingProvider);

            // register our binding provider
            ServiceBusAttributeBindingProvider bindingProvider = new ServiceBusAttributeBindingProvider(_nameResolver, _options, _configuration, _messagingProvider);
            context.AddBindingRule<ServiceBusAttribute>().Bind(bindingProvider);
        }

        internal static void LogExceptionReceivedEvent(ExceptionReceivedEventArgs e, ILoggerFactory loggerFactory)
        {
            try
            {
                var ctxt = e.ExceptionReceivedContext;
                var logger = loggerFactory?.CreateLogger(LogCategories.Executor);
                string message = $"Message processing error (Action={ctxt.Action}, ClientId={ctxt.ClientId}, EntityPath={ctxt.EntityPath}, Endpoint={ctxt.Endpoint})";

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
