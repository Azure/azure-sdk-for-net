// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

                Type type = value.GetType();

                if (!IsAllowedType(type))
                {
                    throw new NotSupportedException($"Type is not currently supported: '{type}'.");
                }
            }

            public static bool IsAllowedType(Type type)
            {
                if (IsAllowedPrimitive(type))
                {
                    return true;
                }

                if (IsAllowedCollectionType(type))
                {
                    return true;
                }

                return IsAllowedAnonymousType(type, new HashSet<Type>());
            }

            // Primitive means "not a collection and not a POCO"
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
                    type == typeof(ETag) ||

                    // Allowable for DynamicData assignments.
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||
                    type == typeof(DynamicData);
            }

            private static bool IsAllowedCollectionType(Type type)
            {
                return
                    IsAllowedArrayType(type) ||
                    IsAllowedListType(type) ||
                    IsAllowedDictionaryType(type);
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
                    if (types[0] == typeof(string) && IsAllowedType(types[1]))
                    {
                        return true;
                    }
                }

                return false;
            }

            private static bool IsAllowedAnonymousType(Type type, HashSet<Type> ancestorTypes)
            {
                if (!IsAnonymousType(type))
                {
                    return false;
                }

                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (IsAllowedPrimitive(property.PropertyType))
                    {
                        continue;
                    }

                    if (IsAllowedCollectionType(property.PropertyType))
                    {
                        continue;
                    }

                    // Detect cycles: trust but verify
                    if (ancestorTypes.Contains(property.PropertyType))
                    {
                        continue;
                    }

                    // Recurse
                    ancestorTypes.Add(type);
                    if (!IsAllowedAnonymousType(property.PropertyType, ancestorTypes))
                    {
                        return false;
                    }
                }

                return true;
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
