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
}
