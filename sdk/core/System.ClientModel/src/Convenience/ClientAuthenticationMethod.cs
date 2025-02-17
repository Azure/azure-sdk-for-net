// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;
/// <summary>
/// Specifies the kind of connection used by the client.
/// </summary>
public enum ClientAuthenticationMethod
{
    /// <summary>
    /// Represents a connection using Credential.
    /// </summary>
    Credential,

    /// <summary>
    /// Represents a connection using an API key.
    /// </summary>
    ApiKey,

    /// <summary>
    /// Represents a connection using an out-of-band method.
    /// </summary>
    NoAuth
}
