// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class AsvValidatorSimulatorClient : IAsvValidatorClient
    {
        public ICollection<StorageAccountCredentials> storageAccoutns;
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "Linq. [TGS]")]
        public AsvValidatorSimulatorClient()
        {
            var defaultAccounts = (from tc in IntegrationTestBase.TestManager.GetAllCredentials()
                                   where tc.IsNotNull() && tc.Environments.IsNotNull()
                                   from e in tc.Environments
                                   where e.IsNotNull() && e.AdditionalStorageAccounts.IsNotNull()
                                   from a in e.AdditionalStorageAccounts
                                   where a.IsNotNull()
                                   select a).ToList();
            var accounts = (from tc in IntegrationTestBase.TestManager.GetAllCredentials()
                            where tc.IsNotNull() && tc.Environments.IsNotNull()
                            from e in tc.Environments
                            where e.IsNotNull() && e.DefaultStorageAccount.IsNotNull()
                           select e.DefaultStorageAccount).ToList();
            accounts.AddRange(defaultAccounts);
            this.storageAccoutns = accounts;
        }

        public Task ValidateAccount(string fullAccount, string key)
        {
            if (!this.storageAccoutns.Any(a => a.Name == fullAccount && a.Key == key))
            {
                throw new ConfigurationErrorsException(string.Format(CultureInfo.InvariantCulture,
                                                                     "Validating connection to '{0}' failed. Inner exception:{1}",
                                                                     fullAccount,
                                                                     "The account does not exist"));
            }
            return Task.Delay(0);
        }

        public async Task CreateContainerIfNotExists(string fullAccount, string key, string container)
        {
            var storageAbstractionCreds = new WindowsAzureStorageAccountCredentials() { Key = key, Name = fullAccount };
            var storageAbstraction = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>().Create(storageAbstractionCreds);
            await storageAbstraction.CreateContainerIfNotExists(container);
            }
        }
    }
