// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.TestFramework.Proxy;

/// <summary>
/// An interface that serves as a way to identify a proxied class, as well as get the original un-proxied
/// instance.
/// </summary>
public interface IInstrumented
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
