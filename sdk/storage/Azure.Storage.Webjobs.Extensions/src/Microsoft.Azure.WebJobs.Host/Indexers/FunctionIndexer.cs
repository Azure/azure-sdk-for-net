// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Invoke;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Properties;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    internal class FunctionIndexer
    {
        public const string ReturnParamName = "$return";

        private static readonly BindingFlags PublicMethodFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        private readonly ITriggerBindingProvider _triggerBindingProvider;
        private readonly IBindingProvider _bindingProvider;
        private readonly IJobActivator _activator;
        private readonly INameResolver _nameResolver;
        private readonly IFunctionExecutor _executor;
        private readonly SingletonManager _singletonManager;
        private readonly ILogger _logger;
        private readonly SharedQueueHandler _sharedQueue;
        private readonly TimeoutAttribute _defaultTimeout;
        private readonly bool _allowPartialHostStartup;
        private readonly IConfiguration _configuration;

        public FunctionIndexer(
            ITriggerBindingProvider triggerBindingProvider,
            IBindingProvider bindingProvider,
            IJobActivator activator,
            IFunctionExecutor executor,
            SingletonManager singletonManager,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            INameResolver nameResolver = null,
            SharedQueueHandler sharedQueue = null,
            TimeoutAttribute defaultTimeout = null,
            bool allowPartialHostStartup = false)
        {
            _triggerBindingProvider = triggerBindingProvider ?? throw new ArgumentNullException(nameof(triggerBindingProvider));
            _bindingProvider = bindingProvider ?? throw new ArgumentNullException(nameof(bindingProvider));
            _activator = activator ?? throw new ArgumentNullException(nameof(activator));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _singletonManager = singletonManager ?? throw new ArgumentNullException(nameof(singletonManager));
            _nameResolver = nameResolver;
            _logger = loggerFactory?.CreateLogger(LogCategories.Startup);
            _sharedQueue = sharedQueue;
            _defaultTimeout = defaultTimeout;
            _allowPartialHostStartup = allowPartialHostStartup;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task IndexTypeAsync(Type type, IFunctionIndexCollector index, CancellationToken cancellationToken)
        {
            foreach (MethodInfo method in type.GetMethods(PublicMethodFlags).Where(IsJobMethod))
            {
                try
                {
                    await IndexMethodAsync(method, index, cancellationToken);
                }
                catch (FunctionIndexingException fex)
                {
                    if (_allowPartialHostStartup)
                    {
                        fex.Handled = true;
                    }

                    fex.TryRecover(_logger);

                    // If recoverable, continue to the rest of the methods.
                    // The method in error simply won't be running in the JobHost.
                    string msg = $"Function '{Utility.GetFunctionShortName(method)}' failed indexing and will be disabled.";
                    _logger?.LogWarning(msg);
                    continue;
                }
            }
        }

        public static IEnumerable<MethodInfo> GetJobMethods(Type type)
        {
            return type.GetMethods(PublicMethodFlags).Where(IsJobMethod);
        }

        public static bool IsJobMethod(MethodInfo method)
        {
            if (method.ContainsGenericParameters)
            {
                return false;
            }

            if (method.GetCustomAttributesData().Any(HasJobAttribute))
            {
                return true;
            }

            if (method.ReturnParameter.GetCustomAttributesData().Any(HasJobAttribute))
            {
                return true;
            }

            if (method.GetParameters().Length == 0)
            {
                return false;
            }

            if (method.GetParameters().Any(p => p.GetCustomAttributesData().Any(HasJobAttribute)))
            {
                return true;
            }

            return false;
        }

        private static bool HasJobAttribute(CustomAttributeData attributeData)
        {
            return attributeData.AttributeType.GetCustomAttribute<BindingAttribute>() != null;
        }

        public async Task IndexMethodAsync(MethodInfo method, IFunctionIndexCollector index, CancellationToken cancellationToken)
        {
            try
            {
                await IndexMethodAsyncCore(method, index, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new FunctionIndexingException(Utility.GetFunctionShortName(method), exception);
            }
        }

        internal async Task IndexMethodAsyncCore(MethodInfo method, IFunctionIndexCollector index, CancellationToken cancellationToken)
        {
            Debug.Assert(method != null);
            bool hasNoAutomaticTriggerAttribute = method.GetCustomAttribute<NoAutomaticTriggerAttribute>() != null;

            ITriggerBinding triggerBinding = null;
            ParameterInfo triggerParameter = null;
            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                ITriggerBinding possibleTriggerBinding = await _triggerBindingProvider.TryCreateAsync(new TriggerBindingProviderContext(parameter, cancellationToken));

                if (possibleTriggerBinding != null)
                {
                    if (triggerBinding == null)
                    {
                        triggerBinding = possibleTriggerBinding;
                        triggerParameter = parameter;
                    }
                    else
                    {
                        throw new InvalidOperationException("More than one trigger per function is not allowed.");
                    }
                }
            }

            Dictionary<string, IBinding> nonTriggerBindings = new Dictionary<string, IBinding>();
            IReadOnlyDictionary<string, Type> bindingDataContract;

            if (triggerBinding != null)
            {
                bindingDataContract = triggerBinding.BindingDataContract;

                // See if a regular binding can handle it. 
                IBinding binding = await _bindingProvider.TryCreateAsync(new BindingProviderContext(triggerParameter, bindingDataContract, cancellationToken));
                if (binding != null)
                {
                    triggerBinding = new TriggerWrapper(triggerBinding, binding);
                }
            }
            else
            {
                bindingDataContract = null;
            }

            bool hasParameterBindingAttribute = false;
            Exception invalidInvokeBindingException = null;

            ReturnParameterInfo returnParameter = null;
            bool triggerHasReturnBinding = false;

            if (TypeUtility.TryGetReturnType(method, out Type methodReturnType) && !IsUnitType(methodReturnType))
            {
                if (bindingDataContract != null && bindingDataContract.TryGetValue(ReturnParamName, out Type triggerReturnType))
                {
                    // The trigger will handle the return value.
                    triggerHasReturnBinding = true;
                }

                // We treat binding to the return type the same as binding to an 'out T' parameter. 
                // An explicit return binding takes precedence over an implicit trigger binding. 
                returnParameter = new ReturnParameterInfo(method, methodReturnType);
                parameters = parameters.Concat(new ParameterInfo[] { returnParameter });
            }

            foreach (ParameterInfo parameter in parameters)
            {
                if (parameter == triggerParameter)
                {
                    continue;
                }

                IBinding binding = await _bindingProvider.TryCreateAsync(new BindingProviderContext(parameter, bindingDataContract, cancellationToken));
                if (binding == null)
                {
                    if (parameter == returnParameter)
                    {
                        if (triggerHasReturnBinding)
                        {
                            // Ok. Skip and let trigger own the return binding. 
                            continue;
                        }
                        else
                        {
                            // If the method has a return value, then we must have a binding to it. 
                            // This is similar to the error we used to throw. 
                            invalidInvokeBindingException = new InvalidOperationException("Functions must return Task or void, have a binding attribute for the return value, or be triggered by a binding that natively supports return values.");
                        }
                    }

                    if (triggerBinding != null && !hasNoAutomaticTriggerAttribute)
                    {
                        throw new InvalidOperationException(
                            string.Format(Resource.UnableToBindParameterFormat,
                            parameter.Name, parameter.ParameterType.Name, Resource.ExtensionInitializationMessage));
                    }
                    else
                    {
                        // Host.Call-only parameter
                        binding = InvokeBinding.Create(parameter.Name, parameter.ParameterType);
                        if (binding == null && invalidInvokeBindingException == null)
                        {
                            // This function might not have any attribute, in which case we shouldn't throw an
                            // exception when we can't bind it. Instead, save this exception for later once we determine
                            // whether or not it is an SDK function.
                            invalidInvokeBindingException = new InvalidOperationException(
                                string.Format(Resource.UnableToBindParameterFormat,
                                parameter.Name, parameter.ParameterType.Name, Resource.ExtensionInitializationMessage));
                        }
                    }
                }
                else if (!hasParameterBindingAttribute)
                {
                    hasParameterBindingAttribute = binding.FromAttribute;
                }

                nonTriggerBindings.Add(parameter.Name, binding);
            }

            // Only index functions with some kind of attribute on them. Three ways that could happen:
            // 1. There's an attribute on a trigger parameter (all triggers come from attributes).
            // 2. There's an attribute on a non-trigger parameter (some non-trigger bindings come from attributes).
            if (triggerBinding == null && !hasParameterBindingAttribute)
            {
                // 3. There's an attribute on the method itself (NoAutomaticTrigger).
                if (method.GetCustomAttribute<NoAutomaticTriggerAttribute>() == null)
                {
                    return;
                }
            }

            if (TypeUtility.IsAsyncVoid(method))
            {
                string msg = $"Function '{Utility.GetFunctionShortName(method)}' is async but does not return a Task. Your function may not run correctly.";
                _logger?.LogWarning(msg);
            }

            if (invalidInvokeBindingException != null)
            {
                throw invalidInvokeBindingException;
            }

            // Validation: prevent multiple ConsoleOutputs
            if (nonTriggerBindings.OfType<TraceWriterBinding>().Count() > 1)
            {
                throw new InvalidOperationException("Can't have multiple TraceWriter/TextWriter parameters in a single function.");
            }

            string triggerParameterName = triggerParameter != null ? triggerParameter.Name : null;
            FunctionDescriptor functionDescriptor = CreateFunctionDescriptor(method, triggerParameterName, triggerBinding, nonTriggerBindings);
            IFunctionInvoker invoker = FunctionInvokerFactory.Create(method, _activator);
            IFunctionDefinition functionDefinition;

            if (triggerBinding != null)
            {
                Type triggerValueType = triggerBinding.TriggerValueType;
                var methodInfo = typeof(FunctionIndexer).GetMethod("CreateTriggeredFunctionDefinition", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(triggerValueType);
                functionDefinition = (FunctionDefinition)methodInfo.Invoke(this, new object[] { triggerBinding, triggerParameterName, functionDescriptor, nonTriggerBindings, invoker });

                if (hasNoAutomaticTriggerAttribute && functionDefinition != null)
                {
                    functionDefinition = new FunctionDefinition(functionDescriptor, functionDefinition.InstanceFactory, listenerFactory: null);
                }
            }
            else
            {
                IFunctionInstanceFactory instanceFactory = new FunctionInstanceFactory(new FunctionBinding(functionDescriptor, nonTriggerBindings, _singletonManager), invoker, functionDescriptor);
                functionDefinition = new FunctionDefinition(functionDescriptor, instanceFactory, listenerFactory: null);
            }

            index.Add(functionDefinition, functionDescriptor, method);
        }

        /// <summary>
        /// Verifies if the provided type is the F# Unit type by performing a type name comparison.
        /// </summary>
        /// <param name="type">The type to be checked.</param>
        /// <returns>True if the type name matches the F# unit type; otherwise, false.</returns>
        private bool IsUnitType(Type type) => string.Equals(type?.FullName, "Microsoft.FSharp.Core.Unit", StringComparison.Ordinal);

        private FunctionDefinition CreateTriggeredFunctionDefinition<TTriggerValue>(
            ITriggerBinding triggerBinding, string parameterName, FunctionDescriptor descriptor,
            IReadOnlyDictionary<string, IBinding> nonTriggerBindings, IFunctionInvokerEx invoker)
        {
            ITriggeredFunctionBinding<TTriggerValue> functionBinding = new TriggeredFunctionBinding<TTriggerValue>(descriptor, parameterName, triggerBinding, nonTriggerBindings, _singletonManager);
            ITriggeredFunctionInstanceFactory<TTriggerValue> instanceFactory = new TriggeredFunctionInstanceFactory<TTriggerValue>(functionBinding, invoker, descriptor);
            ITriggeredFunctionExecutor triggerExecutor = new TriggeredFunctionExecutor<TTriggerValue>(descriptor, _executor, instanceFactory);
            IListenerFactory listenerFactory = new ListenerFactory(descriptor, triggerExecutor, triggerBinding, _sharedQueue);

            return new FunctionDefinition(descriptor, instanceFactory, listenerFactory);
        }

        // Expose internally for testing purposes 
        internal static FunctionDescriptor FromMethod(
            MethodInfo method,
            IConfiguration configuration,
            IJobActivator jobActivator = null,
            INameResolver nameResolver = null,
            TimeoutAttribute defaultTimeout = null)
        {
            var disabled = HostListenerFactory.IsDisabled(method, nameResolver, jobActivator, configuration);

            bool hasCancellationToken = method.GetParameters().Any(p => p.ParameterType == typeof(CancellationToken));

            string logName = method.Name;
            string shortName = method.GetShortName();
            FunctionNameAttribute nameAttribute = method.GetCustomAttribute<FunctionNameAttribute>();
            if (nameAttribute != null)
            {
                logName = nameAttribute.Name;
                shortName = logName;
                if (!FunctionNameAttribute.FunctionNameValidationRegex.IsMatch(logName))
                {
                    throw new InvalidOperationException(string.Format("'{0}' is not a valid function name.", logName));
                }
            }

            return new FunctionDescriptor
            {
                Id = method.GetFullName(),
                LogName = logName,
                FullName = method.GetFullName(),
                ShortName = shortName,
                IsDisabled = disabled,
                HasCancellationToken = hasCancellationToken,
                TimeoutAttribute = TypeUtility.GetHierarchicalAttributeOrNull<TimeoutAttribute>(method) ?? defaultTimeout,
                SingletonAttributes = method.GetCustomAttributes<SingletonAttribute>().ToArray(),
                MethodLevelFilters = method.GetCustomAttributes().OfType<IFunctionFilter>().ToArray(),
                ClassLevelFilters = method.DeclaringType.GetCustomAttributes().OfType<IFunctionFilter>().ToArray()
            };
        }

        private FunctionDescriptor CreateFunctionDescriptor(MethodInfo method, string triggerParameterName,
            ITriggerBinding triggerBinding, IReadOnlyDictionary<string, IBinding> nonTriggerBindings)
        {
            var descr = FromMethod(method, _configuration, this._activator, _nameResolver, _defaultTimeout);

            List<ParameterDescriptor> parameters = new List<ParameterDescriptor>();

            foreach (ParameterInfo parameter in method.GetParameters())
            {
                string name = parameter.Name;

                if (name == triggerParameterName)
                {
                    parameters.Add(triggerBinding.ToParameterDescriptor());
                }
                else
                {
                    parameters.Add(nonTriggerBindings[name].ToParameterDescriptor());
                }
            }

            descr.Parameters = parameters;
            descr.TriggerParameterDescriptor = parameters.OfType<TriggerParameterDescriptor>().FirstOrDefault();

            return descr;
        }

        private class ListenerFactory : IListenerFactory
        {
            private readonly FunctionDescriptor _descriptor;
            private readonly ITriggeredFunctionExecutor _executor;
            private readonly ITriggerBinding _binding;
            private readonly SharedQueueHandler _sharedQueue;

            public ListenerFactory(FunctionDescriptor descriptor, ITriggeredFunctionExecutor executor, ITriggerBinding binding, SharedQueueHandler sharedQueue)
            {
                _descriptor = descriptor;
                _executor = executor;
                _binding = binding;
                _sharedQueue = sharedQueue;
            }

            public async Task<IListener> CreateAsync(CancellationToken cancellationToken)
            {
                ListenerFactoryContext context = new ListenerFactoryContext(_descriptor, _executor, _sharedQueue, cancellationToken);
                return await _binding.CreateListenerAsync(context);
            }
        }

        // Get a ParameterInfo that represents the return type as a parameter. 
        private class ReturnParameterInfo : ParameterInfo
        {
            private readonly IEnumerable<Attribute> _attributes;

            public ReturnParameterInfo(MethodInfo method, Type methodReturnType)
            {
                // If Method is Task<T>, then unwrap to jsut T. 
                var retType = methodReturnType.MakeByRefType(); // 'return T' is 'out T'
                ClassImpl = retType;
                AttrsImpl = ParameterAttributes.Out;
                NameImpl = ReturnParamName;
                MemberImpl = method;

                // union all the parameter attributes
                _attributes = method.ReturnParameter.GetCustomAttributes();
            }

            public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                return _attributes.Where(p => p.GetType() == attributeType).ToArray();
            }
        }

        // Wrapper for leveraging existing input pipeline and converter manager to get a ValueProvider.
        // Forwards all other calls to the inner binding. 
        class TriggerWrapper : ITriggerBinding
        {
            private readonly ITriggerBinding _inner;
            private readonly IBinding _binding;

            // 'inner' provides the rest of the ITriggerBinding functionality. 
            // 'binding' provides the means to get the IValueProvider. 
            public TriggerWrapper(ITriggerBinding inner, IBinding binding)
            {
                _inner = inner;
                _binding = binding;
            }

            public Type TriggerValueType => _inner.TriggerValueType;

            public IReadOnlyDictionary<string, Type> BindingDataContract => _inner.BindingDataContract;

            public async Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
            {
                var data = await _inner.BindAsync(value, context);

                if (data.ValueProvider == null)
                {
                    var valueProvider = await _binding.BindAsync(value, context);
                    data = new TriggerData(valueProvider, data.BindingData);
                }

                return data;
            }

            public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
            {
                return _inner.CreateListenerAsync(context);
            }

            public ParameterDescriptor ToParameterDescriptor()
            {
                return _inner.ToParameterDescriptor();
            }
        }
    }
}
