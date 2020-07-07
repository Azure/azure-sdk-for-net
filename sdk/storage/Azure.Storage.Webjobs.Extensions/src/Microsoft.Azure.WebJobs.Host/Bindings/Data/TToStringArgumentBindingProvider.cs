// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal class TToStringArgumentBindingProvider<TBindingData> : IDataArgumentBindingProvider<TBindingData>
    {
        public IArgumentBinding<TBindingData> TryCreate(ParameterInfo parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            if (parameter.ParameterType != typeof(string))
            {
                return null;
            }

            IConverter<TBindingData, string> converter = TToStringConverterFactory.TryCreate<TBindingData>();

            if (converter == null)
            {
                return null;
            }

            return new TToStringArgumentBinding(converter);
        }

        private class TToStringArgumentBinding : IArgumentBinding<TBindingData>
        {
            private readonly IConverter<TBindingData, string> _converter;

            public TToStringArgumentBinding(IConverter<TBindingData, string> converter)
            {
                _converter = converter;
            }

            public Type ValueType
            {
                get { return typeof(string); }
            }

            public Task<IValueProvider> BindAsync(TBindingData value, ValueBindingContext context)
            {
                object converted = _converter.Convert(value);
                IValueProvider provider = new ObjectValueProvider(converted, typeof(string));
                return Task.FromResult(provider);
            }
        }
    }
}
