// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    internal class DispatchQueueTestConfig : IExtensionConfigProvider
    {
        public const int BatchSize = 6;

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.AddBindingRule<DispatchQueueTriggerAttribute>().BindToTrigger(new ExtensionTriggerAttributeBindingProvider());
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class DispatchQueueTriggerAttribute : Attribute
    {
    }

    internal class ExtensionTriggerAttributeBindingProvider : ITriggerBindingProvider
    {

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;
            var attribute = parameter.GetCustomAttribute<DispatchQueueTriggerAttribute>(inherit: false);
            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            // no extra work when using sharedQueue
            if (parameter.ParameterType != typeof(JObject))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    "Can't bind DispatchQueueTriggerAttribute to type '{0}'.", parameter.ParameterType));
            }

            return Task.FromResult<ITriggerBinding>(new ExtensionTriggerBinding(context.Parameter));
        }

        private class ExtensionTriggerBinding : ITriggerBinding
        {
            private readonly ParameterInfo _parameter;
            private readonly IReadOnlyDictionary<string, Type> _bindingContract;

            public ExtensionTriggerBinding(ParameterInfo parameter)
            {
                _parameter = parameter;
                _bindingContract = CreateBindingDataContract();
            }

            public IReadOnlyDictionary<string, Type> BindingDataContract
            {
                get { return _bindingContract; }
            }

            public Type TriggerValueType
            {
                get { return typeof(JObject); }
            }

            public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
            {
                JObject triggerValue = value as JObject;
                IValueProvider valueBinder = new ExtensionValueBinder(triggerValue);
                return Task.FromResult<ITriggerData>(new TriggerData(valueBinder, GetBindingData(triggerValue)));
            }

            public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
            {
                return Task.FromResult<IListener>(new Listener(context));
            }

            public ParameterDescriptor ToParameterDescriptor()
            {
                return new ExtensionTriggerParameterDescriptor
                {
                    Name = _parameter.Name,
                    DisplayHints = new ParameterDisplayHints
                    {
                        Prompt = "DispatchQueue",
                        Description = "DispatchQueue trigger fired",
                        DefaultValue = "null"
                    }
                };
            }

            private IReadOnlyDictionary<string, object> GetBindingData(JObject value)
            {
                Dictionary<string, object> bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                bindingData.Add("DispatchQueueTrigger", value);
                return bindingData;
            }

            private IReadOnlyDictionary<string, Type> CreateBindingDataContract()
            {
                Dictionary<string, Type> contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
                contract.Add("DispatchQueueTrigger", typeof(JObject));
                return contract;
            }

            private class ExtensionTriggerParameterDescriptor : TriggerParameterDescriptor
            {
                public override string GetTriggerReason(IDictionary<string, string> arguments)
                {
                    return string.Format("DispatchQueue trigger fired at {0}", DateTime.Now.ToString("o"));
                }
            }

            private class ExtensionValueBinder : IValueProvider
            {
                private readonly object _value;

                public ExtensionValueBinder(JObject value)
                {
                    _value = value;
                }

                public Type Type => typeof(JObject);

                public Task<object> GetValueAsync()
                {
                    return Task.FromResult(_value);
                }

                public string ToInvokeString()
                {
                    return _value.ToString();
                }
            }

            private class Listener : IListener
            {
                private IDispatchQueueHandler _dispatchQueue;
                private Task _startDelayEnqueue;

                public Listener(ListenerFactoryContext context)
                {
                    _dispatchQueue = context.GetDispatchQueue(new SimpleHandler(context.Executor));
                }

                public Task StartAsync(CancellationToken cancellationToken)
                {
                    // start a task that will later perform enqueues
                    _startDelayEnqueue = DelayEnqueue();
                    return Task.FromResult(true);
                }

                public Task StopAsync(CancellationToken cancellationToken)
                {
                    // make sure all enqueue has finished
                    return _startDelayEnqueue;
                }

                public void Dispose()
                {
                }

                public void Cancel()
                {
                }

                private Task DelayEnqueue()
                {
                    List<Task> tasks = new List<Task>();
                    for (int i = 0; i < DispatchQueueTestConfig.BatchSize; i++)
                    {
                        JObject payload = JObject.Parse("{ order:" + i + "}");
                        tasks.Add(_dispatchQueue.EnqueueAsync(payload, CancellationToken.None));
                    }
                    return Task.WhenAll(tasks);
                }
            }

            private class SimpleHandler : IMessageHandler
            {
                private ITriggeredFunctionExecutor _executor;
                public SimpleHandler(ITriggeredFunctionExecutor executor)
                {
                    _executor = executor;
                }
                public Task<FunctionResult> TryExecuteAsync(JObject data, CancellationToken cancellationToken)
                {
                    TriggeredFunctionData input = new TriggeredFunctionData
                    {
                        TriggerValue = data
                    };
                    return _executor.TryExecuteAsync(input, cancellationToken);
                }
            }
        }
    }
}
