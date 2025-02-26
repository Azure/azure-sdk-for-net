// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Interface for monitoring CPU usage.
    /// </summary>
    public interface ICpuMonitor
    {
        /// <summary>
        /// Gets the current CPU usage.
        /// </summary>
        float CpuUsage { get; }

        /// <summary>
        /// Gets a value indicating whether the monitor is running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Starts monitoring the CPU usage.
        /// </summary>
        void StartMonitoring();

        /// <summary>
        /// Stops monitoring the CPU usage.
        /// </summary>
        void StopMonitoring();
    }
}
