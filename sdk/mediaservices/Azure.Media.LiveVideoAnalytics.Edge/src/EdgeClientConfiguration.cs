// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//       Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;

namespace Azure.Media.LiveVideoAnalytics.Edge
{
    /// <summary>
    /// Edge client configuration.
    /// </summary>
    public class EdgeClientConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeClientConfiguration"/> class.
        /// </summary>
        /// <param name="deviceId">The device ID.</param>
        /// <param name="moduleId">The module ID.</param>
        public EdgeClientConfiguration(string deviceId, string moduleId)
        {
            DeviceId = deviceId ?? throw new ArgumentNullException(nameof(deviceId));
            ModuleId = moduleId ?? throw new ArgumentNullException(nameof(moduleId));
        }

        /// <summary>
        /// Gets the device ID.
        /// </summary>
        public string DeviceId { get; }

        /// <summary>
        /// Gets the module ID.
        /// </summary>
        public string ModuleId { get; }

        /// <summary>
        /// Gets or sets the response timeout.
        /// </summary>
        /// <remarks>Uses default values when Timespan is set to 0.</remarks>
        public TimeSpan ResponseTimeout { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Gets or sets the connect timeout.
        /// </summary>
        /// <remarks>Uses default values when Timespan is set to 0.</remarks>
        public TimeSpan ConnectTimeout { get; set; } = TimeSpan.Zero;
    }
}
