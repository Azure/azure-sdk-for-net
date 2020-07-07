// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    internal class TriggeredFunctionBinding<TTriggerValue> : ITriggeredFunctionBinding<TTriggerValue>
    {
        private readonly FunctionDescriptor _descriptor;
        private readonly string _triggerParameterName;
        private readonly ITriggerBinding _triggerBinding;
        private readonly IReadOnlyDictionary<string, IBinding> _nonTriggerBindings;
        private readonly SingletonManager _singletonManager;

        public TriggeredFunctionBinding(FunctionDescriptor descriptor, string triggerParameterName, ITriggerBinding triggerBinding,
            IReadOnlyDictionary<string, IBinding> nonTriggerBindings, SingletonManager singletonManager)
        {
            _descriptor = descriptor;
            _triggerParameterName = triggerParameterName;
            _triggerBinding = triggerBinding;
            _nonTriggerBindings = nonTriggerBindings;
            _singletonManager = singletonManager;
        }

        public async Task<IReadOnlyDictionary<string, IValueProvider>> BindAsync(ValueBindingContext context, TTriggerValue value)
        {
            return await BindCoreAsync(context, value, null);
        }

        public async Task<IReadOnlyDictionary<string, IValueProvider>> BindAsync(ValueBindingContext context,
            IDictionary<string, object> parameters)
        {
            if (parameters == null || !parameters.ContainsKey(_triggerParameterName))
            {
                throw new InvalidOperationException("Missing value for trigger parameter '" + _triggerParameterName + "'.");
            }

            object value = parameters[_triggerParameterName];
            return await BindCoreAsync(context, value, parameters);
        }

        private async Task<IReadOnlyDictionary<string, IValueProvider>> BindCoreAsync(ValueBindingContext context, object value, IDictionary<string, object> parameters)
        {
            Dictionary<string, IValueProvider> valueProviders = new Dictionary<string, IValueProvider>();
            IValueProvider triggerProvider;
            IReadOnlyDictionary<string, object> bindingData;

            IValueBinder triggerReturnValueProvider= null;
            try
            {
                ITriggerData triggerData = await _triggerBinding.BindAsync(value, context);
                triggerProvider = triggerData.ValueProvider;
                bindingData = triggerData.BindingData;
                triggerReturnValueProvider = (triggerData as TriggerData)?.ReturnValueProvider;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exception)
            {
                triggerProvider = new BindingExceptionValueProvider(_triggerParameterName, exception);
                bindingData = null;
            }

            valueProviders.Add(_triggerParameterName, triggerProvider);

            // Bind Singleton if specified
            SingletonAttribute singletonAttribute = SingletonManager.GetFunctionSingletonOrNull(_descriptor, isTriggered: true);
            if (singletonAttribute != null)
            {
                string boundScopeId = _singletonManager.GetBoundScopeId(singletonAttribute.ScopeId, bindingData);
                IValueProvider singletonValueProvider = new SingletonValueProvider(_descriptor, boundScopeId, context.FunctionInstanceId.ToString(), singletonAttribute, _singletonManager);
                valueProviders.Add(SingletonValueProvider.SingletonParameterName, singletonValueProvider);
            }

            BindingContext bindingContext = FunctionBinding.NewBindingContext(context, bindingData, parameters);
            foreach (KeyValuePair<string, IBinding> item in _nonTriggerBindings)
            {
                string name = item.Key;
                IBinding binding = item.Value;
                IValueProvider valueProvider;

                try
                {
                    if (parameters != null && parameters.TryGetValue(name, out object parameterValue))
                    {
                        valueProvider = await binding.BindAsync(parameterValue, context);
                    }
                    else
                    {
                        valueProvider = await binding.BindAsync(bindingContext);
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    valueProvider = new BindingExceptionValueProvider(name, exception);
                }

                valueProviders.Add(name, valueProvider);
            }

            // Triggers can optionally process the return values of functions. They do so by declaring
            // a "$return" key in their binding data dictionary and mapping it to an IValueBinder.
            // An explicit return binding takes precedence over an implicit trigger binding. 
            if (!valueProviders.ContainsKey(FunctionIndexer.ReturnParamName))
            {
                if (triggerReturnValueProvider != null)
                {
                    valueProviders.Add(FunctionIndexer.ReturnParamName, triggerReturnValueProvider);
                }
            }

            return valueProviders;
        }      
    }
}
