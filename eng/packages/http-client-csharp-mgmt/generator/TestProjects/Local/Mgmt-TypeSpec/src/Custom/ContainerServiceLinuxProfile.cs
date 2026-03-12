// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Generator.MgmtTypeSpec.Tests.Models
{
    public partial class ContainerServiceLinuxProfile
    {
        /// <summary> Initializes a new instance of <see cref="ContainerServiceLinuxProfile"/> from the SSH configuration. </summary>
        /// <param name="adminUsername"> The administrator username to use for Linux VMs. </param>
        /// <param name="ssh"> The SSH configuration for Linux-based VMs running on Azure. </param>
        public ContainerServiceLinuxProfile(string adminUsername, ContainerServiceSshConfiguration ssh)
        {
            Argument.AssertNotNull(adminUsername, nameof(adminUsername));
            Argument.AssertNotNull(ssh, nameof(ssh));

            AdminUsername = adminUsername;
            Ssh = ssh;
        }
    }
}
