// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOTriggerBinding : ITriggerBinding
    {
        internal const string RequestBindingName = "Request";
        internal const string ConnectionContextBindingName = "ConnectionContext";
        internal const string PayloadBindingName = "Payload";
        internal const string ClaimsBindingName = "Claims";
        internal const string QueryBindingName = "Query";
        internal const string HeadersBindingName = "Headers";
        internal const string ReasonBindingName = "Reason";
        internal const string ClientCertificatesBindingName = "ClientCertificates";
        internal const string SocketIdBindingName = "SocketId";
        internal const string NamespaceBindingName = "Namespace";
        internal const string UserIdName = "UserId";

        private readonly ParameterInfo _parameterInfo;
        private readonly SocketIOTriggerAttribute _attribute;
        private readonly IWebPubSubForSocketIOTriggerDispatcher _dispatcher;
        private readonly SocketIOFunctionsOptions _options;

        public WebPubSubForSocketIOTriggerBinding(ParameterInfo parameterInfo, SocketIOTriggerAttribute attribute, SocketIOFunctionsOptions options, IWebPubSubForSocketIOTriggerDispatcher dispatcher)
        {
            _parameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
            _attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            BindingDataContract = CreateBindingContract(attribute, parameterInfo);
        }

        public Type TriggerValueType => typeof(SocketIOTriggerEvent);

        public IReadOnlyDictionary<string, Type> BindingDataContract { get; }

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (value is SocketIOTriggerEvent triggerEvent)
            {
                if (_attribute.ParameterNames != null && _attribute.ParameterNames.Length != 0)
                {
                    if (triggerEvent.Request is not SocketIOMessageRequest eventReq)
                    {
                        throw new InvalidDataException($"Expect incoming event to be {nameof(SocketIOMessageRequest)}, but it's {triggerEvent.Request.GetType()}");
                    }

                    if (eventReq.Parameters == null || eventReq.Parameters.Count != _attribute.ParameterNames.Length)
                    {
                        throw new ArgumentException($"Parameter length of incoming data dismatch. Expected to be {_attribute.ParameterNames.Length}, but actually {eventReq.Parameters.Count}. Update the {nameof(SocketIOTriggerAttribute.ParameterNames)} to match the actual data");
                    }

                    // Add binding data for arguments
                    AddParameterNamesBindingData(bindingData, _attribute.ParameterNames, eventReq.Parameters.ToArray());
                }

                AddBindingData(bindingData, triggerEvent);

                return Task.FromResult<ITriggerData>(new TriggerData(new SocketIOTriggerValueProvider(_parameterInfo, triggerEvent), bindingData)
                {
                    ReturnValueProvider = new TriggerReturnValueProvider(triggerEvent.TaskCompletionSource),
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

            // Get listener key from attributes.
            var hub = Utilities.FirstOrDefault(_attribute.Hub, _options.Hub);
            if (string.IsNullOrEmpty(hub))
            {
                throw new ArgumentException("Hub name should be configured in either attribute or appsettings.");
            }
            var listernerKey = new SocketIOTriggerKey(hub, _attribute.Namespace, _attribute.EventType, _attribute.EventName);

            var validationOptions = new WebPubSubValidationOptions(_options.DefaultConnectionInfo);

            return Task.FromResult<IListener>(new WebPubSubForSocketIOListener(context.Executor, listernerKey, _dispatcher, validationOptions));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameterInfo.Name,
            };
        }

        private static void AddBindingData(Dictionary<string, object> bindingData, SocketIOTriggerEvent triggerEvent)
        {
            bindingData.Add(RequestBindingName, triggerEvent.Request);
            bindingData.Add(ConnectionContextBindingName, triggerEvent.ConnectionContext);
            bindingData.Add(SocketIdBindingName, triggerEvent.Request.SocketId);
            bindingData.Add(NamespaceBindingName, triggerEvent.Request.Namespace);
            if (!string.IsNullOrEmpty(triggerEvent.ConnectionContext.UserId))
            {
                bindingData.Add(UserIdName, triggerEvent.ConnectionContext.UserId);
            }

            if (triggerEvent.Request is SocketIOConnectRequest connectEventRequest)
            {
                bindingData.Add(ClaimsBindingName, connectEventRequest.Claims);
                bindingData.Add(QueryBindingName, connectEventRequest.Query);
                bindingData.Add(ClientCertificatesBindingName, connectEventRequest.ClientCertificates);
                bindingData.Add(HeadersBindingName, connectEventRequest.Headers);
            }
            else if (triggerEvent.Request is SocketIODisconnectedRequest disconnectedEventRequest)
            {
                bindingData.Add(ReasonBindingName, disconnectedEventRequest.Reason);
            }
            else if (triggerEvent.Request is SocketIOMessageRequest messageEventRequest)
            {
                bindingData.Add(PayloadBindingName, messageEventRequest.Payload);
            }
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

        /// <summary>
        /// Defined what other bindings can use and return value.
        /// </summary>
        private static IReadOnlyDictionary<string, Type> CreateBindingContract(SocketIOTriggerAttribute attribute, ParameterInfo parameterInfo)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                { "$return", typeof(object).MakeByRefType() },
            };

            // Add names in ParameterNames to binding contract, that user can bind to Functions' parameter directly
            if (attribute.ParameterNames != null)
            {
                var parameters = ((MethodInfo)parameterInfo.Member).GetParameters().ToDictionary(p => p.Name, p => p.ParameterType, StringComparer.OrdinalIgnoreCase);
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

            contract.Add(parameterInfo.Name, parameterInfo.ParameterType);
            SafeAddContract(() => contract.Add(RequestBindingName, parameterInfo.ParameterType));
            SafeAddContract(() => contract.Add(ConnectionContextBindingName, typeof(SocketIOSocketContext)));
            SafeAddContract(() => contract.Add(PayloadBindingName, typeof(BinaryData)));
            SafeAddContract(() => contract.Add(ClaimsBindingName, typeof(IDictionary<string, string[]>)));
            SafeAddContract(() => contract.Add(QueryBindingName, typeof(IDictionary<string, string[]>)));
            SafeAddContract(() => contract.Add(HeadersBindingName, typeof(IDictionary<string, string[]>)));
            SafeAddContract(() => contract.Add(ReasonBindingName, typeof(string)));
            SafeAddContract(() => contract.Add(ClientCertificatesBindingName, typeof(WebPubSubClientCertificate[])));
            SafeAddContract(() => contract.Add(SocketIdBindingName, typeof(string)));
            SafeAddContract(() => contract.Add(NamespaceBindingName, typeof(string)));
            SafeAddContract(() => contract.Add(UserIdName, typeof(string)));

            return contract;
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

        private static void SafeAddContract(Action addValue)
        {
            try
            {
                addValue();
            }
            catch
            {
                // ignore dup
            }
        }

        /// <summary>
        /// A provider that responsible for providing value in various type to be bond to function method parameter.
        /// </summary>
        internal class SocketIOTriggerValueProvider : IValueBinder
        {
            private readonly ParameterInfo _parameter;
            private readonly SocketIOTriggerEvent _triggerEvent;

            public SocketIOTriggerValueProvider(ParameterInfo parameter, SocketIOTriggerEvent triggerEvent)
            {
                _parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
                _triggerEvent = triggerEvent ?? throw new ArgumentNullException(nameof(triggerEvent));
            }

            public Task<object> GetValueAsync()
            {
                // Bind un-restrict name to default SocketIOEventRequest.
                if (_parameter.ParameterType.BaseType == typeof(SocketIOEventHandlerRequest))
                {
                    return Task.FromResult<object>(_triggerEvent.Request);
                }

                return Task.FromResult<object>(ConvertTypeIfPossible(_triggerEvent.Request, _parameter.ParameterType));
            }

            public string ToInvokeString()
            {
                return _parameter.Name;
            }

            public Type Type => _parameter.ParameterType;

            // No use here
            public Task SetValueAsync(object value, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }

            private object GetValueByName(string parameterName, Type targetType)
            {
                var property = Utilities.GetProperty(typeof(SocketIOTriggerEvent), parameterName);
                if (property != null)
                {
                    var value = property.GetValue(_triggerEvent);
                    if (value == null || value.GetType() == targetType)
                    {
                        return value;
                    }
                    return ConvertTypeIfPossible(value, targetType);
                }
                return null;
            }

            private static object ConvertTypeIfPossible(object source, Type target)
            {
                if (source is BinaryData data)
                {
                    return data.Convert(target);
                }
                if (target == typeof(JObject))
                {
                    return JToken.FromObject(source);
                }
                if (target == typeof(string))
                {
                    return JToken.FromObject(source).ToString();
                }
                if (target == typeof(byte[]))
                {
                    return Encoding.UTF8.GetBytes(JToken.FromObject(source).ToString());
                }
                if (target == typeof(Stream))
                {
                    return new MemoryStream(Encoding.UTF8.GetBytes(JToken.FromObject(source).ToString()));
                }
                return null;
            }
        }

        /// <summary>
        /// A provider to handle return value.
        /// </summary>
        internal class TriggerReturnValueProvider : IValueBinder
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
