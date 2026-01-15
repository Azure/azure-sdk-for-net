// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Provides extension methods for the <see cref="Random"/> class to generate
/// additional types of random values useful in testing scenarios.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    /// Generates a deterministic <see cref="Guid"/> using the specified <see cref="Random"/> instance.
    /// </summary>
    /// <param name="random">The <see cref="Random"/> instance to use for generating random bytes.</param>
    public static Guid NewGuid(this Random random)
    {
        var bytes = new byte[16];
        random.NextBytes(bytes);
        return new Guid(bytes);
    }
}
