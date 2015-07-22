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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class AsvValidationHelper
    {
        internal static IEnumerable<WabStorageAccountConfiguration> ResolveStorageAccounts(IEnumerable<WabStorageAccountConfiguration> storageAccounts)
        {
            return storageAccounts.Select(ResolveStorageAccount).ToList();
        }

        internal static WabStorageAccountConfiguration ResolveStorageAccount(WabStorageAccountConfiguration storageAccount)
        {
            return new WabStorageAccountConfiguration(
                GetFullyQualifiedStorageAccountName(storageAccount.Name), storageAccount.Key, storageAccount.Container);
        }

        internal static string GetFullyQualifiedStorageAccountName(string accountName)
        {
            // accountName
            if (accountName.IndexOf(".", StringComparison.OrdinalIgnoreCase) == -1)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}.blob.core.windows.net", accountName);
            }

            return accountName;
        }

        /// <summary>
        /// Validates, appends the FQDN suffix if required to storage accounts and creates the default cluster specified in <paramref name="details"/>.
        /// </summary>
        /// <param name="details">The details.</param>
        public static void ValidateAndResolveAsvAccountsAndPrep(ClusterCreateParametersV2 details)
        {
            var defaultStorageAccount = new WabStorageAccountConfiguration(
                details.DefaultStorageAccountName, details.DefaultStorageAccountKey, details.DefaultStorageContainer);
            // Flattens all the configurations into a single list for more uniform validation
            var asvList = ResolveStorageAccounts(details.AdditionalStorageAccounts).ToList();
            asvList.Add(ResolveStorageAccount(defaultStorageAccount));

            // Basic validation on the ASV configurations
            if (string.IsNullOrEmpty(details.DefaultStorageContainer))
            {
                throw new InvalidOperationException("Invalid Container. Default Storage Account Container cannot be null or empty");
            }
            if (asvList.Any(asv => string.IsNullOrEmpty(asv.Name) || string.IsNullOrEmpty(asv.Key)))
            {
                throw new InvalidOperationException("Invalid Azure Configuration. Credentials cannot be null or empty");
            }

            if (asvList.GroupBy(asv => asv.Name).Count(group => group.Count() > 1) > 0)
            {
                throw new InvalidOperationException("Invalid Azure Storage credential. Duplicated values detected");
            }

            // Validates that we can establish the connection to the ASV Names and the default container
            var client = ServiceLocator.Instance.Locate<IAsvValidatorClientFactory>().Create();
            asvList.ForEach(asv => client.ValidateAccount(asv.Name, asv.Key).Wait());

            var resolvedAccounts = ResolveStorageAccounts(details.AdditionalStorageAccounts);
            details.AdditionalStorageAccounts.Clear();
            foreach (var resolvedAccount in resolvedAccounts)
            {
                details.AdditionalStorageAccounts.Add(resolvedAccount);
            }

            var resolvedDefaultStorageAccount = ResolveStorageAccount(defaultStorageAccount);
            details.DefaultStorageAccountName = resolvedDefaultStorageAccount.Name;
            client.CreateContainerIfNotExists(details.DefaultStorageAccountName, details.DefaultStorageAccountKey, details.DefaultStorageContainer).Wait();
        }
    }
}
