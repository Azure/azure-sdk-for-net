// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;

#nullable enable

namespace Azure.AI.OpenAI.Tests.Utils;

/// <summary>
/// A helper class to make working with older versions of System.Text.Json simpler
/// </summary>
public static class JsonOptions
{
    // TODO FIXME once we update to newer versions of System.Text.JSon we should switch to using
    //            JsonNamingPolicy.SnakeCaseLower
    public static JsonNamingPolicy SnakeCaseLower { get; } =
        new SnakeCaseNamingPolicy();

    public static JsonSerializerOptions OpenAIJsonOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new ModelReaderWriterConverter(),
            new UnixDateTimeConverter()
        }
    };

    public static JsonSerializerOptions AzureJsonOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
    };

    // Ported over from the source code for newer versions of System.Text.Json
    private class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private enum SeparatorState
        {
            NotStarted,
            UppercaseLetter,
            LowercaseLetterOrDigit,
            SpaceSeparator
        }

        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            return ConvertName('_', name.AsSpan());
        }

        internal static string ConvertName(char separator, ReadOnlySpan<char> chars)
        {
            char[]? rentedBuffer = null;

            int num = (int)(1.2 * chars.Length);
            Span<char> output = num > 128
                ? (rentedBuffer = ArrayPool<char>.Shared.Rent(num))!
                : stackalloc char[128];

            SeparatorState separatorState = SeparatorState.NotStarted;
            int charsWritten = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c);
                switch (unicodeCategory)
                {
                    case UnicodeCategory.UppercaseLetter:
                        switch (separatorState)
                        {
                            case SeparatorState.LowercaseLetterOrDigit:
                            case SeparatorState.SpaceSeparator:
                                WriteChar(separator, ref output);
                                break;
                            case SeparatorState.UppercaseLetter:
                                if (i + 1 < chars.Length && char.IsLower(chars[i + 1]))
                                {
                                    WriteChar(separator, ref output);
                                }
                                break;
                        }

                        c = char.ToLowerInvariant(c);
                        WriteChar(c, ref output);
                        separatorState = SeparatorState.UppercaseLetter;
                        break;

                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (separatorState == SeparatorState.SpaceSeparator)
                        {
                            WriteChar(separator, ref output);
                        }

                        WriteChar(c, ref output);
                        separatorState = SeparatorState.LowercaseLetterOrDigit;
                        break;

                    case UnicodeCategory.SpaceSeparator:
                        if (separatorState != 0)
                        {
                            separatorState = SeparatorState.SpaceSeparator;
                        }
                        break;

                    default:
                        WriteChar(c, ref output);
                        separatorState = SeparatorState.NotStarted;
                        break;
                }
            }

            string result = output.Slice(0, charsWritten).ToString();
            if (rentedBuffer != null)
            {
                output.Slice(0, charsWritten).Clear();
                ArrayPool<char>.Shared.Return(rentedBuffer);
            }
            return result;

            void ExpandBuffer(ref Span<char> destination)
            {
                int minimumLength = checked(destination.Length * 2);
                char[] array = ArrayPool<char>.Shared.Rent(minimumLength);
                destination.CopyTo(array);
                if (rentedBuffer != null)
                {
                    destination.Slice(0, charsWritten).Clear();
                    ArrayPool<char>.Shared.Return(rentedBuffer);
                }
                rentedBuffer = array;
                destination = rentedBuffer;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void WriteChar(char value, ref Span<char> destination)
            {
                if (charsWritten == destination.Length)
                {
                    ExpandBuffer(ref destination);
                }
                destination[charsWritten++] = value;
            }
        }
    }
}
