// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.SourceGeneration;

internal static class HashHelpers
{
    public static int Combine(int h1, int h2)
    {
        // RyuJIT optimizes this to use the ROL instruction
        // Related GitHub pull request: https://github.com/dotnet/coreclr/pull/1830
        uint rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);
        return ((int)rol5 + h1) ^ h2;
    }
}
