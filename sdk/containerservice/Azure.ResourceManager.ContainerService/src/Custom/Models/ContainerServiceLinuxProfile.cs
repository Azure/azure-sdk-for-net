// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ContainerServiceLinuxProfile
    {
        /// <summary> Initializes a new instance of <see cref="ContainerServiceLinuxProfile"/>. </summary>
        /// <param name="adminUsername">
        /// The administrator username to use for Linux VMs.
        /// Serialized Name: ContainerServiceLinuxProfile.adminUsername
        /// </param>
        /// <param name="ssh">
        /// The SSH configuration for Linux-based VMs running on Azure.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="adminUsername"/> or <paramref name="ssh"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerServiceLinuxProfile(string adminUsername, ContainerServiceSshConfiguration ssh)
        {
            Argument.AssertNotNull(adminUsername, nameof(adminUsername));
            Argument.AssertNotNull(ssh, nameof(ssh));

            AdminUsername = adminUsername;
            Ssh = ssh;
        }

        /// <summary> The list of SSH public keys used to authenticate with Linux-based VMs. A maximum of 1 key may be specified. </summary>
        [WirePath("ssh.publicKeys")]
        public IList<ContainerServiceSshPublicKey> SshPublicKeys
        {
            get
            {
                if (Ssh is null)
                {
                    Ssh = new ContainerServiceSshConfiguration();
                }
                return Ssh.PublicKeys;
            }
            set
            {
                if (Ssh is null)
                {
                    Ssh = new ContainerServiceSshConfiguration();
                }
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                Ssh.PublicKeys.Clear();
                foreach (ContainerServiceSshPublicKey item in value)
                {
                    Ssh.PublicKeys.Add(item);
                }
            }
        }
    }
}
