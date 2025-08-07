// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.AutoSyncAsync;

/// <summary>
/// A helper class for the automatic sync/async testing. This is mixed in with (aka added to) the dynamic proxy
/// that is generated around a client instance. This allows you to a simple way to get the original back, as
/// well as a place to store an additional context.
/// </summary>
public class AutoSyncAsyncMixIn : IAutoSyncAsync
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="original">The original instance.</param>
    public AutoSyncAsyncMixIn(object original, object? context = null)
    {
        Original = original;
        Context = context;
    }

    /// <inheritdoc />
    public object Original { get; }

    /// <inheritdoc />
    public object? Context { get; }
}
