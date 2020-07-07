// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Host
{
    // Bind EventData to itself 
    internal class SimpleTriggerArgumentBinding<TMessage, TTriggerValue> : ITriggerDataArgumentBinding<TTriggerValue>
    {
        private readonly ITriggerBindingStrategy<TMessage, TTriggerValue> _triggerBindingStrategy;
        private readonly IConverterManager _converterManager;
        private readonly FuncAsyncConverter<TMessage, string> _stringConverter;

        public SimpleTriggerArgumentBinding(
            ITriggerBindingStrategy<TMessage, TTriggerValue> triggerBindingStrategy, 
            IConverterManager converterManager, 
            bool isSingleDispatch = true)
        {
            this._triggerBindingStrategy = triggerBindingStrategy;
            this.Contract = TriggerBindingStrategy.GetBindingContract(isSingleDispatch);
            this.ElementType = typeof(TMessage);
            _converterManager = converterManager;
            _stringConverter = _converterManager.GetConverter<TMessage, string, Attribute>();
        }

        /// <summary>
        /// The binding data contract
        /// </summary>
        protected Dictionary<string, Type> Contract { get; set; }

        /// <summary>
        /// The target type being bound to.
        /// </summary>
        protected internal Type ElementType { get; set; }

        protected ITriggerBindingStrategy<TMessage, TTriggerValue> TriggerBindingStrategy
        {
            get
            {
                return _triggerBindingStrategy;
            }
        }

        IReadOnlyDictionary<string, Type> ITriggerDataArgumentBinding<TTriggerValue>.BindingDataContract
        {
            get
            {
                return Contract;
            }
        }

        public Type ValueType
        {
            get
            {
                return typeof(TTriggerValue);
            }
        }

        internal virtual Task<object> ConvertAsync(TMessage value, Dictionary<string, object> bindingData, ValueBindingContext context)
        {
            return Task.FromResult<object>(value);
        }

        protected async Task<string> ConvertToStringAsync(TMessage eventData)
        {
            var val = await _stringConverter(eventData, null, null);
            return val;
        }

        public virtual async Task<ITriggerData> BindAsync(TTriggerValue value, ValueBindingContext context)
        {
            // get the initial binding data for the value
            var bindingData = TriggerBindingStrategy.GetBindingData(value);

            // bind to the event to get the trigger result
            var eventData = TriggerBindingStrategy.BindSingle(value, context);

            // apply conversions to get the target type bound to
            // by the function
            object userValue = await ConvertAsync(eventData, bindingData, context);

            string invokeString = await ConvertToStringAsync(eventData);
            var valueProvider = new ConstantValueProvider(userValue, this.ElementType, invokeString);

            return new TriggerData(valueProvider, bindingData);
        }

        /// <summary>
        /// Extend the binding contract <see cref="Contract"/> with contract members from
        /// the specified contract.
        /// </summary>
        /// <param name="provider">The <see cref="IBindingDataProvider"/> to use.</param>
        protected void AddToBindingContract(IBindingDataProvider provider)
        {
            if (provider != null)
            {
                // Binding data from Poco properties takes precedence over built-ins
                foreach (var kv in provider.Contract)
                {
                    Contract[kv.Key] = kv.Value;
                }
            }
        }

        /// <summary>
        /// Apply binding data from the specified provider to the binding data collection.
        /// </summary>
        /// <param name="provider">The <see cref="IBindingDataProvider"/> to use.</param>
        /// <param name="bindingData">The binding data collection to modify.</param>
        /// <param name="obj">The source object to pull binding data from.</param>
        protected void AddToBindingData(IBindingDataProvider provider, Dictionary<string, object> bindingData, object obj)
        {
            if (bindingData != null && provider != null)
            {
                var data = provider.GetBindingData(obj);
                foreach (var kv in data)
                {
                    bindingData[kv.Key] = kv.Value;
                }
            }
        }
    }
}