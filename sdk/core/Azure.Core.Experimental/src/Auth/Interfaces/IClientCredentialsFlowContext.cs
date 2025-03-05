// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Auth;

/// <summary>
/// An interface implemented by the context type for <see cref="TokenProvider{TContext}"/> implementations supporting client credential flow.
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
