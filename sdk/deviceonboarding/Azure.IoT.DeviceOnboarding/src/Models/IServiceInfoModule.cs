// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Interface for Device Service Info Modules
    /// </summary>
    public interface IServiceInfoModule
    {
        /// <summary>
        /// Gets the name of the module
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the module
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets API version string of the module
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Set of Module's supported Keys
        /// </summary>
        public HashSet<ServiceInfoKeys> SupportedKeys { get; }
    }
}
