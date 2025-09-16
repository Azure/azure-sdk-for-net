// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.Buffers;
using System.Text;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    /// <summary>
    /// A patch value that has been encoded in UTF-8 bytes along with its value kind.
    /// </summary>
    public readonly struct EncodedValue
    {
        private const byte MaxInt32Utf8Bytes = 11;
        private const byte MaxInt64Utf8Bytes = 20;
        private const byte MaxDecimalUtf8Bytes = 64;
        private const byte MaxGuidUtf8Bytes = 48;
        private const byte MaxDateTimeUtf8Bytes = 64;
        private const byte MaxTimeSpanUtf8Bytes = 64;

        private static readonly ReadOnlyMemory<byte> s_null = "null"u8.ToArray();
        private static readonly ReadOnlyMemory<byte> s_true = "true"u8.ToArray();
        private static readonly ReadOnlyMemory<byte> s_false = "false"u8.ToArray();

        internal static readonly EncodedValue Empty = new(ValueKind.None, Array.Empty<byte>());
        internal static readonly EncodedValue Removed = new(ValueKind.Removed);
        internal static readonly EncodedValue Null = new(ValueKind.Null, s_null);

        private EncodedValue(ValueKind kind)
        {
            Kind = kind;
        }

        internal EncodedValue(ValueKind kind, ReadOnlyMemory<byte> value)
        {
            Kind = kind;
            Value = value;
        }

        internal EncodedValue(bool value)
        {
            if (value)
            {
                Kind = ValueKind.BooleanTrue;
                Value = s_true;
            }
            else
            {
                Kind = ValueKind.BooleanFalse;
                Value = s_false;
            }
        }

        internal EncodedValue(byte value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt32Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(DateTime value, StandardFormat format = default)
        {
            Kind = ValueKind.DateTime;

            Span<byte> buffer = stackalloc byte[MaxDateTimeUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten, format))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(DateTimeOffset value, StandardFormat format = default)
        {
            Kind = ValueKind.DateTime;

            Span<byte> buffer = stackalloc byte[MaxDateTimeUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten, format))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(decimal value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxDecimalUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(double value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxDecimalUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(float value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxDecimalUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(Guid value)
        {
            Kind = ValueKind.Guid;

            Span<byte> buffer = stackalloc byte[MaxGuidUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(int value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt32Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(long value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt64Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(sbyte value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt32Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(short value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt32Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(TimeSpan value, StandardFormat format = default)
        {
            Kind = ValueKind.TimeSpan;

            Span<byte> buffer = stackalloc byte[MaxTimeSpanUtf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten, format))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }
        internal EncodedValue(uint value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt32Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(ulong value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt64Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(ushort value)
        {
            Kind = ValueKind.Number;

            Span<byte> buffer = stackalloc byte[MaxInt32Utf8Bytes];
            if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
            {
                Value = buffer.Slice(0, bytesWritten).ToArray();
            }

            Debug.Assert(true, "Failed to encode value");
        }

        internal EncodedValue(string value)
        {
            Kind = ValueKind.Utf8String;
            Value = Encoding.UTF8.GetBytes(value);
        }

        internal EncodedValue(BinaryData value) : this(value.ToMemory()) { }

        internal EncodedValue(ReadOnlySpan<byte> value)
        {
            if (value.SequenceEqual(s_null.Span))
            {
                Kind = ValueKind.Null;
                Value = s_null;
            }
            else if (value.SequenceEqual(s_false.Span))
            {
                Kind = ValueKind.BooleanFalse;
                Value = s_false;
            }
            else if (value.SequenceEqual(s_true.Span))
            {
                Kind = ValueKind.BooleanTrue;
                Value = s_true;
            }
            else
            {
                Kind = ValueKind.Json;
                Value = value.ToArray();
            }
        }

        internal EncodedValue(byte[] value) : this((ReadOnlyMemory<byte>)value) { }

        internal EncodedValue(ReadOnlyMemory<byte> value)
        {
            ReadOnlySpan<byte> span = value.Span;
            if (span.SequenceEqual(s_null.Span))
            {
                Kind = ValueKind.Null;
                Value = s_null;
            }
            else if (span.SequenceEqual(s_false.Span))
            {
                Kind = ValueKind.BooleanFalse;
                Value = s_false;
            }
            else if (span.SequenceEqual(s_true.Span))
            {
                Kind = ValueKind.BooleanTrue;
                Value = s_true;
            }
            else
            {
                Kind = ValueKind.Json;
                Value = value;
            }
        }

        internal ValueKind Kind { get; }

        internal ReadOnlyMemory<byte> Value { get; }

        internal bool TryDecodeValue(out bool value)
        {
            if (Utf8Parser.TryParse(Value.Span, out bool result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out byte value)
        {
            if (Utf8Parser.TryParse(Value.Span, out byte result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out DateTime value, StandardFormat format = default)
        {
            if (Utf8Parser.TryParse(Value.Span, out DateTime result, out _, format.Symbol))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out DateTimeOffset value, StandardFormat format = default)
        {
            if (Utf8Parser.TryParse(Value.Span, out DateTimeOffset result, out _, format.Symbol))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out decimal value)
        {
            if (Utf8Parser.TryParse(Value.Span, out decimal result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out double value)
        {
            if (Utf8Parser.TryParse(Value.Span, out double result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out float value)
        {
            if (Utf8Parser.TryParse(Value.Span, out float result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out Guid value)
        {
            if (Utf8Parser.TryParse(Value.Span, out Guid result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out int value)
        {
            if (Utf8Parser.TryParse(Value.Span, out int result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out long value)
        {
            if (Utf8Parser.TryParse(Value.Span, out long result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out sbyte value)
        {
            if (Utf8Parser.TryParse(Value.Span, out sbyte result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out short value)
        {
            if (Utf8Parser.TryParse(Value.Span, out short result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out TimeSpan value, StandardFormat format = default)
        {
            if (Utf8Parser.TryParse(Value.Span, out TimeSpan result, out _, format.Symbol))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out uint value)
        {
            if (Utf8Parser.TryParse(Value.Span, out uint result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out ulong value)
        {
            if (Utf8Parser.TryParse(Value.Span, out ulong result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeValue(out ushort value)
        {
            if (Utf8Parser.TryParse(Value.Span, out ushort result, out _))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        internal bool TryDecodeNullableValue<T>(out T? value, out bool supportedType)
            where T : struct
        {
            value = default;
            supportedType = true;

            if (Value.Span.SequenceEqual(s_null.Span))
            {
                return true;
            }

            Type target = typeof(T);
            bool parsed;

            if (target == typeof(bool))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out bool boolValue, out _);
                value = parsed ? (T?)(object)boolValue : null;
                return parsed;
            }
            if (target == typeof(byte))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out byte byteValue, out _);
                value = parsed ? (T?)(object)byteValue : null;
                return parsed;
            }
            if (target == typeof(sbyte))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out sbyte sbyteValue, out _);
                value = parsed ? (T?)(object)sbyteValue : null;
                return parsed;
            }
            if (target == typeof(short))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out short shortValue, out _);
                value = parsed ? (T?)(object)shortValue : null;
                return parsed;
            }
            if (target == typeof(ushort))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out ushort ushortValue, out _);
                value = parsed ? (T?)(object)ushortValue : null;
                return parsed;
            }
            if (target == typeof(int))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out int intValue, out _);
                value = parsed ? (T?)(object)intValue : null;
                return parsed;
            }
            if (target == typeof(uint))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out uint uintValue, out _);
                value = parsed ? (T?)(object)uintValue : null;
                return parsed;
            }
            if (target == typeof(long))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out long longValue, out _);
                value = parsed ? (T?)(object)longValue : null;
                return parsed;
            }
            if (target == typeof(ulong))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out ulong ulongValue, out _);
                value = parsed ? (T?)(object)ulongValue : null;
                return parsed;
            }
            if (target == typeof(float))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out float floatValue, out _);
                value = parsed ? (T?)(object)floatValue : null;
                return parsed;
            }
            if (target == typeof(double))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out double doubleValue, out _);
                value = parsed ? (T?)(object)doubleValue : null;
                return parsed;
            }
            if (target == typeof(decimal))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out decimal decimalValue, out _);
                value = parsed ? (T?)(object)decimalValue : null;
                return parsed;
            }
            if (target == typeof(DateTime))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out DateTime dateTimeValue, out _);
                value = parsed ? (T?)(object)dateTimeValue : null;
                return parsed;
            }
            if (target == typeof(DateTimeOffset))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out DateTimeOffset dateTimeOffsetValue, out _);
                value = parsed ? (T?)(object)dateTimeOffsetValue : null;
                return parsed;
            }
            if (target == typeof(Guid))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out Guid guidValue, out _);
                value = parsed ? (T?)(object)guidValue : null;
                return parsed;
            }
            if (target == typeof(TimeSpan))
            {
                parsed = Utf8Parser.TryParse(Value.Span, out TimeSpan timeSpanValue, out _);
                value = parsed ? (T?)(object)timeSpanValue : null;
                return parsed;
            }

            supportedType = false;
            return false;
        }
    }
}
