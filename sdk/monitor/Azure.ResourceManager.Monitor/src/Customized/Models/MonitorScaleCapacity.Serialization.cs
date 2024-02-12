// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    [CodeGenSerialization(nameof(Minimum), SerializationValueHook = nameof(WriteMinimum), DeserializationValueHook = nameof(ReadMinimum))]
    [CodeGenSerialization(nameof(Maximum), SerializationValueHook = nameof(WriteMaximum), DeserializationValueHook = nameof(ReadMaximum))]
    [CodeGenSerialization(nameof(Default), SerializationValueHook = nameof(WriteDefault), DeserializationValueHook = nameof(ReadDefault))]
    public partial class MonitorScaleCapacity : IUtf8JsonSerializable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteMinimum(Utf8JsonWriter writer)
        {
            WriteIntToString(writer, Minimum);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadMinimum(JsonProperty property, ref int minimum)
        {
            ReadStringToInt(property, ref minimum);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteMaximum(Utf8JsonWriter writer)
        {
            WriteIntToString(writer, Maximum);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadMaximum(JsonProperty property, ref int maximum)
        {
            ReadStringToInt(property, ref maximum);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteDefault(Utf8JsonWriter writer)
        {
            WriteIntToString(writer, Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadDefault(JsonProperty property, ref int @default)
        {
            ReadStringToInt(property, ref @default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteIntToString(Utf8JsonWriter writer, int value)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ReadStringToInt(JsonProperty property, ref int propertyValue)
        {
            if (!int.TryParse(property.Value.GetString(), out var value))
            {
                throw new FormatException($"cannot convert property {property} to int");
            }
            propertyValue = value;
        }
    }
}
