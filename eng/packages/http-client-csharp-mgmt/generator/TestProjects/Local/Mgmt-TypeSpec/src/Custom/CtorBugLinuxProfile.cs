// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Generator.MgmtTypeSpec.Tests.Models
{
    public partial class CtorBugLinuxProfile
    {
        /// <summary> Initializes the profile with an SSH configuration. </summary>
        /// <param name="adminUsername"> The administrator username. </param>
        /// <param name="ssh"> The SSH configuration. </param>
        public CtorBugLinuxProfile(string adminUsername, CtorBugSshConfiguration ssh)
        {
            AdminUsername = adminUsername ?? throw new ArgumentNullException(nameof(adminUsername));
            Ssh = ssh ?? throw new ArgumentNullException(nameof(ssh));
        }
    }
}
