// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class ArrayTriggerArgumentBinding<TMessage, TTriggerValue> : SimpleTriggerArgumentBinding<TMessage, TTriggerValue>
    {
        private readonly SimpleTriggerArgumentBinding<TMessage, TTriggerValue> _innerBinding;

        public ArrayTriggerArgumentBinding(
            ITriggerBindingStrategy<TMessage, TTriggerValue> triggerBindingStrategy,
            SimpleTriggerArgumentBinding<TMessage, TTriggerValue> innerBinding,
            IConverterManager converterManager) : base(triggerBindingStrategy, converterManager, false)
        {
            this._innerBinding = innerBinding;
        }

        public override async Task<ITriggerData> BindAsync(TTriggerValue value, ValueBindingContext context)
        {
            Dictionary<string, object> bindingData = TriggerBindingStrategy.GetBindingData(value);

            TMessage[] arrayRaw = TriggerBindingStrategy.BindMultiple(value, context);

            int len = arrayRaw.Length;
            Type elementType = _innerBinding.ElementType;

            var arrayUser = Array.CreateInstance(elementType, len);
            for (int i = 0; i < len; i++)
            {
                TMessage item = arrayRaw[i];
                object obj = await _innerBinding.ConvertAsync(item, null, context);
                arrayUser.SetValue(obj, i);
            }
            Type arrayType = elementType.MakeArrayType();

            IValueProvider valueProvider = new ConstantValueProvider(arrayUser, arrayType, "???");
            var triggerData = new TriggerData(valueProvider, bindingData);
            return triggerData;
        }
    }
}