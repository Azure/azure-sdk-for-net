// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Workloads.Models
{
    /// <summary> Gets or sets the HA software configuration. </summary>
    public partial class HighAvailabilitySoftwareConfiguration
    {
        /// <summary> Initializes a new instance of HighAvailabilitySoftwareConfiguration. </summary>
        /// <param name="fencingClientId"> The fencing client id. </param>
        /// <param name="fencingClientPassword"> The fencing client id secret/password. The secret should never expire. This will be used pacemaker to start/stop the cluster VMs. </param>
        /// <param name="isResponse"> The flag that indicates if the instantiation of <see cref="HighAvailabilitySoftwareConfiguration"/> comes from the response deserialization. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fencingClientId"/> or <paramref name="fencingClientPassword"/> is null. </exception>
        internal HighAvailabilitySoftwareConfiguration(string fencingClientId, string fencingClientPassword, bool isResponse)
        {
            if (fencingClientId == null)
            {
                throw new ArgumentNullException(nameof(fencingClientId));
            }
            if (!isResponse && fencingClientPassword == null)
            {
                throw new ArgumentNullException(nameof(fencingClientPassword));
            }

            FencingClientId = fencingClientId;
            FencingClientPassword = fencingClientPassword;
        }
    }
}
