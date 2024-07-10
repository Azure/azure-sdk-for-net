// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.TestFramework.Proxy;

/// <summary>
/// An implementation of <see cref="IInstrumented"/> that allows you to get the original back.
/// </summary>
public class InstrumentedMixIn : IInstrumented
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="original">The original instance.</param>
    public InstrumentedMixIn(object original, object? context = null)
    {
        Original = original;
        Context = context;
    }

    /// <inheritdoc />
    public object Original { get; }

    /// <inheritdoc />
    public object? Context { get; }
}
