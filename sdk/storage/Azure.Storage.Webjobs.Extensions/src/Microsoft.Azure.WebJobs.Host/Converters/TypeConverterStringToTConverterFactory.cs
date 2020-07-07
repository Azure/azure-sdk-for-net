// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class TypeConverterStringToTConverterFactory : IStringToTConverterFactory
    {
        public IConverter<string, TOutput> TryCreate<TOutput>()
        {
            TypeConverter typeConverter = GetTypeConverter(typeof(TOutput));

            if (typeConverter == null)
            {
                return null;
            }

            if (!typeConverter.CanConvertFrom(typeof(string)))
            {
                return null;
            }

            return new TypeConverterStringToTConverter<TOutput>(typeConverter);
        }

        // BCL implementation may get wrong converters
        // It appears to use Type.GetType() to find a converter, and so has trouble looking up converters from different
        // loader contexts.
        private static TypeConverter GetTypeConverter(Type type)
        {
            // $$$ There has got to be a better way than this to make TypeConverters work.
            foreach (TypeConverterAttribute attr in type.GetCustomAttributes(typeof(TypeConverterAttribute), false))
            {
                string assemblyQualifiedName = attr.ConverterTypeName;
                if (!string.IsNullOrWhiteSpace(assemblyQualifiedName))
                {
                    // Type.GetType() may fail due to loader context issues.
                    string assemblyName = type.Assembly.FullName;

                    if (assemblyQualifiedName.EndsWith(assemblyName, StringComparison.OrdinalIgnoreCase))
                    {
                        int i = assemblyQualifiedName.IndexOf(',');
                        if (i > 0)
                        {
                            string typename = assemblyQualifiedName.Substring(0, i);

                            var a = type.Assembly;
                            var t2 = a.GetType(typename); // lookup type name relative to the 
                            if (t2 != null)
                            {
                                var instance = Activator.CreateInstance(t2);
                                return (TypeConverter)instance;
                            }
                        }
                    }
                }
            }

            return TypeDescriptor.GetConverter(type);
        }
    }
}
