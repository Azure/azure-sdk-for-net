// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.AutoSyncAsync;

/// <summary>
/// An interface that serves as a way to identify a dynamically proxied class that supports automatic sync and async testing. This
/// also provides a way to get the the original un-proxied instance.
/// instance.
/// </summary>
public interface IAutoSyncAsync
{
    /// <summary>
    /// Gets the original un-proxied instance back.
    /// </summary>
    public object Original { get; }

    /// <summary>
    /// Any additional context associated with the instrumented object (e.g. options used to create it).
    /// </summary>
    public object? Context { get; }
}
