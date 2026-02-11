// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
#pragma warning disable AZC0015, AZC0107 // Client methods should return approved types
    public partial class VoiceLiveClient
    {
#pragma warning disable AZC0004 // Websocket is an async only class
        /// <summary>
        /// Starts a new <see cref="VoiceLiveSession"/> for real-time voice communication.
        /// </summary>
        /// <remarks>
        /// The <see cref="VoiceLiveSession"/> abstracts bidirectional communication between the caller and service,
        /// simultaneously sending and receiving WebSocket messages.
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="model"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual async Task<VoiceLiveSession> StartSessionAsync(string model, CancellationToken cancellationToken = default)
        {
            Uri webSocketEndpoint = ConvertToWebSocketEndpoint(_endpoint, model);
            return await CreateAndConnectSessionAsync(webSocketEndpoint, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new <see cref="VoiceLiveSession"/> for real-time voice communication with specified session configuration.
        /// </summary>
        /// <remarks>
        /// The <see cref="VoiceLiveSession"/> abstracts bidirectional communication between the caller and service,
        /// simultaneously sending and receiving WebSocket messages.
        /// </remarks>
        /// <param name="sessionConfig">The configuration for the session.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual async Task<VoiceLiveSession> StartSessionAsync(
            VoiceLiveSessionOptions sessionConfig,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(sessionConfig, nameof(sessionConfig));

            VoiceLiveSession session = await StartSessionAsync(sessionConfig.Model, cancellationToken).ConfigureAwait(false);
            await ApplySessionConfigurationAsync(session, sessionConfig, cancellationToken).ConfigureAwait(false);

            return session;
        }

        /// <summary>
        /// Starts a new <see cref="VoiceLiveSession"/> for real-time voice communication with an agent.
        /// </summary>
        /// <remarks>
        /// The <see cref="VoiceLiveSession"/> abstracts bidirectional communication between the caller and service,
        /// simultaneously sending and receiving WebSocket messages.
        /// </remarks>
        /// <param name="agentConfig">The agent configuration for the session.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual async Task<VoiceLiveSession> StartSessionAsync(AgentSessionConfig agentConfig, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(agentConfig, nameof(agentConfig));

            Uri webSocketEndpoint = ConvertToWebSocketEndpoint(_endpoint, agentConfig);
            return await CreateAndConnectSessionAsync(webSocketEndpoint, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new <see cref="VoiceLiveSession"/> for real-time voice communication with an agent and specified session configuration.
        /// </summary>
        /// <remarks>
        /// The <see cref="VoiceLiveSession"/> abstracts bidirectional communication between the caller and service,
        /// simultaneously sending and receiving WebSocket messages.
        /// </remarks>
        /// <param name="agentConfig">The agent configuration for the session.</param>
        /// <param name="sessionConfig">The configuration for the session.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual async Task<VoiceLiveSession> StartSessionAsync(
            AgentSessionConfig agentConfig,
            VoiceLiveSessionOptions sessionConfig,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(agentConfig, nameof(agentConfig));
            Argument.AssertNotNull(sessionConfig, nameof(sessionConfig));

            VoiceLiveSession session = await StartSessionAsync(agentConfig, cancellationToken).ConfigureAwait(false);
            await ApplySessionConfigurationAsync(session, sessionConfig, cancellationToken).ConfigureAwait(false);

            return session;
        }
#pragma warning restore AZC0004 // Websocket is an async only class

        /// <summary>
        /// Creates and connects a VoiceLiveSession with the specified endpoint.
        /// </summary>
        /// <param name="webSocketEndpoint">The WebSocket endpoint to connect to.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A connected VoiceLiveSession.</returns>
        private async Task<VoiceLiveSession> CreateAndConnectSessionAsync(Uri webSocketEndpoint, CancellationToken cancellationToken)
        {
            VoiceLiveSession session = _keyCredential != null ?
                new(this, webSocketEndpoint, _keyCredential) :
                new(this, webSocketEndpoint, _tokenCredential);

            await session.ConnectAsync(Options.Headers, cancellationToken).ConfigureAwait(false);
            return session;
        }

        /// <summary>
        /// Applies session configuration to an established session.
        /// </summary>
        /// <param name="session">The session to configure.</param>
        /// <param name="sessionConfig">The session configuration to apply.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        private async Task ApplySessionConfigurationAsync(VoiceLiveSession session, VoiceLiveSessionOptions sessionConfig, CancellationToken cancellationToken)
        {
            ClientEventSessionUpdate sessionUpdateEvent = new(sessionConfig);
            await session.SendCommandAsync(sessionUpdateEvent, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Converts an HTTP endpoint to a WebSocket endpoint.
        /// </summary>
        /// <param name="httpEndpoint">The HTTP endpoint to convert.</param>
        /// <param name="model">The model to include in query parameters.</param>
        /// <returns>The WebSocket endpoint.</returns>
        private Uri ConvertToWebSocketEndpoint(Uri httpEndpoint, string model)
        {
            Argument.AssertNotNull(httpEndpoint, nameof(httpEndpoint));

            var builder = CreateWebSocketUriBuilder(httpEndpoint);

            if (!builder.Query.Contains("model="))
            {
                builder.Query = $"{builder.Query.TrimStart('?')}&model={model}";
            }

            return builder.Uri;
        }

        /// <summary>
        /// Converts an HTTP endpoint to a WebSocket endpoint with agent configuration.
        /// </summary>
        /// <param name="httpEndpoint">The HTTP endpoint to convert.</param>
        /// <param name="agentConfig">The agent configuration for agent-centric sessions.</param>
        /// <returns>The WebSocket endpoint.</returns>
        private Uri ConvertToWebSocketEndpoint(Uri httpEndpoint, AgentSessionConfig agentConfig)
        {
            Argument.AssertNotNull(httpEndpoint, nameof(httpEndpoint));
            Argument.AssertNotNull(agentConfig, nameof(agentConfig));

            var builder = CreateWebSocketUriBuilder(httpEndpoint);

            // Add agent-specific query parameters (required)
            builder.Query = $"{builder.Query.TrimStart('?')}&agent-name={Uri.EscapeDataString(agentConfig.AgentName)}";
            builder.Query = $"{builder.Query}&agent-project-name={Uri.EscapeDataString(agentConfig.ProjectName)}";

            // Add optional agent parameters
            if (!string.IsNullOrEmpty(agentConfig.AgentVersion))
            {
                builder.Query = $"{builder.Query}&agent-version={Uri.EscapeDataString(agentConfig.AgentVersion)}";
            }

            if (!string.IsNullOrEmpty(agentConfig.ConversationId))
            {
                builder.Query = $"{builder.Query}&conversation-id={Uri.EscapeDataString(agentConfig.ConversationId)}";
            }

            if (!string.IsNullOrEmpty(agentConfig.AuthenticationIdentityClientId))
            {
                builder.Query = $"{builder.Query}&agent-authentication-identity-client-id={Uri.EscapeDataString(agentConfig.AuthenticationIdentityClientId)}";
            }

            if (!string.IsNullOrEmpty(agentConfig.FoundryResourceOverride))
            {
                builder.Query = $"{builder.Query}&foundry-resource-override={Uri.EscapeDataString(agentConfig.FoundryResourceOverride)}";
            }

            return builder.Uri;
        }

        /// <summary>
        /// Creates a UriBuilder with common WebSocket endpoint setup.
        /// </summary>
        /// <param name="httpEndpoint">The HTTP endpoint to convert.</param>
        /// <returns>A UriBuilder configured for WebSocket connections.</returns>
        private UriBuilder CreateWebSocketUriBuilder(Uri httpEndpoint)
        {
            var scheme = httpEndpoint.Scheme.ToLower() switch
            {
                "wss" => "wss",
                "ws" => "ws",
                "https" => "wss",
                "http" => "ws",
                _ => throw new ArgumentException($"Scheme {httpEndpoint.Scheme} is not supported."),
            };

            var builder = new UriBuilder(httpEndpoint)
            {
                Scheme = scheme
            };

            // Ensure the path includes the WebSocket endpoint
            if (!builder.Path.EndsWith("/realtime", StringComparison.OrdinalIgnoreCase))
            {
                builder.Path = builder.Path.TrimEnd('/') + "/voice-live/realtime";
            }

            // Add the query parameter for the API version if it doesn't already exist
            if (!builder.Query.Contains("api-version="))
            {
                builder.Query = $"{builder.Query.TrimStart('?')}&api-version={Options.Version}";
            }

            return builder;
        }
    }
}