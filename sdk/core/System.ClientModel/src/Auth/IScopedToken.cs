// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a token.
/// </summary>
public interface IScopedToken : ITokenContext
{
    /// <summary>
    /// Gets the scopes required to authenticate.
    /// </summary>
    string[] Scopes { get; }
}
