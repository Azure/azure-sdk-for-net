// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Core;

namespace Microsoft.Azure.Management.Fluent.Compute
{
    public enum KnownLinuxVirtualMachineImage
    {
        [EnumName("Canonical UbuntuServer 14.04.4-LTS")]
        UBUNTU_SERVER_14_04_LTS,
        [EnumName("Canonical UbuntuServer 16.04.0-LTS")]
        UBUNTU_SERVER_16_04_LTS,
        [EnumName("credativ Debian 8")]
        DEBIAN_8,
        [EnumName("OpenLogic CentOS 7.2")]
        CENTOS_7_2,
        [EnumName("SUSE openSUSE-Leap 42.1")]
        OPENSUSE_LEAP_42_1,
        [EnumName("SUSE SLES 12-SP1")]
        SLES_12_SP1
    }
}
