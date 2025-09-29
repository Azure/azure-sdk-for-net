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
            // Convert the HTTP endpoint to a WebSocket endpoint
            Uri webSocketEndpoint = ConvertToWebSocketEndpoint(_endpoint, model);

            VoiceLiveSession session = _keyCredential != null ? new(this, webSocketEndpoint, _keyCredential) : new(this, webSocketEndpoint, _tokenCredential);

            await session.ConnectAsync(_options.Headers, cancellationToken).ConfigureAwait(false);

            return session;
        }

        /// <summary>
        /// Starts a new <see cref="VoiceLiveSession"/> for real-time voice communication.
        /// </summary>
        /// <remarks>
        /// The <see cref="VoiceLiveSession"/> abstracts bidirectional communication between the caller and service,
        /// simultaneously sending and receiving WebSocket messages.
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="model"></param>
        /// <returns>A new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual VoiceLiveSession StartSession(string model, CancellationToken cancellationToken = default)
        {
            return StartSessionAsync(model, cancellationToken).EnsureCompleted();
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

            // Send the session configuration
            ClientEventSessionUpdate sessionUpdateEvent = new(sessionConfig);
            await session.SendCommandAsync(sessionUpdateEvent, cancellationToken).ConfigureAwait(false);

            return session;
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
        /// <returns>A new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual VoiceLiveSession StartSession(
            VoiceLiveSessionOptions sessionConfig,
            CancellationToken cancellationToken = default)
        {
            return StartSessionAsync(sessionConfig, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Converts an HTTP endpoint to a WebSocket endpoint.
        /// </summary>
        /// <param name="httpEndpoint">The HTTP endpoint to convert.</param>
        /// <param name="model"></param>
        /// <returns>The WebSocket endpoint.</returns>
        private Uri ConvertToWebSocketEndpoint(Uri httpEndpoint, string model)
        {
            if (httpEndpoint == null)
            {
                throw new ArgumentNullException(nameof(httpEndpoint));
            }

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
                builder.Path = builder.Path.TrimEnd('/') + "/voice-agent/realtime";
            }

            // Add the query parameter for the API version if it doesn't already exist
            if (!builder.Query.Contains("api-version="))
            {
                builder.Query = $"{builder.Query.TrimStart('?')}&api-version={_options.Version}";
            }

            if (!builder.Query.Contains("model="))
            {
                builder.Query = $"{builder.Query.TrimStart('?')}&model={model}";
            }

            return builder.Uri;
        }
    }
#pragma warning restore AZC0015, AZC0107
}
