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
            // Down-level implementation of Convert.ToHexString that uses a
            // Span<char> instead of a StringBuilder to avoid allocations.
            // The implementation is copied from .NET's HexConverter.ToString
            // See https://github.com/dotnet/runtime/blob/acd31754892ab0431ac2c40038f541ffa7168be7/src/libraries/Common/src/System/HexConverter.cs#L180
            // The only modification is that we allow larger stack allocations.
            Span<char> result = bytes.Length > 32 ?
                new char[bytes.Length * 2] :
                stackalloc char[bytes.Length * 2];

            int pos = 0;
            foreach (byte b in bytes)
            {
                ToCharsBuffer(b, result, pos);
                pos += 2;
            }

            return result.ToString();

            static void ToCharsBuffer(byte value, Span<char> buffer, int startingIndex)
            {
                // An explanation of this algorithm can be found at
                // https://github.com/dotnet/runtime/blob/acd31754892ab0431ac2c40038f541ffa7168be7/src/libraries/Common/src/System/HexConverter.cs#L33
                uint difference = ((value & 0xF0U) << 4) + (value & 0x0FU) - 0x8989U;
                uint packedResult = (((uint)(-(int)difference) & 0x7070U) >> 4) + difference + 0xB9B9U;

                buffer[startingIndex + 1] = (char)(packedResult & 0xFF);
                buffer[startingIndex] = (char)(packedResult >> 8);
            }
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
