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

                if (!IsAllowedType(value.GetType(), value))
                {
                    throw new NotSupportedException($"Type is not currently supported: '{value.GetType()}'.");
                }

                // TODO: validate types in collections
            }

            public static bool IsAllowedType<T>(Type type, T value)
            {
                if (IsAllowedKnownType(type, value))
                {
                    return true;
                }

                return IsAllowedPoco(type, value, new HashSet<Type>());
            }

            private static bool IsAllowedKnownType<T>(Type type, T value)
            {
                return IsAllowedPrimitive(type) ||
                    IsAllowedArray(type, value) ||
                    IsAllowedCollection(type, value) ||
                    IsAllowedInterface(type) ||

                    // TODO: separate out non-primitive values?
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||
                    type == typeof(DynamicData);
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

            private static bool IsAllowedArray<T>(Type type, T value)
            {
                if (!type.IsArray)
                {
                    return false;
                }

                if (type == typeof(object[]))
                {
                    object[] objects = GetAs<object[]>(value!);
                    foreach (object obj in objects)
                    {
                        if (obj is null)
                        {
                            continue;
                        }

                        if (!IsAllowedType(obj.GetType(), obj))
                        {
                            return false;
                        }
                    }
                }

                Type? elementType = type.GetElementType();
                return elementType != null && IsAllowedType(elementType, value);
            }

            // TODO: Test case: list of lists of object

            private static bool IsAllowedCollection<T>(Type type, T value)
            {
                return IsAllowedList(type, value) || IsAllowedDictionary(type, value);
            }

            private static bool IsAllowedList<T>(Type type, T value)
            {
                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type[] types = type.GetGenericArguments();
                    if (IsAllowedPrimitive(types[0]))
                    {
                        return true;
                    }

                    // TODO: want to separate out test for allowed POCOs
                    // independent of value check

                    if (types[0] == typeof(object))
                    {
                        List<object> objects = GetAs<List<object>>(value!);
                        return AreAllowedTypes(objects);
                    }
                }

                return false;
            }

            private static bool IsAllowedDictionary<T>(Type type, T value)
            {
                if (!type.IsGenericType)
                {
                    return false;
                }

                if (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    Type[] types = type.GetGenericArguments();
                    if (IsAllowedPrimitive(types[0]) && IsAllowedPrimitive(types[1]))
                    {
                        return true;
                    }

                    if (types[0] == typeof(object))
                    {
                        IDictionary dict = (IDictionary)value!;
                        if (!AreAllowedTypes(GetAs<IEnumerable<object>>(dict.Keys)))
                        {
                            return false;
                        }
                    }

                    if (types[1] == typeof(object))
                    {
                        IDictionary dict = (IDictionary)value!;
                        if (!AreAllowedTypes(GetAs<IEnumerable<object>>(dict.Keys)))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            private static T GetAs<T>(object value) where T : notnull
            {
                return (T)value;
            }

            private static bool AreAllowedTypes<T>(IEnumerable<T> values)
            {
                foreach (T value in values)
                {
                    if (value == null)
                    {
                        continue;
                    }

                    if (!IsAllowedType(value.GetType(), value))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool IsAllowedInterface(Type type)
            {
                // TODO: Interface support
                return
                    type == typeof(IEnumerable<bool>) ||
                    type == typeof(IEnumerable<int>);
            }

            private static bool IsAllowedPoco<T>(Type type, T value, HashSet<Type> ancestorTypes)
            {
                if (value == null)
                {
                    return true;
                }

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

                    // Get the value
                    object propertyValue = property.GetValue(value);

                    if (IsAllowedKnownType(property.PropertyType, propertyValue))
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
                    if (!IsAllowedPoco(property.PropertyType, propertyValue, ancestorTypes))
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
