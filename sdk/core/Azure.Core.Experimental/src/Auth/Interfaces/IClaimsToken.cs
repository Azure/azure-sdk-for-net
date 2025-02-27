// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a token.
/// </summary>
public interface IClaimsToken : IScopedFlowToken
{
    /// <summary>
    /// Additional claims to be included in the token.
    /// </summary>
    string Claims { get; }
}
