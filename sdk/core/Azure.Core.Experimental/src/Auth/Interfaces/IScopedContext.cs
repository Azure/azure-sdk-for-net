// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Auth;

/// <summary>
/// An interface implemented by auth flow interfaces supporting scopes.
/// </summary>
public interface IScopedFlowContext : ITokenContext
{
    /// <summary>
    /// Gets the scopes required to authenticate.
    /// </summary>
    string[] Scopes { get; }

    /// <summary>
    /// Clones the current context with additional scopes.
    /// </summary>
    /// <param name="additionalScopes"></param>
    /// <returns></returns>
    ITokenContext WithAdditionalScopes(params string[] additionalScopes);
}
