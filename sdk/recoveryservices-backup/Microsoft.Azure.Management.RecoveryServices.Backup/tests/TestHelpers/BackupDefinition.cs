// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class BackupDefinition
    {
        private readonly VmDefinition vmDefinition;

        private readonly string policyName;

        public BackupDefinition(VmDefinition vmDefinition, string policyName)
        {
            this.vmDefinition = vmDefinition;
            this.policyName = policyName;
        }

        public VmDefinition VmDefinition
        {
            get { return vmDefinition; }
        }

        public string PolicyName
        {
            get { return policyName; }
        }

        public static BackupDefinition TestCrud = new BackupDefinition(
            new VmDefinition(new StorageAccountDefinition()),
            "DefaultPolicy");
    }
}
