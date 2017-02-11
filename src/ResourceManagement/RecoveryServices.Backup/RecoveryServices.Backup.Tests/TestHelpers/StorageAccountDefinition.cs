// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class StorageAccountDefinition
    {
        private readonly string saName;
        private readonly string saRg;
        
        public StorageAccountDefinition()
        {
            this.saName = TestSettings.Instance.RestoreStorageAccountName;
            this.saRg = TestSettings.Instance.RestoreStorageAccountResourceGroupName;
        }

        public string StorageAccountName
        {
            get { return saName; }
        }

        public string StorageAccountRg
        {
            get { return saRg; }
        }

        public string GetStorageAccountId(string subscriptionId)
        {
            return string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Storage/storageAccounts/{2}", subscriptionId, saRg, saName);
        }
    }
}
