// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal class StringToTArgumentBindingProvider<TBindingData> : IDataArgumentBindingProvider<TBindingData>
    {
        public IArgumentBinding<TBindingData> TryCreate(ParameterInfo parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            if (typeof(TBindingData) != typeof(string))
            {
                return null;
            }

            Type parameterType = parameter.ParameterType;

            return (IArgumentBinding<TBindingData>)TryCreateBinding(parameterType);
        }

        private static IArgumentBinding<string> TryCreateBinding(Type itemType)
        {
            MethodInfo method = typeof(StringToTArgumentBindingProvider<TBindingData>).GetMethod(
                "TryCreateBindingGeneric", BindingFlags.NonPublic | BindingFlags.Static);
            Debug.Assert(method != null);
            MethodInfo genericMethod = method.MakeGenericMethod(itemType);
            Debug.Assert(genericMethod != null);
            Func<IArgumentBinding<string>> lambda = (Func<IArgumentBinding<string>>)Delegate.CreateDelegate(
                typeof(Func<IArgumentBinding<string>>), genericMethod);

            return lambda.Invoke();
        }

        private static IArgumentBinding<string> TryCreateBindingGeneric<TOutput>()
        {
            IConverter<string, TOutput> converter = StringToTConverterFactory.Instance.TryCreate<TOutput>();

            if (converter == null)
            {
                return null;
            }

            return new StringToTArgumentBinding<TOutput>(converter);
        }

        private class StringToTArgumentBinding<TOutput> : IArgumentBinding<string>
        {
            private readonly IConverter<string, TOutput> _converter;

            public StringToTArgumentBinding(IConverter<string, TOutput> converter)
            {
                _converter = converter;
            }

            public Type ValueType
            {
                get { return typeof(TOutput); }
            }

            public Task<IValueProvider> BindAsync(string value, ValueBindingContext context)
            {
                TOutput converted = _converter.Convert(value);
                IValueProvider provider = new ObjectValueProvider(converted, typeof(TOutput));
                return Task.FromResult(provider);
            }
        }
    }
}
