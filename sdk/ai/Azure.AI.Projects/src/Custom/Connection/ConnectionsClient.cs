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
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public ConnectionsClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
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
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Foundry project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public ConnectionsClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential) : this(endpoint, subscriptionId, resourceGroupName, projectName, credential, new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Foundry project name. </param>
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
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Foundry project name. </param>
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

        /// <summary> Gets the properties of the specified machine learning workspace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<GetWorkspaceResponse>> GetWorkspaceAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetWorkspaceAsync(context).ConfigureAwait(false);
            return Response.FromValue(GetWorkspaceResponse.FromResponse(response), response);
        }

        /// <summary> Gets the properties of the specified machine learning workspace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GetWorkspaceResponse> GetWorkspace(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetWorkspace(context);
            return Response.FromValue(GetWorkspaceResponse.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Gets the properties of the specified machine learning workspace.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWorkspaceAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetWorkspaceAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetWorkspace");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetWorkspaceRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the properties of the specified machine learning workspace.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWorkspace(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetWorkspace(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetWorkspace");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetWorkspaceRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List the details of all the connections (not including their credentials). </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListConnectionsResponse>> GetConnectionsAsync(ConnectionType? category = null, bool? includeAll = null, string target = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetConnectionsAsync(category?.ToSerialString(), includeAll, target, context).ConfigureAwait(false);
            return Response.FromValue(ListConnectionsResponse.FromResponse(response), response);
        }

        /// <summary> List the details of all the connections (not including their credentials). </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListConnectionsResponse> GetConnections(ConnectionType? category = null, bool? includeAll = null, string target = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetConnections(category?.ToSerialString(), includeAll, target, context);
            return Response.FromValue(ListConnectionsResponse.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] List the details of all the connections (not including their credentials)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetConnectionsAsync(ConnectionType?,bool?,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="category"> Category of the workspace connection. Allowed values: "AzureOpenAI" | "Serverless" | "AzureBlob" | "AIServices" | "CognitiveSearch". </param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetConnectionsAsync(string category, bool? includeAll, string target, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetConnections");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConnectionsRequest(category, includeAll, target, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] List the details of all the connections (not including their credentials)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetConnections(ConnectionType?,bool?,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="category"> Category of the workspace connection. Allowed values: "AzureOpenAI" | "Serverless" | "AzureBlob" | "AIServices" | "CognitiveSearch". </param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetConnections(string category, bool? includeAll, string target, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetConnections");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConnectionsRequest(category, includeAll, target, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the details of a single connection, without credentials. </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ConnectionResponse>> GetConnectionAsync(string connectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetConnectionAsync(connectionName, context).ConfigureAwait(false);
            return Response.FromValue(ConnectionResponse.FromResponse(response), response);
        }

        /// <summary> Get the details of a single connection, without credentials. </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ConnectionResponse> GetConnection(string connectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetConnection(connectionName, context);
            return Response.FromValue(ConnectionResponse.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get the details of a single connection, without credentials.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetConnectionAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetConnectionAsync(string connectionName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));

            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetConnection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConnectionRequest(connectionName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get the details of a single connection, without credentials.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetConnection(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetConnection(string connectionName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));

            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetConnection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConnectionRequest(connectionName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the details of a single connection, including credentials (if available). </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="ignored"> The body is ignored. TODO: Can we remove this?. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> or <paramref name="ignored"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ConnectionResponse>> GetConnectionWithSecretsAsync(string connectionName, string ignored, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));
            Argument.AssertNotNull(ignored, nameof(ignored));

            GetConnectionWithSecretsRequest getConnectionWithSecretsRequest = new GetConnectionWithSecretsRequest(ignored, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetConnectionWithSecretsAsync(connectionName, getConnectionWithSecretsRequest.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(ConnectionResponse.FromResponse(response), response);
        }

        /// <summary> Get the details of a single connection, including credentials (if available). </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="ignored"> The body is ignored. TODO: Can we remove this?. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> or <paramref name="ignored"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ConnectionResponse> GetConnectionWithSecrets(string connectionName, string ignored, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));
            Argument.AssertNotNull(ignored, nameof(ignored));

            GetConnectionWithSecretsRequest getConnectionWithSecretsRequest = new GetConnectionWithSecretsRequest(ignored, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetConnectionWithSecrets(connectionName, getConnectionWithSecretsRequest.ToRequestContent(), context);
            return Response.FromValue(ConnectionResponse.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get the details of a single connection, including credentials (if available).
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetConnectionWithSecretsAsync(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetConnectionWithSecretsAsync(string connectionName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetConnectionWithSecrets");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConnectionWithSecretsRequest(connectionName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get the details of a single connection, including credentials (if available).
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetConnectionWithSecrets(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionName"> Connection Name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetConnectionWithSecrets(string connectionName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(connectionName, nameof(connectionName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConnectionsClient.GetConnectionWithSecrets");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConnectionWithSecretsRequest(connectionName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List the details of all the connections (not including their credentials). </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="withCredential"></param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConnectionResponse>> GetDefaultConnectionAsync(ConnectionType category, bool? withCredential = null, bool? includeAll = null, string target = null, CancellationToken cancellationToken = default)
        {
            ListConnectionsResponse connections = await GetConnectionsAsync(category, includeAll, target, cancellationToken).ConfigureAwait(false);

            if (connections?.Value == null || connections.Value.Count == 0)
            {
                throw new InvalidOperationException("No connections found for the specified parameters.");
            }

            var connection = connections.Value[0];
            return withCredential.GetValueOrDefault()
                ? await GetConnectionWithSecretsAsync(connection.Name, "ignored").ConfigureAwait(false)
                : Response.FromValue(connection, null);
            ;
        }

        /// <summary> Get the details of a single connection. </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="withCredential"></param>
        /// <param name="includeAll"> Indicates whether to list datastores. Service default: do not list datastores. </param>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConnectionResponse> GetDefaultConnection(ConnectionType category, bool? withCredential = null, bool? includeAll = null, string target = null, CancellationToken cancellationToken = default)
        {
            ListConnectionsResponse connections = GetConnections(category, includeAll, target, cancellationToken);

            if (connections?.Value == null || connections.Value.Count == 0)
            {
                throw new InvalidOperationException("No connections found for the specified parameters.");
            }

            ConnectionResponse connection = connections.Value[0];
            return withCredential.GetValueOrDefault()
                ? GetConnectionWithSecrets(connection.Name, "ignored")
                : Response.FromValue(connection, null);
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

        internal HttpMessage CreateGetConnectionWithSecretsRequest(string connectionName, RequestContent content, RequestContext context)
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

        internal HttpMessage CreateGetWorkspaceRequest(RequestContext context)
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
            uri.AppendPath("/", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
