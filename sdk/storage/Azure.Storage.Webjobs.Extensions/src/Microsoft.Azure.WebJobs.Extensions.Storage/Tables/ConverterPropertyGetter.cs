// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal class ConverterPropertyGetter<TReflected, TProperty, TConvertedProperty>
        : IPropertyGetter<TReflected, TConvertedProperty>
    {
        private readonly IPropertyGetter<TReflected, TProperty> _propertyGetter;
        private readonly IConverter<TProperty, TConvertedProperty> _converter;

        public ConverterPropertyGetter(IPropertyGetter<TReflected, TProperty> propertyGetter,
            IConverter<TProperty, TConvertedProperty> converter)
        {
            if (propertyGetter == null)
            {
                throw new ArgumentNullException("propertyGetter");
            }
            
            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }

            _converter = converter;
            _propertyGetter = propertyGetter;
        }

        public TConvertedProperty GetValue(TReflected instance)
        {
            TProperty propertyValue = _propertyGetter.GetValue(instance);
            return _converter.Convert(propertyValue);
        }
    }
}
