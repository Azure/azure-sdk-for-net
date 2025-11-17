// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using Azure.Core;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Collect the primary logic for mapping .NET types to Bicep types in one place.
/// </summary>
internal static class BicepTypeMapping
{
    /// <summary>
    /// Map standard Azure types into Bicep primitive type names like bool,
    /// int, string, object, or array.  More complex types are not supported.
    /// </summary>
    /// <param name="type">A .NET type.</param>
    /// <returns>A corresponding Bicep type name or null.</returns>
    public static string? GetBicepTypeName(Type type) =>
        type == typeof(bool) ? "bool" :
        type == typeof(int) ? "int" :
        type == typeof(long) ? "int" :
        type == typeof(string) ? "string" :
        type == typeof(object) ? "object" :
        type == typeof(Uri) ? "string" :
        type == typeof(DateTimeOffset) ? "string" :
        type == typeof(TimeSpan) ? "string" :
        type == typeof(Guid) ? "string" :
        type == typeof(IPAddress) ? "string" :
        type == typeof(ETag) ? "string" :
        type == typeof(ResourceIdentifier) ? "string" :
        type == typeof(ResourceType) ? "string" :
        type == typeof(AzureLocation) ? "string" :
        typeof(Enum).IsAssignableFrom(type) ? "string" :
        typeof(System.Collections.IDictionary).IsAssignableFrom(type) ? "object" :
        typeof(System.Collections.IEnumerable).IsAssignableFrom(type) ? "array" :
        null;

    /// <summary>
    /// Convert a .NET object into a literal Bicep string.
    /// </summary>
    /// <param name="value">The .NET value.</param>
    /// <param name="format">Optional format.</param>
    /// <returns>The corresponding Bicep literal string.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when we cannot convert a value to a literal Bicep string.
    /// </exception>
    public static string ToLiteralString(object value, string? format) =>
        value switch
        {
            bool b => b.ToString(),
            int i => i.ToString(),
            long i => i.ToString(),
            float f => f.ToString(),
            double d => d.ToString(),
            string s => s,
            Uri u => u.AbsoluteUri,
            DateTimeOffset d => d.ToString("o"),
            TimeSpan t when format == "P" => XmlConvert.ToString(t),
            TimeSpan t => t.ToString(),
            Guid g => g.ToString(),
            IPAddress a => a.ToString(),
            ETag e => e.ToString(),
            ResourceIdentifier i => i.ToString(),
            AzureLocation azureLocation => azureLocation.ToString(),
            ResourceType rt => rt.ToString(),
            Enum e => GetEnumValue(e),
            // Other extensible enums like AzureLocation (AzureLocation has been handled above)
            // TODO: Can we either tag or special case all that we care about because ValueType is too broad
            ValueType ee => ee.ToString()!,
            _ => throw new InvalidOperationException($"Cannot convert {value} to a literal Bicep string.")
        };

    /// <summary>
    /// Get the value of an enum.  This is either the name of the enum value or
    /// optionally overridden by a DataMember attribute when the wire value
    /// is different from the .NET name.
    /// </summary>
    /// <param name="value">An enum value.</param>
    /// <returns>The enum value's string representation.</returns>
    private static string GetEnumValue(Enum value)
    {
        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            DataMemberAttribute? member = type.GetField(name)?.GetCustomAttribute<DataMemberAttribute>();
            return member?.Name ?? value.ToString();
        }
        return value.ToString();
    }
}
