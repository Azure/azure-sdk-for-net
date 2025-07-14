// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    public static Guid NewGuid(this Random random)
    {
        var bytes = new byte[16];
        random.NextBytes(bytes);
        return new Guid(bytes);
    }
}
