// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Client for device onboarding
    /// </summary>
    public class DeviceOnboardingClient
    {
        /// <summary>
        /// Consumer provided implementation for CBOR conversion
        /// </summary>
        protected CBORConverterProvider _CBORConverterProvider;

        /// <summary>
        /// Consumer provided implementation for managing device credentials
        /// </summary>
        protected DeviceCredentialProvider _deviceCredentialProvider;

        /// <summary>
        /// Client options
        /// </summary>
        protected DeviceOnboardingClientOptions options;

        #region Constructors
        /// <summary>
        /// Constructor for mocking DeviceOnboardingClient
        /// </summary>
        protected DeviceOnboardingClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceOnboardingClient"/> class.
        /// </summary>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        public DeviceOnboardingClient(CBORConverterProvider cborConverter, DeviceCredentialProvider credProvider)
        {
            this._CBORConverterProvider = cborConverter;
            this._deviceCredentialProvider = credProvider;
            this.options = new DeviceOnboardingClientOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceOnboardingClient"/> class.
        /// </summary>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        /// <param name="options"></param>
        public DeviceOnboardingClient(CBORConverterProvider cborConverter, DeviceCredentialProvider credProvider, DeviceOnboardingClientOptions options)
        {
            this._CBORConverterProvider = cborConverter;
            this._deviceCredentialProvider = credProvider;
            this.options = options;
        }
        #endregion region

        /// <summary>
        /// Get device initializer client
        /// </summary>
        /// <param name="ov"></param>
        /// <returns></returns>
        public DeviceInitializer GetDeviceInitializer(OwnershipVoucher ov = null)
        {
            return new DeviceInitializer(ov, _CBORConverterProvider, _deviceCredentialProvider, options);
        }
        /// <summary>
        /// Get device discovery client
        /// </summary>
        /// <param name="rvServerUrl"></param>
        /// <returns></returns>
        public DeviceDiscoverer GetDeviceDiscoverer(string rvServerUrl)
        {
            return new DeviceDiscoverer(rvServerUrl, _CBORConverterProvider, _deviceCredentialProvider, options);
        }

        /// <summary>
        /// Get device provisioning client
        /// </summary>
        /// <param name="ownerServerUrl"></param>
        /// <param name="ownerInfo"></param>
        /// <param name="registeredModules"></param>
        /// <returns></returns>
        public DeviceProvisioner GetDeviceProvisioner(string ownerServerUrl, TO2OwnerInfo ownerInfo, Dictionary<string, BaseServiceInfoModuleDevice> registeredModules)
        {
            return new DeviceProvisioner(ownerServerUrl, ownerInfo, registeredModules, _CBORConverterProvider, _deviceCredentialProvider, options);
        }
    }
}
