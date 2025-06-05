// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

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
    /// Gets the properties to be used for token requests.
    /// </summary>
    public IReadOnlyDictionary<string, object> Properties { get; }

    /// <summary>
    /// Creates a new instance of <see cref="GetTokenOptions"/> with the specified scopes.
    /// </summary>
    /// <param name="properties">The additional properties to be used for token requests.</param>
    public GetTokenOptions(IReadOnlyDictionary<string, object> properties)
    {
        Properties = properties switch
        {
            Dictionary<string, object> dict => new ReadOnlyDictionary<string, object>(dict),
            ReadOnlyDictionary<string, object> readOnlyDict => readOnlyDict,
            _ => new ReadOnlyDictionary<string, object>(properties.ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
        };
    }
}
