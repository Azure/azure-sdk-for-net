// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal class ConverterArgumentBindingProvider<TBindingData, T> : IDataArgumentBindingProvider<TBindingData>
    {
        private readonly IConverter<TBindingData, T> _converter;

        public ConverterArgumentBindingProvider(IConverter<TBindingData, T> converter)
        {
            _converter = converter;
        }

        public IArgumentBinding<TBindingData> TryCreate(ParameterInfo parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            if (parameter.ParameterType != typeof(T))
            {
                return null;
            }

            return new ConverterArgumentBinding(_converter);
        }

        internal class ConverterArgumentBinding : IArgumentBinding<TBindingData>
        {
            private readonly IConverter<TBindingData, T> _converter;

            public ConverterArgumentBinding(IConverter<TBindingData, T> converter)
            {
                _converter = converter;
            }

            public Type ValueType
            {
                get { return typeof(T); }
            }

            public Task<IValueProvider> BindAsync(TBindingData value, ValueBindingContext context)
            {
                object converted = _converter.Convert(value);
                IValueProvider provider = new ObjectValueProvider(converted, typeof(T));
                return Task.FromResult(provider);
            }
        }
    }
}
