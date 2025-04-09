// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace System.ClientModel.Primitives;

/// <summary>
/// An interface implemented by auth flow interfaces supporting scopes.
/// </summary>
public class GetTokenOptions
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
    public ReadOnlyMemory<string> Scopes { get; }

    /// <summary>
    /// Gets the properties to be used for token requests.
    /// </summary>
    public IReadOnlyDictionary<string, object> Properties { get; }

    /// <summary>
    /// Creates a new instance of <see cref="GetTokenOptions"/> with the specified scopes.
    /// </summary>
    /// <param name="scopes">The scopes to be used in a call to <see cref="AuthenticationTokenProvider.GetToken(GetTokenOptions, Threading.CancellationToken)"/> or <see cref="AuthenticationTokenProvider.GetTokenAsync(GetTokenOptions, Threading.CancellationToken)"/></param>
    /// <param name="properties">The properties to be used for token requests.</param>
    public GetTokenOptions(ReadOnlyMemory<string> scopes, IReadOnlyDictionary<string, object> properties)
    {
        Scopes = scopes;
        Properties = properties switch
        {
            Dictionary<string, object> dict => new ReadOnlyDictionary<string, object>(dict),
            ReadOnlyDictionary<string, object> readOnlyDict => readOnlyDict,
            _ => new ReadOnlyDictionary<string, object>(properties.ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
        };
    }

    /// <summary>
    /// Creates a new instance of <see cref="GetTokenOptions"/> by combining the current scopes with additional scopes.
    /// </summary>
    /// <param name="additionalScopes">Additional authentication scopes to be combined with existing ones.</param>
    /// <returns>A new <see cref="GetTokenOptions"/> instance containing both original and additional scopes.</returns>
    /// <remarks>
    /// This method creates a new options instance rather than modifying the existing one, maintaining immutability.
    /// The order of scopes is preserved, with original scopes followed by additional scopes.
    /// </remarks>
    public GetTokenOptions WithAdditionalScopes(ReadOnlyMemory<string> additionalScopes)
    {
        var originalScopes = Scopes;
        var combined = new string[originalScopes.Length + additionalScopes.Length];
        originalScopes.Span.CopyTo(combined.AsSpan(0, originalScopes.Length));
        additionalScopes.Span.CopyTo(combined.AsSpan(originalScopes.Length));
        return new GetTokenOptions(combined, Properties);
    }
}
