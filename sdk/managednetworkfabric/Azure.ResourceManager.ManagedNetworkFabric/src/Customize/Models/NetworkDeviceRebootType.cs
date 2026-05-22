// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct NetworkDeviceRebootType
    {
        /// <summary> RebootType GracefulRebootWithoutZTP. </summary>
        public static NetworkDeviceRebootType GracefulRebootWithoutZtp => GracefulRebootWithoutZTP;

        /// <summary> RebootType GracefulRebootWithZTP. </summary>
        public static NetworkDeviceRebootType GracefulRebootWithZtp => GracefulRebootWithZTP;

        /// <summary> RebootType UngracefulRebootWithoutZTP. </summary>
        public static NetworkDeviceRebootType UngracefulRebootWithoutZtp => UngracefulRebootWithoutZTP;

        /// <summary> RebootType UngracefulRebootWithZTP. </summary>
        public static NetworkDeviceRebootType UngracefulRebootWithZtp => UngracefulRebootWithZTP;
    }
}
