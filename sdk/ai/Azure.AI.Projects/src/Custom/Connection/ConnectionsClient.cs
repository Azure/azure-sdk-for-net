// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Projects
{
    /// <summary> The Endpoints sub-client. </summary>
    [CodeGenClient("Connections")]
    public partial class ConnectionsClient
    {
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public ConnectionsClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public ConnectionsClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "ResourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "ProjectName"),
                  credential,
                  options)
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public ConnectionsClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential) : this(endpoint, subscriptionId, resourceGroupName, projectName, credential, new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public ConnectionsClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential, AIProjectClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AIProjectClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = new Uri("https://management.azure.com");
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _projectName = projectName;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of ConnectionsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal ConnectionsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = new Uri("https://management.azure.com");
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _projectName = projectName;
            _apiVersion = apiVersion;
        }

        /// <summary> List the details of all the connections (not including their credentials). </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="withCredential"></param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<ConnectionsListSecretsResponse>> GetDefaultConnectionAsync(ConnectionType category, bool? withCredential = null, bool? includeAll = null, string target = null, CancellationToken cancellationToken = default)
        {
            ConnectionsListResponse connections = await GetConnectionsAsync(category, includeAll, target, cancellationToken).ConfigureAwait(false);

            if (connections?.Value == null || connections.Value.Count == 0)
            {
                throw new InvalidOperationException("No connections found for the specified parameters.");
            }

            var secret = connections.Value[0];
            return withCredential.GetValueOrDefault()
                ? await GetSecretsAsync(secret.Name, "ignored").ConfigureAwait(false)
                : await GetConnectionAsync(secret.Name).ConfigureAwait(false);
        }

        /// <summary> Get the details of a single connection. </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="withCredential"></param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<ConnectionsListSecretsResponse> GetDefaultConnection(ConnectionType category, bool? withCredential = null, bool? includeAll = null, string target = null, CancellationToken cancellationToken = default)
        {
            ConnectionsListResponse connections = GetConnections(category, includeAll, target, cancellationToken);

            if (connections?.Value == null || connections.Value.Count == 0)
            {
                throw new InvalidOperationException("No connections found for the specified parameters.");
            }

            var secret = connections.Value[0];
            return withCredential.GetValueOrDefault()
                ? GetSecrets(secret.Name, "ignored")
                : GetConnection(secret.Name);
        }

        // CUSTOM: Fixed the request URI by removing "/agents/v1.0"
        internal HttpMessage CreateGetConnectionsRequest(string category, bool? includeAll, string target, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/subscriptions/", false);
            uri.AppendRaw(_subscriptionId, true);
            uri.AppendRaw("/resourceGroups/", false);
            uri.AppendRaw(_resourceGroupName, true);
            uri.AppendRaw("/providers/Microsoft.MachineLearningServices/workspaces/", false);
            uri.AppendRaw(_projectName, true);
            uri.AppendPath("/connections", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (category != null)
            {
                uri.AppendQuery("category", category, true);
            }
            if (includeAll != null)
            {
                uri.AppendQuery("includeAll", includeAll.Value, true);
            }
            if (target != null)
            {
                uri.AppendQuery("target", target, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetConnectionRequest(string connectionName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/subscriptions/", false);
            uri.AppendRaw(_subscriptionId, true);
            uri.AppendRaw("/resourceGroups/", false);
            uri.AppendRaw(_resourceGroupName, true);
            uri.AppendRaw("/providers/Microsoft.MachineLearningServices/workspaces/", false);
            uri.AppendRaw(_projectName, true);
            uri.AppendPath("/connections/", false);
            uri.AppendPath(connectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSecretsRequest(string connectionName, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/subscriptions/", false);
            uri.AppendRaw(_subscriptionId, true);
            uri.AppendRaw("/resourceGroups/", false);
            uri.AppendRaw(_resourceGroupName, true);
            uri.AppendRaw("/providers/Microsoft.MachineLearningServices/workspaces/", false);
            uri.AppendRaw(_projectName, true);
            uri.AppendPath("/connections/", false);
            uri.AppendPath(connectionName, true);
            uri.AppendPath("/listsecrets", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }
    }
}
