// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    internal class EventGridTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly EventGridExtensionConfigProvider _extensionConfigProvider;
        internal EventGridTriggerAttributeBindingProvider(EventGridExtensionConfigProvider extensionConfigProvider)
        {
            _extensionConfigProvider = extensionConfigProvider;
        }

        // called when loading the function
        // no input yet
        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;
            EventGridTriggerAttribute attribute = parameter.GetCustomAttribute<EventGridTriggerAttribute>(inherit: false);
            bool singleDispatch = !parameter.ParameterType.IsArray;
            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            return Task.FromResult<ITriggerBinding>(new EventGridTriggerBinding(context.Parameter, _extensionConfigProvider, singleDispatch));
        }

        internal class EventGridTriggerBinding : ITriggerBinding
        {
            private readonly ParameterInfo _parameter;
            private readonly Dictionary<string, Type> _bindingContract;
            private readonly EventGridExtensionConfigProvider _eventGridExtensionConfigProvider;
            private readonly bool _singleDispatch;

            public EventGridTriggerBinding(ParameterInfo parameter, EventGridExtensionConfigProvider eventGridExtensionConfigProvider, bool singleDispatch)
            {
                _eventGridExtensionConfigProvider = eventGridExtensionConfigProvider;
                _parameter = parameter;
                _singleDispatch = singleDispatch;
                _bindingContract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
                {
                    { "data", _singleDispatch ? typeof(object) : typeof(object[]) }
                };
            }

            public IReadOnlyDictionary<string, Type> BindingDataContract
            {
                get { return _bindingContract; }
            }

            public Type TriggerValueType
            {
                get { return _singleDispatch ? typeof(JObject) : typeof(JArray); }
            }

            // Extract binding data
            // Conversion from value to parameterType is done by GenericCompositeBindingProvider
            public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
            {
                if (!_singleDispatch)
                {
                    if (!(value is JArray triggerVals))
                    {
                        throw new InvalidOperationException($"Unable to bind {value} to type {_parameter.ParameterType}. " +
                            $"Expected {nameof(value)} to be of type {typeof(JArray)}");
                    }
                    var eventDataCollection = triggerVals.Select(ev => ev["data"]).ToArray();
                    var bindingDataCollection = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "data", eventDataCollection }
                    };
                    return Task.FromResult<ITriggerData>(new TriggerData(null, bindingDataCollection));
                }

                JObject triggerValue = null;
                if (value is string stringValue)
                {
                    try
                    {
                        triggerValue = JObject.Parse(stringValue);
                    }
                    catch (Exception)
                    {
                        throw new FormatException($"Unable to parse {stringValue} to {typeof(JObject)}");
                    }
                }
                else
                {
                    // default casting
                    triggerValue = value as JObject;
                }

                if (triggerValue == null)
                {
                    throw new InvalidOperationException($"Unable to bind {value} to type {_parameter.ParameterType}");
                }

                var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    // if triggerValue does not have data property, this will be null
                    { "data", triggerValue["data"] }
                };

                return Task.FromResult<ITriggerData>(new TriggerData(null, bindingData));
            }

            public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
            {
                // for csharp function, shortName == functionNameAttribute.Name
                // for csharpscript function, shortName == Functions.FolderName (need to strip the first half)
                string functionName = context.Descriptor.ShortName.Split('.').Last();
                return Task.FromResult<IListener>(new EventGridListener(context.Executor, _eventGridExtensionConfigProvider, functionName, _singleDispatch));
            }

            public ParameterDescriptor ToParameterDescriptor()
            {
                return new EventGridTriggerParameterDescriptor
                {
                    Name = _parameter.Name,
                    DisplayHints = new ParameterDisplayHints
                    {
                        // TODO: Customize your Dashboard display strings
                        Prompt = "EventGrid",
                        Description = "EventGrid trigger fired",
                        DefaultValue = "Sample"
                    }
                };
            }

            private class EventGridTriggerParameterDescriptor : TriggerParameterDescriptor
            {
                public override string GetTriggerReason(IDictionary<string, string> arguments)
                {
                    // TODO: Customize your Dashboard display string
                    return string.Format(CultureInfo.InvariantCulture, "EventGrid trigger fired at {0:o}", DateTime.Now);
                }
            }
        }
    }
}
