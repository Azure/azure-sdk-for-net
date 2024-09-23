// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatDataSourceVectorizationSource")]
public abstract partial class DataSourceVectorizer
{
    /// <summary>
    /// Creates a new data source embedding dependency reference from an authenticated endpoint.
    /// </summary>
    /// <remarks>
    /// Vectorization endpoint authentication only supports api-key- and access-token-based authentication, as
    /// created via <see cref="DataSourceAuthentication.FromApiKey(string)"/> and
    /// <see cref="DataSourceAuthentication.FromAccessToken(string)"/>, respectively.
    /// </remarks>
    /// <param name="endpoint"> The endpoint to use for vectorization. </param>
    /// <param name="authentication"> The authentication mechanism to use with the endpoint. </param>
    /// <returns></returns>
    public static DataSourceVectorizer FromEndpoint(Uri endpoint, DataSourceAuthentication authentication)
        => new InternalAzureChatDataSourceEndpointVectorizationSource(endpoint, authentication);
    public static DataSourceVectorizer FromDeploymentName(string deploymentName)
        => new InternalAzureChatDataSourceDeploymentNameVectorizationSource(deploymentName);
    public static DataSourceVectorizer FromModelId(string modelId)
        => new InternalAzureChatDataSourceModelIdVectorizationSource(modelId);
    public static DataSourceVectorizer FromIntegratedResource()
        => new InternalAzureChatDataSourceIntegratedVectorizationSource();
}
