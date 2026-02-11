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
        /// <param name="model">The model to use for the session.</param>
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
            return await StartSessionWithConfigurationAsync(
                sessionConfig?.Model,
                agentConfig: null,
                sessionConfig,
                cancellationToken).ConfigureAwait(false);
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
            return await StartSessionWithConfigurationAsync(
                model: null,
                agentConfig,
                sessionConfig,
                cancellationToken).ConfigureAwait(false);
        }
#pragma warning restore AZC0004 // Websocket is an async only class

        /// <summary>
        /// Core method for starting a session with optional configurations.
        /// </summary>
        /// <param name="model">The model to use (for model-based sessions).</param>
        /// <param name="agentConfig">The agent configuration (for agent-based sessions).</param>
        /// <param name="sessionConfig">Optional session configuration to apply after connection.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A connected and optionally configured VoiceLiveSession.</returns>
        private async Task<VoiceLiveSession> StartSessionWithConfigurationAsync(
            string model,
            AgentSessionConfig agentConfig,
            VoiceLiveSessionOptions sessionConfig,
            CancellationToken cancellationToken)
        {
            // Validate inputs
            if (sessionConfig != null)
            {
                Argument.AssertNotNull(sessionConfig, nameof(sessionConfig));
            }
            if (agentConfig != null)
            {
                Argument.AssertNotNull(agentConfig, nameof(agentConfig));
            }

            // Create endpoint and session
            Uri webSocketEndpoint = agentConfig != null
                ? ConvertToWebSocketEndpoint(_endpoint, agentConfig)
                : ConvertToWebSocketEndpoint(_endpoint, model ?? sessionConfig?.Model);

            VoiceLiveSession session = await CreateAndConnectSessionAsync(webSocketEndpoint, cancellationToken).ConfigureAwait(false);

            // Apply session configuration if provided
            if (sessionConfig != null)
            {
                await ApplySessionConfigurationAsync(session, sessionConfig, cancellationToken).ConfigureAwait(false);
            }

            return session;
        }

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
            AddQueryParameter(builder, "model", model);
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

            // Add required agent parameters
            AddQueryParameter(builder, "agent-name", agentConfig.AgentName);
            AddQueryParameter(builder, "agent-project-name", agentConfig.ProjectName);

            // Add optional agent parameters
            AddQueryParameterIfNotEmpty(builder, "agent-version", agentConfig.AgentVersion);
            AddQueryParameterIfNotEmpty(builder, "conversation-id", agentConfig.ConversationId);
            AddQueryParameterIfNotEmpty(builder, "agent-authentication-identity-client-id", agentConfig.AuthenticationIdentityClientId);
            AddQueryParameterIfNotEmpty(builder, "foundry-resource-override", agentConfig.FoundryResourceOverride);

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

        /// <summary>
        /// Adds a query parameter to the UriBuilder if the value is not null or empty.
        /// </summary>
        /// <param name="builder">The UriBuilder to modify.</param>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        private void AddQueryParameter(UriBuilder builder, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                builder.Query = $"{builder.Query.TrimStart('?')}&{name}={Uri.EscapeDataString(value)}";
            }
        }

        /// <summary>
        /// Adds a query parameter to the UriBuilder only if the value is not null or empty.
        /// </summary>
        /// <param name="builder">The UriBuilder to modify.</param>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        private void AddQueryParameterIfNotEmpty(UriBuilder builder, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AddQueryParameter(builder, name, value);
            }
        }
    }
}