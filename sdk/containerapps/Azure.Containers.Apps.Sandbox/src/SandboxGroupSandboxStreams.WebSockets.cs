// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
#pragma warning disable AZC0004 // WebSocket connections are asynchronous only.
    public partial class SandboxGroupSandboxStreams
    {
        private const string AuthorizationScope = "https://management.azuredevcompute.io/.default";
        private static readonly TokenRequestContext s_tokenRequestContext = new TokenRequestContext(new[] { AuthorizationScope });

        internal Func<Uri, string, CancellationToken, Task<WebSocket>> WebSocketConnector { get; set; } = ConnectWebSocketAsync;

        /// <summary> Connects to an interactive exec session in the running sandbox. </summary>
        /// <param name="credential"> The credential used to authenticate the WebSocket connection. </param>
        /// <param name="containerName"> The container where the interactive session runs. </param>
        /// <param name="user"> The user for the interactive session. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A connected sandbox stream. The caller is responsible for closing and disposing it. </returns>
        public virtual async Task<SandboxStream> ConnectToSandboxExecStreamAsync(
            TokenCredential credential,
            string containerName = default,
            string user = default,
            CancellationToken cancellationToken = default)
        {
            var query = new List<KeyValuePair<string, string>>();
            AddQueryParameter(query, "containerName", containerName);
            AddQueryParameter(query, "user", user);

            return await ConnectAsync(credential, "exec/stream", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Connects to the log stream of the running sandbox. </summary>
        /// <param name="credential"> The credential used to authenticate the WebSocket connection. </param>
        /// <param name="tailLines"> The number of recent log lines to return. </param>
        /// <param name="logFormat"> The format of streamed log records. </param>
        /// <param name="follow"> Whether to continue streaming new log records. </param>
        /// <param name="containerName"> The container whose logs are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A connected sandbox stream. The caller is responsible for closing and disposing it. </returns>
        public virtual async Task<SandboxStream> ConnectToSandboxLogStreamAsync(
            TokenCredential credential,
            int? tailLines = default,
            int? logFormat = default,
            bool? follow = default,
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            var query = new List<KeyValuePair<string, string>>();
            AddQueryParameter(query, "tailLines", tailLines?.ToString(CultureInfo.InvariantCulture));
            AddQueryParameter(query, "logFormat", logFormat?.ToString(CultureInfo.InvariantCulture));
            AddQueryParameter(query, "follow", follow?.ToString().ToLowerInvariant());
            AddQueryParameter(query, "containerName", containerName);

            return await ConnectAsync(credential, "logstream", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Connects to the process stream of the running sandbox. </summary>
        /// <param name="credential"> The credential used to authenticate the WebSocket connection. </param>
        /// <param name="containerName"> The container whose processes are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A connected sandbox stream. The caller is responsible for closing and disposing it. </returns>
        public virtual async Task<SandboxStream> ConnectToSandboxProcessesStreamAsync(
            TokenCredential credential,
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            var query = new List<KeyValuePair<string, string>>();
            AddQueryParameter(query, "containerName", containerName);

            return await ConnectAsync(credential, "processes/stream", query, cancellationToken).ConfigureAwait(false);
        }

        private async Task<SandboxStream> ConnectAsync(
            TokenCredential credential,
            string operationPath,
            IReadOnlyList<KeyValuePair<string, string>> query,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            AccessToken accessToken = await credential.GetTokenAsync(s_tokenRequestContext, cancellationToken).ConfigureAwait(false);
            Uri uri = CreateWebSocketUri(operationPath, query);
            WebSocket webSocket = await WebSocketConnector(uri, accessToken.Token, cancellationToken).ConfigureAwait(false);
            return new SandboxStream(webSocket);
        }

        internal Uri CreateWebSocketUri(string operationPath, IReadOnlyList<KeyValuePair<string, string>> query)
        {
            var builder = new UriBuilder(_endpoint)
            {
                Scheme = GetWebSocketScheme(_endpoint.Scheme),
                Path = JoinPath(
                    _endpoint.AbsolutePath,
                    "subscriptions",
                    _subscriptionId,
                    "resourceGroups",
                    _resourceGroupName,
                    "sandboxGroups",
                    _sandboxGroupName,
                    "sandboxes",
                    _id,
                    operationPath)
            };

            var queryParameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("api-version", _apiVersion)
            };
            queryParameters.AddRange(query);
            builder.Query = BuildQuery(queryParameters);
            return builder.Uri;
        }

        private static async Task<WebSocket> ConnectWebSocketAsync(
            Uri uri,
            string accessToken,
            CancellationToken cancellationToken)
        {
            var socket = new ClientWebSocket();
            socket.Options.SetRequestHeader("Authorization", CreateAuthorizationHeaderValue(accessToken));

            try
            {
                await socket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
                return socket;
            }
            catch
            {
                socket.Dispose();
                throw;
            }
        }

        private static string GetWebSocketScheme(string scheme)
        {
            if (string.Equals(scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(scheme, "wss", StringComparison.OrdinalIgnoreCase))
            {
                return "wss";
            }

            if (string.Equals(scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(scheme, "ws", StringComparison.OrdinalIgnoreCase))
            {
                return "ws";
            }

            throw new ArgumentException($"Scheme '{scheme}' is not supported for WebSocket connections.", nameof(scheme));
        }

        internal static string CreateAuthorizationHeaderValue(string accessToken)
        {
            return string.Concat("Bearer ", accessToken);
        }

        private static string JoinPath(string basePath, params string[] segments)
        {
            string path = basePath.TrimEnd('/');
            foreach (string segment in segments)
            {
                foreach (string part in segment.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    path += "/" + Uri.EscapeDataString(part);
                }
            }
            return path;
        }

        private static string BuildQuery(IReadOnlyList<KeyValuePair<string, string>> parameters)
        {
            var values = new List<string>(parameters.Count);
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    values.Add($"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}");
                }
            }
            return string.Join("&", values);
        }

        private static void AddQueryParameter(
            ICollection<KeyValuePair<string, string>> query,
            string name,
            string value)
        {
            if (value != null)
            {
                query.Add(new KeyValuePair<string, string>(name, value));
            }
        }
    }
#pragma warning restore AZC0004
#pragma warning restore AZC0004
}
