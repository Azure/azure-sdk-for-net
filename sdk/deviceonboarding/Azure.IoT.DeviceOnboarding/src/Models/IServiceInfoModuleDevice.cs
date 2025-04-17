// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Interface for Device Service Info Modules Implementation
    /// </summary>
    public interface IServiceInfoModuleDevice
    {
        /// <summary>
        /// Gets the Service Module Contract
        /// </summary>
        public IServiceInfoModule ServiceModuleContract { get; }

        /// <summary>
        /// Gets the Name of the module
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the Version of the module
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets or Sets the status of the module
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Determines if this is the First Module in Service Info Exchange
        /// </summary>
        public bool IsFirstModule { get; }

        /// <summary>
        /// Process the incoming Service Info Request
        /// </summary>
        /// <param name="serviceInfo"></param>
        /// <returns></returns>
        public ServiceInfo ProcessRequest(ServiceInfoKeyValuePair serviceInfo);

        /// <summary>
        /// Generate and Return the first ServiceInfo of the message
        /// This is implemented by the First Module
        /// </summary>
        /// <returns></returns>
        public ServiceInfo GenerateModulesFirstServiceInfo();
    }
}
