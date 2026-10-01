// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Controls how <see cref="ShareChangeFeedClient"/> reacts when a change feed reset marker
    /// is discovered during enumeration.
    /// </summary>
    /// <remarks>
    /// Azure Files emits a reset marker on events such as HardFailover or classic account
    /// migration. A reset breaks log-sequence continuity, so consumers must decide whether to
    /// stop and re-baseline or observe the reset in the ordered stream and continue reading.
    ///
    /// If <see cref="ShareChangeFeedClientOptions.ResetPolicy"/> is <c>null</c>, the client
    /// applies a per-API default:
    /// <list type="bullet">
    ///   <item>
    ///     <description>
    ///     Batched APIs (<see cref="ShareChangeFeedClient.GetChanges(System.DateTimeOffset?, System.DateTimeOffset?)"/>,
    ///     <see cref="ShareChangeFeedClient.GetChangesBetweenSnapshots(string, string)"/>, and their
    ///     continuation-token / async counterparts) default to <see cref="ThrowOnReset"/> so
    ///     correctness-sensitive consumers fail fast when a reset falls inside the requested range.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///     Streaming APIs (<see cref="ShareChangeFeedClient.GetChanges()"/> and
    ///     <see cref="ShareChangeFeedClient.GetChanges(string)"/> plus their async counterparts)
    ///     default to <see cref="ContinueOnReset"/> so consumers receive the reset event in-band
    ///     at its ordered position.
    ///     </description>
    ///   </item>
    /// </list>
    /// Explicitly setting <see cref="ShareChangeFeedClientOptions.ResetPolicy"/> overrides the
    /// per-API default for every method on the client.
    /// </remarks>
    public enum ShareChangeFeedResetPolicy
    {
        /// <summary>
        /// When a reset marker is detected, throw <see cref="ShareChangeFeedResetException"/>.
        /// Batched APIs fail before yielding any events when the requested range crosses a reset
        /// boundary; streaming APIs stop at the reset boundary.
        /// </summary>
        ThrowOnReset = 0,

        /// <summary>
        /// When a reset marker is detected, surface it in-band as a
        /// <see cref="ShareChangeFeedResetEvent"/> at its position in the ordered stream and
        /// continue enumeration. Consumers must decide whether to stop, re-baseline, or keep
        /// reading past the marker.
        /// </summary>
        ContinueOnReset = 1,
    }
}
