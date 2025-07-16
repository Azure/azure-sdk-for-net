// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using System.Linq;

namespace Azure.Generator.Visitors.Utilities
{
    internal static class TypeNameUtilities
    {
        private const string AzurePackageNamespacePrefix = "Azure.";
        private const string AzureResourceManagerPackageNamespacePrefix = "Azure.ResourceManager.";

        public static string GetResourceProviderName()
        {
            var packageName = CodeModelGenerator.Instance.Configuration.PackageName;
            var segments = packageName.Split('.');
            if (packageName.StartsWith(AzureResourceManagerPackageNamespacePrefix))
            {
                return $"Arm{string.Join("", segments.Skip(2))}";
            }
            if (packageName.StartsWith(AzurePackageNamespacePrefix))
            {
                if (segments.Length > 2)
                {
                    // skips "Azure" and the following segment
                    return string.Join("", segments.Skip(2));
                }

                return string.Join("", segments.Skip(1));
            }
            return string.Join("", segments);
        }
    }
}