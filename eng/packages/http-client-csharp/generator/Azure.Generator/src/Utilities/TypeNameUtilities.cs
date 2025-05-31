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
        /// Returns the name of the RP from the package name using the following:
        /// If the package name starts with `Azure.ResourceManager`, returns every segment concatenating after the `Azure.ResourceManager` prefix.
        /// If the package name starts with `Azure`, returns every segment concatenating together after the `Azure` prefix.
        /// Returns the package name as the RP name if nothing matches.
        /// </summary>
        public static string GetResourceProviderName()
        {
            var packageName = AzureClientGenerator.Instance.Configuration.PackageName;
            var segments = packageName.Split('.');
            if (packageName.StartsWith(AzurePackageNamespacePrefix))
            {
                if (packageName.StartsWith(AzureMgmtPackageNamespacePrefix))
                {
                    return string.Join("", segments.Skip(2)); // skips "Azure" and "ResourceManager"
                }

                return string.Join("", segments.Skip(1));
            }
            return string.Join("", segments);
        }
    }
}