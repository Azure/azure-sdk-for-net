// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Extensions.Tables.Converters;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal static class TToEntityPropertyConverterFactory
    {
        public static IConverter<TInput, EntityProperty> Create<TInput>()
        {
            if (typeof(TInput) == typeof(EntityProperty))
            {
                return (IConverter<TInput, EntityProperty>)new IdentityConverter<EntityProperty>();
            }

            if (typeof(TInput) == typeof(bool))
            {
                return (IConverter<TInput, EntityProperty>)new BooleanToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(bool?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableBooleanToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(byte[]))
            {
                return (IConverter<TInput, EntityProperty>)new ByteArrayToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(DateTime))
            {
                return (IConverter<TInput, EntityProperty>)new DateTimeToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(DateTime?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableDateTimeToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(DateTimeOffset))
            {
                return (IConverter<TInput, EntityProperty>)new DateTimeOffsetToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(DateTimeOffset?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableDateTimeOffsetToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(double))
            {
                return (IConverter<TInput, EntityProperty>)new DoubleToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(double?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableDoubleToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(Guid))
            {
                return (IConverter<TInput, EntityProperty>)new GuidToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(Guid?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableGuidToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(int))
            {
                return (IConverter<TInput, EntityProperty>)new Int32ToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(int?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableInt32ToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(long))
            {
                return (IConverter<TInput, EntityProperty>)new Int64ToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(long?))
            {
                return (IConverter<TInput, EntityProperty>)new NullableInt64ToEntityPropertyConverter();
            }

            if (typeof(TInput) == typeof(string))
            {
                return (IConverter<TInput, EntityProperty>)new StringToEntityPropertyConverter();
            }

            if (typeof(TInput).IsEnum)
            {
                return new EnumToEntityPropertyConverter<TInput>();
            }

            if (typeof(TInput).IsGenericType && typeof(TInput).GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type nullableElementType = typeof(TInput).GetGenericArguments()[0];
                if (nullableElementType.IsEnum)
                {
                    return CreateNullableEnumConverter<TInput>(nullableElementType);
                }
            }

            return new PocoToEntityPropertyConverter<TInput>();
        }

        private static IConverter<TInput, EntityProperty> CreateNullableEnumConverter<TInput>(Type enumType)
        {
            Type genericType = typeof(NullableEnumToEntityPropertyConverter<>).MakeGenericType(enumType);
            return (IConverter<TInput, EntityProperty>)Activator.CreateInstance(genericType);
        }
    }
}