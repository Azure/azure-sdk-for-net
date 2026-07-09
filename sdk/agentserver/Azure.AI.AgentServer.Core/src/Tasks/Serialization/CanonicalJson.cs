// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// Produces canonical JSON bytes that are byte-compatible with the cross-language
/// task protocol's canonicalization rules — sorted object keys (ordinal), compact
/// <c>","</c>/<c>":"</c> separators, non-ASCII escaped as <c>\uXXXX</c> (matching
/// Python's <c>json.dumps(value, sort_keys=True, separators=(",", ":"))</c> with
/// the default <c>ensure_ascii=True</c>), and UTF-8 output.
/// </summary>
/// <remarks>
/// Used wherever the protocol measures serialized sizes (§28a.2) and computes
/// content hashes for attachment refs (§23.6), so a record written by one
/// language can be validated by another.
/// </remarks>
internal static class CanonicalJson
{
    /// <summary>Serializes a parsed JSON element to canonical UTF-8 bytes.</summary>
    /// <param name="element">The JSON element to serialize.</param>
    /// <returns>The canonical UTF-8 byte representation.</returns>
    public static byte[] SerializeToUtf8Bytes(JsonElement element)
    {
        var sb = new StringBuilder();
        WriteElement(sb, element);
        return Encoding.UTF8.GetBytes(sb.ToString());
    }

    /// <summary>Serializes an arbitrary value to canonical UTF-8 bytes.</summary>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Optional serializer options used to project <paramref name="value"/> to JSON first.</param>
    /// <returns>The canonical UTF-8 byte representation.</returns>
    public static byte[] SerializeToUtf8Bytes(object? value, JsonSerializerOptions? options = null)
    {
        using var doc = JsonSerializer.SerializeToDocument(value, options);
        return SerializeToUtf8Bytes(doc.RootElement);
    }

    /// <summary>Measures the canonical UTF-8 byte length of a JSON element.</summary>
    /// <param name="element">The JSON element to measure.</param>
    /// <returns>The number of UTF-8 bytes in the canonical form.</returns>
    public static int MeasureByteSize(JsonElement element) => SerializeToUtf8Bytes(element).Length;

    /// <summary>Computes the lower-case hex SHA-256 of the canonical bytes of a JSON element.</summary>
    /// <param name="element">The JSON element to hash.</param>
    /// <returns>64 lower-case hex characters (no <c>sha256:</c> prefix).</returns>
    public static string ComputeSha256Hex(JsonElement element)
    {
        var bytes = SerializeToUtf8Bytes(element);
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    private static void WriteElement(StringBuilder sb, JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                WriteObject(sb, element);
                break;
            case JsonValueKind.Array:
                WriteArray(sb, element);
                break;
            case JsonValueKind.String:
                WriteString(sb, element.GetString()!);
                break;
            case JsonValueKind.Number:
                sb.Append(NormalizeNumber(element));
                break;
            case JsonValueKind.True:
                sb.Append("true");
                break;
            case JsonValueKind.False:
                sb.Append("false");
                break;
            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
                sb.Append("null");
                break;
            default:
                sb.Append("null");
                break;
        }
    }

    private static void WriteObject(StringBuilder sb, JsonElement element)
    {
        // Collect property names and sort ordinally to match Python's sort_keys
        // (which orders by Unicode code point).
        var props = new System.Collections.Generic.List<JsonProperty>();
        foreach (var p in element.EnumerateObject())
        {
            props.Add(p);
        }

        props.Sort(static (a, b) => string.CompareOrdinal(a.Name, b.Name));

        sb.Append('{');
        bool first = true;
        foreach (var p in props)
        {
            if (!first)
            {
                sb.Append(',');
            }

            first = false;
            WriteString(sb, p.Name);
            sb.Append(':');
            WriteElement(sb, p.Value);
        }

        sb.Append('}');
    }

    private static void WriteArray(StringBuilder sb, JsonElement element)
    {
        sb.Append('[');
        bool first = true;
        foreach (var item in element.EnumerateArray())
        {
            if (!first)
            {
                sb.Append(',');
            }

            first = false;
            WriteElement(sb, item);
        }

        sb.Append(']');
    }

    private static string NormalizeNumber(JsonElement element)
    {
        // A JSON number token is an *integer* literal only when it has no fractional
        // part or exponent. Integers are emitted verbatim (Python's json round-trips
        // integer digits without change, including arbitrary precision); floats are
        // emitted using Python's repr(float) so a value such as 1.0 hashes identically
        // across languages (Python keeps the ".0"; .NET's shortest form would drop it).
        string raw = element.GetRawText();
        bool isFloat = raw.IndexOf('.') >= 0 || raw.IndexOf('e') >= 0 || raw.IndexOf('E') >= 0;
        if (!isFloat)
        {
            if (element.TryGetInt64(out long l))
            {
                return l.ToString(CultureInfo.InvariantCulture);
            }

            if (element.TryGetUInt64(out ulong ul))
            {
                return ul.ToString(CultureInfo.InvariantCulture);
            }

            // Integer outside the 64-bit range: emit the verbatim digits (JSON forbids
            // leading zeros/plus signs, so this matches Python's str(int) exactly).
            return raw;
        }

        return PythonFloatRepr(element.GetDouble());
    }

    /// <summary>
    /// Formats a double exactly as CPython's <c>repr(float)</c> / <c>json.dumps</c> would, so
    /// canonical hashes of user JSON containing floats match the Python implementation. This
    /// reproduces CPython's shortest-round-trip digits plus its fixed-vs-exponential decision
    /// (exponential when the decimal point position is &lt;= -4 or &gt; 16).
    /// </summary>
    private static string PythonFloatRepr(double d)
    {
        if (double.IsNaN(d))
        {
            return "NaN";
        }

        if (double.IsPositiveInfinity(d))
        {
            return "Infinity";
        }

        if (double.IsNegativeInfinity(d))
        {
            return "-Infinity";
        }

        // .NET's "R" gives the shortest round-trippable digits, matching CPython's digit choice.
        string s = d.ToString("R", CultureInfo.InvariantCulture);

        bool negative = s.StartsWith("-", StringComparison.Ordinal);
        if (negative)
        {
            s = s.Substring(1);
        }

        int exp = 0;
        int eIdx = s.IndexOfAny(new[] { 'E', 'e' });
        string mantissa = s;
        if (eIdx >= 0)
        {
            exp = int.Parse(s.Substring(eIdx + 1), CultureInfo.InvariantCulture);
            mantissa = s.Substring(0, eIdx);
        }

        int dot = mantissa.IndexOf('.');
        string intPart = dot >= 0 ? mantissa.Substring(0, dot) : mantissa;
        string fracPart = dot >= 0 ? mantissa.Substring(dot + 1) : string.Empty;

        // decpt = position of the decimal point relative to the first digit of the mantissa.
        string digits = intPart + fracPart;
        int decpt = intPart.Length + exp;

        // Strip leading zeros (shifting the point), then trailing zeros (which do not).
        int lead = 0;
        while (lead < digits.Length - 1 && digits[lead] == '0')
        {
            lead++;
            decpt--;
        }

        digits = digits.Substring(lead).TrimEnd('0');
        if (digits.Length == 0)
        {
            // Value is zero: CPython repr is "0.0" (sign preserved for -0.0).
            return negative ? "-0.0" : "0.0";
        }

        string body;
        if (decpt <= -4 || decpt > 16)
        {
            string m = digits.Length == 1 ? digits : digits.Substring(0, 1) + "." + digits.Substring(1);
            int e = decpt - 1;
            string es = (e < 0 ? "-" : "+") + Math.Abs(e).ToString("D2", CultureInfo.InvariantCulture);
            body = m + "e" + es;
        }
        else if (decpt <= 0)
        {
            body = "0." + new string('0', -decpt) + digits;
        }
        else if (decpt >= digits.Length)
        {
            body = digits + new string('0', decpt - digits.Length) + ".0";
        }
        else
        {
            body = digits.Substring(0, decpt) + "." + digits.Substring(decpt);
        }

        return negative ? "-" + body : body;
    }

    private static void WriteString(StringBuilder sb, string value)
    {
        sb.Append('"');
        foreach (char c in value)
        {
            switch (c)
            {
                case '"':
                    sb.Append("\\\"");
                    break;
                case '\\':
                    sb.Append("\\\\");
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                case '\n':
                    sb.Append("\\n");
                    break;
                case '\r':
                    sb.Append("\\r");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                default:
                    if (c < 0x20 || c > 0x7E)
                    {
                        // ensure_ascii=True: escape control + all non-ASCII as \uXXXX (lower-case hex).
                        sb.Append("\\u");
                        sb.Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        sb.Append(c);
                    }

                    break;
            }
        }

        sb.Append('"');
    }
}
