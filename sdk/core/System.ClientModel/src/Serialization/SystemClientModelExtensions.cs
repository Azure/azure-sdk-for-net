// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.ClientModel.Json;
using System.ClientModel.Serialization;

namespace System.ClientModel;

/// <summary>
/// Extensions that can be used for serialization.
/// </summary>
public static class SystemClientModelExtensions
{
    /// <summary>
    /// Return the content of the BinaryData as a dynamic type.  Please see https://aka.ms/azsdk/net/dynamiccontent for details.
    /// </summary>
    [RequiresUnreferencedCode(DynamicJsonData.SerializationRequiresUnreferencedCode)]
    [RequiresDynamicCode(DynamicJsonData.SerializationRequiresUnreferencedCode)]
    public static dynamic ToDynamicFromJson(this BinaryData utf8Json)
    {
        DynamicJsonDataOptions options = new DynamicJsonDataOptions();
        return utf8Json.ToDynamicFromJson(options);
    }

    /// <summary>
    /// Return the content of the BinaryData as a dynamic type.  Please see https://aka.ms/azsdk/net/dynamiccontent for details.
    /// <paramref name="propertyNameFormat">The format of property names in the JSON content.
    /// This value indicates to the dynamic type that it can convert property names on the returned value to this format in the underlying JSON.
    /// Please see https://aka.ms/azsdk/net/dynamiccontent#use-c-naming-conventions for details.
    /// </paramref>
    /// <paramref name="dateTimeFormat">The standard format specifier to pass when serializing DateTime and DateTimeOffset values in the JSON content.
    /// To serialize to unix time, pass the value <code>"x"</code> and
    /// see <see href="https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings">https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings#table-of-format-specifiers</see> for other well known values.
    /// </paramref>
    /// </summary>
    [RequiresUnreferencedCode(DynamicJsonData.SerializationRequiresUnreferencedCode)]
    [RequiresDynamicCode(DynamicJsonData.SerializationRequiresUnreferencedCode)]
    public static dynamic ToDynamicFromJson(this BinaryData utf8Json, JsonPropertyNames propertyNameFormat, string dateTimeFormat = DynamicJsonData.RoundTripFormat)
    {
        DynamicJsonDataOptions options = new DynamicJsonDataOptions()
        {
            PropertyNameFormat = propertyNameFormat,
            DateTimeFormat = dateTimeFormat
        };

        return utf8Json.ToDynamicFromJson(options);
    }

    /// <summary>
    /// Return the content of the BinaryData as a dynamic type.
    /// </summary>
    [RequiresUnreferencedCode(DynamicJsonData.SerializationRequiresUnreferencedCode)]
    [RequiresDynamicCode(DynamicJsonData.SerializationRequiresUnreferencedCode)]
    internal static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicJsonDataOptions options)
    {
        MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, DynamicJsonDataOptions.ToSerializerOptions(options));
        return new DynamicJsonData(mdoc.RootElement, options);
    }

    private static object? GetObject(in this JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.String:
                return element.GetString();
            case JsonValueKind.Number:
                if (element.TryGetInt32(out int intValue))
                {
                    return intValue;
                }
                if (element.TryGetInt64(out long longValue))
                {
                    return longValue;
                }
                return element.GetDouble();
            case JsonValueKind.True:
                return true;
            case JsonValueKind.False:
                return false;
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
                return null;
            case JsonValueKind.Object:
                var dictionary = new Dictionary<string, object?>();
                foreach (JsonProperty jsonProperty in element.EnumerateObject())
                {
                    dictionary.Add(jsonProperty.Name, jsonProperty.Value.GetObject());
                }
                return dictionary;
            case JsonValueKind.Array:
                var list = new List<object?>();
                foreach (JsonElement item in element.EnumerateArray())
                {
                    list.Add(item.GetObject());
                }
                return list.ToArray();
            default:
                throw new NotSupportedException("Not supported value kind " + element.ValueKind);
        }
    }
}
