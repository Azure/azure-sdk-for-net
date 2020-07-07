// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Cancellation;
using Microsoft.Azure.WebJobs.Host.Bindings.Data;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Hosting;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.Azure.WebJobs
{
    public static class WebJobsBuilderExtensions
    {
        private static readonly IDictionary<Type, object> _startupTypeMap = new Dictionary<Type, object>();

        public static IWebJobsExtensionBuilder AddExtension<TExtension>(this IWebJobsBuilder builder)
          where TExtension : class, IExtensionConfigProvider
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IExtensionConfigProvider, TExtension>());

            return new WebJobsExtensionBuilder(builder.Services, ExtensionInfo.FromExtension<TExtension>());
        }

        public static IWebJobsExtensionBuilder AddExtension(this IWebJobsBuilder builder, IExtensionConfigProvider instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IExtensionConfigProvider>(instance));

            return new WebJobsExtensionBuilder(builder.Services, ExtensionInfo.FromInstance(instance));
        }

        public static IWebJobsBuilder AddExtension(this IWebJobsBuilder builder, Type extensionConfigProviderType)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IExtensionConfigProvider), extensionConfigProviderType));

            return builder;
        }

        public static IWebJobsBuilder UseHostId(this IWebJobsBuilder builder, string hostId)
        {
            if (!HostIdValidator.IsValid(hostId))
            {
                throw new InvalidOperationException(HostIdValidator.ValidationMessage);
            }

            builder.Services.AddSingleton<IHostIdProvider>(new FixedHostIdProvider(hostId));

            return builder;
        }

        public static IWebJobsBuilder UseWebJobsStartup<T>(this IWebJobsBuilder builder) where T : IWebJobsStartup, new()
        {
            return builder.UseWebJobsStartup<T>(NullLoggerFactory.Instance);
        }

        public static IWebJobsBuilder UseWebJobsStartup<T>(this IWebJobsBuilder builder, ILoggerFactory loggerFactory) where T : IWebJobsStartup, new()
        {
            return builder.UseWebJobsStartup(typeof(T), loggerFactory);
        }

        public static IWebJobsBuilder UseWebJobsStartup(this IWebJobsBuilder builder, Type startupType)
        {
            return builder.UseWebJobsStartup(startupType, NullLoggerFactory.Instance);
        }

        public static IWebJobsBuilder UseWebJobsStartup(this IWebJobsBuilder builder, Type startupType, ILoggerFactory loggerFactory)
        {
            return UseWebJobsStartup(builder, startupType, null, loggerFactory);
        }

        public static IWebJobsBuilder UseWebJobsStartup(this IWebJobsBuilder builder, Type startupType, WebJobsBuilderContext context, ILoggerFactory loggerFactory)
        {
            if (!typeof(IWebJobsStartup).IsAssignableFrom(startupType))
            {
                throw new ArgumentException($"The {nameof(startupType)} argument must be an implementation of {typeof(IWebJobsStartup).FullName}");
            }

            IWebJobsStartup startup;

            // Use the existing instance if it's already been created
            if (_startupTypeMap.TryGetValue(startupType, out object startupObject))
            {
                startup = (IWebJobsStartup)startupObject;

                // We no longer need this.
                _startupTypeMap.Remove(startupType);
            }
            else
            {
                startup = (IWebJobsStartup)Activator.CreateInstance(startupType);
            }

            if (loggerFactory == NullLoggerFactory.Instance)
            {
                ConfigureStartup(startup, context, builder);
            }
            else
            {
                ConfigureAndLogUserConfiguredServices(startup, context, builder, loggerFactory);
            }

            return builder;
        }

        private static void ConfigureAndLogUserConfiguredServices(IWebJobsStartup startup, WebJobsBuilderContext context, IWebJobsBuilder builder, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<TrackedServiceCollection>();

            if (builder.Services is ITrackedServiceCollection tracker)
            {
                if (tracker != null)
                {
                    tracker.ResetTracking();
                    ConfigureStartup(startup, context, builder);
                    StringBuilder sb = new StringBuilder("Services registered by external startup type " + startup.GetType().ToString() + ":");

                    foreach (ServiceDescriptor service in tracker.TrackedCollectionChanges)
                    {
                        sb.AppendLine();
                        sb.Append($" {service.ServiceType.FullName}: ");

                        if (service.ImplementationType != null)
                        {
                            sb.Append($"Implementation: {service.ImplementationType.FullName}");
                        }
                        else if (service.ImplementationInstance != null)
                        {
                            sb.Append($"Instance: {service.ImplementationInstance.GetType().FullName}");
                        }
                        else if (service.ImplementationFactory != null)
                        {
                            sb.Append("Factory");
                        }

                        sb.Append($", Lifetime: {service.Lifetime.ToString()}");
                    }
                    logger.LogDebug(new EventId(500, "ExternalStartupServices"), sb.ToString());
                }
            }
        }

        private static void ConfigureStartup(IWebJobsStartup startup, WebJobsBuilderContext context, IWebJobsBuilder builder)
        {
            if (startup is IWebJobsStartup2 startup2)
            {
                startup2.Configure(context, builder);
            }
            else
            {
                startup.Configure(builder);
            }
        }

        /// <summary>
        /// Enables use of external configuration providers, allowing them to inject services and update
        /// configuration during the host initialization process.
        /// Type discovery is performed using the <see cref="DefaultStartupTypeLocator"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> instance to configure.</param>
        /// <returns>The updated <see cref="IHostBuilder"/> instance.</returns>
        public static IWebJobsBuilder UseExternalStartup(this IWebJobsBuilder builder)
        {
            return builder.UseExternalStartup(new DefaultStartupTypeLocator(), NullLoggerFactory.Instance);
        }


        public static IWebJobsBuilder UseExternalStartup(this IWebJobsBuilder builder, ILoggerFactory loggerFactory)
        {
            return builder.UseExternalStartup(new DefaultStartupTypeLocator(), loggerFactory);
        }

        public static IWebJobsBuilder UseExternalStartup(this IWebJobsBuilder builder, IWebJobsStartupTypeLocator startupTypeLocator)
        {
            return builder.UseExternalStartup(startupTypeLocator, NullLoggerFactory.Instance);
        }

        /// <summary>
        /// Enables use of external configuration providers, allowing them to inject services and update
        /// configuration during the host initialization process.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> instance to configure.</param>
        /// <param name="startupTypeLocator">An implementation of <see cref="IWebJobsStartupTypeLocator"/> that provides a list of types that 
        /// should be used in the startup process.</param>
        /// <returns>The updated <see cref="IHostBuilder"/> instance.</returns>
        public static IWebJobsBuilder UseExternalStartup(this IWebJobsBuilder builder, IWebJobsStartupTypeLocator startupTypeLocator, ILoggerFactory loggerFactory)
        {
            return UseExternalStartup(builder, startupTypeLocator, null, loggerFactory);
        }

        public static IWebJobsBuilder UseExternalStartup(this IWebJobsBuilder builder, IWebJobsStartupTypeLocator startupTypeLocator, WebJobsBuilderContext context, ILoggerFactory loggerFactory)
        {
            IEnumerable<Type> types = startupTypeLocator.GetStartupTypes()
                .Where(t => typeof(IWebJobsStartup).IsAssignableFrom(t));

            foreach (var type in types)
            {
                builder.UseWebJobsStartup(type, context, loggerFactory);
            }

            return builder;
        }

        // This is an alternative to AddDashboardLogging
        public static IWebJobsBuilder AddTableLogging(this IWebJobsBuilder builder, IEventCollectorFactory eventCollectorFactory)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (eventCollectorFactory == null)
            {
                throw new ArgumentNullException(nameof(eventCollectorFactory));
            }

            builder.Services.AddSingleton<IFunctionOutputLoggerProvider, FastTableLoggerProvider>();
            builder.Services.AddSingleton<IFunctionOutputLogger, FastTableLoggerProvider>();

            builder.Services.AddSingleton(eventCollectorFactory);
            return builder;
        }

        /// <summary>
        /// Adds the ability to bind to an <see cref="ExecutionContext"/> from a WebJobs function.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        /// <param name="configure">An optional <see cref="Action{ExecutionContextBindingOptions}"/> to configure the provided <see cref="ExecutionContextOptions"/>.</param>
        /// <returns></returns>
        public static IWebJobsBuilder AddExecutionContextBinding(this IWebJobsBuilder builder, Action<ExecutionContextOptions> configure = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddSingleton<IBindingProvider, ExecutionContextBindingProvider>();

            if (configure != null)
            {
                builder.Services.Configure(configure);
            }

            return builder;
        }

        /// <summary>
        /// Adds builtin bindings 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebJobsBuilder AddBuiltInBindings(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // for typeof(CancellationToken)
            builder.Services.AddSingleton<IBindingProvider, CancellationTokenBindingProvider>();

            // The TraceWriter binder handles all remaining TraceWriter/TextWriter parameters. It must come after the
            // Blob binding provider; otherwise bindings like Do([Blob("a/b")] TextWriter blob) wouldn't work.
            // for typeof(TraceWriter), typeof(TextWriter)
            builder.Services.AddSingleton<IBindingProvider, TraceWriterBindingProvider>();

            // for typeof(ILogger)
            builder.Services.AddSingleton<IBindingProvider, ILoggerBindingProvider>();

            // arbitrary binding to binding data 
            builder.Services.AddSingleton<IBindingProvider, DataBindingProvider>();

            return builder;
        }

        public static IWebJobsConfigurationBuilder UseWebJobsConfigurationStartup<T>(this IWebJobsConfigurationBuilder builder, WebJobsBuilderContext context = null) where T : IWebJobsConfigurationStartup, new()
        {
            return builder.UseWebJobsConfigurationStartup<T>(context, NullLoggerFactory.Instance);
        }

        public static IWebJobsConfigurationBuilder UseWebJobsConfigurationStartup<T>(this IWebJobsConfigurationBuilder builder, WebJobsBuilderContext context, ILoggerFactory loggerFactory) where T : IWebJobsConfigurationStartup, new()
        {
            return builder.UseWebJobsConfigurationStartup(typeof(T), context, loggerFactory);
        }

        public static IWebJobsConfigurationBuilder UseWebJobsConfigurationStartup(this IWebJobsConfigurationBuilder builder, Type startupType, WebJobsBuilderContext context = null)
        {
            return builder.UseWebJobsConfigurationStartup(startupType, context, NullLoggerFactory.Instance);
        }

        public static IWebJobsConfigurationBuilder UseWebJobsConfigurationStartup(this IWebJobsConfigurationBuilder builder, Type startupType, WebJobsBuilderContext context, ILoggerFactory loggerFactory)
        {
            if (!typeof(IWebJobsConfigurationStartup).IsAssignableFrom(startupType))
            {
                throw new ArgumentException($"The {nameof(startupType)} argument must be an implementation of {typeof(IWebJobsConfigurationStartup).FullName}");
            }

            var startup = (IWebJobsConfigurationStartup)Activator.CreateInstance(startupType);

            // Store this if it's needed for IWebJobsStartup as well. This will always be called before UseWebJobsStartup()
            if (typeof(IWebJobsStartup).IsAssignableFrom(startupType))
            {
                _startupTypeMap[startupType] = startup;
            }

            if (loggerFactory == NullLoggerFactory.Instance)
            {
                startup.Configure(context, builder);
            }
            else
            {
                ConfigureAndLogUserConfigurationProviders(startup, context, builder, loggerFactory);
            }

            return builder;
        }

        private static void ConfigureAndLogUserConfigurationProviders(IWebJobsConfigurationStartup startup, WebJobsBuilderContext context, IWebJobsConfigurationBuilder builder, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<TrackedConfigurationBuilder>();

            if (builder.ConfigurationBuilder is ITrackedConfigurationBuilder tracker)
            {
                if (tracker != null)
                {
                    tracker.ResetTracking();
                    startup.Configure(context, builder);
                    StringBuilder sb = new StringBuilder($"{nameof(IConfigurationSource)}s registered by external startup type " + startup.GetType().ToString() + ":");

                    foreach (IConfigurationSource source in tracker.TrackedConfigurationSources)
                    {
                        sb.AppendLine();
                        sb.Append($" {source.GetType().FullName}");
                    }
                    logger.LogDebug(new EventId(600, "ExternalConfigurationProviders"), sb.ToString());
                }
            }
        }

        public static IWebJobsConfigurationBuilder UseExternalConfigurationStartup(this IWebJobsConfigurationBuilder builder, WebJobsBuilderContext context)
        {
            return builder.UseExternalConfigurationStartup(new DefaultStartupTypeLocator(), context, NullLoggerFactory.Instance);
        }

        public static IWebJobsConfigurationBuilder UseExternalConfigurationStartup(this IWebJobsConfigurationBuilder builder, IWebJobsStartupTypeLocator startupTypeLocator, WebJobsBuilderContext context, ILoggerFactory loggerFactory)
        {
            IEnumerable<Type> types = startupTypeLocator.GetStartupTypes()
                .Where(t => typeof(IWebJobsConfigurationStartup).IsAssignableFrom(t));

            foreach (var type in types)
            {
                builder.UseWebJobsConfigurationStartup(type, context, loggerFactory);
            }

            return builder;
        }
    }
}