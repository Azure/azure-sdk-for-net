// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.ComponentModel;
using System.Globalization;

namespace DataFactory.Tests.Framework
{
    public abstract class ValueWrapper
    {
        public abstract object GetValue();

        public override string ToString()
        {
            return Convert.ToString(this.GetValue(), CultureInfo.CurrentCulture);
        }

        public static bool TryConvertToType<TActual, TExpected>(TActual value, out TExpected convertedValue)
        {
            convertedValue = default(TExpected);

            if (value == null)
            {
                return true;
            }

            // Try to convert the value to the expected type
            Type expectedType = typeof(TExpected);

            object tempConvertedValue;
            if (ValueWrapper.TryConvertToType(value, expectedType, out tempConvertedValue))
            {
                convertedValue = (TExpected)tempConvertedValue;
                return true;
            }

            return false;
        }

        public static bool TryConvertToType(object value, Type expectedType, out object convertedValue)
        {
            convertedValue = null;

            if (value == null)
            {
                return false;
            }

            Type actualType = value.GetType();

            // Try to convert the value to the expected type
            TypeConverter expectedConverter = TypeDescriptor.GetConverter(expectedType);
            TypeConverter actualConverter = TypeDescriptor.GetConverter(actualType);

            if (expectedConverter.CanConvertFrom(actualType))
            {
                try
                {
                    convertedValue = expectedConverter.ConvertFrom(value);
                    if (convertedValue is DateTime)
                    {
                        if (((DateTime)convertedValue).Kind == DateTimeKind.Unspecified)
                        {
                            convertedValue = new DateTime(((DateTime)convertedValue).Ticks, DateTimeKind.Utc);
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    // Couldn't convert the value to the expected type, for whatever reason. Just swallow the exception.
                }
            }

            if (actualConverter.CanConvertTo(expectedType))
            {
                try
                {
                    convertedValue = actualConverter.ConvertTo(value, expectedType);
                    return true;
                }
                catch (Exception)
                {
                    // Couldn't convert the value to the expected type, for whatever reason. Just swallow the exception.
                }
            }

            return false;
        }
    }
}
