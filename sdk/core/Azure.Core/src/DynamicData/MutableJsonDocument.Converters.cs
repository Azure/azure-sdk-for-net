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
            public static readonly AllowListConverterFactory Default = new();

            public override bool CanConvert(Type typeToConvert)
            {
                return !IsAllowedType(typeToConvert);
            }

            public static bool IsAllowedType(Type type)
            {
                if (IsAllowedKnownType(type))
                {
                    return true;
                }

                return IsAllowedPoco(type, new List<Type>());
            }

            private static bool IsAllowedPoco(Type type, List<Type> ancestorTypes)
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
                    if (ancestorTypes.Contains(type))
                    {
                        continue;
                    }

                    // Recurse
                    ancestorTypes.Add(type);
                    if (!IsAllowedPoco(property.PropertyType, ancestorTypes))
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

            private static bool IsAllowedKnownType(Type type)
            {
                return IsAllowedPrimitive(type) ||
                    IsAllowedArray(type) ||
                    IsAllowedInterface(type) ||

                    // TODO: separate out non-primitive values?
                    type == typeof(JsonElement) ||
                    type == typeof(JsonDocument) ||
                    type == typeof(MutableJsonDocument) ||
                    type == typeof(MutableJsonElement) ||
                    type == typeof(Dictionary<string, object>) ||

                    // TODO: We'll want to remove this dependency
                    type == typeof(DynamicData) ||

					// TODO: Keep this?
                    type == typeof(object[])
                    ;
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
                    type == typeof(Guid);
            }

            private static bool IsAllowedArray(Type type)
            {
                // TODO: add array support differently
                return
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
                    type == typeof(Guid[]);
            }

            private static bool IsAllowedInterface(Type type)
            {
                // TODO: Interface support
                return
                    type == typeof(IEnumerable<bool>) ||
                    type == typeof(IEnumerable<int>);
            }

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
                    throw new NotSupportedException($"Type is not currently supported: '{typeToConvert}'");
                }

                public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
                {
                    throw new NotSupportedException($"Type is not currently supported: '{typeof(T)}'");
                }
            }
        }
    }
}
