// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// An interface implemented by instrumented clients that allows interceptors to retrieve the original value.
/// </summary>
public interface IWrappedClient
{
    /// <summary>
    /// Gets the original value.
    /// </summary>
    public object Original { get; }
}