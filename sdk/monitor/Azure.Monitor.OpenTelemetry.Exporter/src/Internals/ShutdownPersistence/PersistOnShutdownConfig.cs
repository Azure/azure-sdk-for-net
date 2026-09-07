// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
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
        /// Overrides <see cref="DrainBudgetMilliseconds"/>. Settable through <c>AppContext.SetData</c>
        /// or a runtimeconfig.json configProperty.
        /// </summary>
        /// <remarks>
        /// Zero suits a short-lived application: the telemetry is already durable on disk, so exit
        /// costs only the file write and delivery falls to a later run. Raising it cannot guarantee
        /// delivery, because <c>Shutdown()</c> does not wait on the drain at all and <c>Dispose()</c>
        /// is capped by the five second grace period OpenTelemetry gives it. A caller that must not
        /// exit before ingestion answers wants <see cref="DisablePersistOnShutdownSwitchName"/> with
        /// a bounded network timeout instead.
        /// </remarks>
        internal const string DrainBudgetOverrideName = "Azure.Monitor.OpenTelemetry.Exporter.ShutdownDrainBudgetMilliseconds";

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
        /// Network timeout for the Statsbeat exporter. Its meter provider exports once more as it is
        /// disposed, which is on the process exit path, and the pipeline default of 100 seconds would
        /// make an unreachable endpoint stall it. Losing internal telemetry is acceptable; stalling
        /// exit is not. This applies only to Statsbeat, which transmits to its own endpoint and so
        /// gets a transmitter of its own rather than sharing the customer's.
        /// </summary>
        internal static readonly TimeSpan InternalTelemetryNetworkTimeout = TimeSpan.FromSeconds(5);

        internal static bool IsPersistOnShutdownEnabled => !IsSwitchEnabled(DisablePersistOnShutdownSwitchName);

        internal static bool IsPersistOnForceFlushEnabled => IsSwitchEnabled(PersistOnForceFlushSwitchName);

        /// <summary>
        /// Resolves how long to wait on the background drain. <see cref="Timeout.Infinite"/> is what
        /// <c>Shutdown()</c> passes, and blocking process exit on the network is the problem this
        /// design exists to avoid, so it maps to "do not wait".
        /// </summary>
        internal static int ResolveDrainWait(int remainingMilliseconds)
        {
            if (remainingMilliseconds < 0)
            {
                return 0;
            }

            return Math.Min(remainingMilliseconds, GetDrainBudgetMilliseconds());
        }

        /// <summary>
        /// The default is retained so that long-running services keep delivering their final batch
        /// within a graceful shutdown window. <c>Dispose()</c> passes a finite timeout, so without
        /// an override that window is used.
        /// </summary>
        internal static int GetDrainBudgetMilliseconds()
        {
            var configured = AppContext.GetData(DrainBudgetOverrideName);

            switch (configured)
            {
                case int milliseconds when milliseconds >= 0:
                    return milliseconds;

                case string text when int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsed) && parsed >= 0:
                    return parsed;

                default:
                    return DrainBudgetMilliseconds;
            }
        }

        private static bool IsSwitchEnabled(string switchName)
            => AppContext.TryGetSwitch(switchName, out var enabled) && enabled;
    }
}
