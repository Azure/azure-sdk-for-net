// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    public partial class DynamicData
    {
        internal class AllowList
        {
            public static void AssertAllowedValue<T>(T value)
            {
                if (value == null)
                {
                    return;
                }

                if (!IsAllowedValue(value))
                {
                    throw new NotSupportedException($"Assigning this value is not supported, either because its type '{value.GetType()}' is not allowed, or because it contains unallowed types.");
                }
            }

            private static bool IsAllowedValue<T>(T value)
            {
                if (value == null)
                {
                    return true;
                }

                Type type = value.GetType();
                if (IsAllowedType(type))
                {
                    return true;
                }

                if (IsAllowedCollectionValue(type, value))
                {
                    return true;
                }

                return IsAllowedAnonymousValue(type, value);
            }

            private static bool IsAllowedType(Type type)
            {
                return type.IsPrimitive ||
                    type == typeof(decimal) ||
                    type == typeof(string) ||
                    type == typeof(DateTime) ||
                    type == typeof(DateTimeOffset) ||
                    type == typeof(TimeSpan) ||
                    type == typeof(Uri) ||
                    type == typeof(Guid) ||
                    type == typeof(ETag) ||
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    type == typeof(DynamicData);
            }

            private static bool IsAllowedCollectionValue<T>(Type type, T value)
            {
                return
                    IsAllowedArrayValue(type, value) ||
                    IsAllowedListValue(type, value) ||
                    IsAllowedDictionaryValue(type, value);
            }

            private static bool IsAllowedArrayValue<T>(Type type, T value)
            {
                if (value is not Array array)
                {
                    return false;
                }

                Type? elementType = type.GetElementType();
                if (elementType == null)
                {
                    return false;
                }

                if (elementType.IsPrimitive || elementType == typeof(string))
                {
                    return true;
                }

                return IsAllowedEnumerableValue(elementType, array);
            }

            private static bool IsAllowedListValue<T>(Type type, T value)
            {
                if (value == null)
                {
                    return true;
                }

                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() != typeof(List<>))
                {
                    return false;
                }

                Type genericArgument = type.GetGenericArguments()[0];
                if (genericArgument.IsPrimitive || genericArgument == typeof(string))
                {
                    return true;
                }

                return IsAllowedEnumerableValue(genericArgument, (IEnumerable)value);
            }

            private static bool IsAllowedDictionaryValue<T>(Type type, T value)
            {
                if (value == null)
                {
                    return true;
                }

                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() != typeof(Dictionary<,>))
                {
                    return false;
                }

                Type[] genericArguments = type.GetGenericArguments();
                if (genericArguments[0] != typeof(string))
                {
                    return false;
                }

                if (genericArguments[1].IsPrimitive || genericArguments[1] == typeof(string))
                {
                    return true;
                }

                return IsAllowedEnumerableValue(genericArguments[1], ((IDictionary)value).Values);
            }

            private static bool IsAllowedEnumerableValue(Type elementType, IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    // Don't allow heterogenous collections,
                    // unless the types it's holding are allowed types.
                    if (item.GetType() != elementType && !IsAllowedType(item.GetType()))
                    {
                        return false;
                    }

                    if (!IsAllowedValue(item))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool IsAllowedAnonymousValue<T>(Type type, T value)
            {
                if (!IsAnonymousType(type))
                {
                    return false;
                }

                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (!IsAllowedValue(property.GetValue(value)))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool IsAnonymousType(Type type)
            {
                return type.Name.StartsWith("<>f__AnonymousType");
            }
        }
    }
}
