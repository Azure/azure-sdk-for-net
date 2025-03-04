// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a token.
/// </summary>
public interface IClientCredentialsFlowContext : IScopedFlowContext
{
    /// <summary>
    /// Gets the token endpoint URI.
    /// </summary>
    Uri TokenUri { get; }

    /// <summary>
    /// Gets the refresh token endpoint URI.
    /// </summary>
    Uri RefreshUri { get; }
}
