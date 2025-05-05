// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;
/// <summary>
/// Specifies the kind of connection used by the client.
/// </summary>
public enum CredentialKind
{
    /// <summary>
    /// Represents a connection using an out-of-band method.
    /// </summary>
    None = 0,

    /// <summary>
    /// Represents a connection using an API key as a string.
    /// </summary>
    ApiKeyString = 1,

    /// <summary>
    /// Represents a connection using Token Credential.
    /// </summary>
    TokenCredential = 2,
}
