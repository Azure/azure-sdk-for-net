// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    public partial class DynamicData
    {
        internal class AllowList
        {
            public static void AssertAllowedType<T>(T value)
            {
                if (value == null)
                {
                    return;
                }

                if (!IsAllowedType(value.GetType()))
                {
                    throw new NotSupportedException($"Type is not currently supported: '{value.GetType()}'.");
                }
            }

            public static bool IsAllowedType(Type type)
            {
                if (IsAllowedKnownType(type))
                {
                    return true;
                }

                return IsAllowedPocoType(type, new HashSet<Type>());
            }

            private static bool IsAllowedKnownType(Type type)
            {
                if (type == typeof(object))
                {
                    return true;
                }

                return IsAllowedPrimitive(type) ||
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    // We assume these were pre-validated
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||
                    type == typeof(DynamicData) ||
                    IsAllowedArrayType(type) ||
                    IsAllowedCollectionType(type) ||
                    IsAllowedEnumerableType(type);
            }

            private static bool IsAllowedPrimitive(Type type)
            {
                return
                    type.IsPrimitive ||
                    type == typeof(decimal) ||
                    type == typeof(string) ||
                    type == typeof(DateTime) ||
                    type == typeof(DateTimeOffset) ||
                    type == typeof(TimeSpan) ||
                    type == typeof(Uri) ||
                    type == typeof(Guid) ||
                    type == typeof(ETag);
            }

            private static bool IsAllowedArrayType(Type type)
            {
                if (!type.IsArray)
                {
                    return false;
                }

                Type? elementType = type.GetElementType();
                return elementType != null && IsAllowedType(elementType);
            }

            private static bool IsAllowedCollectionType(Type type)
            {
                return
                    IsAllowedListType(type) ||
                    IsAllowedDictionaryType(type);
            }

            private static bool IsAllowedListType(Type type)
            {
                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() != typeof(List<>))
                {
                    return false;
                }

                Type[] types = type.GetGenericArguments();
                return IsAllowedType(types[0]);
            }

            private static bool IsAllowedDictionaryType(Type type)
            {
                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    Type[] types = type.GetGenericArguments();
                    if (IsAllowedType(types[0]) && IsAllowedType(types[1]))
                    {
                        return true;
                    }
                }

                return false;
            }

            private static bool IsAllowedEnumerableType(Type type)
            {
                if (!type.IsGenericType)
                {
                    return false;
                }

                if (!type.IsInterface)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() != typeof(IEnumerable<>))
                {
                    return false;
                }

                Type[] types = type.GetGenericArguments();
                return IsAllowedType(types[0]);
            }

            private static bool IsAllowedPocoType(Type type, HashSet<Type> ancestorTypes)
            {
                if (!HasPublicParameterlessConstructor(type) && !IsAnonymousType(type))
                {
                    return false;
                }

                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (!property.CanRead)
                    {
                        return false;
                    }

                    if (!property.CanWrite && !IsAnonymousType(type))
                    {
                        return false;
                    }

                    if (IsAllowedKnownType(property.PropertyType))
                    {
                        continue;
                    }

                    // Trust but verify
                    if (ancestorTypes.Contains(property.PropertyType))
                    {
                        continue;
                    }

                    // Recurse
                    ancestorTypes.Add(type);
                    if (!IsAllowedPocoType(property.PropertyType, ancestorTypes))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool HasPublicParameterlessConstructor(Type type)
            {
                return type.GetConstructor(Type.EmptyTypes) != null;
            }

            private static bool IsAnonymousType(Type type)
            {
                return
                    type.Namespace == null &&
                    Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false);
            }
        }
    }
}
