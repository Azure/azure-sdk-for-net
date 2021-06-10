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
    [CodeGenSuppress("WebPubSubServiceClient", typeof(string), typeof(Uri), typeof(WebPubSubServiceClientOptions))]
    public partial class WebPubSubServiceClient
    {
        private AzureKeyCredential _credential;

        private const string JsonContent = "application/json";

        /// <summary>
        /// The hub.
        /// </summary>
        public virtual string Hub => hub;

        /// <summary>
        /// The service endpoint.
        /// </summary>
        public virtual Uri Endpoint => endpoint;

        /// <summary> Initializes a new instance of WebPubSubServiceClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="hub"> Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public WebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential)
            : this(endpoint, hub, credential, new WebPubSubServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of WebPubSubServiceClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="hub"> Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public WebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential, WebPubSubServiceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(hub, nameof(hub));
            Argument.AssertNotNull(credential, nameof(credential));

            this._credential = credential;
            this.hub = hub;
            this.endpoint = endpoint;

            options ??= new WebPubSubServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            apiVersion = options.Version;

            Pipeline = HttpPipelineBuilder.Build(
                options,
                perCallPolicies: new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() },
                perRetryPolicies: new HttpPipelinePolicy[] { new WebPubSubAuthenticationPolicy(credential) },
                new ResponseClassifier()
            );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClient"/>.
        /// </summary>
        /// <param name="connectionString">Connection string contains Endpoint and AccessKey.</param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        public WebPubSubServiceClient(string connectionString, string hub) : this(ParseConnectionString(connectionString), hub)
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return await SendToAllAsync(JsonContent, RequestContent.Create((object)message), excluded, options).ConfigureAwait(false);
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="message"></param>
        /// <param name="excluded">Excluded connection Ids.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToAll(string message, IEnumerable<string> excluded = null, CancellationToken cancellationToken = default)
        {
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return SendToAll(JsonContent, RequestContent.Create((object)message), excluded, options);
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return await SendToUserAsync(userId, JsonContent, RequestContent.Create((object)message), options).ConfigureAwait(false);
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return SendToUser(userId, JsonContent, RequestContent.Create((object)message), options);
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return await SendToConnectionAsync(connectionId, JsonContent, RequestContent.Create((object)message), options).ConfigureAwait(false);
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return SendToConnection(connectionId, JsonContent, RequestContent.Create((object)message), options);
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return await SendToGroupAsync(group, JsonContent, RequestContent.Create((object)message), excluded, options).ConfigureAwait(false);
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
            RequestOptions options = default;
            if (cancellationToken != default)
                options = new RequestOptions() { CancellationToken = cancellationToken };

            return SendToGroup(group, JsonContent, RequestContent.Create((object)message), excluded, options);
        }

        /// <summary> Check if there are any client connections inside the given group. </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GroupExistsAsync(string group, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = await GroupExistsAsync(group, options).ConfigureAwait(false);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if there are any client connections inside the given group. </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GroupExists(string group, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = GroupExists(group, options);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if there are any client connections connected for the given user. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> UserExistsAsync(string userId, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = await UserExistsAsync(userId, options).ConfigureAwait(false);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if there are any client connections connected for the given user. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> UserExists(string userId, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = UserExists(userId, options);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if the connection with the given connectionId exists. </summary>
        /// <param name="connectionId"> The connection Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ConnectionExistsAsync(string connectionId, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = await ConnectionExistsAsync(connectionId, options).ConfigureAwait(false);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if the connection with the given connectionId exists. </summary>
        /// <param name="connectionId"> The connection Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> ConnectionExists(string connectionId, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = ConnectionExists(connectionId, options);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Grant permission to the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GrantPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = null, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = await GrantPermissionAsync(permission.ToString(), connectionId, targetName, options).ConfigureAwait(false);
            return response;
        }

        /// <summary> Grant permission to the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GrantPermission(WebPubSubPermission permission, string connectionId, string targetName = null, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = GrantPermission(permission.ToString(), connectionId, targetName, options);
            return response;
        }

        /// <summary> Revoke permission for the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RevokePermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = null, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = await RevokePermissionAsync(permission.ToString(), connectionId, targetName, options).ConfigureAwait(false);
            return response;
        }

        /// <summary> Revoke permission for the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RevokePermission(WebPubSubPermission permission, string connectionId, string targetName = null, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = RevokePermission(permission.ToString(), connectionId, targetName, options);
            return response;
        }

        /// <summary> Check if a connection has permission to the specified action. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CheckPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = null, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = await CheckPermissionAsync(permission.ToString(), connectionId, targetName, options).ConfigureAwait(false);
            return response;
        }

        /// <summary> Check if a connection has permission to the specified action. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CheckPermission(WebPubSubPermission permission, string connectionId, string targetName = null, CancellationToken cancellationToken = default)
        {
            var options = new RequestOptions() { StatusOption = ResponseStatusOption.NoThrow, CancellationToken = cancellationToken };
            var response = CheckPermission(permission.ToString(), connectionId, targetName, options);
            return response;
        }
    }
}
