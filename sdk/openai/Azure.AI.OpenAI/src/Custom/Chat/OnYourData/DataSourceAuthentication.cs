// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

using Azure.Core;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureChatDataSourceAuthenticationOptions")]
[Experimental("AOAI001")]
public partial class DataSourceAuthentication
{
    /// <summary> Creates authentication using an API key. </summary>
    /// <param name="apiKey"> The API key to use for data source authentication. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromApiKey(string apiKey)
        => new InternalAzureChatDataSourceApiKeyAuthenticationOptions(apiKey);
    /// <summary> Creates authentication using a connection string. </summary>
    /// <param name="connectionString"> The connection string to use for data source authentication. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromConnectionString(string connectionString)
        => new InternalAzureChatDataSourceConnectionStringAuthenticationOptions(connectionString);
    /// <summary> Creates authentication using a system-assigned managed identity. </summary>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromSystemManagedIdentity()
        => new InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions();
    /// <summary> Creates authentication using a user-assigned managed identity. </summary>
    /// <param name="identityResource"> The resource identifier of the user-assigned managed identity. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromUserManagedIdentity(ResourceIdentifier identityResource)
        => new InternalAzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions(identityResource);
#if !AZURE_OPENAI_GA
    /// <summary> Creates authentication using a username and password combination. </summary>
    /// <param name="username"> The username to use for authentication. </param>
    /// <param name="password"> The password to use for authentication. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromUsernameAndPassword(string username, string password)
        => new InternalAzureChatDataSourceUsernameAndPasswordAuthenticationOptions(username, password);
    /// <summary> Creates authentication using an access token. </summary>
    /// <param name="accessToken"> The access token to use for data source authentication. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromAccessToken(string accessToken)
        => new InternalAzureChatDataSourceAccessTokenAuthenticationOptions(accessToken);
    /// <summary> Creates authentication using a key and key identifier pair. </summary>
    /// <param name="key"> The key value to use for authentication. </param>
    /// <param name="keyId"> The identifier associated with the key. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromKeyAndKeyId(string key, string keyId)
        => new InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(key, keyId);
    /// <summary> Creates authentication using a base64-encoded API key. </summary>
    /// <param name="encodedApiKey"> The base64-encoded API key for data source authentication. </param>
    /// <returns> A new <see cref="DataSourceAuthentication"/> instance. </returns>
    public static DataSourceAuthentication FromEncodedApiKey(string encodedApiKey)
        => new InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(encodedApiKey);
#endif
}
