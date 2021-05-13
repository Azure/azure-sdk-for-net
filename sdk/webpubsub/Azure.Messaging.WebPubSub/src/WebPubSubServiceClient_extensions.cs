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
        private AzureKeyCredential credential;

        private const string JsonContent = "application/json";

        /// <summary>
        /// The hub.
        /// </summary>
        public string Hub => hub;

        /// <summary>
        /// The service endpoint.
        /// </summary>
        public Uri Endpoint => endpoint;

        /// <summary> Initializes a new instance of WebPubSubServiceClient. </summary>
        /// <param name="hub"> Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public WebPubSubServiceClient(string hub, AzureKeyCredential credential, Uri endpoint = null, WebPubSubServiceClientOptions options = null)
        {
            this.credential = credential;

            if (hub == null)
            {
                throw new ArgumentNullException(nameof(hub));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("");

            options ??= new WebPubSubServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            Pipeline = HttpPipelineBuilder.Build(options, new WebPubSubAuthenticationPolicy(credential));
            this.hub = hub;
            this.endpoint = endpoint;
            apiVersion = options.Version;
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
            this(hub, parsedConnectionString.Credential, parsedConnectionString.Endpoint)
        {
        }

        private WebPubSubServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsedConnectionString, string hub, WebPubSubServiceClientOptions options) :
            this(hub, parsedConnectionString.Credential, parsedConnectionString.Endpoint, options)
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

            return await SendToAllAsync(JsonContent, RequestContent.Create(message), excluded, options).ConfigureAwait(false);
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

            return SendToAll(JsonContent, RequestContent.Create(message), excluded, options);
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

            return await SendToUserAsync(userId, JsonContent, RequestContent.Create(message), options).ConfigureAwait(false);
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

            return SendToUser(userId, JsonContent, RequestContent.Create(message), options);
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

            return await SendToConnectionAsync(connectionId, JsonContent, RequestContent.Create(message), options).ConfigureAwait(false);
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

            return SendToConnection(connectionId, JsonContent, RequestContent.Create(message), options);
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

            return await SendToGroupAsync(group, JsonContent, RequestContent.Create(message), excluded, options).ConfigureAwait(false);
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

            return SendToGroup(group, JsonContent, RequestContent.Create(message), excluded, options);
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
    }
}
