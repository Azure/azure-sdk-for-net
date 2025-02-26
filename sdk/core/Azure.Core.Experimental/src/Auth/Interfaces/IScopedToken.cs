// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a token.
/// </summary>
public interface IScopedFlowToken : ITokenContext
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
    object CloneWithAdditionalScopes(string[] additionalScopes);
}
