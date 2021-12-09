// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class ConverterPropertySetter<TReflected, TProperty, TConvertedProperty>
        : IPropertySetter<TReflected, TConvertedProperty>
    {
        private readonly IConverter<TConvertedProperty, TProperty> _converter;
        private readonly IPropertySetter<TReflected, TProperty> _propertySetter;

        public ConverterPropertySetter(IConverter<TConvertedProperty, TProperty> converter,
            IPropertySetter<TReflected, TProperty> propertySetter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _propertySetter = propertySetter ?? throw new ArgumentNullException(nameof(propertySetter));
        }

        public void SetValue(ref TReflected instance, TConvertedProperty value)
        {
            TProperty propertyValue = _converter.Convert(value);
            _propertySetter.SetValue(ref instance, propertyValue);
        }
    }
}