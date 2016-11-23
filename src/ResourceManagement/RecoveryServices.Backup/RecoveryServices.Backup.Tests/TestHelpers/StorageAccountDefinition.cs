//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
