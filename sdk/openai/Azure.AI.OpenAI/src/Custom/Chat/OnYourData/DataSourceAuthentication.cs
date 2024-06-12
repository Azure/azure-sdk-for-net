// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatDataSourceAuthenticationOptions")]
public partial class DataSourceAuthentication
{
    public static DataSourceAuthentication FromApiKey(string apiKey)
        => new InternalAzureChatDataSourceApiKeyAuthenticationOptions(apiKey);
    public static DataSourceAuthentication FromAccessToken(string accessToken)
        => new InternalAzureChatDataSourceAccessTokenAuthenticationOptions(accessToken);
    public static DataSourceAuthentication FromConnectionString(string connectionString)
        => new InternalAzureChatDataSourceConnectionStringAuthenticationOptions(connectionString);
    public static DataSourceAuthentication FromKeyAndKeyId(string key, string keyId)
        => new InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(key, keyId);
    public static DataSourceAuthentication FromEncodedApiKey(string encodedApiKey)
        => new InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(encodedApiKey);
    public static DataSourceAuthentication FromSystemManagedIdentity()
        => new InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions();
    public static DataSourceAuthentication FromUserManagedIdentity(string identityResourceId)
        => new InternalAzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions(identityResourceId);
}