// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Azure Web PubSub Service Client.
    /// </summary>
    public partial class WebPubSubServiceClient
    {
        private const string ApiVersion = "2020-10-01";

        private const string JsonContent = "application/json";
        private const string TextContent = "text/plain";

        private Uri _endpoint;
        private readonly string hub;
        private readonly ClientDiagnostics _clientDiagnostics;
        private AzureKeyCredential _credential;

        internal WebPubSubRestClient RestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        /// <param name="credential"></param>
        public WebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential) : this(endpoint, hub, credential, new WebPubSubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public WebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential, WebPubSubServiceClientOptions options): this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new WebPubSubAuthenticationPolicy(credential)),
            endpoint)
        {
            _endpoint = endpoint;
            this.hub = hub;
            _credential = credential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="connectionString">Connection string contains Endpoint and AccessKey.</param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        public WebPubSubServiceClient(string connectionString, string hub): this(ParseConnectionString(connectionString), hub)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="connectionString">Connection string contains Endpoint and AccessKey.</param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        /// <param name="options"></param>
        public WebPubSubServiceClient(string connectionString, string hub, WebPubSubServiceClientOptions options) : this(ParseConnectionString(connectionString), hub, options)
        {
        }

        /// <summary>
        /// This constructor is intended to be used for mocking.
        /// </summary>
        protected WebPubSubServiceClient()
        {
        }

        internal WebPubSubServiceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri vaultBaseUrl)
        {
            RestClient = new WebPubSubRestClient(clientDiagnostics, pipeline, vaultBaseUrl, ApiVersion);
            _clientDiagnostics = clientDiagnostics;
        }

        private WebPubSubServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsedConnectionString, string hub) : this(
            parsedConnectionString.Endpoint, hub, parsedConnectionString.Credential)
        {
        }

        private WebPubSubServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsedConnectionString, string hub, WebPubSubServiceClientOptions options) : this(
            parsedConnectionString.Endpoint, hub, parsedConnectionString.Credential, options)
        {
        }

        /// <summary>Broadcast content inside request body to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToAllAsync(string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{nameof(WebPubSubServiceClient)}.{nameof(SendToAll)}");
            scope.Start();
            try
            {
                return await RestClient.SendToAllAsync(hub, RequestContent.Create(message), TextContent, excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Broadcast content inside request body to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToAll(string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.Broadcast");
            scope.Start();
            try
            {
                return RestClient.SendToAll(hub, RequestContent.Create(message), TextContent, excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Broadcast content inside request body to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToAllAsync(RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.BroadcastAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToAllAsync(hub, message, contentType, excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Broadcast content inside request body to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToAll(RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.Broadcast");
            scope.Start();
            try
            {
                return RestClient.SendToAll(hub, message, contentType, excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToUserAsync(string userId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUserAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToUserAsync(hub, userId, RequestContent.Create(message), TextContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToUser(string userId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUser");
            scope.Start();
            try
            {
                return RestClient.SendToUser(hub, userId, RequestContent.Create(message), TextContent, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToUserAsync(string userId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUserAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToUserAsync(hub, userId, message, contentType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToUser(string userId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUser");
            scope.Start();
            try
            {
                return RestClient.SendToUser(hub, userId, message, contentType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToConnectionAsync(string connectionId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnectionAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToConnectionAsync(hub, connectionId, RequestContent.Create(message), TextContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToConnection(string connectionId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnection");
            scope.Start();
            try
            {
                return RestClient.SendToConnection(hub, connectionId, RequestContent.Create(message), TextContent, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToConnectionAsync(string connectionId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnectionAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToConnectionAsync(hub, connectionId, message, contentType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToConnection(string connectionId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnection");
            scope.Start();
            try
            {
                return RestClient.SendToConnection(hub, connectionId, message, contentType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToGroupAsync(string group, string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToGroupAsync(hub, group, RequestContent.Create(message), TextContent, excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToGroup(string group, string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroup");
            scope.Start();
            try
            {
                return RestClient.SendToGroup(hub, group, RequestContent.Create(message), TextContent, excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> SendToGroupAsync(string group, RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToGroupAsync(hub, group, message, contentType, excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send content inside request body to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response SendToGroup(string group, RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroup");
            scope.Start();
            try
            {
                return RestClient.SendToGroup(hub, group, message, contentType, excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if the connection with the given connectionId exists</summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<bool>> ConnectionExistsAsync(string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckConnectionExistenceAsync");
            scope.Start();
            try
            {
                var response = await RestClient.ConnectionExistsAsync(hub, connectionId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if the connection with the given connectionId exists</summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response<bool> ConnectionExists(string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroup");
            scope.Start();
            try
            {
                var response = RestClient.ConnectionExists(hub, connectionId, cancellationToken);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if the connection with the given connectionId exists</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<bool>> GroupExistsAsync(string group, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckGroupExistenceAsync");
            scope.Start();
            try
            {
                var response = await RestClient.GroupExistsAsync(hub, group, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if the connection with the given connectionId exists</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response<bool> GroupExists(string group, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckGroupExistence");
            scope.Start();
            try
            {
                var response = RestClient.GroupExists(hub, group, cancellationToken);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if there are any client connections connected for the given user</summary>
        /// <param name="userId">Target user Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<bool>> UserExistsAsync(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckUserExistenceAsync");
            scope.Start();
            try
            {
                var response = await RestClient.UserExistsAsync(hub, userId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if there are any client connections connected for the given user</summary>
        /// <param name="userId">Target user Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response<bool> UserExists(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckUserExistence");
            scope.Start();
            try
            {
                var response = RestClient.UserExists(hub, userId, cancellationToken);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Add a connection to the target group.</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="connectionId">Target connection Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> AddConnectionToGroupAsync(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            if (connectionId is null)
            {
                throw new ArgumentNullException(nameof(connectionId));
            }

            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddConnectionToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.AddConnectionToGroupAsync(hub, group, connectionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Add a connection to the target group.</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="connectionId">Target connection Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response AddConnectionToGroup(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddConnectionToGroup");
            scope.Start();
            try
            {
                return RestClient.AddConnectionToGroup(hub, group, connectionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Remove a user from all groups.</summary>
        /// <param name="userId">Target user Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> RemoveUserFromAllGroupsAsync(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromAllGroupsAsync");
            scope.Start();
            try
            {
                return await RestClient.RemoveUserFromAllGroupsAsync(hub, userId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Remove a user from all groups.</summary>
        /// <param name="userId">Target user Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response RemoveUserFromAllGroups(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromAllGroups");
            scope.Start();
            try
            {
                return RestClient.RemoveUserFromAllGroups(hub, userId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Grant permission to the connection.</summary>
        /// <param name="permission">Current supported actions are joinLeaveGroup and sendToGroup.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="targetName">If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> GrantPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.GrantPermissionAsync");
            scope.Start();
            try
            {
                return await RestClient.GrantPermissionAsync(hub, ToPermission(permission), connectionId, targetName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Grant permission to the connection.</summary>
        /// <param name="permission">Current supported actions are joinLeaveGroup and sendToGroup.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="targetName">Optional. If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response GrantPermission(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.GrantPermission");
            scope.Start();
            try
            {
                return RestClient.GrantPermission(hub, ToPermission(permission), connectionId, targetName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Revoke permission for the connection.</summary>
        /// <param name="permission">Current supported actions are joinLeaveGroup and sendToGroup.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="targetName">If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> RevokePermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RevokePermissionAsync");
            scope.Start();
            try
            {
                return await RestClient.RevokePermissionAsync(hub, ToPermission(permission), connectionId, targetName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Revoke permission for the connection.</summary>
        /// <param name="permission">Current supported actions are joinLeaveGroup and sendToGroup.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="targetName">If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response RevokePermission(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RevokePermission");
            scope.Start();
            try
            {;
                return RestClient.RevokePermission(hub, ToPermission(permission), connectionId, targetName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if a connection have permission to the specific action.</summary>
        /// <param name="permission">Current supported actions are joinLeaveGroup and sendToGroup.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="targetName">If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<bool>> CheckPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckPermissionAsync");
            scope.Start();
            try
            {
                var response = await RestClient.CheckPermissionAsync(hub, ToPermission(permission), connectionId, targetName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Check if a connection have permission to the specific action.</summary>
        /// <param name="permission">Body of the requerst. Either `joinLeaveGroup` or `sendToGroup`.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="targetName">If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response<bool> CheckPermission(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CheckPermission");
            scope.Start();
            try
            {
                var response = RestClient.CheckPermission(hub, ToPermission(permission), connectionId, targetName, cancellationToken);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Close the client connection.
        /// </summary>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="reason">The reason closing the client connection.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> CloseClientConnectionAsync(string connectionId, string reason = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CloseClientConnectionAsync");
            scope.Start();
            try
            {
                var response = await RestClient.CloseClientConnectionAsync(hub, connectionId, reason, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Close the client connection.
        /// </summary>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="reason">The reason closing the client connection.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response CloseClientConnection(string connectionId, string reason = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CloseClientConnection");
            scope.Start();
            try
            {
                var response = RestClient.CloseClientConnection(hub, connectionId, reason, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Remove a connection from the target group.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> RemoveConnectionFromGroupAsync(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CloseClientConnectionAsync");
            scope.Start();
            try
            {
                var response = await RestClient.RemoveConnectionFromGroupAsync(hub, group, connectionId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Remove a connection from the target group.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="connectionId">Target connection Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response RemoveConnectionFromGroup(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CloseClientConnection");
            scope.Start();
            try
            {
                var response = RestClient.RemoveConnectionFromGroup(hub, group, connectionId, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Add a user to the target group.</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="userId">Target user Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> AddUserToGroupAsync(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddConnectionToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.AddUserToGroupAsync(hub, group, userId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Add a user to the target group.</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="userId">Target user Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response AddUserToGroup(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddConnectionToGroup");
            scope.Start();
            try
            {
                return RestClient.AddUserToGroup(hub, group, userId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Remove a user from the target group.</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="userId">Target user Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> RemoveUserFromGroupAsync(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromAllGroupsAsync");
            scope.Start();
            try
            {
                return await RestClient.RemoveUserFromGroupAsync(hub, group, userId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Remove a user from the target group.</summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="userId">Target user Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response RemoveUserFromGroup(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromAllGroups");
            scope.Start();
            try
            {
                return RestClient.RemoveUserFromGroup(hub, group, userId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static Models.WebPubSubPermission ToPermission(WebPubSubPermission permission)
        {
            if (permission == WebPubSubPermission.JoinLeaveGroup)
                return Models.WebPubSubPermission.JoinLeaveGroup;
            if (permission == WebPubSubPermission.SendToGroup)
                return Models.WebPubSubPermission.SendToGroup;
            else
                throw new InvalidOperationException($"Invalid permission {(int)permission}");
        }
    }
}
