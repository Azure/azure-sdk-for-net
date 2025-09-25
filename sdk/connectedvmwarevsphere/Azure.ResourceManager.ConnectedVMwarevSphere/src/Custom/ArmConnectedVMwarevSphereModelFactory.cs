// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Models
{
    public static partial class ArmConnectedVMwarevSphereModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.OSProfileForVmInstance"/>. </summary>
        /// <param name="computerName"> Gets or sets computer name. </param>
        /// <param name="adminUsername"> Gets or sets administrator username. </param>
        /// <param name="adminPassword"> Sets administrator password. </param>
        /// <param name="guestId"> Gets or sets the guestId. </param>
        /// <param name="osType"> Gets or sets the type of the os. </param>
        /// <param name="osSku"> Gets or sets os sku. </param>
        /// <param name="toolsRunningStatus"> Gets or sets the current running status of VMware Tools running in the guest operating system. </param>
        /// <param name="toolsVersionStatus"> Gets or sets the current version status of VMware Tools installed in the guest operating system. </param>
        /// <param name="toolsVersion"> Gets or sets the current version of VMware Tools. </param>
        /// <param name="windowsConfiguration"> Windows Configuration. </param>
        /// <returns> A new <see cref="Models.OSProfileForVmInstance"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSProfileForVmInstance OSProfileForVmInstance(string computerName, string adminUsername, string adminPassword, string guestId, VMwareOSType? osType, string osSku, string toolsRunningStatus, string toolsVersionStatus, string toolsVersion, VMwareVmWindowsConfiguration windowsConfiguration)
        {
            return OSProfileForVmInstance(computerName, adminUsername, adminPassword, guestId, osType, osSku, toolsRunningStatus, toolsVersionStatus, toolsVersion, windowsConfiguration, linuxConfiguration: default, cloudInitConfiguration: default);
        }

        /// <summary> Initializes a new instance of OSProfileForVmInstance. </summary>
        /// <param name="computerName"> Gets or sets computer name. </param>
        /// <param name="adminUsername"> Gets or sets administrator username. </param>
        /// <param name="adminPassword"> Sets administrator password. </param>
        /// <param name="guestId"> Gets or sets the guestId. </param>
        /// <param name="osType"> Gets or sets the type of the os. </param>
        /// <param name="osSku"> Gets or sets os sku. </param>
        /// <param name="toolsRunningStatus"> Gets or sets the current running status of VMware Tools running in the guest operating system. </param>
        /// <param name="toolsVersionStatus"> Gets or sets the current version status of VMware Tools installed in the guest operating system. </param>
        /// <param name="toolsVersion"> Gets or sets the current version of VMware Tools. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.ConnectedVMwarevSphere.Models.OSProfileForVmInstance" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSProfileForVmInstance OSProfileForVmInstance(string computerName, string adminUsername, string adminPassword, string guestId, VMwareOSType? osType, string osSku, string toolsRunningStatus, string toolsVersionStatus, string toolsVersion)
        {
            return OSProfileForVmInstance(computerName, adminUsername, adminPassword, guestId, osType, osSku, toolsRunningStatus, toolsVersionStatus, toolsVersion, windowsConfiguration: default);
        }
    }
}
