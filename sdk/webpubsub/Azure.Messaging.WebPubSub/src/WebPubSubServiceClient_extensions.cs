// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Autorest.CSharp.Core;

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Azure Web PubSub Service Client.
    /// </summary>
    [CodeGenSuppress("WebPubSubServiceClient", typeof(string), typeof(Uri), typeof(WebPubSubServiceClientOptions))]
    [CodeGenSuppress("SendToAll", typeof(RequestContent), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("SendToAllAsync", typeof(RequestContent), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("SendToConnection", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("SendToConnectionAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("SendToGroup", typeof(string), typeof(RequestContent), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("SendToGroupAsync", typeof(string), typeof(RequestContent), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("SendToUser", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("SendToUserAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("AddUserToGroup", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("AddUserToGroupAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("RemoveUserFromGroup", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("RemoveUserFromGroupAsync", typeof(string), typeof(string), typeof(RequestContext))]
    public partial class WebPubSubServiceClient
    {
        private readonly WebPubSubServiceClientOptions.ServiceVersion _apiVersionEnum;
        private AzureKeyCredential _credential;
        private TokenCredential _tokenCredential;

        /// <summary>
        /// The hub.
        /// </summary>
        public virtual string Hub => _hub;

        /// <summary>
        /// The service endpoint.
        /// </summary>
        public virtual Uri Endpoint { get; }

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
            : this(endpoint, hub, options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            _credential = credential;

            HttpPipelinePolicy[] perCallPolicies;
            if (options.ReverseProxyEndpoint != null)
            {
                perCallPolicies = new HttpPipelinePolicy[] { new ReverseProxyPolicy(options.ReverseProxyEndpoint) };
            }
            else
            {
                perCallPolicies = Array.Empty<HttpPipelinePolicy>();
            }

            _pipeline = HttpPipelineBuilder.Build(
                options,
                perCallPolicies: perCallPolicies,
                perRetryPolicies: new HttpPipelinePolicy[] { new WebPubSubAuthenticationPolicy(credential) },
                new ResponseClassifier()
            );
        }

        /// <summary> Initializes a new instance of WebPubSubServiceClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="hub"> Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore. </param>
        /// <param name="credential"> A token credential used to authenticate to an Azure Service. </param>
        public WebPubSubServiceClient(Uri endpoint, string hub, TokenCredential credential)
            : this(endpoint, hub, credential, new WebPubSubServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of WebPubSubServiceClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="hub"> Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore. </param>
        /// <param name="credential"> A token credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public WebPubSubServiceClient(Uri endpoint, string hub, TokenCredential credential, WebPubSubServiceClientOptions options)
            : this(endpoint, hub, options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            _tokenCredential = credential;

            HttpPipelinePolicy[] perCallPolicies;
            if (options.ReverseProxyEndpoint != null)
            {
                perCallPolicies = new HttpPipelinePolicy[] { new ReverseProxyPolicy(options.ReverseProxyEndpoint) };
            }
            else
            {
                perCallPolicies = Array.Empty<HttpPipelinePolicy>();
            }

            _pipeline = HttpPipelineBuilder.Build(
                options,
                perCallPolicies: perCallPolicies,
                perRetryPolicies: new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, WebPubSubServiceClientOptions.CredentialScopeName) },
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

        private WebPubSubServiceClient(Uri endpoint, string hub, WebPubSubServiceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(hub, nameof(hub));

            _hub = hub;
            _endpoint = endpoint.AbsoluteUri;
            Endpoint = endpoint;

            options ??= new WebPubSubServiceClientOptions();
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _apiVersion = options.Version;
            _apiVersionEnum = options.VersionEnum;
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToAllAsync(string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return await SendToAllAsync(RequestContent.Create(content), contentType.ToString(), default, context: default).ConfigureAwait(false);
        }

        /// <summary>Broadcast message to all the connected client connections.</summary>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToAll(string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return SendToAll(RequestContent.Create(content), contentType, excluded: default, context: default);
        }

        /// <summary>
        /// Send message to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToUserAsync(string userId, string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(userId, nameof(userId));
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return await SendToUserAsync(userId, RequestContent.Create(content), contentType, context: default).ConfigureAwait(false);
        }

        /// <summary>
        /// Send message to the specific user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToUser(string userId, string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(userId, nameof(userId));
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return SendToUser(userId, RequestContent.Create(content), contentType, context: default);
        }

        /// <summary>
        /// Send message to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToConnectionAsync(string connectionId, string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(connectionId, nameof(connectionId));
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return await SendToConnectionAsync(connectionId, RequestContent.Create(content), contentType, context: default).ConfigureAwait(false);
        }

        /// <summary>
        /// Send message to the specific connection.
        /// </summary>
        /// <param name="connectionId">The connection Id.</param>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToConnection(string connectionId, string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(connectionId, nameof(connectionId));
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return SendToConnection(connectionId, RequestContent.Create(content), contentType, context: default);
        }

        /// <summary>
        /// Send message to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> SendToGroupAsync(string group, string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(group, nameof(group));
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return await SendToGroupAsync(group, RequestContent.Create(content), contentType, excluded: default, context: default).ConfigureAwait(false);
        }

        /// <summary>
        /// Send message to a group of connections.
        /// </summary>
        /// <param name="group">Target group name, which length should be greater than 0 and less than 1025.</param>
        /// <param name="content"></param>
        /// <param name="contentType">Defaults to ContentType.PlainText.</param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response SendToGroup(string group, string content, ContentType contentType = default)
        {
            Argument.AssertNotNull(group, nameof(group));
            Argument.AssertNotNull(content, nameof(content));

            if (contentType == default)
                contentType = ContentType.TextPlain;

            return SendToGroup(group, RequestContent.Create(content), contentType, excluded: default, context: default);
        }

        /// <summary> Check if there are any client connections inside the given group. </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual async Task<Response<bool>> GroupExistsAsync(string group, RequestContext context = default)
        {
            var response = await GroupExistsImplAsync(group, context).ConfigureAwait(false);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if there are any client connections inside the given group. </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual Response<bool> GroupExists(string group, RequestContext context = default)
        {
            var response = GroupExistsImpl(group, context);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if there are any client connections connected for the given user. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual async Task<Response<bool>> UserExistsAsync(string userId, RequestContext context = default)
        {
            var response = await UserExistsImplAsync(userId, context).ConfigureAwait(false);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if there are any client connections connected for the given user. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual Response<bool> UserExists(string userId, RequestContext context = default)
        {
            var response = UserExistsImpl(userId, context);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if the connection with the given connectionId exists. </summary>
        /// <param name="connectionId"> The connection Id. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual async Task<Response<bool>> ConnectionExistsAsync(string connectionId, RequestContext context = default)
        {
            var response = await ConnectionExistsImplAsync(connectionId, context).ConfigureAwait(false);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Check if the connection with the given connectionId exists. </summary>
        /// <param name="connectionId"> The connection Id. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual Response<bool> ConnectionExists(string connectionId, RequestContext context = default)
        {
            var response = ConnectionExistsImpl(connectionId, context);
            return Response.FromValue(response.Status == 200, response);
        }

        /// <summary> Grant permission to the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual async Task<Response> GrantPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = null, RequestContext context = default)
        {
            var response = await GrantPermissionAsync(PermissionToString(permission), connectionId, targetName, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Grant permission to the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual Response GrantPermission(WebPubSubPermission permission, string connectionId, string targetName = null, RequestContext context = default)
        {
            var response = GrantPermission(PermissionToString(permission), connectionId, targetName, context);
            return response;
        }

        /// <summary> Revoke permission for the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual async Task<Response> RevokePermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = null, RequestContext context = default)
        {
            var response = await RevokePermissionAsync(PermissionToString(permission), connectionId, targetName, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Revoke permission for the connection. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual Response RevokePermission(WebPubSubPermission permission, string connectionId, string targetName = null, RequestContext context = default)
        {
            var response = RevokePermission(PermissionToString(permission), connectionId, targetName, context);
            return response;
        }

        /// <summary> Check if a connection has permission to the specified action. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual async Task<Response<bool>> CheckPermissionAsync(WebPubSubPermission permission, string connectionId, string targetName = null, RequestContext context = default)
        {
            var response = await CheckPermissionAsync(PermissionToString(permission), connectionId, targetName, context).ConfigureAwait(false);
            return Response.FromValue((response.Status == 200), response);
        }

        /// <summary> Check if a connection has permission to the specified action. </summary>
        /// <param name="permission"> The permission: current supported actions are joinLeaveGroup and sendToGroup. </param>
        /// <param name="connectionId"> Target connection Id. </param>
        /// <param name="targetName"> Optional. If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission. </param>
        /// <param name="context">Options specifying the cancellation token, controlling error reporting, etc.</param>
        public virtual Response<bool> CheckPermission(WebPubSubPermission permission, string connectionId, string targetName = null, RequestContext context = default)
        {
            var response = CheckPermission(PermissionToString(permission), connectionId, targetName, context);
            return Response.FromValue((response.Status == 200), response);
        }

        /// <summary> Add a user to the target group. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="group"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: string,
        ///   message: string,
        ///   target: string,
        ///   details: [ErrorDetail],
        ///   inner: {
        ///     code: string,
        ///     inner: InnerError
        ///   }
        /// }
        /// </code>
        /// </remarks>
        public virtual async Task<Response> AddUserToGroupAsync(string group, string userId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.AddUserToGroup");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAddUserToGroupRequest(userId, group, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a user to the target group. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="group"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: string,
        ///   message: string,
        ///   target: string,
        ///   details: [ErrorDetail],
        ///   inner: {
        ///     code: string,
        ///     inner: InnerError
        ///   }
        /// }
        /// </code>
        /// </remarks>
        public virtual Response AddUserToGroup(string group, string userId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.AddUserToGroup");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAddUserToGroupRequest(userId, group, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Remove a user from the target group. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="group"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: string,
        ///   message: string,
        ///   target: string,
        ///   details: [ErrorDetail],
        ///   inner: {
        ///     code: string,
        ///     inner: InnerError
        ///   }
        /// }
        /// </code>
        /// </remarks>
        public virtual async Task<Response> RemoveUserFromGroupAsync(string group, string userId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.RemoveUserFromGroup");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRemoveUserFromGroupRequest(userId, group, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Remove a user from the target group. </summary>
        /// <param name="userId"> Target user Id. </param>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="group"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: string,
        ///   message: string,
        ///   target: string,
        ///   details: [ErrorDetail],
        ///   inner: {
        ///     code: string,
        ///     inner: InnerError
        ///   }
        /// }
        /// </code>
        /// </remarks>
        public virtual Response RemoveUserFromGroup(string group, string userId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.RemoveUserFromGroup");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRemoveUserFromGroupRequest(userId, group, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add filtered connections to multiple groups.
        /// </summary>
        /// <param name="groups"> A list of groups which target connections will be added into. </param>
        /// <param name="filter"> An OData filter which target connections satisfy. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response AddConnectionsToGroups(IEnumerable<string> groups, string filter, RequestContext context = null)
        {
            Argument.AssertNotNull(filter, nameof(filter));
            Argument.AssertNotNull(groups, nameof(groups));

            return AddConnectionsToGroups(RequestContent.Create(new { filter = filter, groups = groups }), context);
        }

        /// <summary>
        /// Add filtered connections to multiple groups.
        /// </summary>
        /// <param name="groups"> A list of groups which target connections will be added into. </param>
        /// <param name="filter"> An OData filter which target connections satisfy. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> AddConnectionsToGroupsAsync(IEnumerable<string> groups, string filter, RequestContext context = null)
        {
            Argument.AssertNotNull(filter, nameof(filter));
            Argument.AssertNotNull(groups, nameof(groups));

            return await AddConnectionsToGroupsAsync(RequestContent.Create(new { filter = filter, groups = groups }), context).ConfigureAwait(false);
        }

        /// <summary>
        /// Remove filtered connections from multiple groups.
        /// </summary>
        /// <param name="groups"> A list of groups which target connections will be added into. </param>
        /// <param name="filter"> An OData filter which target connections satisfy. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual Response RemoveConnectionsFromGroups(IEnumerable<string> groups, string filter = null, RequestContext context = null)
        {
            Argument.AssertNotNull(groups, nameof(groups));

            return RemoveConnectionsFromGroups(RequestContent.Create(new { filter = filter, groups = groups }), context);
        }

        /// <summary>
        /// Remove filtered connections from multiple groups.
        /// </summary>
        /// <param name="groups"> A list of groups which target connections will be added into. </param>
        /// <param name="filter"> An OData filter which target connections satisfy. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns>A <see cref="Response"/> if successful.</returns>
        public virtual async Task<Response> RemoveConnectionsFromGroupsAsync(IEnumerable<string> groups, string filter = null, RequestContext context = null)
        {
            Argument.AssertNotNull(groups, nameof(groups));

            return await RemoveConnectionsFromGroupsAsync(RequestContent.Create(new { filter = filter, groups = groups }), context).ConfigureAwait(false);
        }

        /// <summary>
        /// List all the connections in a group.
        /// </summary>
        /// <param name="group"> Target group name, whose length should be greater than 0 and less than 1025. </param>
        /// <param name="maxpagesize"> The maximum number of connections to include in a single response. It should be between 1 and 200. </param>
        /// <param name="maxCount"> The maximum number of connections to return. If the value is not set, then all the connections in a group are returned. </param>
        /// <param name="continuationToken"> A token that allows the client to retrieve the next page of results. This parameter is provided by the service in the response of a previous request when there are additional results to be fetched. Clients should include the continuationToken in the next request to receive the subsequent page of data. If this parameter is omitted, the server will return the first page of results. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="group"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="group"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{GroupMember}"/> from the service. </returns>
        public virtual Pageable<WebPubSubGroupMember> ListConnectionsInGroup(string group, int? maxpagesize = null, int? maxCount = null, string continuationToken = null)
        {
            Argument.AssertNotNullOrEmpty(group, nameof(group));
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConnectionsInGroupsRequest(group, pageSizeHint, maxCount, continuationToken, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConnectionsInGroupsNextPageRequest(nextLink, group, pageSizeHint, maxCount, continuationToken, null);

            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, WebPubSubGroupMember.ParseFromJson, ClientDiagnostics, _pipeline, "WebPubSubServiceClient.ListConnectionsInGroup", "value", "nextLink", maxpagesize, null);
        }

        /// <summary>
        /// List all the connections in a group.
        /// </summary>
        /// <param name="group"> Target group name, whose length should be greater than 0 and less than 1025. </param>
        /// <param name="maxpagesize"> The maximum number of connections to include in a single response. It should be between 1 and 200. </param>
        /// <param name="maxCount"> The maximum number of connections to return. If the value is not set, then all the connections in a group are returned. </param>
        /// <param name="continuationToken"> A token that allows the client to retrieve the next page of results. This parameter is provided by the service in the response of a previous request when there are additional results to be fetched. Clients should include the continuationToken in the next request to receive the subsequent page of data. If this parameter is omitted, the server will return the first page of results. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="group"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="group"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{GroupMember}"/> from the service. </returns>
        public virtual AsyncPageable<WebPubSubGroupMember> ListConnectionsInGroupAsync(string group, int? maxpagesize = null, int? maxCount = null, string continuationToken = null)
        {
            Argument.AssertNotNullOrEmpty(group, nameof(group));
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConnectionsInGroupsRequest(group, pageSizeHint, maxCount, continuationToken, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConnectionsInGroupsNextPageRequest(nextLink, group, pageSizeHint, maxCount, continuationToken, null);

            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, WebPubSubGroupMember.ParseFromJson, ClientDiagnostics, _pipeline, "WebPubSubServiceClient.ListConnectionsInGroup", "value", "nextLink", maxpagesize, null);
        }
    }
}
