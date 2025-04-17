// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Client options for device onboarding client
    /// </summary>
    public class DeviceOnboardingClientOptions : ClientOptions
    {
        /// <summary>
        /// The versions of device onboarding api supported by this client
        /// library.
        /// </summary>
        private const ServiceVersion Latest = ServiceVersion.V101;

        /// <summary>
        /// Max ServiceInfo size for TO2
        /// </summary>
        public int MaxServiceInfoSize = 32767;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceOnboardingClientOptions"/> class.
        /// class.
        /// </summary>
        /// <param name="serviceVersion">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public DeviceOnboardingClientOptions(ServiceVersion serviceVersion = Latest)
        {
            VersionString = serviceVersion switch
            {
                ServiceVersion.V101 => "101",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        internal string VersionString { get; }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// FDO version 101
            /// </summary>
            V101 = 101
        }

        internal static DeviceOnboardingClientOptions DefaultOptions => new()
        { };
    }
}
