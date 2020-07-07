// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Bind to a POCO Type using JSON deserialization. Populate binding contract with POCO members.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <typeparam name="TTriggerValue"></typeparam>
    internal class PocoTriggerArgumentBinding<TMessage, TTriggerValue> : StringTriggerArgumentBinding<TMessage, TTriggerValue>
    {
        private IBindingDataProvider _bindingDataProvider;

        public PocoTriggerArgumentBinding(ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy, IConverterManager converterManager, Type elementType) : 
            base(bindingStrategy, converterManager)
        {
            this.ElementType = elementType;

            _bindingDataProvider = BindingDataProvider.FromType(elementType);
            AddToBindingContract(_bindingDataProvider);
        }

        internal override async Task<object> ConvertAsync(
            TMessage value,
            Dictionary<string, object> bindingData,
            ValueBindingContext context)
        {
            var obj = await ReadObjectAsync(value);

            AddToBindingData(_bindingDataProvider, bindingData, obj);

            return obj;
        }

        private async Task<object> ReadObjectAsync(TMessage value)
        {
            string json = await this.ConvertToStringAsync(value);

            object obj;
            try
            {
                obj = JsonConvert.DeserializeObject(json, this.ElementType);
            }
            catch (JsonException e)
            {
                // Easy to have the queue payload not deserialize properly. So give a useful error. 
                string msg = string.Format(CultureInfo.CurrentCulture,
@"Binding parameters to complex objects (such as '{0}') uses Json.NET serialization. 
1. Bind the parameter type as 'string' instead of '{0}' to get the raw values and avoid JSON deserialization, or
2. Change the queue payload to be valid json. The JSON parser failed: {1}
", this.ElementType.Name, e.Message);
                throw new InvalidOperationException(msg);
            }

            return obj;
        }
    }
}