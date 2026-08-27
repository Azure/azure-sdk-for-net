// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence
{
    /// <summary>
    /// Controls the "write to persistent storage, then upload out-of-band" behavior used when a
    /// provider shuts down. Short-lived processes exit before an ingestion round trip can complete,
    /// so the exit path persists telemetry and leaves delivery to a background drain in this or a
    /// subsequent process.
    /// </summary>
    internal static class PersistOnShutdownConfig
    {
        /// <summary>
        /// Opts in to applying persist-only behavior to ForceFlush in addition to shutdown. Off by
        /// default because callers that flush per-invocation generally expect delivery, not durability.
        /// </summary>
        internal const string PersistOnForceFlushSwitchName = "Azure.Monitor.OpenTelemetry.Exporter.PersistOnForceFlush";

        /// <summary>
        /// Reverts shutdown to the legacy blocking transmission.
        /// </summary>
        internal const string DisablePersistOnShutdownSwitchName = "Azure.Monitor.OpenTelemetry.Exporter.DisablePersistOnShutdown";

        /// <summary>
        /// Upper bound on how long shutdown waits for the background drain. The telemetry is already
        /// durable on disk at this point, so this may resolve to zero without data loss.
        /// </summary>
        internal const int DrainBudgetMilliseconds = 2000;

        /// <summary>
        /// Upper bound for the transmission attempted when persistent storage is unavailable. This is
        /// the one path where the request itself is the durability, so it must never resolve to zero.
        /// </summary>
        internal const int FallbackPostBudgetMilliseconds = 3000;

        /// <summary>
        /// Network timeout for the internal telemetry exporters (Statsbeat, customer SDK stats).
        /// Their meter providers export once more as they are disposed, which is on the process exit
        /// path, and the pipeline default of 100 seconds would make an unreachable endpoint stall it.
        /// Losing internal telemetry is acceptable; stalling exit is not.
        /// </summary>
        internal static readonly TimeSpan InternalTelemetryNetworkTimeout = TimeSpan.FromSeconds(5);

        internal static bool IsPersistOnShutdownEnabled => !IsSwitchEnabled(DisablePersistOnShutdownSwitchName);

        internal static bool IsPersistOnForceFlushEnabled => IsSwitchEnabled(PersistOnForceFlushSwitchName);

        /// <summary>
        /// Resolves how long to wait on the background drain. <see cref="Timeout.Infinite"/> is what
        /// <c>Dispose()</c> passes, and blocking process exit on the network is the problem this
        /// design exists to avoid, so it maps to "do not wait".
        /// </summary>
        internal static int ResolveDrainWait(int remainingMilliseconds)
        {
            if (remainingMilliseconds < 0)
            {
                return 0;
            }

            return Math.Min(remainingMilliseconds, DrainBudgetMilliseconds);
        }

        private static bool IsSwitchEnabled(string switchName)
            => AppContext.TryGetSwitch(switchName, out var enabled) && enabled;
    }
}
