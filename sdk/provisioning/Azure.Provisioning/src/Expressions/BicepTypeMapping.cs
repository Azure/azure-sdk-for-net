// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
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
    private const string RoundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";

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
        type == typeof(byte[]) ? "string" :
        type == typeof(BinaryData) ? "string" :
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
            int i => ToString(i, format),
            long i => ToString(i, format),
            float f => f.ToString(format ?? "G", CultureInfo.InvariantCulture),
            double d => d.ToString(format ?? "G", CultureInfo.InvariantCulture),
            string s => s,
            Uri u => u.AbsoluteUri,
            DateTimeOffset d => format is null ? d.ToString("o", CultureInfo.InvariantCulture) : ToString(d, format),
            TimeSpan t => format is null ? t.ToString() : ToString(t, format),
            byte[] b => ToString(b, format ?? "D"),
            BinaryData b => ToString(b.ToArray(), format ?? "D"),
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

    public static string ToString(DateTimeOffset value, string format) => format switch
    {
        "D" => value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
        "U" => value.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture),
        "O" or "o" => value.ToUniversalTime().ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
        "R" => value.ToString("r", CultureInfo.InvariantCulture),
        "T" => value.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
        _ => value.ToString(format, CultureInfo.InvariantCulture)
    };

    public static string ToString(TimeSpan value, string format) => format switch
    {
        "P" => XmlConvert.ToString(value),
        "%s" => Convert.ToInt32(Math.Round(value.TotalSeconds)).ToString(CultureInfo.InvariantCulture),
        "%S" => Convert.ToInt64(Math.Round(value.TotalSeconds)).ToString(CultureInfo.InvariantCulture),
        "s\\.FFF" or "s\\.FFFFFF" => value.TotalSeconds.ToString(CultureInfo.InvariantCulture),
        "%m" => Convert.ToInt32(Math.Round(value.TotalMilliseconds)).ToString(CultureInfo.InvariantCulture),
        "%M" => Convert.ToInt64(Math.Round(value.TotalMilliseconds)).ToString(CultureInfo.InvariantCulture),
        "m\\.FFF" or "m\\.FFFFFF" => value.TotalMilliseconds.ToString(CultureInfo.InvariantCulture),
        _ => value.ToString(format, CultureInfo.InvariantCulture)
    };

    public static string ToString(byte[] value, string format) => format switch
    {
        "D" => Convert.ToBase64String(value),
        "U" => Convert.ToBase64String(value).TrimEnd('=').Replace('+', '-').Replace('/', '_'),
        _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
    };

    private static string ToString(int value, string? format) =>
        string.Equals(format, "S", StringComparison.Ordinal) ?
            value.ToString(CultureInfo.InvariantCulture) :
            value.ToString();

    private static string ToString(long value, string? format) =>
        string.Equals(format, "S", StringComparison.Ordinal) ?
            value.ToString(CultureInfo.InvariantCulture) :
            value.ToString();

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
