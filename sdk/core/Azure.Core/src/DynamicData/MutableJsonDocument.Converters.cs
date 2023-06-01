// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Dynamic;

namespace Azure.Core.Json
{
    internal partial class MutableJsonDocument
    {
        public class AllowListConverterFactory : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
            {
                return !IsAllowedType(typeToConvert);
            }

            private static bool IsAllowedType(Type type)
            {
                if (IsAllowedPrimitive(type))
                {
                    return true;
                }

                return IsAllowedNestedPoco(type, new List<Type>());
            }

            private static bool IsAllowedNestedPoco(Type type, List<Type> ancestorTypes)
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

                    if (IsAllowedPrimitive(property.PropertyType))
                    {
                        continue;
                    }

                    // TODO: I think we can delete this case, but confirm
                    if (IsSimplePoco(property.PropertyType))
                    {
                        continue;
                    }

                    // Trust but verify
                    if (ancestorTypes.Contains(type))
                    {
                        continue;
                    }

                    // Recurse
                    ancestorTypes.Add(type);
                    if (!IsAllowedNestedPoco(property.PropertyType, ancestorTypes))
                    {
                        return false;
                    }

                    // TODO: Make sure this works with different ordering, e.g. I check the nesting before I get to an invalid typed property
                }

                return true;
            }

            private static bool IsSimplePoco(Type type)
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

                    if (!IsAllowedPrimitive(property.PropertyType))
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

            private static bool IsAllowedPrimitive(Type type)
            {
                return
                    type == typeof(bool) ||
                    type == typeof(string) ||
                    type == typeof(byte) ||
                    type == typeof(sbyte) ||
                    type == typeof(short) ||
                    type == typeof(ushort) ||
                    type == typeof(int) ||
                    type == typeof(uint) ||
                    type == typeof(long) ||
                    type == typeof(ulong) ||
                    type == typeof(float) ||
                    type == typeof(double) ||
                    type == typeof(decimal) ||
                    type == typeof(DateTime) ||
                    type == typeof(DateTimeOffset) ||
                    type == typeof(Guid) ||

                    // TODO: separate out non-primitive values?
                    // TODO: is this object thing too permissive?
                    type == typeof(Dictionary<string, object>) ||
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||

                    // TODO: We'll want to remove this dependency
                    type == typeof(DynamicData) ||

                    // TODO: add array support differently
                    type == typeof(bool[]) ||
                    type == typeof(string[]) ||
                    type == typeof(byte[]) ||
                    type == typeof(sbyte[]) ||
                    type == typeof(short[]) ||
                    type == typeof(ushort[]) ||
                    type == typeof(int[]) ||
                    type == typeof(uint[]) ||
                    type == typeof(long[]) ||
                    type == typeof(ulong[]) ||
                    type == typeof(float[]) ||
                    type == typeof(double[]) ||
                    type == typeof(decimal[]) ||
                    type == typeof(DateTime[]) ||
                    type == typeof(DateTimeOffset[]) ||
                    type == typeof(Guid[]) ||

                    // TODO: Interface support
                    type == typeof(IEnumerable<bool>) ||
                    type == typeof(IEnumerable<int>) ||

                    type == typeof(object[])
                    ;
            }

            // TODO: add array support

            public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
            {
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                    typeof(ThrowingConverter<>).MakeGenericType(new Type[] { typeToConvert }),
                    BindingFlags.Instance | BindingFlags.Public,
                    binder: null,
                    args: new object[] { options },
                    culture: null)!;

                return converter;
            }

            private class ThrowingConverter<T> : JsonConverter<T>
            {
                public ThrowingConverter(JsonSerializerOptions options) { }

                public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                {
                    throw new NotSupportedException($"Type is not currently supported: '{typeToConvert}");
                }

                public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
                {
                    throw new NotSupportedException($"Type is not currently supported: '{typeof(T)}");
                }
            }
        }
    }
}
