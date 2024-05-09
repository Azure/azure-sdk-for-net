// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;

#nullable enable

namespace Azure.Core.Shared;

internal static class EventSourceEventFormatting
{
    [ThreadStatic]
    private static StringBuilder? s_cachedStringBuilder;
    private const int CachedStringBuilderCapacity = 512;

    public static string Format(EventWrittenEventArgs eventData)
    {
        var payloadArray = eventData.Payload?.ToArray() ?? Array.Empty<object?>();

        ProcessPayloadArray(payloadArray);

        if (eventData.Message != null)
        {
            try
            {
                return string.Format(CultureInfo.InvariantCulture, eventData.Message, payloadArray);
            }
            catch (FormatException)
            {
            }
        }

        StringBuilder stringBuilder = RentStringBuilder();
        stringBuilder.Append(eventData.EventName);

        if (!string.IsNullOrWhiteSpace(eventData.Message))
        {
            stringBuilder.AppendLine();
            stringBuilder.Append(nameof(eventData.Message)).Append(" = ").Append(eventData.Message);
        }

        if (eventData.PayloadNames != null)
        {
            for (int i = 0; i < eventData.PayloadNames.Count; i++)
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(eventData.PayloadNames[i]).Append(" = ").Append(payloadArray[i]);
            }
        }

        return ToStringAndReturnStringBuilder(stringBuilder);
    }

    private static void ProcessPayloadArray(object?[] payloadArray)
    {
        for (int i = 0; i < payloadArray.Length; i++)
        {
            payloadArray[i] = FormatValue(payloadArray[i]);
        }
    }

    private static object? FormatValue(object? o)
    {
        if (o is byte[] bytes)
        {
#if NET6_0_OR_GREATER
            return Convert.ToHexString(bytes);
#else
            int length = 2 * bytes.Length; // Two hex characters per byte
            if (length < 256)
            {
                static char ToHex(int value) => (char)(value < 10 ? value + '0' : value - 10 + 'A');

                Span<char> buffer = stackalloc char[length];
                for (int i = 0; i < bytes.Length; i++)
                {
                    byte b = bytes[i];
                    buffer[i * 2] = ToHex(b >> 4);
                    buffer[i * 2 + 1] = ToHex(b & 0xF);
                }

                return buffer.ToString();
            }

            var stringBuilder = new StringBuilder(length);
            foreach (byte b in bytes)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return stringBuilder.ToString();
#endif
        }

        return o;
    }

    private static StringBuilder RentStringBuilder()
    {
        StringBuilder? builder = s_cachedStringBuilder;
        if (builder is null)
        {
            return new StringBuilder(CachedStringBuilderCapacity);
        }

        s_cachedStringBuilder = null;
        return builder;
    }

    private static string ToStringAndReturnStringBuilder(StringBuilder builder)
    {
        string result = builder.ToString();
        if (builder.Capacity <= CachedStringBuilderCapacity)
        {
            s_cachedStringBuilder = builder.Clear();
        }

        return result;
    }
}
