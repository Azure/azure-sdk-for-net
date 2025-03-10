// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Auth;

/// <summary>
/// An interface implemented by the context type for <see cref="TokenProvider{TContext}"/> implementations supporting authorization code flow.
/// </summary>
public interface IAuthorizationCodeFlowContext : IScopedFlowContext
{
    /// <summary>
    /// Gets the authorization endpoint URI.
    /// </summary>
    Uri AuthorizationUri { get; }

    /// <summary>
    /// Gets the token endpoint URI.
    /// </summary>
    Uri TokenUri { get; }

    /// <summary>
    /// Gets the refresh token endpoint URI.
    /// </summary>
    Uri RefreshUri { get; }
}
