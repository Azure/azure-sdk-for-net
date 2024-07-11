using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

#nullable enable

namespace Azure.AI.OpenAI.Tests.Utils;

/// <summary>
/// A helper class to make working with older versions of System.Text.Json simpler
/// </summary>
internal static class JsonHelpers
{
    // TODO FIXME once we update to newer versions of System.Text.JSon we should switch to using
    //            JsonNamingPolicy.SnakeCaseLower
    public static JsonNamingPolicy SnakeCaseLower { get; } =
        new SnakeCaseNamingPolicy();

    public static JsonSerializerOptions OpenAIJsonOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = SnakeCaseLower,
#if NETFRAMEWORK
        IgnoreNullValues = true,
#else
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
#endif
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
#if NETFRAMEWORK
        IgnoreNullValues = true,
#else
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
#endif
    };

    // TODO FIXME once we move to newer versions of System.Text.Json we can directly call
    //            JsonSerializer.Serialize(...) with a stream
    public static void Serialize<T>(Stream stream, T value, JsonSerializerOptions? options = null)
    {
#if NETFRAMEWORK
        using Utf8JsonWriter writer = new(stream, new JsonWriterOptions()
        {
            Encoder = options?.Encoder,
            Indented = options?.WriteIndented == true,
            SkipValidation = false
        });

        JsonSerializer.Serialize(writer, value, options);
#else
        JsonSerializer.Serialize(stream, value, options);
#endif
    }

#if NET6_0_OR_GREATER
    // .Net 6 and newer already have the extension method we need defined in JsonsSerializer
#else
    // TODO FIXME once we move to newer versions of System.Text.Json we can directly use the
    //            JsonSerializer extension method for elements
    public static T? Deserialize<T>(this JsonElement element, JsonSerializerOptions? options = null)
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream, new()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Indented = false,
            SkipValidation = true
        });
        element.WriteTo(writer);
        writer.Flush();

        stream.Seek(0, SeekOrigin.Begin);
        if (((ulong)stream.Length & 0xffffffff00000000) != 0ul)
        {
            throw new ArgumentOutOfRangeException("JsonElement is too large");
        }

        ReadOnlySpan<byte> span = new(stream.GetBuffer(), 0, (int)stream.Length);
        return JsonSerializer.Deserialize<T>(span, options);
    }
#endif

    public static T? Deserialize<T>(Stream stream, JsonSerializerOptions? options = null)
    {
#if NETFRAMEWORK
        // For now let's keep it simple and load entire JSON bytes into memory
        using MemoryStream buffer = new();
        stream.CopyTo(buffer);

        ReadOnlySpan<byte> jsonBytes = buffer.GetBuffer().AsSpan(0, (int)buffer.Length);
        return JsonSerializer.Deserialize<T>(jsonBytes, options);
#else
        return JsonSerializer.Deserialize<T>(stream, options);
#endif
    }

    public static JsonElement SerializeToElement<T>(T value, JsonSerializerOptions? options = null)
    {
#if NET6_0_OR_GREATER
        return JsonSerializer.SerializeToElement(value, options);
#else
        using MemoryStream stream = new();
        Serialize(stream, value, options);
        stream.Seek(0, SeekOrigin.Begin);
        return JsonDocument.Parse(stream).RootElement;
#endif
    }

    // Ported over from the source code for newer versions of System.Text.Json
    internal class SnakeCaseNamingPolicy : JsonNamingPolicy
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
