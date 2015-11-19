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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv
{
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class AsvValidatorValidatorClient : IAsvValidatorClient
    {
        public async Task ValidateAccount(string fullAccount, string key)
        {
            try
            {
                var storageAbstractionCreds = new WindowsAzureStorageAccountCredentials() { Key = key, Name = fullAccount };
                var storageAbstraction = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>().Create(storageAbstractionCreds);
                var listContainersUri = new Uri(string.Format("{0}://{1}/", Constants.WabsProtocol, fullAccount));
                await storageAbstraction.List(listContainersUri, false);
            }
            catch (Exception e)
            {
                throw new ConfigurationErrorsException(string.Format(CultureInfo.InvariantCulture,
                                                                     "Validating connection to '{0}' failed. Inner exception:{1}",
                                                                     fullAccount,
                                                                     e.Message),
                                                       e);
            }
        }

        public async Task CreateContainerIfNotExists(string fullAccount, string key, string container)
        {
            try
            {
                var storageAbstractionCreds = new WindowsAzureStorageAccountCredentials() { Key = key, Name = fullAccount };
                var storageAbstraction = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>().Create(storageAbstractionCreds);
                await storageAbstraction.CreateContainerIfNotExists(container);
            }
            catch (Exception e)
            {
                throw new ConfigurationErrorsException(string.Format(CultureInfo.InvariantCulture,
                                                                     "Validating container '{0}' (storage '{1}') failed. Inner exception:{2}",
                                                                     container,
                                                                     fullAccount,
                                                                     e.Message),
                                                       e);
            }
        }
    }
}
