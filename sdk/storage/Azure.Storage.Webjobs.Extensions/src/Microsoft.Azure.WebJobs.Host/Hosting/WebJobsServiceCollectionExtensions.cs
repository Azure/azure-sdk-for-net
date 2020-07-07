// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Configuration;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Hosting;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Extension methods for setting up WebJobs services in a <see cref="IServiceCollection" />.
    /// </summary>
    public static class WebJobsServiceCollectionExtensions
    {
        private const string SingletonConfigSectionName = "Singleton";

        /// <summary>
        /// Adds the WebJobs services to the provided <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IWebJobsBuilder AddWebJobs(this IServiceCollection services, Action<JobHostOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure != null)
            {
                services.Configure(configure);
            }

            // A LOT of the service registrations below need to be cleaned up
            // maintaining some of the existing dependencies and model we previously had, 
            // but this should be reviewed as it can be improved.
            services.TryAddSingleton<IExtensionRegistryFactory, DefaultExtensionRegistryFactory>();
            services.TryAddSingleton<IExtensionRegistry>(p => p.GetRequiredService<IExtensionRegistryFactory>().Create());

            // Type conversion
            services.TryAddSingleton<ITypeLocator, DefaultTypeLocator>();
            services.TryAddSingleton<IConverterManager, ConverterManager>();
            services.TryAddSingleton<IFunctionIndexProvider, FunctionIndexProvider>();
            services.TryAddSingleton<SingletonManager>();
            services.TryAddSingleton<IHostSingletonManager>(provider => provider.GetRequiredService<SingletonManager>());
            services.TryAddSingleton<SharedQueueHandler>();
            services.TryAddSingleton<IFunctionExecutor, FunctionExecutor>();
            services.TryAddSingleton<IDrainModeManager, DrainModeManager>();
            services.TryAddSingleton<IJobHostContextFactory, JobHostContextFactory>();

            services.TryAddSingleton<ILoadBalancerQueue, InMemoryLoadBalancerQueue>();

            // Anybody can add IBindingProvider via DI. 
            // Consume the whole list via a CompositeBindingProvider
            services.TryAddSingleton<CompositeBindingProviderFactory>();
            services.TryAddSingleton<CompositeBindingProvider>(
                p => p.GetRequiredService<CompositeBindingProviderFactory>().Create());

            services.TryAddSingleton<ISharedContextProvider, SharedContextProvider>();

            services.TryAddSingleton<IJobHostMetadataProviderFactory, JobHostMetadataProviderFactory>();
            services.TryAddSingleton<IJobHostMetadataProvider>(p => p.GetService<IJobHostMetadataProviderFactory>().Create());
            services.TryAddSingleton<IHostIdProvider, DefaultHostIdProvider>();
            services.TryAddSingleton<IDashboardLoggingSetup, NullDashboardLoggingSetup>();
            services.TryAddSingleton<IFunctionOutputLogger, NullFunctionOutputLogger>();
            services.TryAddSingleton<IFunctionInstanceLogger, FunctionInstanceLogger>();
            services.TryAddSingleton<IHostInstanceLogger, NullHostInstanceLogger>();
            services.TryAddSingleton<IDistributedLockManager, InMemoryDistributedLockManager>();
            services.TryAddSingleton<IScaleMonitorManager, ScaleMonitorManager>();

            // $$$ Can we remove these completely? 
            services.TryAddSingleton<DefaultTriggerBindingFactory>();
            services.TryAddSingleton<ITriggerBindingProvider>(p => p.GetRequiredService<DefaultTriggerBindingFactory>().Create());

            // Exception handler
            services.TryAddSingleton<IWebJobsExceptionHandlerFactory, DefaultWebJobsExceptionHandlerFactory>();
            services.TryAddSingleton<IWebJobsExceptionHandler>(p => p.GetRequiredService<IWebJobsExceptionHandlerFactory>().Create(p.GetRequiredService<IHost>()));

            services.TryAddSingleton<INameResolver, DefaultNameResolver>();
            services.TryAddSingleton<IJobActivator, DefaultJobActivator>();

            // Event collector
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IEventCollectorProvider, FunctionResultAggregatorProvider>());
            services.TryAddSingleton<IEventCollectorFactory, EventCollectorFactory>();
            services.TryAddSingleton<IAsyncCollector<FunctionInstanceLogEntry>>(p => p.GetRequiredService<IEventCollectorFactory>().Create());

            // Core host services
            services.TryAddSingleton<IJobHost, JobHost>();

            // Configuration
            services.AddSingleton(typeof(IWebJobsExtensionConfiguration<>), typeof(WebJobsExtensionConfiguration<>));

            // Options logging
            services.AddTransient(typeof(IOptionsFactory<>), typeof(WebJobsOptionsFactory<>));
            services.AddSingleton<IOptionsLoggingSource, OptionsLoggingSource>();
            services.AddSingleton<IHostedService, OptionsLoggingService>();
            services.AddSingleton<IOptionsFormatter<LoggerFilterOptions>, LoggerFilterOptionsFormatter>();

            services.AddOptions<SingletonOptions>()
                .Configure<IHostingEnvironment>((options, env) =>
                {
                    if (env.IsDevelopment())
                    {
                        options.ListenerLockPeriod = TimeSpan.FromSeconds(15);
                    }
                })
                .Configure<IConfiguration>((options, config) =>
                {
                    var section = config.GetWebJobsRootConfiguration().GetSection(SingletonConfigSectionName);
                    section.Bind(options);
                });

            var builder = new WebJobsBuilder(services);
            builder.AddBuiltInBindings();

            return builder;
        }
    }
}
