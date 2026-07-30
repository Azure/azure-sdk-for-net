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
    /// <param name="format">
    /// Optional serialization format token emitted by the provisioning generator.
    /// Supported tokens are:
    /// <list type="bullet">
    /// <item><description><c>R</c>, <c>O</c>, <c>U</c>, and <c>D</c> for <see cref="DateTimeOffset"/> values.</description></item>
    /// <item><description><c>T</c>, <c>P</c>, <c>c</c>, <c>seconds</c>, <c>seconds-int64</c>, <c>seconds-float</c>, <c>seconds-double</c>, <c>milliseconds</c>, <c>milliseconds-int64</c>, <c>milliseconds-float</c>, and <c>milliseconds-double</c> for <see cref="TimeSpan"/> values.</description></item>
    /// <item><description><c>string</c> for string-encoded integer values.</description></item>
    /// </list>
    /// </param>
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
            float f => f.ToString(CultureInfo.InvariantCulture),
            double d => d.ToString(CultureInfo.InvariantCulture),
            string s => s,
            Uri u => u.AbsoluteUri,
            DateTimeOffset d => format is null ? d.ToString("o", CultureInfo.InvariantCulture) : ToString(d, format),
            TimeSpan t => format is null ? t.ToString() : ToString(t, format),
            byte[] b => Convert.ToBase64String(b),
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
    /// Convert a .NET object into a literal Bicep expression.
    /// </summary>
    /// <param name="value">The .NET value.</param>
    /// <param name="format">Optional serialization format token emitted by the provisioning generator.</param>
    /// <returns>The corresponding Bicep expression.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when we cannot convert a value to a literal Bicep expression.
    /// </exception>
    public static BicepExpression ToLiteralExpression(object value, string? format) =>
        value switch
        {
            bool b => BicepSyntax.Value(b),
            int i => ToExpression(i, format),
            long i => ToExpression(i, format),
            float f => BicepSyntax.Value(f),
            double d => BicepSyntax.Value(d),
            string s => BicepSyntax.Value(s),
            Uri u => BicepSyntax.Value(ToLiteralString(u, format)),
            DateTimeOffset d => ToExpression(d, format),
            TimeSpan t => ToExpression(t, format),
            byte[] b => BicepSyntax.Value(ToLiteralString(b, null)),
            Guid g => BicepSyntax.Value(ToLiteralString(g, format)),
            IPAddress a => BicepSyntax.Value(ToLiteralString(a, format)),
            ETag e => BicepSyntax.Value(ToLiteralString(e, format)),
            ResourceIdentifier i => BicepSyntax.Value(ToLiteralString(i, format)),
            AzureLocation azureLocation => BicepSyntax.Value(ToLiteralString(azureLocation, format)),
            ResourceType rt => BicepSyntax.Value(ToLiteralString(rt, format)),
            Enum e => BicepSyntax.Value(ToLiteralString(e, format)),
            ValueType ee => BicepSyntax.Value(ToLiteralString(ee, format)),
            _ => throw new InvalidOperationException($"Cannot convert {value} to a Bicep expression.")
        };

    public static string ToString(DateTimeOffset value, string format) => format switch
    {
        "D" => value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
        "U" => value.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture),
        "O" => value.ToUniversalTime().ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
        "R" => value.ToString("r", CultureInfo.InvariantCulture),
        _ => ThrowUnsupportedFormat(value, format)
    };

    public static string ToString(TimeSpan value, string format) => format switch
    {
        "T" => ToIsoTimeString(value),
        "P" => XmlConvert.ToString(value),
        "c" => value.ToString("c", CultureInfo.InvariantCulture),
        "seconds" => Convert.ToInt32(Math.Round(value.TotalSeconds)).ToString(CultureInfo.InvariantCulture),
        "seconds-int64" => Convert.ToInt64(Math.Round(value.TotalSeconds)).ToString(CultureInfo.InvariantCulture),
        "seconds-float" or "seconds-double" => value.TotalSeconds.ToString(CultureInfo.InvariantCulture),
        "milliseconds" => Convert.ToInt32(Math.Round(value.TotalMilliseconds)).ToString(CultureInfo.InvariantCulture),
        "milliseconds-int64" => Convert.ToInt64(Math.Round(value.TotalMilliseconds)).ToString(CultureInfo.InvariantCulture),
        "milliseconds-float" or "milliseconds-double" => value.TotalMilliseconds.ToString(CultureInfo.InvariantCulture),
        _ => ThrowUnsupportedFormat(value, format)
    };

    private static string ToString(int value, string? format) =>
        string.Equals(format, "string", StringComparison.Ordinal) ?
            value.ToString(CultureInfo.InvariantCulture) :
            format is null ? value.ToString(CultureInfo.InvariantCulture) : ThrowUnsupportedFormat(value, format);

    private static string ToString(long value, string? format) =>
        string.Equals(format, "string", StringComparison.Ordinal) ?
            value.ToString(CultureInfo.InvariantCulture) :
            format is null ? value.ToString(CultureInfo.InvariantCulture) : ThrowUnsupportedFormat(value, format);

    private static BicepExpression ToExpression(int value, string? format) =>
        string.Equals(format, "string", StringComparison.Ordinal) ?
            BicepSyntax.Value(value.ToString(CultureInfo.InvariantCulture)) :
            format is null ? BicepSyntax.Value(value) : BicepSyntax.Value(ThrowUnsupportedFormat(value, format));

    private static BicepExpression ToExpression(long value, string? format) =>
        string.Equals(format, "string", StringComparison.Ordinal) ?
            BicepSyntax.Value(value.ToString(CultureInfo.InvariantCulture)) :
            format is null ? BicepSyntax.Value(value) : BicepSyntax.Value(ThrowUnsupportedFormat(value, format));

    private static BicepExpression ToExpression(DateTimeOffset value, string? format) =>
        format switch
        {
            null => BicepSyntax.Value(value.ToString("o", CultureInfo.InvariantCulture)),
            "U" => BicepSyntax.Value(value.ToUnixTimeSeconds()),
            "D" or "O" or "R" => BicepSyntax.Value(ToString(value, format)),
            _ => BicepSyntax.Value(ThrowUnsupportedFormat(value, format))
        };

    private static BicepExpression ToExpression(TimeSpan value, string? format) =>
        format switch
        {
            null => BicepSyntax.Value(value.ToString()),
            "seconds" => BicepSyntax.Value(Convert.ToInt32(Math.Round(value.TotalSeconds))),
            "seconds-int64" => BicepSyntax.Value(Convert.ToInt64(Math.Round(value.TotalSeconds))),
            "seconds-float" or "seconds-double" => BicepSyntax.Value(value.TotalSeconds),
            "milliseconds" => BicepSyntax.Value(Convert.ToInt32(Math.Round(value.TotalMilliseconds))),
            "milliseconds-int64" => BicepSyntax.Value(Convert.ToInt64(Math.Round(value.TotalMilliseconds))),
            "milliseconds-float" or "milliseconds-double" => BicepSyntax.Value(value.TotalMilliseconds),
            "T" or "P" or "c" => BicepSyntax.Value(ToString(value, format)),
            _ => BicepSyntax.Value(ThrowUnsupportedFormat(value, format))
        };

    private static string ToIsoTimeString(TimeSpan value)
    {
        if (value < TimeSpan.Zero || value >= TimeSpan.FromDays(1))
        {
            throw new InvalidOperationException($"Cannot convert {value} to an ISO 8601 time string.");
        }
        return value.Ticks % TimeSpan.TicksPerSecond == 0 ?
            value.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture) :
            value.ToString(@"hh\:mm\:ss\.fffffff", CultureInfo.InvariantCulture).TrimEnd('0');
    }

    private static string ThrowUnsupportedFormat(object value, string? format) =>
        throw new InvalidOperationException($"Format token '{format}' is not supported for {value.GetType().Name}.");

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
