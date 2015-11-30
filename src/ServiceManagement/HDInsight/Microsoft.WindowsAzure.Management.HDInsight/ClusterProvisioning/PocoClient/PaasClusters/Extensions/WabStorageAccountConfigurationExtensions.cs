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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.PaasClusters.Extensions
{
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;

    internal static class WabStorageAccountConfigurationExtensions
    {
        /// <summary>
        /// An extension method that converts wire WASB container to user facing WabStorageAccountConfiguration type.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>An instance of WabStorageAccountConfiguration.</returns>
        public static WabStorageAccountConfiguration ToWabStorageAccountConfiguration(this BlobContainerCredentialBackedResource resource)
        {
            if (resource != null)
            {
                return new WabStorageAccountConfiguration(resource.AccountDnsName, resource.Key, resource.BlobContainerName);
            }
            return null;
        }
    }
}
