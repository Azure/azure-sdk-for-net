// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents an update indicating that an error has occurred.
    /// </summary>
    public sealed class ErrorUpdate : VoiceLiveUpdate
    {
        private readonly VoiceLiveServerEventError _errorEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorUpdate"/> class.
        /// </summary>
        /// <param name="errorEvent">The error event.</param>
        internal ErrorUpdate(VoiceLiveServerEventError errorEvent)
            : base(VoiceLiveUpdateKind.Error)
        {
            Argument.AssertNotNull(errorEvent, nameof(errorEvent));
            _errorEvent = errorEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        /// <param name="errorEvent">The error event.</param>
        internal ErrorUpdate(
            VoiceLiveUpdateKind kind,
            string eventId,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            VoiceLiveServerEventError errorEvent)
            : base(kind, eventId, additionalBinaryDataProperties)
        {
            _errorEvent = errorEvent;
        }

        /// <summary>
        /// Gets the error details.
        /// </summary>
        public Error Error => _errorEvent?.Error;

        /// <summary>
        /// Gets the error type.
        /// </summary>
        public string ErrorType => Error?.Type;

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string ErrorCode => Error?.Code;

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage => Error?.Message;

        /// <summary>
        /// Gets the error parameter, if available.
        /// </summary>
        public string ErrorParam => Error?.Param;

        /// <summary>
        /// Gets the event ID that caused the error, if available.
        /// </summary>
        public string ErrorEventId => Error?.EventId;

        /// <summary>
        /// Returns a string representation of the error.
        /// </summary>
        /// <returns>A string containing the error details.</returns>
        public override string ToString()
        {
            if (Error == null)
                return $"ErrorUpdate: Unknown error";

            var parts = new List<string>();
            
            if (!string.IsNullOrEmpty(ErrorType))
                parts.Add($"Type: {ErrorType}");
            
            if (!string.IsNullOrEmpty(ErrorCode))
                parts.Add($"Code: {ErrorCode}");
            
            if (!string.IsNullOrEmpty(ErrorMessage))
                parts.Add($"Message: {ErrorMessage}");
            
            if (!string.IsNullOrEmpty(ErrorParam))
                parts.Add($"Param: {ErrorParam}");
            
            if (!string.IsNullOrEmpty(ErrorEventId))
                parts.Add($"EventId: {ErrorEventId}");

            return $"ErrorUpdate: {string.Join(", ", parts)}";
        }
    }
}