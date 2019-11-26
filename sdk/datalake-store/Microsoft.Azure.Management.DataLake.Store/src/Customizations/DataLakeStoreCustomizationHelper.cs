// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.DataLake.Store
{
    internal static class DataLakeStoreCustomizationHelper
    {
        /// <summary>
        /// This constant is used as the default package version to place in the user agent.
        /// It should mirror the package version in the project.json file.
        /// </summary>
        internal const string PackageVersion = "2.4.1-preview";

        internal const string DefaultAdlsFileSystemDnsSuffix = "azuredatalakestore.net";

        /// <summary>
        /// Get the assembly version of a service client.
        /// </summary>
        /// <returns>The assembly version of the client.</returns>        
        internal static void UpdateUserAgentAssemblyVersion(IAzureClient clientToUpdate, string assemblyVersionToUse)
        {
            var type = clientToUpdate.GetType();

            var newVersion = string.IsNullOrEmpty(assemblyVersionToUse) ? 
                PackageVersion : assemblyVersionToUse;

            foreach (
                var info in
                    clientToUpdate.HttpClient.DefaultRequestHeaders.UserAgent.Where(
                        info => info.Product.Name.Equals(type.FullName, StringComparison.OrdinalIgnoreCase)))
            {
                clientToUpdate.HttpClient.DefaultRequestHeaders.UserAgent.Remove(info);
                clientToUpdate.HttpClient.DefaultRequestHeaders.UserAgent.Add(
                    new System.Net.Http.Headers.ProductInfoHeaderValue(type.FullName, newVersion));
                break;
            }

        }
    }
}
