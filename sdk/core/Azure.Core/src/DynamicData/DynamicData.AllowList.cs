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

                if (!IsAllowedType(value.GetType(), out bool needsValueCheck))
                {
                    throw new NotSupportedException($"Type is not currently supported: '{value.GetType()}'.");
                }

                if (needsValueCheck && !IsAllowedValue(value))
                {
                    throw new NotSupportedException($"Type contains unsupported object types: '{value.GetType()}'.");
                }
            }

            #region Allowed types
            public static bool IsAllowedType(Type type, out bool needsValueCheck)
            {
                if (IsAllowedKnownType(type, out needsValueCheck))
                {
                    return true;
                }

                return IsAllowedPocoType(type, new HashSet<Type>(), out needsValueCheck);
            }

            private static bool IsAllowedKnownType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

                if (type == typeof(object))
                {
                    needsValueCheck = true;
                    return true;
                }

                return IsAllowedPrimitive(type) ||
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    // We assume these were pre-validated
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||
                    type == typeof(DynamicData) ||
                    IsAllowedArrayType(type, out needsValueCheck) ||
                    IsAllowedCollectionType(type, out needsValueCheck) ||
                    IsAllowedEnumerableType(type, out needsValueCheck);
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

            private static bool IsAllowedArrayType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

                if (!type.IsArray)
                {
                    return false;
                }

                Type? elementType = type.GetElementType();
                return elementType != null && IsAllowedType(elementType, out needsValueCheck);
            }

            private static bool IsAllowedCollectionType(Type type, out bool needsValueCheck)
            {
                return
                    IsAllowedListType(type, out needsValueCheck) ||
                    IsAllowedDictionaryType(type, out needsValueCheck);
            }

            private static bool IsAllowedListType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() != typeof(List<>))
                {
                    return false;
                }

                Type[] types = type.GetGenericArguments();
                return IsAllowedType(types[0], out needsValueCheck);
            }

            private static bool IsAllowedDictionaryType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    Type[] types = type.GetGenericArguments();
                    bool firstArgNeedsCheck, secondArgNeedsCheck;
                    if (IsAllowedType(types[0], out firstArgNeedsCheck) &&
                        IsAllowedType(types[1], out secondArgNeedsCheck))
                    {
                        needsValueCheck = firstArgNeedsCheck || secondArgNeedsCheck;
                        return true;
                    }
                }

                return false;
            }

            private static bool IsAllowedEnumerableType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

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
                return IsAllowedType(types[0], out needsValueCheck);
            }

            private static bool IsAllowedPocoType(Type type, HashSet<Type> ancestorTypes, out bool needsValueCheck)
            {
                needsValueCheck = false;

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

                    if (IsAllowedKnownType(property.PropertyType, out needsValueCheck))
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
                    if (!IsAllowedPocoType(property.PropertyType, ancestorTypes, out needsValueCheck))
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

            #endregion

            #region Allowed values

            private static bool IsAllowedValue<T>(T value)
            {
                // If we got here, T must have a generic type holding an object somewhere in
                // the type graph, or a POCO with a property of that description.

                if (value == null)
                {
                    return true;
                }

                // GetType() should not return object. This is the base case for recursion.
                Type type = value.GetType();
                if (IsAllowedPrimitive(type))
                {
                    return true;
                }

                if (IsAllowedKnownType(type, out _))
                {
                    return IsAllowedKnownValue(value);
                }

                return IsAllowedPocoValue(value);
            }

            private static bool IsAllowedKnownValue<T>(T value)
            {
                return
                    IsAllowedArrayValue(value) ||
                    IsAllowedCollectionValue(value) ||
                    IsAllowedEnumerableValue(value);
            }

            private static bool IsAllowedArrayValue<T>(T value)
            {
                Type type = typeof(T);

                if (!type.IsArray)
                {
                    return false;
                }

                throw new NotImplementedException();
            }

            private static bool IsAllowedCollectionValue<T>(T value)
            {
                return IsAllowedListValue(value) || IsAllowedDictionaryValue(value);
            }

            private static bool IsAllowedListValue<T>(T value)
            {
                if (value == null)
                {
                    return true;
                }

                if (value is not IList list)
                {
                    return false;
                }

                return IsAllowedEnumerableValue(list);
            }

            private static bool IsAllowedDictionaryValue<T>(T value)
            {
                if (value == null)
                {
                    return true;
                }

                if (value is not IDictionary dictionary)
                {
                    return false;
                }

                if (!IsAllowedEnumerableValue(dictionary.Keys))
                {
                    return false;
                }

                if (!IsAllowedEnumerableValue(dictionary.Values))
                {
                    return false;
                }

                return true;
            }

            private static bool IsAllowedEnumerableValue<T>(T value)
            {
                if (value == null)
                {
                    return true;
                }

                if (value is not IEnumerable enumerable)
                {
                    return false;
                }

                foreach (var item in enumerable)
                {
                    if (!IsAllowedValue(item))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool IsAllowedPocoValue<T>(T value)
            {
                if (value is null)
                {
                    return true;
                }

                Type type = value.GetType();
                if (!IsAllowedPocoType(type, new HashSet<Type>(), out bool needsValueCheck))
                {
                    return false;
                }

                if (!needsValueCheck)
                {
                    return true;
                }

                foreach (PropertyInfo property in type.GetProperties())
                {
                    object? propertyValue = property.GetValue(value);
                    if (!IsAllowedValue(propertyValue))
                    {
                        return false;
                    }
                }

                return true;
            }

            #endregion
        }
    }
}
