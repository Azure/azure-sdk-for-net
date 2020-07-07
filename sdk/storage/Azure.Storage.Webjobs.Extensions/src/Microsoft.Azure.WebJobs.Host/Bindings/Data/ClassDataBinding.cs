// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal class ClassDataBinding<TBindingData> : IBinding
        where TBindingData : class
    {
        private static readonly IObjectToTypeConverter<TBindingData> Converter =
            ObjectToTypeConverterFactory.CreateForClass<TBindingData>();

        private readonly string _parameterName;
        private readonly IArgumentBinding<TBindingData> _argumentBinding;

        public ClassDataBinding(string parameterName, IArgumentBinding<TBindingData> argumentBinding)
        {
            _parameterName = parameterName;
            _argumentBinding = argumentBinding;
        }

        public bool FromAttribute
        {
            get { return false; }
        }

        private Task<IValueProvider> BindAsync(TBindingData bindingDataItem, ValueBindingContext context)
        {
            return _argumentBinding.BindAsync(bindingDataItem, context);
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            TBindingData typedValue;

            if (!Converter.TryConvert(value, out typedValue))
            {
                throw new InvalidOperationException("Unable to convert value to " + typeof(TBindingData).Name + ".");
            }

            return BindAsync(typedValue, context);
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var bindingData = context.BindingData;
            if (bindingData == null || !bindingData.ContainsKey(_parameterName))
            {
                throw new InvalidOperationException($"Binding data does not contain expected value '{_parameterName}'.");
            }

            object untypedValue = bindingData[_parameterName];
            if (!(untypedValue is TBindingData) && untypedValue != null)
            {
                throw new InvalidOperationException($"Binding data for '{_parameterName}' is not of expected type {typeof(TBindingData).Name}.");
            }

            return BindAsync((TBindingData)untypedValue, context.ValueContext);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new BindingDataParameterDescriptor
            {
                Name = _parameterName
            };
        }
    }
}
