// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Properties;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class JobHostContextFactory : IJobHostContextFactory
    {
        private readonly IFunctionExecutor _functionExecutor;
        private readonly IFunctionIndexProvider _functionIndexProvider;
        private readonly ITriggerBindingProvider _triggerBindingProvider;
        private readonly SingletonManager _singletonManager;
        private readonly IJobActivator _activator;
        private readonly IHostIdProvider _hostIdProvider;
        private readonly INameResolver _nameResolver;
        private readonly IExtensionRegistry _extensions;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueHandler _sharedQueueHandler;
        private readonly IOptions<JobHostOptions> _jobHostOptions;
        private readonly IHostInstanceLogger _hostInstanceLogger;
        private readonly IFunctionInstanceLogger _functionInstanceLogger;
        private readonly IFunctionOutputLogger _functionOutputLogger;
        private readonly IConverterManager _converterManager;
        private readonly IAsyncCollector<FunctionInstanceLogEntry> _eventCollector;
        private readonly IDashboardLoggingSetup _dashboardLoggingSetup;
        private readonly IScaleMonitorManager _monitorManager;
        private readonly IDrainModeManager _drainModeManager;

        public JobHostContextFactory(
            IDashboardLoggingSetup dashboardLoggingSetup,
            IFunctionExecutor functionExecutor,
            IFunctionIndexProvider functionIndexProvider,
            ITriggerBindingProvider triggerBindingProvider,
            SingletonManager singletonManager,
            IJobActivator activator,
            IHostIdProvider hostIdProvider,
            INameResolver nameResolver,
            IExtensionRegistry extensions,
            ILoggerFactory loggerFactory,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueHandler sharedQueueHandler,
            IOptions<JobHostOptions> jobHostOptions,            
            IHostInstanceLogger hostInstanceLogger,
            IFunctionInstanceLogger functionInstanceLogger,
            IFunctionOutputLogger functionOutputLogger,
            IConverterManager converterManager,
            IAsyncCollector<FunctionInstanceLogEntry> eventCollector,
            IScaleMonitorManager monitorManager,
            IDrainModeManager drainModeManager)
        {
            _dashboardLoggingSetup = dashboardLoggingSetup;
            _functionExecutor = functionExecutor;
            _functionIndexProvider = functionIndexProvider;
            _triggerBindingProvider = triggerBindingProvider;
            _singletonManager = singletonManager;
            _activator = activator;
            _hostIdProvider = hostIdProvider;
            _nameResolver = nameResolver;
            _extensions = extensions;
            _loggerFactory = loggerFactory;
            _exceptionHandler = exceptionHandler;
            _sharedQueueHandler = sharedQueueHandler;
            _jobHostOptions = jobHostOptions;
            _hostInstanceLogger = hostInstanceLogger;
            _functionInstanceLogger = functionInstanceLogger;
            _functionOutputLogger = functionOutputLogger;
            _converterManager = converterManager;
            _eventCollector = eventCollector;
            _monitorManager = monitorManager;
            _drainModeManager = drainModeManager;
        }

        public async Task<JobHostContext> Create(JobHost host, CancellationToken shutdownToken, CancellationToken cancellationToken)
        {
            using (CancellationTokenSource combinedCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, shutdownToken))
            {
                CancellationToken combinedCancellationToken = combinedCancellationSource.Token;

                await WriteSiteExtensionManifestAsync(combinedCancellationToken);
                                
                // TODO: FACAVAL: Chat with Brettsam, this should probably be moved out of here.
                _loggerFactory.AddProvider(new FunctionOutputLoggerProvider());

                IFunctionIndex functions = await _functionIndexProvider.GetAsync(combinedCancellationToken);

                Action listenersCreatedCallback = () =>
                {
                    // only trigger HostInitialized after all listeners are created (but before
                    // they are started).
                    host.OnHostInitialized();
                };
                IListenerFactory functionsListenerFactory = new HostListenerFactory(functions.ReadAll(), _singletonManager, _activator, _nameResolver, _loggerFactory, _monitorManager, listenersCreatedCallback, _jobHostOptions.Value.AllowPartialHostStartup, _drainModeManager);

                string hostId = await _hostIdProvider.GetHostIdAsync(cancellationToken);
                bool dashboardLoggingEnabled = _dashboardLoggingSetup.Setup(functions, functionsListenerFactory, out IFunctionExecutor hostCallExecutor,
                    out IListener listener, out HostOutputMessage hostOutputMessage, hostId, shutdownToken);
                if (dashboardLoggingEnabled)
                { 
                    // Publish this to Azure logging account so that a web dashboard can see it. 
                    await LogHostStartedAsync(functions, hostOutputMessage, _hostInstanceLogger, combinedCancellationToken);
                }

                if (_functionExecutor is FunctionExecutor executor)
                {
                    executor.HostOutputMessage = hostOutputMessage;
                }

                IEnumerable<FunctionDescriptor> descriptors = functions.ReadAllDescriptors();
                int descriptorsCount = descriptors.Count();

                ILogger startupLogger = _loggerFactory?.CreateLogger(LogCategories.Startup);

                if (_jobHostOptions.Value.UsingDevelopmentSettings)
                {
                    startupLogger?.LogDebug("Development settings applied");
                }

                if (descriptorsCount == 0)
                {
                    startupLogger?.LogWarning($"No job functions found. Try making your job classes and methods public. {Resource.ExtensionInitializationMessage}");
                }
                else
                {
                    StringBuilder functionsTrace = new StringBuilder();
                    functionsTrace.AppendLine("Found the following functions:");

                    foreach (FunctionDescriptor descriptor in descriptors)
                    {
                        functionsTrace.AppendLine(descriptor.FullName);
                    }
                    string msg = functionsTrace.ToString();
                    startupLogger?.LogInformation(msg);
                }

                return new JobHostContext(
                    functions,
                    hostCallExecutor,
                    listener,
                    _eventCollector,
                    _loggerFactory);
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        internal static IListener CreateHostListener(IListenerFactory allFunctionsListenerFactory, SharedQueueHandler sharedQueue,
            IRecurrentCommand heartbeatCommand, IWebJobsExceptionHandler exceptionHandler, CancellationToken shutdownToken)
        {
            IListener factoryListener = new ListenerFactoryListener(allFunctionsListenerFactory, sharedQueue);
            IListener heartbeatListener = new HeartbeatListener(heartbeatCommand, exceptionHandler, factoryListener);
            IListener shutdownListener = new ShutdownListener(shutdownToken, heartbeatListener);
            return shutdownListener;
        }

        private static Task LogHostStartedAsync(IFunctionIndex functionIndex, HostOutputMessage hostOutputMessage,
           IHostInstanceLogger logger, CancellationToken cancellationToken)
        {
            IEnumerable<FunctionDescriptor> functions = functionIndex.ReadAllDescriptors();

            HostStartedMessage message = new HostStartedMessage
            {
                HostInstanceId = hostOutputMessage.HostInstanceId,
                HostDisplayName = hostOutputMessage.HostDisplayName,
                SharedQueueName = hostOutputMessage.SharedQueueName,
                InstanceQueueName = hostOutputMessage.InstanceQueueName,
                Heartbeat = hostOutputMessage.Heartbeat,
                WebJobRunIdentifier = hostOutputMessage.WebJobRunIdentifier,
                Functions = functions
            };

            return logger.LogHostStartedAsync(message, cancellationToken);
        }

        internal static Assembly GetHostAssembly(IEnumerable<MethodInfo> methods)
        {
            // 1. Try to get the assembly name from the first method.
            MethodInfo firstMethod = methods.FirstOrDefault();

            if (firstMethod != null)
            {
                return firstMethod.DeclaringType.Assembly;
            }

            // 2. If there are no function definitions, try to use the entry assembly.
            Assembly entryAssembly = Assembly.GetEntryAssembly();

            if (entryAssembly != null)
            {
                return entryAssembly;
            }

            // 3. If there's no entry assembly either, we don't have anything to use.
            return null;
        }

        private static async Task WriteSiteExtensionManifestAsync(CancellationToken cancellationToken)
        {
            string jobDataPath = Environment.GetEnvironmentVariable(WebSitesKnownKeyNames.JobDataPath);
            if (jobDataPath == null)
            {
                // we're not in Azure Web Sites, bye bye.
                return;
            }

            const string Filename = "WebJobsSdk.marker";
            var path = Path.Combine(jobDataPath, Filename);
            const int DefaultBufferSize = 4096;

            try
            {
                using (Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, DefaultBufferSize, useAsync: true))
                using (TextWriter writer = new StreamWriter(stream))
                {
                    // content is not really important, this would help debugging though
                    cancellationToken.ThrowIfCancellationRequested();
                    await writer.WriteAsync(DateTime.UtcNow.ToString("s") + "Z");
                    await writer.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException || ex is IOException)
                {
                    // simultaneous access error or an error caused by some other issue
                    // ignore it and skip marker creation
                }
                else
                {
                    throw;
                }
            }
        }

        internal static IFunctionExecutor CreateHostCallExecutor(IListenerFactory instanceQueueListenerFactory,
            IRecurrentCommand heartbeatCommand, IWebJobsExceptionHandler exceptionHandler,
            CancellationToken shutdownToken, IFunctionExecutor innerExecutor)
        {
            IFunctionExecutor heartbeatExecutor = new HeartbeatFunctionExecutor(heartbeatCommand,
                exceptionHandler, innerExecutor);
            IFunctionExecutor abortListenerExecutor = new AbortListenerFunctionExecutor(instanceQueueListenerFactory, heartbeatExecutor);
            IFunctionExecutor shutdownFunctionExecutor = new ShutdownFunctionExecutor(shutdownToken, abortListenerExecutor);
            return shutdownFunctionExecutor;
        }

        internal class DataOnlyHostOutputMessage : HostOutputMessage
        {
            internal override void AddMetadata(IDictionary<string, string> metadata)
            {
                throw new NotSupportedException();
            }
        }
    }
}