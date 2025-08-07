// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerBinding : ITriggerBinding
    {
        private const string ReturnParameterKey = "$return";

        private readonly ParameterInfo _parameterInfo;
        private readonly SignalRTriggerAttribute _attribute;
        private readonly ISignalRTriggerDispatcher _dispatcher;
        private readonly IOptionsMonitor<SignatureValidationOptions> _signatureValidationOptions;
        private readonly ServiceHubContext _hubContext;

        public SignalRTriggerBinding(ParameterInfo parameterInfo, SignalRTriggerAttribute attribute, ISignalRTriggerDispatcher dispatcher, IOptionsMonitor<SignatureValidationOptions> signatureValidationOptions, ServiceHubContext hubContext)
        {
            _parameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
            _attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _signatureValidationOptions = signatureValidationOptions ?? throw new ArgumentNullException(nameof(signatureValidationOptions));
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            BindingDataContract = CreateBindingContract(_attribute, _parameterInfo);
        }

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (value is SignalRTriggerEvent triggerEvent)
            {
                var bindingContext = triggerEvent.Context;
                bindingContext.HubContext = _hubContext;
                // If ParameterNames are set, bind them in order.
                // To reduce undefined situation, number of arguments should keep consist with that of ParameterNames
                if (_attribute.ParameterNames != null && _attribute.ParameterNames.Length != 0)
                {
                    if (bindingContext.Arguments == null ||
                        bindingContext.Arguments.Length != _attribute.ParameterNames.Length)
                    {
                        throw new SignalRTriggerParametersNotMatchException(_attribute.ParameterNames.Length, bindingContext.Arguments?.Length ?? 0);
                    }

                    AddParameterNamesBindingData(bindingData, _attribute.ParameterNames, bindingContext.Arguments);
                }

                return Task.FromResult<ITriggerData>(new TriggerData(new SignalRTriggerValueProvider(_parameterInfo, bindingContext), bindingData)
                {
                    ReturnValueProvider = triggerEvent.TaskCompletionSource == null ? null : new TriggerReturnValueProvider(triggerEvent.TaskCompletionSource),
                });
            }

            return Task.FromResult<ITriggerData>(null);
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // It's not a real listener, and it doesn't need a start or close.
            _dispatcher.Map((_attribute.HubName, _attribute.Category, _attribute.Event),
                new ExecutionContext { Executor = context.Executor, SignatureValidationOptions = _signatureValidationOptions });

            return Task.FromResult<IListener>(new NullListener());
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameterInfo.Name,
            };
        }

        /// <summary>
        /// Type of object in BindAsync
        /// </summary>
        public Type TriggerValueType => typeof(SignalRTriggerEvent);

        // TODO: Use dynamic contract to deal with parameterName
        public IReadOnlyDictionary<string, Type> BindingDataContract { get; }

        /// <summary>
        /// Defined what other bindings can use and return value.
        /// </summary>
        private static IReadOnlyDictionary<string, Type> CreateBindingContract(SignalRTriggerAttribute attribute, ParameterInfo parameter)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                { ReturnParameterKey, typeof(object).MakeByRefType() },
            };

            // Add names in ParameterNames to binding contract, that user can bind to Functions' parameter directly
            if (attribute.ParameterNames != null)
            {
                var parameters = ((MethodInfo)parameter.Member).GetParameters().ToDictionary(p => p.Name, p => p.ParameterType, StringComparer.OrdinalIgnoreCase);
                foreach (var parameterName in attribute.ParameterNames)
                {
                    if (parameters.ContainsKey(parameterName))
                    {
                        contract.Add(parameterName, parameters[parameterName]);
                    }
                    else
                    {
                        contract.Add(parameterName, typeof(object));
                    }
                }
            }

            return contract;
        }

        private void AddParameterNamesBindingData(Dictionary<string, object> bindingData, string[] parameterNames, object[] arguments)
        {
            var length = parameterNames.Length;
            for (var i = 0; i < length; i++)
            {
                if (BindingDataContract.TryGetValue(parameterNames[i], out var type))
                {
                    bindingData.Add(parameterNames[i], ConvertValueIfNecessary(arguments[i], type));
                }
                else
                {
                    bindingData.Add(parameterNames[i], arguments[i]);
                }
            }
        }

        private static object ConvertValueIfNecessary(object value, Type targetType)
        {
            if (value != null && !targetType.IsAssignableFrom(value.GetType()))
            {
                var underlyingTargetType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                var jObject = value as JObject;
                if (jObject != null)
                {
                    value = jObject.ToObject(targetType);
                }
                else if (underlyingTargetType == typeof(Guid) && value.GetType() == typeof(string))
                {
                    // Guids need to be converted by their own logic
                    // Intentionally throw here on error to standardize behavior
                    value = Guid.Parse((string)value);
                }
                else
                {
                    // if the type is nullable, we only need to convert to the
                    // correct underlying type
                    value = Convert.ChangeType(value, underlyingTargetType, CultureInfo.InvariantCulture);
                }
            }

            return value;
        }

        // TODO: Add more supported type
        /// <summary>
        /// A provider that responsible for providing value in various type to be bond to function method parameter.
        /// </summary>
        private class SignalRTriggerValueProvider : IValueBinder
        {
            private readonly InvocationContext _value;
            private readonly ParameterInfo _parameter;

            public SignalRTriggerValueProvider(ParameterInfo parameter, InvocationContext value)
            {
                _parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
                _value = value ?? throw new ArgumentNullException(nameof(value));
            }

            public Task<object> GetValueAsync()
            {
                if (_parameter.ParameterType == typeof(InvocationContext))
                {
                    return Task.FromResult<object>(_value);
                }
                else if (_parameter.ParameterType == typeof(object) ||
                         _parameter.ParameterType == typeof(JObject))
                {
                    return Task.FromResult<object>(JObject.FromObject(_value));
                }
                // Isolated worker model
                else if (_parameter.ParameterType == typeof(string))
                {
                    return Task.FromResult(JsonConvert.SerializeObject(_value) as object);
                }

                return Task.FromResult<object>(null);
            }

            public string ToInvokeString()
            {
                return _value.ToString();
            }

            public Type Type => _parameter.ParameterType;

            // No use here
            public Task SetValueAsync(object value, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// A provider to handle return value.
        /// </summary>
        private class TriggerReturnValueProvider : IValueBinder
        {
            private readonly TaskCompletionSource<object> _tcs;

            public TriggerReturnValueProvider(TaskCompletionSource<object> tcs)
            {
                _tcs = tcs;
            }

            public Task<object> GetValueAsync()
            {
                // Useless for return value provider
                return null;
            }

            public string ToInvokeString()
            {
                // Useless for return value provider
                return string.Empty;
            }

            public Type Type => typeof(object).MakeByRefType();

            public Task SetValueAsync(object value, CancellationToken cancellationToken)
            {
                _tcs.TrySetResult(value);
                return Task.CompletedTask;
            }
        }
    }
}