// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Mocks.Client;

/// <summary>
/// An implementation of <see cref="IWrapped"/> that allows you to get the original back, as well as a place
/// to store an additional context.
/// </summary>
public class WrappedMixIn : IWrapped
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="original">The original instance.</param>
    public WrappedMixIn(object original, object? context = null)
    {
        Original = original;
        Context = context;
    }

    /// <inheritdoc />
    public object Original { get; }

    /// <inheritdoc />
    public object? Context { get; }
}
