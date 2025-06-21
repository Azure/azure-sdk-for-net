// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Base class for Device Service Info Modules Implementation
    /// </summary>
    public abstract class BaseServiceInfoModuleDevice : IServiceInfoModuleDevice
    {
        #region interface IServiceInfoModuleDevice

        /// <inheritdoc/>
        public abstract IServiceInfoModule ServiceModuleContract { get; }

        /// <inheritdoc/>
        public abstract string Name { get; }

        /// <inheritdoc/>
        public abstract string Version { get; }

        /// <inheritdoc/>
        public abstract bool IsActive { get; set; }

        /// <inheritdoc/>
        public abstract bool IsFirstModule { get; }

        /// <inheritdoc/>
        public abstract ServiceInfo GenerateModulesFirstServiceInfo();

        /// <inheritdoc/>
        public abstract ServiceInfo ProcessRequest(ServiceInfoKeyValuePair serviceInfo);

        #endregion

        /// <summary>
        /// Get ServiceInfo Full Name
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        protected string GenerateServiceInfoKey(string keyName)
        {
            return string.Concat(Name, ServiceInfoOrchestrator.ServiceInfoKeyDelimiter, keyName);
        }
    }
}
