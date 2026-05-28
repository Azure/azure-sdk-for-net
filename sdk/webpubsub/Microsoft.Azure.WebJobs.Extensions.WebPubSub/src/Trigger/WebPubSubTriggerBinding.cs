// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerBinding : ITriggerBinding
    {
        private readonly ParameterInfo _parameterInfo;
        private readonly WebPubSubTriggerAttribute _attribute;
        private readonly IWebPubSubTriggerDispatcher _dispatcher;
        private readonly WebPubSubFunctionsOptions _options;

        public WebPubSubTriggerBinding(ParameterInfo parameterInfo, WebPubSubTriggerAttribute attribute, WebPubSubFunctionsOptions options, IWebPubSubTriggerDispatcher dispatcher)
        {
            _parameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
            _attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            BindingDataContract = CreateBindingContract(parameterInfo);
        }

        public Type TriggerValueType => typeof(WebPubSubTriggerEvent);

        public IReadOnlyDictionary<string, Type> BindingDataContract { get; }

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (value is WebPubSubTriggerEvent triggerEvent)
            {
                AddBindingData(bindingData, triggerEvent);

                return Task.FromResult<ITriggerData>(new TriggerData(new WebPubSubTriggerValueProvider(_parameterInfo, triggerEvent), bindingData)
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
            var attributeName = Utilities.GetFunctionKey(hub, _attribute.EventType, _attribute.EventName, _attribute.ClientProtocols);
            var listernerKey = attributeName;

            var validationOptions = _attribute.Connections != null ?
                new WebPubSubValidationOptions(_attribute.Connections) :
                new WebPubSubValidationOptions(_options.ConnectionString);

            return Task.FromResult<IListener>(new WebPubSubListener(context.Executor, listernerKey, _dispatcher, validationOptions));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameterInfo.Name,
            };
        }

        private static void AddBindingData(Dictionary<string, object> bindingData, WebPubSubTriggerEvent triggerEvent)
        {
            bindingData.Add(nameof(triggerEvent.Request), triggerEvent.Request);
            bindingData.Add(nameof(triggerEvent.ConnectionContext), triggerEvent.ConnectionContext);
            bindingData.Add(nameof(triggerEvent.Data), triggerEvent.Data);
            bindingData.Add(nameof(triggerEvent.DataType), triggerEvent.DataType);
            bindingData.Add(nameof(triggerEvent.Claims), triggerEvent.Claims);
            bindingData.Add(nameof(triggerEvent.Query), triggerEvent.Query);
            bindingData.Add(nameof(triggerEvent.Reason), triggerEvent.Reason);
            bindingData.Add(nameof(triggerEvent.Subprotocols), triggerEvent.Subprotocols);
            bindingData.Add(nameof(triggerEvent.ClientCertificates), triggerEvent.ClientCertificates);
        }

        /// <summary>
        /// Defined what other bindings can use and return value.
        /// </summary>
        private static IReadOnlyDictionary<string, Type> CreateBindingContract(ParameterInfo parameterInfo)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                { "$return", typeof(object).MakeByRefType() },
            };

            contract.Add(parameterInfo.Name, parameterInfo.ParameterType);
            SafeAddContract(() => contract.Add("Request", parameterInfo.ParameterType));
            SafeAddContract(() => contract.Add("ConnectionContext", typeof(WebPubSubConnectionContext)));
            SafeAddContract(() => contract.Add("Data", typeof(BinaryData)));
            SafeAddContract(() => contract.Add("DataType", typeof(WebPubSubDataType)));
            SafeAddContract(() => contract.Add("Claims", typeof(IDictionary<string, string[]>)));
            SafeAddContract(() => contract.Add("Query", typeof(IDictionary<string, string[]>)));
            SafeAddContract(() => contract.Add("Reason", typeof(string)));
            SafeAddContract(() => contract.Add("Subprotocols", typeof(string[])));
            SafeAddContract(() => contract.Add("ClientCertificates", typeof(WebPubSubClientCertificate[])));

            return contract;
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
        internal class WebPubSubTriggerValueProvider : IValueBinder
        {
            private readonly ParameterInfo _parameter;
            private readonly WebPubSubTriggerEvent _triggerEvent;

            public WebPubSubTriggerValueProvider(ParameterInfo parameter, WebPubSubTriggerEvent triggerEvent)
            {
                _parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
                _triggerEvent = triggerEvent ?? throw new ArgumentNullException(nameof(triggerEvent));
            }

            public Task<object> GetValueAsync()
            {
                // Bind un-restrict name to default WebPubSubEventRequest.
                if (_parameter.ParameterType.BaseType == typeof(WebPubSubEventRequest))
                {
                    return Task.FromResult<object>(_triggerEvent.Request);
                }

                // Bind rest with name and type repected.
                return Task.FromResult(GetValueByName(_parameter.Name, _parameter.ParameterType));
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
                var property = Utilities.GetProperty(typeof(WebPubSubTriggerEvent), parameterName);
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
