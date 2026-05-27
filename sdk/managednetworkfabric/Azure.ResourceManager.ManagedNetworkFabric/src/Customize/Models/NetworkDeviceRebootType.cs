// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct NetworkDeviceRebootType
    {
        // The TypeSpec generator does not emit public constants for these service-defined ZTP reboot values.
        // Removing these shims would drop the shipped reboot-type members and break callers compiled against the GA SDK.

        /// <summary> RebootType GracefulRebootWithoutZTP. </summary>
        public static NetworkDeviceRebootType GracefulRebootWithoutZtp => new NetworkDeviceRebootType("GracefulRebootWithoutZTP");

        /// <summary> RebootType GracefulRebootWithZTP. </summary>
        public static NetworkDeviceRebootType GracefulRebootWithZtp => new NetworkDeviceRebootType("GracefulRebootWithZTP");

        /// <summary> RebootType UngracefulRebootWithoutZTP. </summary>
        public static NetworkDeviceRebootType UngracefulRebootWithoutZtp => new NetworkDeviceRebootType("UngracefulRebootWithoutZTP");

        /// <summary> RebootType UngracefulRebootWithZTP. </summary>
        public static NetworkDeviceRebootType UngracefulRebootWithZtp => new NetworkDeviceRebootType("UngracefulRebootWithZTP");
    }
}
