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
    private ReadOnlyMemory<byte> ThrowPropertyNotFoundException(ReadOnlySpan<byte> jsonPath)
       => throw new KeyNotFoundException(Encoding.UTF8.GetString(jsonPath.ToArray()));

    private void ThrowIfNull(object? obj, string parameterName)
    {
        if (obj is null)
        {
            ThrowArgumentNullException(parameterName);
        }
    }

    [DoesNotReturn]
    private void ThrowArgumentNullException(string parameterName)
        => throw new ArgumentNullException(parameterName);

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private string ThrowFormatNotSupportedException(string format)
       => throw new NotSupportedException($"The format '{format}' is not supported.");
}
