// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal class HostListenerFactory : IListenerFactory
    {
        private static readonly MethodInfo JobActivatorCreateMethod = typeof(IJobActivator).GetMethod("CreateInstance", BindingFlags.Public | BindingFlags.Instance).GetGenericMethodDefinition();
        private const string IsDisabledFunctionName = "IsDisabled";
        private readonly IEnumerable<IFunctionDefinition> _functionDefinitions;
        private readonly SingletonManager _singletonManager;
        private readonly IJobActivator _activator;
        private readonly INameResolver _nameResolver;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private readonly bool _allowPartialHostStartup;
        private readonly Action _listenersCreatedCallback;
        private readonly IScaleMonitorManager _monitorManager;
        private readonly IDrainModeManager _drainModeManager;


        public HostListenerFactory(IEnumerable<IFunctionDefinition> functionDefinitions, SingletonManager singletonManager, IJobActivator activator,
            INameResolver nameResolver, ILoggerFactory loggerFactory, IScaleMonitorManager monitorManager, Action listenersCreatedCallback, bool allowPartialHostStartup = false, IDrainModeManager drainModeManager = null)
        {
            _functionDefinitions = functionDefinitions;
            _singletonManager = singletonManager;
            _activator = activator;
            _nameResolver = nameResolver;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory?.CreateLogger(LogCategories.Startup);
            _allowPartialHostStartup = allowPartialHostStartup;
            _monitorManager = monitorManager;
            _listenersCreatedCallback = listenersCreatedCallback;
            _drainModeManager = drainModeManager;
        }

        public async Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            List<IListener> listeners = new List<IListener>();

            foreach (IFunctionDefinition functionDefinition in _functionDefinitions)
            {
                // Determine if the function is disabled
                if (functionDefinition.Descriptor.IsDisabled)
                {
                    string msg = string.Format("Function '{0}' is disabled", functionDefinition.Descriptor.ShortName);
                    _logger?.LogInformation(msg);
                    continue;
                }

                IListenerFactory listenerFactory = functionDefinition.ListenerFactory;
                if (listenerFactory == null)
                {
                    continue;
                }

                IListener listener = await listenerFactory.CreateAsync(cancellationToken);

                RegisterScaleMonitor(listener, _monitorManager);

                // if the listener is a Singleton, wrap it with our SingletonListener
                SingletonAttribute singletonAttribute = SingletonManager.GetListenerSingletonOrNull(listener.GetType(), functionDefinition.Descriptor);
                if (singletonAttribute != null)
                {
                    listener = new SingletonListener(functionDefinition.Descriptor, singletonAttribute, _singletonManager, listener, _loggerFactory);
                }

                // wrap the listener with a function listener to handle exceptions
                listener = new FunctionListener(listener, functionDefinition.Descriptor, _loggerFactory, _allowPartialHostStartup);
                listeners.Add(listener);
            }

            _listenersCreatedCallback?.Invoke();

            var compositeListener = new CompositeListener(listeners);
            _drainModeManager?.RegisterListener(compositeListener);
            return compositeListener;
        }

        /// <summary>
        /// Check to see if the specified listener is an <see cref="IScaleMonitor"/> and if so
        /// register it with the <see cref="IScaleMonitorManager"/>.
        /// </summary>
        /// <remarks>
        /// Note that disabled functions won't have their monitors registered. Therefore we'll only be
        /// monitoring valid, non-disabled functions which is what we want.
        /// Similarly, any functions failing indexing won't have their monitors registered.
        /// </remarks>
        /// <param name="listener">The listener to check and register a monitor for.</param>
        /// <param name="monitorManager">The monitor manager to register to.</param>
        internal static void RegisterScaleMonitor(IListener listener, IScaleMonitorManager monitorManager)
        {
            if (listener is IScaleMonitor scaleMonitor)
            {
                monitorManager.Register(scaleMonitor);
            }
            else if (listener is IScaleMonitorProvider)
            {
                var monitor = ((IScaleMonitorProvider)listener).GetMonitor();
                monitorManager.Register(monitor);
            }
            else if (listener is IEnumerable<IListener>)
            {
                // for composite listeners, we need to check all the inner listeners
                foreach (var innerListener in ((IEnumerable<IListener>)listener))
                {
                    RegisterScaleMonitor(innerListener, monitorManager);
                }
            }
        }

        internal static bool IsDisabled(MethodInfo method, INameResolver nameResolver, IJobActivator activator, IConfiguration configuration)
        {
            // First try to resolve disabled state by setting
            string settingName = string.Format(CultureInfo.InvariantCulture, "AzureWebJobs.{0}.Disabled", Utility.GetFunctionName(method));
            // Linux does not support dots in env variable name. So we replace dots with underscores.
            string settingNameLinux = string.Format(CultureInfo.InvariantCulture, "AzureWebJobs_{0}_Disabled", Utility.GetFunctionName(method));
            if (configuration.IsSettingEnabled(settingName) || configuration.IsSettingEnabled(settingNameLinux))
            {
                return true;
            }
            else
            {
                // Second try to resolve disabled state by attribute
                ParameterInfo triggerParameter = method.GetParameters().FirstOrDefault();
                if (triggerParameter != null)
                {
                    // look for the first DisableAttribute up the hierarchy
                    DisableAttribute disableAttribute = TypeUtility.GetHierarchicalAttributeOrNull<DisableAttribute>(triggerParameter);
                    if (disableAttribute != null)
                    {
                        if (!string.IsNullOrEmpty(disableAttribute.SettingName))
                        {
                            return IsDisabledBySetting(disableAttribute.SettingName, method, nameResolver, configuration);
                        }
                        else if (disableAttribute.ProviderType != null)
                        {
                            // a custom provider Type has been specified
                            return IsDisabledByProvider(disableAttribute.ProviderType, method, activator);
                        }
                        else
                        {
                            // the default constructor was used
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        internal static bool IsDisabledBySetting(string settingName, MethodInfo method, INameResolver nameResolver, IConfiguration configuration)
        {
            if (nameResolver != null)
            {
                settingName = nameResolver.ResolveWholeString(settingName);
            }

            BindingTemplate bindingTemplate = BindingTemplate.FromString(settingName);
            Dictionary<string, object> bindingData = new Dictionary<string, object>();
            bindingData.Add("MethodName", string.Format(CultureInfo.InvariantCulture, "{0}.{1}", method.DeclaringType.Name, method.Name));
            bindingData.Add("MethodShortName", method.Name);
            settingName = bindingTemplate.Bind(bindingData);

            return configuration.IsSettingEnabled(settingName);
        }

        internal static bool IsDisabledByProvider(Type providerType, MethodInfo jobFunction, IJobActivator activator)
        {
            MethodInfo methodInfo = providerType.GetMethod(IsDisabledFunctionName, BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(MethodInfo) }, null);
            if (methodInfo == null)
            {
                methodInfo = providerType.GetMethod(IsDisabledFunctionName, BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(MethodInfo) }, null);
            }

            if (methodInfo == null || methodInfo.ReturnType != typeof(bool))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Type '{0}' must declare a method 'IsDisabled' returning bool and taking a single parameter of Type MethodInfo.", providerType.Name));
            }

            if (methodInfo.IsStatic)
            {
                return (bool)methodInfo.Invoke(null, new object[] { jobFunction });
            }
            else
            {
                MethodInfo createMethod = JobActivatorCreateMethod.MakeGenericMethod(providerType);
                object instance = createMethod.Invoke(activator, null);
                return (bool)methodInfo.Invoke(instance, new object[] { jobFunction });
            }
        }
    }
}
