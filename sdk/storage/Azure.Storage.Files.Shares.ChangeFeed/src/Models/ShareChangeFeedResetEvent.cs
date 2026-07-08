// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// A specialized <see cref="ShareChangeFeedEvent"/> that represents an Azure Files
    /// Change Feed reset marker. Reset markers are emitted by the service on events such as
    /// HardFailover or classic account migration. When observed, log-sequence continuity has
    /// been broken from this point onward and consumers must decide whether to stop,
    /// re-baseline, or continue reading past the marker.
    /// </summary>
    /// <remarks>
    /// A reset event is surfaced in-band on <see cref="ShareChangeFeedClient.GetChanges()"/>
    /// enumerations (default <see cref="ShareChangeFeedResetPolicy.ContinueOnReset"/>) at its
    /// ordered position in the stream, or via <see cref="ShareChangeFeedResetException.ResetEvent"/>
    /// when the client is configured with <see cref="ShareChangeFeedResetPolicy.ThrowOnReset"/>.
    /// The base <see cref="ShareChangeFeedEvent.Reason"/> is always
    /// <see cref="ShareChangeFeedReasonType.Reset"/>; the base <see cref="ShareChangeFeedEvent.Id"/>
    /// holds the reset event GUID as its string form; the base
    /// <see cref="ShareChangeFeedEvent.EventTime"/> holds the reset time.
    /// </remarks>
    public class ShareChangeFeedResetEvent : ShareChangeFeedEvent
    {
        /// <summary>
        /// Server-generated GUID identifying this reset event. Matches the
        /// <c>resetId</c> field in the per-event marker JSON.
        /// </summary>
        public Guid ResetId { get; internal set; }

        /// <summary>
        /// Windows FILETIME ticks (100 ns since 1601 UTC) at which the reset was emitted.
        /// Monotonic per stamp and also encoded into the per-event blob key.
        /// </summary>
        public long ResetFileTime { get; internal set; }

        /// <summary>
        /// Unversioned account name recorded on the reset event.
        /// </summary>
        public string AccountName { get; internal set; }

        /// <summary>
        /// Unversioned share (container) name recorded on the reset event.
        /// </summary>
        public string ContainerName { get; internal set; }

        /// <summary>
        /// Verbatim, human-readable cause of the reset (for example,
        /// "Customer-managed unplanned failover" or "Tracking State Reset"). This is the free-form
        /// <c>reason</c> field from the reset marker JSON; it is exposed here under a distinct
        /// name to avoid shadowing the inherited <see cref="ShareChangeFeedEvent.Reason"/> property
        /// (which is the strongly-typed <see cref="ShareChangeFeedReasonType"/> and is always
        /// <see cref="ShareChangeFeedReasonType.Reset"/> for a reset event).
        /// </summary>
        public string ResetReason { get; internal set; }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedResetEvent"/> from a pointer plus its
        /// per-event marker.
        /// </summary>
        /// <param name="pointer">The parsed <c>meta/reset-latest.json</c> pointer.</param>
        /// <param name="perEvent">The parsed <c>meta/resets/&lt;FILETIME&gt;.json</c> per-event blob.</param>
        internal ShareChangeFeedResetEvent(
            ShareChangeFeedResetPointer pointer,
            ShareChangeFeedResetMarker perEvent)
        {
            if (pointer == null)
                throw new ArgumentNullException(nameof(pointer));
            if (perEvent == null)
                throw new ArgumentNullException(nameof(perEvent));

            // Populate base ShareChangeFeedEvent fields so the reset event flows through the
            // ordered stream indistinguishably from a normal event, except for Reason and the
            // reset-specific properties below.
            SchemaVersion = perEvent.SchemaVersion;
            Reason = ShareChangeFeedReasonType.Reset;
            // Reset markers are not tied to a wire protocol (SMB/REST); leave Protocol at default.
            EventTime = perEvent.ResetTimeUtc;
            Id = perEvent.ResetId.ToString();
            // Reset events are not associated with a container version number.
            ContainerVersionNumber = 0;
            EventData = null;

            ResetId = perEvent.ResetId;
            ResetFileTime = perEvent.ResetFileTime;
            AccountName = perEvent.AccountName;
            ContainerName = perEvent.ContainerName;
            ResetReason = perEvent.Reason;
        }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedResetEvent"/> for mocking purposes.
        /// </summary>
        internal ShareChangeFeedResetEvent()
        {
            Reason = ShareChangeFeedReasonType.Reset;
        }

        /// <summary>
        /// Returns a human-readable string summarizing the reset event.
        /// </summary>
        public override string ToString()
            => $"{EventTime}: Reset ({ResetReason ?? "Unknown"}) {AccountName}/{ContainerName} [{ResetId}]";
    }
}
