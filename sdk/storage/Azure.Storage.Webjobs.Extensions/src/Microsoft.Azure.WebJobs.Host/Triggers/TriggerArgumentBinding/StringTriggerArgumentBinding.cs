// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    // Bind TMessage --> String. Use IConverterManager for the conversion. 
    internal class StringTriggerArgumentBinding<TMessage, TTriggerValue> : SimpleTriggerArgumentBinding<TMessage, TTriggerValue>
    {
        public StringTriggerArgumentBinding(ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy, IConverterManager converterManager) : 
            base(bindingStrategy, converterManager)
        {
            this.ElementType = typeof(string);
        }

        internal override Task<object> ConvertAsync(
            TMessage value,
            Dictionary<string, object> bindingData,
            ValueBindingContext context)
        {
            var obj = ConvertToStringAsync(value);
            return Task.FromResult<object>(obj);
        }
    }
}