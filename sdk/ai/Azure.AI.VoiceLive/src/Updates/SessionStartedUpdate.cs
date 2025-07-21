// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents an update indicating that a session has been started.
    /// </summary>
    public sealed class SessionStartedUpdate : VoiceLiveUpdate
    {
        private readonly VoiceLiveServerEventSessionCreated _sessionCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStartedUpdate"/> class.
        /// </summary>
        /// <param name="sessionCreated">The session created event.</param>
        internal SessionStartedUpdate(VoiceLiveServerEventSessionCreated sessionCreated)
            : base(VoiceLiveUpdateKind.SessionStarted)
        {
            Argument.AssertNotNull(sessionCreated, nameof(sessionCreated));
            _sessionCreated = sessionCreated;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStartedUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        /// <param name="sessionCreated">The session created event.</param>
        internal SessionStartedUpdate(
            VoiceLiveUpdateKind kind,
            string eventId,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            VoiceLiveServerEventSessionCreated sessionCreated)
            : base(kind, eventId, additionalBinaryDataProperties)
        {
            _sessionCreated = sessionCreated;
        }

        /// <summary>
        /// Gets the session that was created.
        /// </summary>
        public VoiceLiveResponseSession Session => _sessionCreated?.Session;

        /// <summary>
        /// Gets the session ID.
        /// </summary>
        public string SessionId => Session?.Id;

        /// <summary>
        /// Gets the session object type.
        /// </summary>
        public string SessionObject => Session?.Object;
    }
}