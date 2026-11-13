// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Text;
using Azure.Core;

namespace Azure.AI.VoiceLive.Diagnostics
{
    /// <summary>
    /// Handles content logging for VoiceLive WebSocket operations using Azure SDK patterns.
    /// </summary>
    internal class VoiceLiveWebSocketContentLogger
    {
        private readonly DiagnosticsOptions _diagnostics;
        private readonly AzureVoiceLiveEventSource _eventSource;

        public VoiceLiveWebSocketContentLogger(DiagnosticsOptions diagnostics)
        {
            _diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
            _eventSource = AzureVoiceLiveEventSource.Singleton;
        }

        /// <summary>
        /// Gets a value indicating whether content logging is enabled.
        /// </summary>
        public bool IsContentLoggingEnabled =>
            _diagnostics.IsLoggingEnabled &&
            _diagnostics.IsLoggingContentEnabled &&
            _eventSource.IsEnabled();

        /// <summary>
        /// Gets a value indicating whether general logging is enabled.
        /// </summary>
        public bool IsLoggingEnabled =>
            _diagnostics.IsLoggingEnabled &&
            _eventSource.IsEnabled();

        /// <summary>
        /// Logs a WebSocket connection opening.
        /// </summary>
        public void LogConnectionOpening(string connectionId, string uri)
        {
            if (IsLoggingEnabled)
            {
                _eventSource.WebSocketConnectionOpening(connectionId, uri);
            }
        }

        /// <summary>
        /// Logs a WebSocket connection opening.
        /// </summary>
        public void LogConnectionOpened(string connectionId)
        {
            if (IsLoggingEnabled)
            {
                _eventSource.WebSocketConnectionOpened(connectionId);
            }
        }

        /// <summary>
        /// Logs a WebSocket connection closing.
        /// </summary>
        public void LogConnectionClosing(string connectionId, int closeCode, string reason)
        {
            if (IsLoggingEnabled)
            {
                _eventSource.WebSocketConnectionClosing(connectionId, closeCode, reason);
            }
        }

        /// <summary>
        /// Logs a WebSocket connection closing.
        /// </summary>
        public void LogConnectionClosed(string connectionId)
        {
            if (IsLoggingEnabled)
            {
                _eventSource.WebSocketConnectionClosed(connectionId);
            }
        }

        /// <summary>
        /// Logs a sent WebSocket message.
        /// </summary>
        public void LogSentMessage(string connectionId, ReadOnlyMemory<byte> message, bool isText = true)
        {
            if (!IsLoggingEnabled)
                return;

            var messageType = isText ? "Text" : "Binary";
            _eventSource.WebSocketMessageSent(connectionId, messageType, message.Length);

            if (IsContentLoggingEnabled && message.Length > 0)
            {
                var content = TruncateContent(message);
                var encoding = isText ? Encoding.UTF8 : null;
                _eventSource.WebSocketMessageSentContent(connectionId, content.ToArray(), encoding);
            }
        }

        /// <summary>
        /// Logs a received WebSocket message.
        /// </summary>
        public void LogReceivedMessage(string connectionId, ReadOnlyMemory<byte> message, bool isText = true)
        {
            if (!IsLoggingEnabled)
                return;

            var messageType = isText ? "Text" : "Binary";
            _eventSource.WebSocketMessageReceived(connectionId, messageType, message.Length);

            if (IsContentLoggingEnabled && message.Length > 0)
            {
                var content = TruncateContent(message);
                var encoding = isText ? Encoding.UTF8 : null;
                _eventSource.WebSocketMessageReceivedContent(connectionId, content.ToArray(), encoding);
            }
        }

        /// <summary>
        /// Logs a WebSocket error with optional message content.
        /// </summary>
        public void LogError(string connectionId, string error, ReadOnlyMemory<byte> message = default, bool isText = true)
        {
            if (!IsLoggingEnabled)
                return;

            _eventSource.WebSocketMessageError(connectionId, error);

            // Error content is always logged if content logging is enabled (follows Azure.Core pattern)
            if (_diagnostics.IsLoggingContentEnabled && message.Length > 0)
            {
                var content = TruncateContent(message);
                var encoding = isText ? Encoding.UTF8 : null;
                _eventSource.WebSocketMessageErrorContent(connectionId, content.ToArray(), encoding);
            }
        }

        /// <summary>
        /// Logs a WebSocket error with optional message content.
        /// </summary>
        public void LogError(string connectionId, Exception ex, ReadOnlyMemory<byte> message = default, bool isText = true)
        {
            if (!IsLoggingEnabled)
                return;

            _eventSource.WebSocketMessageError(connectionId, $"Exception {ex}");
        }

        private ReadOnlyMemory<byte> TruncateContent(ReadOnlyMemory<byte> content)
        {
            if (content.Length <= _diagnostics.LoggedContentSizeLimit)
                return content;

            return content.Slice(0, _diagnostics.LoggedContentSizeLimit);
        }
    }
}
