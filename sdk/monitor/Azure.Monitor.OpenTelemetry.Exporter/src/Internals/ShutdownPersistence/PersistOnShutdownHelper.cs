// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence
{
    internal static class PersistOnShutdownHelper
    {
        /// <summary>
        /// Runs the pipeline's own drain with the transmitter in persist-only mode, so that the
        /// exports triggered by that drain are written to storage rather than transmitted, then
        /// starts a bounded upload of everything now stored.
        /// </summary>
        /// <remarks>
        /// The scope has to be opened here rather than in the exporter because
        /// <c>BaseExportProcessor</c> exports the remaining batch before it shuts the exporter down.
        /// </remarks>
        internal static bool PersistThenDrain(ITransmitter? transmitter, Func<bool> exportRemaining, int timeoutMilliseconds)
        {
            if (transmitter == null)
            {
                return exportRemaining();
            }

            var stopwatch = Stopwatch.StartNew();
            bool result;

            using (transmitter.BeginPersistOnlyScope())
            {
                result = exportRemaining();
            }

            transmitter.DrainStorage(PersistOnShutdownConfig.ResolveDrainWait(GetRemainingMilliseconds(timeoutMilliseconds, stopwatch)));

            return result;
        }

        /// <summary>
        /// Writing to storage consumes part of the caller's budget, so the drain only gets what is
        /// left of it.
        /// </summary>
        private static int GetRemainingMilliseconds(int timeoutMilliseconds, Stopwatch stopwatch)
        {
            if (timeoutMilliseconds < 0)
            {
                return Timeout.Infinite;
            }

            var elapsed = stopwatch.ElapsedMilliseconds;

            return elapsed >= timeoutMilliseconds ? 0 : (int)(timeoutMilliseconds - elapsed);
        }
    }
}
