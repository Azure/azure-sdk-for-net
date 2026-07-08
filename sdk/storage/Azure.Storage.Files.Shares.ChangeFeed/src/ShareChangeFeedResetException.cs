// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Thrown by <see cref="ShareChangeFeedClient"/> when a reset marker is discovered on
    /// the change feed and the effective reset policy is
    /// <see cref="ShareChangeFeedResetPolicy.ThrowOnReset"/>.
    /// </summary>
    /// <remarks>
    /// A reset marker signals that log-sequence continuity has been broken (for example, by a
    /// HardFailover or classic account migration). Batched APIs
    /// (<see cref="ShareChangeFeedClient.GetChanges(System.DateTimeOffset?, System.DateTimeOffset?)"/>
    /// and <see cref="ShareChangeFeedClient.GetChangesBetweenSnapshots(string, string)"/>) fail
    /// fast before yielding any events when the requested range crosses a reset boundary; the
    /// streaming <see cref="ShareChangeFeedClient.GetChanges()"/> overloads stop at the reset
    /// boundary. Inspect <see cref="ResetEvent"/> to recover reset context (id, time, account,
    /// share, reason) and drive the appropriate recovery path (typically a full re-baseline).
    /// </remarks>
    public class ShareChangeFeedResetException : Exception
    {
        /// <summary>
        /// The reset marker discovered on the change feed. Never <c>null</c> for exceptions
        /// produced by the SDK; the property is nullable only to support serialization.
        /// </summary>
        public ShareChangeFeedResetEvent ResetEvent { get; }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedResetException"/> around the supplied
        /// reset event, using a generated default message.
        /// </summary>
        /// <param name="resetEvent">The reset event that triggered the exception.</param>
        public ShareChangeFeedResetException(ShareChangeFeedResetEvent resetEvent)
            : base(BuildMessage(resetEvent))
        {
            ResetEvent = resetEvent;
        }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedResetException"/> with a caller-supplied
        /// message.
        /// </summary>
        /// <param name="resetEvent">The reset event that triggered the exception.</param>
        /// <param name="message">A descriptive error message.</param>
        public ShareChangeFeedResetException(ShareChangeFeedResetEvent resetEvent, string message)
            : base(message)
        {
            ResetEvent = resetEvent;
        }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedResetException"/> with a caller-supplied
        /// message and inner exception.
        /// </summary>
        /// <param name="resetEvent">The reset event that triggered the exception.</param>
        /// <param name="message">A descriptive error message.</param>
        /// <param name="innerException">The exception that caused the current exception.</param>
        public ShareChangeFeedResetException(ShareChangeFeedResetEvent resetEvent, string message, Exception innerException)
            : base(message, innerException)
        {
            ResetEvent = resetEvent;
        }

        private static string BuildMessage(ShareChangeFeedResetEvent resetEvent)
        {
            if (resetEvent == null)
            {
                return "A Files Change Feed reset marker was discovered.";
            }

            return $"A Files Change Feed reset marker was discovered at {resetEvent.EventTime:O} " +
                $"(resetId: {resetEvent.ResetId}, reason: {resetEvent.ResetReason ?? "Unknown"}). " +
                "Log-sequence continuity has been broken; the caller must re-baseline before " +
                "resuming change feed consumption.";
        }
    }
}
