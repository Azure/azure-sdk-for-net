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

            private static bool IsAllowedValue<T>(T value)
            {
                // TODO: implement
                return false;
            }

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
                    IsAllowedArrayType(type, out needsValueCheck) ||
                    IsAllowedCollectionType(type, out needsValueCheck) ||
                    IsAllowedInterfaceType(type, out needsValueCheck) ||

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

            private static bool IsAllowedArrayType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

                if (!type.IsArray)
                {
                    return false;
                }

                //if (type == typeof(object[]))
                //{
                //    object[] objects = GetAs<object[]>(value!);
                //    foreach (object obj in objects)
                //    {
                //        if (obj is null)
                //        {
                //            continue;
                //        }

                //        if (!IsAllowedType(obj.GetType(), obj))
                //        {
                //            return false;
                //        }
                //    }
                //}

                Type? elementType = type.GetElementType();
                return elementType != null && IsAllowedType(elementType, out needsValueCheck);
            }

            // TODO: Test case: list of lists of object

            private static bool IsAllowedCollectionType(Type type, out bool needsValueCheck)
            {
                needsValueCheck = false;

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

                if (type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type[] types = type.GetGenericArguments();
                    if (IsAllowedType(types[0], out needsValueCheck))
                    {
                        return true;
                    }
                }

                return false;
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
                    if (IsAllowedPrimitive(types[0]) && IsAllowedPrimitive(types[1]))
                    {
                        return true;
                    }

                    //if (types[0] == typeof(object))
                    //{
                    //    IDictionary dict = (IDictionary)value!;
                    //    if (!AreAllowedTypes(GetAs<IEnumerable<object>>(dict.Keys)))
                    //    {
                    //        return false;
                    //    }
                    //}

                    //if (types[1] == typeof(object))
                    //{
                    //    IDictionary dict = (IDictionary)value!;
                    //    if (!AreAllowedTypes(GetAs<IEnumerable<object>>(dict.Keys)))
                    //    {
                    //        return false;
                    //    }
                    //}

                    //return true;
                }

                return false;
            }

            //private static T GetAs<T>(object value) where T : notnull
            //{
            //    return (T)value;
            //}

            //private static bool AreAllowedTypes<T>(IEnumerable<T> values)
            //{
            //    foreach (T value in values)
            //    {
            //        if (value == null)
            //        {
            //            continue;
            //        }

            //        if (!IsAllowedType(value.GetType(), value))
            //        {
            //            return false;
            //        }
            //    }

            //    return true;
            //}

            private static bool IsAllowedInterfaceType(Type type, out bool needsValueCheck)
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

                if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    Type[] types = type.GetGenericArguments();
                    if (IsAllowedType(types[0], out needsValueCheck))
                    {
                        return true;
                    }
                }

                return false;
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
        }
    }
}
