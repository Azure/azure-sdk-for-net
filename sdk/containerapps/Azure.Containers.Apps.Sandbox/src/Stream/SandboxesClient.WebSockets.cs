// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Containers.Apps.Sandbox.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Containers.Apps.Sandbox
{
    [CodeGenSuppress("GetSandboxExecStream", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSandboxExecStreamAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSandboxExecStream", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSandboxExecStreamAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSandboxLogStream", typeof(string), typeof(int?), typeof(int?), typeof(bool?), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSandboxLogStreamAsync", typeof(string), typeof(int?), typeof(int?), typeof(bool?), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSandboxLogStream", typeof(string), typeof(int?), typeof(int?), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSandboxLogStreamAsync", typeof(string), typeof(int?), typeof(int?), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSandboxProcessesStream", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSandboxProcessesStreamAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSandboxProcessesStream", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSandboxProcessesStreamAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class SandboxesClient
    {
        private readonly TokenCredential _webSocketCredential;
        internal Func<Uri, string, CancellationToken, Task<ISandboxWebSocketClient>> WebSocketConnector { get; set; } =
            SandboxWebSocketClient.ConnectAsync;

        internal SandboxesClient(ClientDiagnostics diagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion,
            string subscriptionId, string resourceGroupName, string sandboxGroupName, TokenCredential credential)
            : this(diagnostics, pipeline, endpoint, apiVersion, subscriptionId, resourceGroupName, sandboxGroupName)
        {
            _webSocketCredential = credential;
        }

#pragma warning disable AZC0004, AZC0015 // WebSocket connections are asynchronous and return a connected session.
        /// <summary> Opens an interactive exec WebSocket connection. The caller must dispose the returned stream. </summary>
        /// <param name="id"> The sandbox identifier. </param>
        /// <param name="containerName"> The container where the session runs. </param>
        /// <param name="user"> The optional user for the session. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual Task<SandboxStream> ConnectToSandboxExecStreamAsync(string id,
            string containerName = default, string user = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            using HttpMessage message = CreateGetSandboxExecStreamRequest(id, containerName, user, cancellationToken.ToRequestContext());
            return ConnectWebSocketAsync(message.Request.Uri.ToUri(), "SandboxesClient.ConnectToSandboxExecStream", cancellationToken);
        }

        /// <summary> Opens an unbuffered HTTP log stream. Dispose the returned stream after reading it. </summary>
        /// <param name="id"> The sandbox identifier. </param>
        /// <param name="tailLines"> The number of previous log lines. </param>
        /// <param name="logFormat"> The format of the log records. </param>
        /// <param name="follow"> Whether to follow new log records. </param>
        /// <param name="containerName"> The container whose logs are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual async Task<Response<Stream>> OpenSandboxLogStreamAsync(string id, int tailLines = 100,
            SandboxLogFormat logFormat = SandboxLogFormat.Text, bool follow = true, string containerName = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            if (tailLines < 0 || tailLines > 300)
                throw new ArgumentOutOfRangeException(nameof(tailLines), "Tail lines must be between 0 and 300.");
            string format = logFormat switch
            {
                SandboxLogFormat.Text => "text",
                SandboxLogFormat.Json => "json",
                _ => throw new ArgumentOutOfRangeException(nameof(logFormat))
            };

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxesClient.OpenSandboxLogStream");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSandboxLogStreamRequest(
                    id, tailLines, null, follow, containerName, cancellationToken.ToRequestContext());
                message.Request.Uri.AppendQuery("logFormat", format);
                message.BufferResponse = false;
                Response response = await Pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                Stream content = message.ExtractResponseContent() ?? Stream.Null;
                return Response.FromValue(content, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Opens and starts an interactive exec session. Dispose the session when finished. </summary>
        /// <param name="id"> The sandbox identifier. </param>
        /// <param name="request"> The initial WebSocket exec configuration. </param>
        /// <param name="containerName"> The container where the session runs. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting and sending the start message. </param>
        public virtual async Task<SandboxExecSession> StartSandboxExecSessionAsync(string id, SandboxExecStartRequest request,
            string containerName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxesClient.StartSandboxExecSession");
            scope.Start();
            SandboxStream stream = null;
            try
            {
                stream = await ConnectToSandboxExecStreamAsync(id, containerName, cancellationToken: cancellationToken).ConfigureAwait(false);
                SandboxExecSession session = new SandboxExecSession(stream);
                await session.StartAsync(request, cancellationToken).ConfigureAwait(false);
                return session;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                stream?.Dispose();
                throw;
            }
        }

        /// <summary> Opens a read-only stream of process snapshots (one text message per refresh). </summary>
        public virtual async Task<SandboxProcessStream> OpenSandboxProcessStreamAsync(string id,
            string containerName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxesClient.OpenSandboxProcessStream");
            scope.Start();
            try
            {
                SandboxStream stream = await ConnectToSandboxProcessesStreamAsync(id, containerName, cancellationToken).ConfigureAwait(false);
                return new SandboxProcessStream(stream);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Opens a process WebSocket connection. The caller must dispose the returned stream. </summary>
        /// <param name="id"> The sandbox identifier. </param>
        /// <param name="containerName"> The container whose processes are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual Task<SandboxStream> ConnectToSandboxProcessesStreamAsync(string id,
            string containerName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            using HttpMessage message = CreateGetSandboxProcessesStreamRequest(id, containerName, cancellationToken.ToRequestContext());
            return ConnectWebSocketAsync(message.Request.Uri.ToUri(), "SandboxesClient.ConnectToSandboxProcessesStream", cancellationToken);
        }

        private async Task<SandboxStream> ConnectWebSocketAsync(Uri httpUri, string scopeName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                if (_webSocketCredential == null)
                    throw new InvalidOperationException("A TokenCredential is required for sandbox WebSocket connections.");

                UriBuilder builder = new UriBuilder(httpUri)
                {
                    Scheme = httpUri.Scheme switch
                    {
                        "https" => "wss",
                        "http" => "ws",
                        _ => throw new ArgumentException("The endpoint must use HTTP or HTTPS.", nameof(httpUri))
                    }
                };
                AccessToken token = await _webSocketCredential.GetTokenAsync(
                    new TokenRequestContext(SandboxGroupClient.WebSocketAuthorizationScopes), cancellationToken).ConfigureAwait(false);
                ISandboxWebSocketClient socket = await WebSocketConnector(builder.Uri, $"{token.TokenType} {token.Token}", cancellationToken).ConfigureAwait(false);
                return new SandboxStream(socket);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
#pragma warning restore AZC0004, AZC0015
    }
}
