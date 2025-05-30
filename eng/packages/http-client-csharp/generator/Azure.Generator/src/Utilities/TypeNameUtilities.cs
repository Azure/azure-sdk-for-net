// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;

namespace Azure.Generator.Utilities
{
    internal static class TypeNameUtilities
    {
        private const string AzurePackageNamespacePrefix = "Azure.";
        private const string AzureMgmtPackageNamespacePrefix = "Azure.ResourceManager.";

        /// <summary>
        /// Returns the name of the RP from the namespace by the following rule:
        /// If the namespace starts with `Azure.ResourceManager` and it is a management plane package, returns every segment concatenating after the `Azure.ResourceManager` prefix.
        /// If the namespace starts with `Azure`, returns every segment concatenating together after the `Azure` prefix
        /// Returns the namespace as the RP name if nothing matches.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <returns></returns>
        public static string GetResourceProviderName(string namespaceName)
        {
            var segments = namespaceName.Split('.');
            if (namespaceName.StartsWith(AzurePackageNamespacePrefix))
            {
                if (namespaceName.StartsWith(AzureMgmtPackageNamespacePrefix))
                {
                    return string.Join("", segments.Skip(2)); // skips "Azure" and "ResourceManager"
                }

                return string.Join("", segments.Skip(1));
            }
            return string.Join("", segments);
        }
    }
}