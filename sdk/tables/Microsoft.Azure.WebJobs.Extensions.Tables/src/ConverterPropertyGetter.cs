// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class ConverterPropertyGetter<TReflected, TProperty, TConvertedProperty>
        : IPropertyGetter<TReflected, TConvertedProperty>
    {
        private readonly IPropertyGetter<TReflected, TProperty> _propertyGetter;
        private readonly IConverter<TProperty, TConvertedProperty> _converter;

        public ConverterPropertyGetter(IPropertyGetter<TReflected, TProperty> propertyGetter,
            IConverter<TProperty, TConvertedProperty> converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _propertyGetter = propertyGetter ?? throw new ArgumentNullException(nameof(propertyGetter));
        }

        public TConvertedProperty GetValue(TReflected instance)
        {
            TProperty propertyValue = _propertyGetter.GetValue(instance);
            return _converter.Convert(propertyValue);
        }
    }
}