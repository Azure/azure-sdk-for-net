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
        public ContainerServiceLinuxProfile(string adminUsername, ContainerServiceSshConfiguration ssh)     // Add this constructor for backward compatibility, as previous versions of the SDK had a constructor with these parameters.
        {
            Argument.AssertNotNull(adminUsername, nameof(adminUsername));
            Argument.AssertNotNull(ssh, nameof(ssh));

            AdminUsername = adminUsername;
            Ssh = ssh;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerServiceLinuxProfile"/>. </summary>
        /// <param name="adminUsername"> The administrator username to use for Linux VMs. </param>
        /// <param name="sshPublicKeys"> The list of SSH public keys used to authenticate with Linux-based VMs. A maximum of 1 key may be specified. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="adminUsername"/> or <paramref name="sshPublicKeys"/> is null. </exception>
        public ContainerServiceLinuxProfile(string adminUsername, IList<ContainerServiceSshPublicKey> sshPublicKeys)    // Add this constructor for a MTG bug https://github.com/microsoft/typespec/issues/9331, will be removed in the future after the bug is fixed.
        {
            Argument.AssertNotNull(adminUsername, nameof(adminUsername));
            Argument.AssertNotNull(sshPublicKeys, nameof(sshPublicKeys));

            AdminUsername = adminUsername;
            Ssh = new ContainerServiceSshConfiguration(sshPublicKeys);
        }

        /// <summary> The list of SSH public keys used to authenticate with Linux-based VMs. A maximum of 1 key may be specified. </summary>
        [WirePath("ssh.publicKeys")]
        public IList<ContainerServiceSshPublicKey> SshPublicKeys    // Add setter for SshPublicKeys for backward compatibility.
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
