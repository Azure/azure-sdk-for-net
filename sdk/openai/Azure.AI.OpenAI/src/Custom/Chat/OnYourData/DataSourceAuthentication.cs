// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

using Azure.Core;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureChatDataSourceAuthenticationOptions")]
[Experimental("AOAI001")]
public partial class DataSourceAuthentication
{
    public static DataSourceAuthentication FromApiKey(string apiKey)
        => new InternalAzureChatDataSourceApiKeyAuthenticationOptions(apiKey);
    public static DataSourceAuthentication FromConnectionString(string connectionString)
        => new InternalAzureChatDataSourceConnectionStringAuthenticationOptions(connectionString);
    public static DataSourceAuthentication FromSystemManagedIdentity()
        => new InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions();
    public static DataSourceAuthentication FromUserManagedIdentity(ResourceIdentifier identityResource)
        => new InternalAzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions(identityResource);
#if !AZURE_OPENAI_GA
    public static DataSourceAuthentication FromUsernameAndPassword(string username, string password)
        => new InternalAzureChatDataSourceUsernameAndPasswordAuthenticationOptions(username, password);
    public static DataSourceAuthentication FromAccessToken(string accessToken)
        => new InternalAzureChatDataSourceAccessTokenAuthenticationOptions(accessToken);
    public static DataSourceAuthentication FromKeyAndKeyId(string key, string keyId)
        => new InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(key, keyId);
    public static DataSourceAuthentication FromEncodedApiKey(string encodedApiKey)
        => new InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(encodedApiKey);
#endif
}
