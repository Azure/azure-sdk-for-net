// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// This attribute should be set on all client assemblies with value of one of the resource providers
    /// from the https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/azure-services-resource-providers list.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    internal class AzureResourceProviderNamespaceAttribute : Attribute
    {
        public string ResourceProviderNamespace { get; }

        public AzureResourceProviderNamespaceAttribute(string resourceProviderNamespace)
        {
            ResourceProviderNamespace = resourceProviderNamespace;
        }
    }
}