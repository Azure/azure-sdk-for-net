// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Extensions.Tables.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal static class EntityPropertyToTConverterFactory
    {
        public static IConverter<EntityProperty, TOutput> Create<TOutput>()
        {
            if (typeof(TOutput) == typeof(EntityProperty))
            {
                return (IConverter<EntityProperty, TOutput>)new IdentityConverter<EntityProperty>();
            }

            if (typeof(TOutput) == typeof(bool))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToBooleanConverter();
            }

            if (typeof(TOutput) == typeof(bool?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableBooleanConverter();
            }

            if (typeof(TOutput) == typeof(byte[]))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToByteArrayConverter();
            }

            if (typeof(TOutput) == typeof(DateTime))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToDateTimeConverter();
            }

            if (typeof(TOutput) == typeof(DateTime?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableDateTimeConverter();
            }

            if (typeof(TOutput) == typeof(DateTimeOffset))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToDateTimeOffsetConverter();
            }

            if (typeof(TOutput) == typeof(DateTimeOffset?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableDateTimeOffsetConverter();
            }

            if (typeof(TOutput) == typeof(double))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToDoubleConverter();
            }

            if (typeof(TOutput) == typeof(double?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableDoubleConverter();
            }

            if (typeof(TOutput) == typeof(Guid))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToGuidConverter();
            }

            if (typeof(TOutput) == typeof(Guid?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableGuidConverter();
            }

            if (typeof(TOutput) == typeof(int))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToInt32Converter();
            }

            if (typeof(TOutput) == typeof(int?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableInt32Converter();
            }

            if (typeof(TOutput) == typeof(long))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToInt64Converter();
            }

            if (typeof(TOutput) == typeof(long?))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToNullableInt64Converter();
            }

            if (typeof(TOutput) == typeof(string))
            {
                return (IConverter<EntityProperty, TOutput>)new EntityPropertyToStringConverter();
            }

            if (typeof(TOutput).IsEnum)
            {
                return new EntityPropertyToEnumConverter<TOutput>();
            }

            if (typeof(TOutput).IsGenericType && typeof(TOutput).GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type nullableElementType = typeof(TOutput).GetGenericArguments()[0];
                if (nullableElementType.IsEnum)
                {
                    return CreateNullableEnumConverter<TOutput>(nullableElementType);
                }
            }

            return new EntityPropertyToPocoConverter<TOutput>();
        }

        private static IConverter<EntityProperty, TOutput> CreateNullableEnumConverter<TOutput>(Type enumType)
        {
            Type genericType = typeof(EntityPropertyToNullableEnumConverter<>).MakeGenericType(enumType);
            return (IConverter<EntityProperty, TOutput>)Activator.CreateInstance(genericType);
        }
    }
}