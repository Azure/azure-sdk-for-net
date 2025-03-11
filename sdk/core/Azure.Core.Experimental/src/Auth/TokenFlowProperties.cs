// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Auth;

/// <summary>
/// An interface implemented by auth flow interfaces supporting scopes.
/// </summary>
public class TokenFlowProperties
{
    /// <summary>
    /// The name of the property used to specify the scopes required to authenticate.
    /// </summary>
    public const string ScopesPropertyName = "scopes";

    /// <summary>
    /// The name of the property used to specify the token URL.
    /// </summary>
    public const string TokenUrlPropertyName = "tokenUrl";

    /// <summary>
    /// The name of the property used to specify the authorization URL.
    /// </summary>
    public const string AuthorizationUrlPropertyName = "authorizationUrl";

    /// <summary>
    /// The name of the property used to specify the client ID.
    /// </summary>
    public const string RefreshUrlPropertyName = "refreshUrl";

    /// <summary>
    /// Gets the scopes required to authenticate.
    /// </summary>
    public string[] Scopes { get; }

    /// <summary>
    /// Gets the properties to be used for token requests.
    /// </summary>
    public IReadOnlyDictionary<string, object> Properties { get; }

    /// <summary>
    /// Creates a new instance of <see cref="TokenFlowProperties"/> with the specified scopes.
    /// </summary>
    /// <param name="scopes">The scopes to be used in a call to <see cref="TokenProvider.GetToken(TokenFlowProperties, Threading.CancellationToken)"/> or <see cref="TokenProvider.GetTokenAsync(TokenFlowProperties, Threading.CancellationToken)"/></param>
    /// <param name="properties">The properties to be used for token requests.</param>
    public TokenFlowProperties(string[] scopes, IReadOnlyDictionary<string, object> properties)
    {
        Scopes = scopes;
        Properties = properties;
    }

    /// <summary>
    /// Clones the current context with additional scopes.
    /// </summary>
    /// <param name="additionalScopes"></param>
    /// <returns></returns>
    public TokenFlowProperties WithAdditionalScopes(string[] additionalScopes)
    {
        return new TokenFlowProperties([.. Scopes, .. additionalScopes], Properties);
    }
}
