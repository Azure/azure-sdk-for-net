// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
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

                if (IsAllowedLeafType(type))
                {
                    return true;
                }

                if (IsAllowedCollectionValue(type, value))
                {
                    return true;
                }

                return IsAllowedAnonymousValue(type, value, null, 0);
            }

            private static bool IsAllowedLeafType(Type type)
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

                    // Allowable for DynamicData assignments.
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||
                    type == typeof(DynamicData);
            }

            private static bool IsAllowedNonInheritableType(Type type)
            {
                return (type.IsValueType || type.IsSealed) &&
                    IsAllowedLeafType(type);
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

                if (IsAllowedNonInheritableType(elementType))
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

                Type elementType = type.GetGenericArguments()[0];
                if (IsAllowedNonInheritableType(elementType))
                {
                    return true;
                }

                return IsAllowedEnumerableValue(elementType, (IEnumerable)value);
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

                Type[] types = type.GetGenericArguments();
                if (types[0] != typeof(string))
                {
                    return false;
                }

                if (IsAllowedNonInheritableType(types[1]))
                {
                    return true;
                }

                return IsAllowedEnumerableValue(types[1], ((IDictionary)value).Values);
            }

            private static bool IsAllowedEnumerableValue(Type elementType, IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    // Don't allow heterogenous collections
                    if (item.GetType() != elementType)
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

            private static bool IsAllowedAnonymousValue<T>(Type type, T value, Type[]? visited, int depth)
            {
                if (!IsAnonymousType(type))
                {
                    return false;
                }

                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (IsAllowedLeafType(property.PropertyType))
                    {
                        continue;
                    }

                    object? propertyValue = property.GetValue(value);
                    if (IsAllowedCollectionValue(property.PropertyType, propertyValue))
                    {
                        continue;
                    }

                    // Detect cycles: trust but verify
                    if (ContainsType(visited, depth, property.PropertyType))
                    {
                        continue;
                    }

                    // Recurse
                    visited = AddType(visited, depth, type);
                    if (!IsAllowedAnonymousValue(property.PropertyType, propertyValue, visited, depth + 1))
                    {
                        return false;
                    }

                    if (depth == 0 && visited != null)
                    {
                        // We're back at the top of the stack
                        ArrayPool<Type>.Shared.Return(visited);
                    }
                }

                return true;
            }

            private static bool IsAnonymousType(Type type)
            {
                return type.Name.StartsWith("<>f__AnonymousType");
            }

            private static bool ContainsType(Type[]? types, int count, Type type)
            {
                if (types == null)
                {
                    return false;
                }

                for (int i = 0; i < count; i++)
                {
                    if (types[i] == type)
                    {
                        return true;
                    }
                }

                return false;
            }

            private const int _expandIncrement = 16;
            private static Type[] AddType(Type[]? types, int count, Type type)
            {
                if (count % _expandIncrement == 0)
                {
                    int length = types == null ? 0 : types.Length;
                    Type[] expanded = ArrayPool<Type>.Shared.Rent(length + _expandIncrement);

                    if (types is not null)
                    {
                        Array.Copy(types, expanded, length);
                        ArrayPool<Type>.Shared.Return(types);
                    }

                    types = expanded;
                }

                types![count] = type;
                return types;
            }
        }
    }
}
