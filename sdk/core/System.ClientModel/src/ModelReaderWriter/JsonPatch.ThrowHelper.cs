// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static ReadOnlyMemory<byte> ThrowKeyNotFoundException(ReadOnlySpan<byte> jsonPath)
       => throw new KeyNotFoundException($"No value found at JSON path '{Encoding.UTF8.GetString(jsonPath.ToArray())}'.");

    private static void ThrowIfNull(object? obj, string parameterName)
    {
        if (obj is null)
        {
            ThrowArgumentNullException(parameterName);
        }
    }

    [DoesNotReturn]
    private static void ThrowArgumentNullException(string parameterName)
        => throw new ArgumentNullException(parameterName);

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static string ThrowFormatNotSupportedException(string format)
       => throw new NotSupportedException($"The format '{format}' is not supported.");

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static T ThrowFormatException<T>(ReadOnlySpan<byte> jsonPath)
       => throw new FormatException($"Value at '{Encoding.UTF8.GetString(jsonPath.ToArray())}' is not a {typeof(T)}.");

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static T? NullableTypeNotSupported<T>()
        => throw new NotSupportedException($"Type '{typeof(T)}' is not supported by GetNullableValue.");

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static EncodedValue ThrowEncodeFailedException<T>(T value)
        => throw new InvalidOperationException($"Failed to encode value '{value}'.");

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static void ThrowIndexOutOfRangeException(ReadOnlySpan<byte> jsonPath)
        => throw new IndexOutOfRangeException($"Cannot remove non-existing array item at path '{Encoding.UTF8.GetString(jsonPath.ToArray())}'.");

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static void ThrowInvalidToken(JsonPathTokenType tokenType)
        => throw new InvalidOperationException($"Unexpected token type: {tokenType}");
}
