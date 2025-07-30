// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// Occurs when a command is being sent to the service via WebSocket.
        /// </summary>
        public event EventHandler<BinaryData> SendingCommand;

        /// <summary>
        /// Occurs when a message is received from the service via WebSocket.
        /// </summary>
        public event EventHandler<BinaryData> ReceivingMessage;

        /// <summary>
        /// Starts a new <see cref="VoiceLiveSession"/> for real-time voice communication.
        /// </summary>
        /// <remarks>
        /// The <see cref="VoiceLiveSession"/> abstracts bidirectional communication between the caller and service,
        /// simultaneously sending and receiving WebSocket messages.
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual async Task<VoiceLiveSession> StartSessionAsync(CancellationToken cancellationToken = default)
        {
            // Convert the HTTP endpoint to a WebSocket endpoint
            Uri webSocketEndpoint = ConvertToWebSocketEndpoint(_endpoint);

            VoiceLiveSession session = new(this, webSocketEndpoint, _keyCredential);

            await session.ConnectAsync(cancellationToken).ConfigureAwait(false);

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
        /// <returns>A new, connected instance of <see cref="VoiceLiveSession"/>.</returns>
        public virtual VoiceLiveSession StartSession(CancellationToken cancellationToken = default)
        {
            return StartSessionAsync(cancellationToken).EnsureCompleted();
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
            RequestSession sessionConfig,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(sessionConfig, nameof(sessionConfig));

            VoiceLiveSession session = await StartSessionAsync(cancellationToken).ConfigureAwait(false);

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
            RequestSession sessionConfig,
            CancellationToken cancellationToken = default)
        {
            return StartSessionAsync(sessionConfig, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Raises the <see cref="SendingCommand"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="command">The command being sent.</param>
        protected internal virtual void OnSendingCommand(object sender, BinaryData command)
        {
            SendingCommand?.Invoke(sender, command);
        }

        /// <summary>
        /// Raises the <see cref="ReceivingMessage"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="message">The message being received.</param>
        protected internal virtual void OnReceivingMessage(object sender, BinaryData message)
        {
            ReceivingMessage?.Invoke(sender, message);
        }

        /// <summary>
        /// Converts an HTTP endpoint to a WebSocket endpoint.
        /// </summary>
        /// <param name="httpEndpoint">The HTTP endpoint to convert.</param>
        /// <returns>The WebSocket endpoint.</returns>
        private static Uri ConvertToWebSocketEndpoint(Uri httpEndpoint)
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

            return builder.Uri;
        }
    }
#pragma warning restore AZC0015, AZC0107
}
