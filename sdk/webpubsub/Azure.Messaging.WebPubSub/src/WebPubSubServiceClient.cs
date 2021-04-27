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
        private const string JsonContent = "application/json";
        private const string TextContent = "text/plain";

        private readonly Uri _endpoint;
        private readonly string _hub;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AzureKeyCredential _credential;

        internal WebPubSubRestClient RestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        /// <param name="credential"></param>
        public WebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential) :
            this(endpoint, hub, credential, new WebPubSubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public WebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential, WebPubSubServiceClientOptions options) :
            this(endpoint, credential, options)
        {
            _endpoint = endpoint;
            _hub = hub;
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
        public WebPubSubServiceClient(string connectionString, string hub, WebPubSubServiceClientOptions options) :
            this(ParseConnectionString(connectionString), hub, options)
        {
        }

        /// <summary>
        /// This constructor is intended to be used for mocking.
        /// </summary>
        protected WebPubSubServiceClient()
        {
        }

        internal WebPubSubServiceClient(Uri endpoint, AzureKeyCredential credential, WebPubSubServiceClientOptions options)
        {
            if (credential == default) throw new ArgumentNullException(nameof(credential));
            if (options == default) options = new WebPubSubServiceClientOptions();

            ClientDiagnostics clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new WebPubSubAuthenticationPolicy(credential));
            RestClient = new WebPubSubRestClient(clientDiagnostics, pipeline, endpoint, options.Version);
            _clientDiagnostics = clientDiagnostics;
        }

        private WebPubSubServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsedConnectionString, string hub) :
            this(parsedConnectionString.Endpoint, hub, parsedConnectionString.Credential)
        {
        }

        private WebPubSubServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsedConnectionString, string hub, WebPubSubServiceClientOptions options) :
            this(parsedConnectionString.Endpoint, hub, parsedConnectionString.Credential, options)
        {
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToAllAsync(string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{nameof(WebPubSubServiceClient)}.{nameof(SendToAll)}");
            scope.Start();
            try
            {
                return await RestClient.SendToAllAsync(_hub, TextContent, RequestContent.Create(message), excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToAll(string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToAll");
            scope.Start();
            try
            {
                return RestClient.SendToAll(_hub, TextContent, RequestContent.Create(message), excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToAllAsync(RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToAllAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToAllAsync(_hub, contentType, message, excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToAll(RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToAll");
            scope.Start();
            try
            {
                return RestClient.SendToAll(_hub, contentType, message, excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToUserAsync(string userId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUserAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToUserAsync(_hub, userId, TextContent, RequestContent.Create(message), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToUser(string userId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUser");
            scope.Start();
            try
            {
                return RestClient.SendToUser(_hub, userId, TextContent, RequestContent.Create(message), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToUserAsync(string userId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUserAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToUserAsync(_hub, userId, contentType, message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToUser(string userId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToUser");
            scope.Start();
            try
            {
                return RestClient.SendToUser(_hub, userId, contentType, message, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToConnectionAsync(string connectionId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnectionAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToConnectionAsync(_hub, connectionId, TextContent, RequestContent.Create(message), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToConnection(string connectionId, string message, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnection");
            scope.Start();
            try
            {
                return RestClient.SendToConnection(_hub, connectionId, TextContent, RequestContent.Create(message), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToConnectionAsync(string connectionId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnectionAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToConnectionAsync(_hub, connectionId, contentType, message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToConnection(string connectionId, RequestContent message, string contentType = JsonContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToConnection");
            scope.Start();
            try
            {
                return RestClient.SendToConnection(_hub, connectionId, contentType, message, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToGroupAsync(string group, string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToGroupAsync(_hub, group, TextContent, RequestContent.Create(message), excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToGroup(string group, string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroup");
            scope.Start();
            try
            {
                return RestClient.SendToGroup(_hub, group, TextContent, RequestContent.Create(message), excluded, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToGroupAsync(string group, RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.SendToGroupAsync(_hub, group, contentType, message, excluded, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Send message to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="message"></param>
        /// <param name="contentType">Supported values are: application/json, application/octet-stream, and text/plain.</param>
        /// <param name="excluded">Excluded connection Ids</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToGroup(string group, RequestContent message, string contentType = JsonContent, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.SendToGroup");
            scope.Start();
            try
            {
                return RestClient.SendToGroup(_hub, group, contentType, message, excluded, cancellationToken);
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
        /// <returns>true if the specified connection exists; false otherwise.</returns>
        public virtual async Task<Response<bool>> ConnectionExistsAsync(string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.ConnectionExistsAsync");
            scope.Start();
            try
            {
                var response = await RestClient.ConnectionExistsAsync(_hub, connectionId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>true if the specified connection exists; false otherwise.</returns>
        public virtual Response<bool> ConnectionExists(string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.ConnectionExists");
            scope.Start();
            try
            {
                var response = RestClient.ConnectionExists(_hub, connectionId, cancellationToken);
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
        /// <returns>true if the specified group exists; false otherwise.</returns>
        public virtual async Task<Response<bool>> GroupExistsAsync(string group, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.GroupExistsAsync");
            scope.Start();
            try
            {
                var response = await RestClient.GroupExistsAsync(_hub, group, cancellationToken).ConfigureAwait(false);
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
        /// <returns>true if the specified group exists; false otherwise.</returns>
        public virtual Response<bool> GroupExists(string group, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.GroupExists");
            scope.Start();
            try
            {
                var response = RestClient.GroupExists(_hub, group, cancellationToken);
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
        /// <returns>true if the specified user exists; false otherwise.</returns>
        public virtual async Task<Response<bool>> UserExistsAsync(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.UserExistsAsync");
            scope.Start();
            try
            {
                var response = await RestClient.UserExistsAsync(_hub, userId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>true if the specified user exists; false otherwise.</returns>
        public virtual Response<bool> UserExists(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.UserExists");
            scope.Start();
            try
            {
                var response = RestClient.UserExists(_hub, userId, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> AddConnectionToGroupAsync(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddConnectionToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.AddConnectionToGroupAsync(_hub, group, connectionId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response AddConnectionToGroup(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddConnectionToGroup");
            scope.Start();
            try
            {
                return RestClient.AddConnectionToGroup(_hub, group, connectionId, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> RemoveUserFromAllGroupsAsync(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromAllGroupsAsync");
            scope.Start();
            try
            {
                return await RestClient.RemoveUserFromAllGroupsAsync(_hub, userId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response RemoveUserFromAllGroups(string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromAllGroups");
            scope.Start();
            try
            {
                return RestClient.RemoveUserFromAllGroups(_hub, userId, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> GrantPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.GrantPermissionAsync");
            scope.Start();
            try
            {
                return await RestClient.GrantPermissionAsync(_hub, permission, connectionId, targetName, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response GrantPermission(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.GrantPermission");
            scope.Start();
            try
            {
                return RestClient.GrantPermission(_hub, permission, connectionId, targetName, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> RevokePermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RevokePermissionAsync");
            scope.Start();
            try
            {
                return await RestClient.RevokePermissionAsync(_hub, permission, connectionId, targetName, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response RevokePermission(WebPubSubPermission permission, string connectionId, string targetName = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RevokePermission");
            scope.Start();
            try
            {;
                return RestClient.RevokePermission(_hub, permission, connectionId, targetName, cancellationToken);
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
                var response = await RestClient.CheckPermissionAsync(_hub, permission, connectionId, targetName, cancellationToken).ConfigureAwait(false);
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
                var response = RestClient.CheckPermission(_hub, permission, connectionId, targetName, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> CloseClientConnectionAsync(string connectionId, string reason = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CloseClientConnectionAsync");
            scope.Start();
            try
            {
                var response = await RestClient.CloseClientConnectionAsync(_hub, connectionId, reason, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response CloseClientConnection(string connectionId, string reason = default, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.CloseClientConnection");
            scope.Start();
            try
            {
                var response = RestClient.CloseClientConnection(_hub, connectionId, reason, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> RemoveConnectionFromGroupAsync(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveConnectionFromGroupAsync");
            scope.Start();
            try
            {
                var response = await RestClient.RemoveConnectionFromGroupAsync(_hub, group, connectionId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response RemoveConnectionFromGroup(string group, string connectionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveConnectionFromGroup");
            scope.Start();
            try
            {
                var response = RestClient.RemoveConnectionFromGroup(_hub, group, connectionId, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> AddUserToGroupAsync(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddUserToGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.AddUserToGroupAsync(_hub, group, userId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response AddUserToGroup(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.AddUserToGroup");
            scope.Start();
            try
            {
                return RestClient.AddUserToGroup(_hub, group, userId, cancellationToken);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> RemoveUserFromGroupAsync(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromGroupAsync");
            scope.Start();
            try
            {
                return await RestClient.RemoveUserFromGroupAsync(_hub, group, userId, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response RemoveUserFromGroup(string group, string userId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WebPubSubServiceRestClient.RemoveUserFromGroup");
            scope.Start();
            try
            {
                return RestClient.RemoveUserFromGroup(_hub, group, userId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
