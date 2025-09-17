﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.ClientModel.Primitives;

/// <summary>
/// A struct representing a JSON patch for partial updates to a JSON structure.
/// </summary>
[Experimental("SCME0001")]
public partial struct JsonPatch
{
    /// <summary>
    /// Delegate for propagating set operations to child properties of the containing model.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate bool PropagatorSetter(ReadOnlySpan<byte> jsonPath, EncodedValue value);

    /// <summary>
    /// Delegate for propagating get operations from child properties of the containing model.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate bool PropagatorGetter(ReadOnlySpan<byte> jsonPath, out EncodedValue value);

    /// <summary>
    /// Initializes a new instance of <see cref="JsonPatch"/> with utf8 JSON representing the entire object.
    /// </summary>
    /// <param name="utf8Json">The utf8 JSON.</param>
    public JsonPatch(ReadOnlyMemory<byte> utf8Json)
    {
        _rawJson = new(ValueKind.Json, utf8Json);
    }

    /// <summary>
    /// Sets the callbacks for propagating values to/from another JsonPatch on child properties.
    /// </summary>
    /// <param name="setter">The <see cref="PropagatorSetter"/> callback to use.</param>
    /// <param name="getter">The <see cref="PropagatorSetter"/> callback to use.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPropagators(PropagatorSetter setter, PropagatorGetter getter)
    {
        _propagatorSetter = setter;
        _propagatorGetter = getter;
    }

    /// <summary>
    /// Determines whether the specified JSON path exists in the patch.
    /// </summary>
    /// <param name="jsonPath">The JSON path to check.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
        {
            return false;
        }

        // if someone called Append on an array, we don't want to consider that as "contains" for the array path
        // since the entire array wasn't set it was just one item appended to it.
        return _properties.TryGetValue(jsonPath, out var value) && !value.Kind.HasFlag(ValueKind.ArrayItemAppend);
    }

    #region Set Methods
    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, bool value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, byte value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="format">The format to encode the value into.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, DateTime value, StandardFormat format = default)
    {
        SetInternal(jsonPath, new(value, format));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="format">The format to encode the value into.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, DateTimeOffset value, StandardFormat format = default)
    {
        SetInternal(jsonPath, new(value, format));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, decimal value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, double value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, float value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, Guid value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, int value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, long value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, sbyte value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, short value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="format">The format to encode the value into.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, TimeSpan value, StandardFormat format = default)
    {
        SetInternal(jsonPath, new(value, format));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, uint value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, ulong value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, ushort value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, string value)
    {
        SetInternal(jsonPath, new(value));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="utf8Json">The utf8 json to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, byte[] utf8Json)
    {
        SetInternal(jsonPath, new(utf8Json));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="utf8Json">The utf8 json to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, BinaryData utf8Json)
    {
        SetInternal(jsonPath, new(utf8Json));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="utf8Json">The utf8 json to set.</param>
    public void Set(ReadOnlySpan<byte> jsonPath, ReadOnlySpan<byte> utf8Json)
    {
        SetInternal(jsonPath, new(utf8Json));
    }

    /// <summary>
    /// Sets a value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    /// <param name="value">The value to set.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Set(ReadOnlySpan<byte> jsonPath, EncodedValue value)
    {
        SetInternal(jsonPath, value);
    }

    /// <summary>
    /// Sets NULL at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to be set.</param>
    public void SetNull(ReadOnlySpan<byte> jsonPath)
    {
        SetInternal(jsonPath, EncodedValue.Null);
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Gets a boolean value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public bool GetBoolean(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out bool boolValue))
        {
            return boolValue;
        }

        return ThrowFormatException<bool>(jsonPath);
    }

    /// <summary>
    /// Gets a byte value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public byte GetByte(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out byte byteValue))
        {
            return byteValue;
        }

        return ThrowFormatException<byte>(jsonPath);
    }

    /// <summary>
    /// Gets a DateTime value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="format">The format the DateTime is in.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public DateTime GetDateTime(ReadOnlySpan<byte> jsonPath, StandardFormat format = default)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out DateTime dateTimeValue, format))
        {
            return dateTimeValue;
        }

        return ThrowFormatException<DateTime>(jsonPath);
    }

    /// <summary>
    /// Gets a DateTimeOffset value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="format">The format the DateTimeOffset is in.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public DateTimeOffset GetDateTimeOffset(ReadOnlySpan<byte> jsonPath, StandardFormat format = default)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out DateTimeOffset dateTimeOffsetValue, format))
        {
            return dateTimeOffsetValue;
        }

        return ThrowFormatException<DateTimeOffset>(jsonPath);
    }

    /// <summary>
    /// Gets a decimal value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public decimal GetDecimal(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out decimal decimalValue))
        {
            return decimalValue;
        }

        return ThrowFormatException<decimal>(jsonPath);
    }

    /// <summary>
    /// Gets a double value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public double GetDouble(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out double doubleValue))
        {
            return doubleValue;
        }

        return ThrowFormatException<double>(jsonPath);
    }

    /// <summary>
    /// Gets a float value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public float GetFloat(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out float floatValue))
        {
            return floatValue;
        }

        return ThrowFormatException<float>(jsonPath);
    }

    /// <summary>
    /// Gets a Guid value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public Guid GetGuid(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out Guid guidValue))
        {
            return guidValue;
        }

        return ThrowFormatException<Guid>(jsonPath);
    }

    /// <summary>
    /// Gets a Int32 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public int GetInt32(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out int intValue))
        {
            return intValue;
        }

        return ThrowFormatException<int>(jsonPath);
    }

    /// <summary>
    /// Gets a Int64 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public long GetInt64(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out long int64Value))
        {
            return int64Value;
        }

        return ThrowFormatException<long>(jsonPath);
    }

    /// <summary>
    /// Gets a Int8 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public sbyte GetInt8(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out sbyte int8Value))
        {
            return int8Value;
        }

        return ThrowFormatException<sbyte>(jsonPath);
    }

    /// <summary>
    /// Gets a Int16 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public short GetInt16(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out short int16Value))
        {
            return int16Value;
        }

        return ThrowFormatException<short>(jsonPath);
    }

    /// <summary>
    /// Gets a TimeSpan value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="format">The format the TimeSpan is in.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public TimeSpan GetTimeSpan(ReadOnlySpan<byte> jsonPath, StandardFormat format = default)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out TimeSpan timeSpanValue, format))
        {
            return timeSpanValue;
        }

        return ThrowFormatException<TimeSpan>(jsonPath);
    }

    /// <summary>
    /// Gets a UInt32 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public uint GetUInt32(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out uint uintValue))
        {
            return uintValue;
        }

        return ThrowFormatException<uint>(jsonPath);
    }

    /// <summary>
    /// Gets a UInt64 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public ulong GetUInt64(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out ulong uint64Value))
        {
            return uint64Value;
        }

        return ThrowFormatException<ulong>(jsonPath);
    }

    /// <summary>
    /// Gets a UInt16 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public ushort GetUInt16(ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeValue(out ushort uint16Value))
        {
            return uint16Value;
        }

        return ThrowFormatException<ushort>(jsonPath);
    }

    /// <summary>
    /// Gets a string value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public string? GetString(ReadOnlySpan<byte> jsonPath)
    {
        if (TryGetValue(jsonPath, out string? stringValue))
        {
            return stringValue;
        }

        ThrowKeyNotFoundException(jsonPath);
        return null;
    }

    /// <summary>
    /// Gets the Utf8 JSON value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    public BinaryData GetJson(ReadOnlySpan<byte> jsonPath)
    {
        return new(GetEncodedValue(jsonPath));
    }

    /// <summary>
    /// Gets a nullable primitive value at the specified JSON path.
    /// </summary>
    /// <typeparam name="T">The struct type if its not null.</typeparam>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    /// <exception cref="NotSupportedException">If the <typeparamref name="T"/> is not supported.</exception>
    public T? GetNullableValue<T>(ReadOnlySpan<byte> jsonPath)
        where T : struct
    {
        if (!TryGetEncodedValueInternal(jsonPath, out EncodedValue encodedValue))
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        if (encodedValue.TryDecodeNullableValue(out T? value, out bool supportedType))
        {
            return value;
        }

        if (supportedType)
        {
            return ThrowFormatException<T?>(jsonPath);
        }
        else
        {
            return NullableTypeNotSupported<T>();
        }
    }
    #endregion

    #region TryGet Methods
    /// <summary>
    /// Tries to get a boolean value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out bool value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out bool result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a byte value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out byte value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out byte result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a DateTime value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <param name="format">The format the DateTime is in.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out DateTime value, StandardFormat format = default)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out DateTime result, format.Symbol))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a DateTimeOffset value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <param name="format">The format the DateTimeOffset is in.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out DateTimeOffset value, StandardFormat format = default)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out DateTimeOffset result, format.Symbol))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a decimal value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out decimal value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out decimal result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a double value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out double value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out double result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a float value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out float value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out float result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a Guid value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out Guid value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out Guid result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a Int32 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out int value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out int result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a Int64 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out long value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out long result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a Int8 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out sbyte value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out sbyte result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a Int16 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out short value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out short result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a TimeSpan value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <param name="format">The format the TimeSpan is in.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out TimeSpan value, StandardFormat format = default)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out TimeSpan result, format.Symbol))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a UInt32 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out uint value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out uint result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a UInt64 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out ulong value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out ulong result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a UInt16 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out ushort value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue)
            && encodedValue.TryDecodeValue(out ushort result))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a string value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetValue(ReadOnlySpan<byte> jsonPath, out string? value)
    {
        if (TryGetEncodedValueInternal(jsonPath, out var encodedValue))
        {
            if (EncodedValue.Null.Value.Span.SequenceEqual(encodedValue.Value.Span))
            {
                value = null;
                return true;
            }

            var span = encodedValue.Value.Span;
            if (span.Length >= 2 && span[0] == (byte)'"' && span[span.Length - 1] == (byte)'"')
            {
                // Trim the quotes
                span = span.Slice(1, span.Length - 2);
            }

#if NET6_0_OR_GREATER
            value = Encoding.UTF8.GetString(span);
#else
            value = Encoding.UTF8.GetString(span.ToArray());
#endif
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Tries to get a UInt16 value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetNullableValue<T>(ReadOnlySpan<byte> jsonPath, out T? value)
        where T : struct
    {
        value = default;

        if (!TryGetEncodedValueInternal(jsonPath, out EncodedValue encodedValue))
        {
            return false;
        }

        if (encodedValue.Kind.HasFlag(ValueKind.Null))
        {
            return true;
        }

        if (encodedValue.TryDecodeNullableValue(out T? result, out _))
        {
            value = result;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to get a string value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TryGetEncodedValue(ReadOnlySpan<byte> jsonPath, out EncodedValue value)
    {
        return TryGetEncodedValueInternal(jsonPath, out value);
    }

    /// <summary>
    /// Tries to get the Utf8 JSON value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to get.</param>
    /// <param name="value">The value if found.</param>
    /// <returns>True if the value was found and parsed; otherwise, false.</returns>
    public bool TryGetJson(ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> value)
    {
        var found = TryGetEncodedValueInternal(jsonPath, out var encodedValue);
        value = encodedValue.Value;
        return found;
    }
    #endregion

    #region Append Methods
    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, bool value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, byte value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    /// <param name="format">The format to encode the value into.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, DateTime value, StandardFormat format = default)
    {
        EncodedValue encodedValue = new(value, format);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    /// <param name="format">The format to encode the value into.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, DateTimeOffset value, StandardFormat format = default)
    {
        EncodedValue encodedValue = new(value, format);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, decimal value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, double value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, float value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, Guid value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, int value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, long value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, sbyte value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, short value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    /// <param name="format">The format to encode the value into.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, TimeSpan value, StandardFormat format = default)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, uint value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, ulong value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, ushort value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="value">The value to append.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, string value)
    {
        EncodedValue encodedValue = new(value);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="utf8Json">The utf8 json to insert.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, byte[] utf8Json)
    {
        EncodedValue encodedValue = new(utf8Json);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="utf8Json">The utf8 json to insert.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, BinaryData utf8Json)
    {
        EncodedValue encodedValue = new(utf8Json);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends a value to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    /// <param name="utf8Json">The utf8 json to insert.</param>
    public void Append(ReadOnlySpan<byte> arrayPath, ReadOnlySpan<byte> utf8Json)
    {
        EncodedValue encodedValue = new(utf8Json);
        encodedValue.Kind |= ValueKind.ArrayItemAppend;
        SetInternal(arrayPath, encodedValue);
    }

    /// <summary>
    /// Appends NULL to an array at the specified JSON path.
    /// </summary>
    /// <param name="arrayPath">The JSON path pointing at the array.</param>
    public void AppendNull(ReadOnlySpan<byte> arrayPath)
    {
        SetInternal(arrayPath, new(ValueKind.Null | ValueKind.ArrayItemAppend, EncodedValue.Null.Value));
    }
    #endregion

    /// <summary>
    /// Removes the value at the specified JSON path.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to remove.</param>
    public void Remove(ReadOnlySpan<byte> jsonPath)
    {
        SetInternal(jsonPath, EncodedValue.Removed);
    }

    /// <summary>
    /// Checks if the value at the specified JSON path has been removed.
    /// </summary>
    /// <param name="jsonPath">The JSON path of the value to check.</param>
    public bool IsRemoved(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties is null)
        {
            return false;
        }

        return _properties.TryGetValue(jsonPath, out var value) && value.Kind == ValueKind.Removed;
    }

    /// <summary>
    /// Checks if there is a child property of the given prefix that matches the given property name.
    /// Allows the caller to avoid concatenating the prefix and property name to check for existence.
    /// </summary>
    /// <param name="prefix">The prefix JSON path.</param>
    /// <param name="property">The property name.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Contains(ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> property)
    {
        if (_properties == null)
        {
            return false;
        }

        Span<byte> normalizedPrefix = stackalloc byte[prefix.Length];
        JsonPathComparer.Default.Normalize(prefix, normalizedPrefix, out int bytesWritten);
        normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

        foreach (var kvp in _properties)
        {
            ReadOnlySpan<byte> keySpan = kvp.Key;

            if (!keySpan.StartsWith(normalizedPrefix))
            {
                continue;
            }

            if (property.SequenceEqual(keySpan.Slice(normalizedPrefix.Length).GetPropertyNameFromSlice()))
            {
                return true;
            }
        }

        return false;
    }

    /// <inheritdoc />
    public override string ToString()
        => ToString("JP");

    /// <summary>
    /// Returns a string representation of the object using the specified format.
    /// </summary>
    /// <param name="format">The format to return 'J' for application/json or 'JP' for application/json-patch+json.</param>
    /// <returns>A string that represents the object, formatted according to the specified format.</returns>
    public string ToString(string format)
    {
        ThrowIfNull(format, nameof(format));

        switch (format)
        {
            case "J":
                return SerializeToJson();
            case "JP":
                return SerializeToJsonPatch();
            default:
                return ThrowFormatNotSupportedException(format);
        }
    }
}
