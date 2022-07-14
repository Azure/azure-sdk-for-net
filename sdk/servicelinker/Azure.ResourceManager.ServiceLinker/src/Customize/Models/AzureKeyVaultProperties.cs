// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The resource properties when type is Azure Key Vault. </summary>
    [CodeGenSuppress("AzureKeyVaultProperties", typeof(AzureResourceType), typeof(bool?))]
    public partial class AzureKeyVaultProperties : AzureResourceBaseProperties
    {
        /// <summary> Initializes a new instance of AzureKeyVaultProperties. </summary>
        /// <param name="azureResourceType"> The azure resource type. </param>
        /// <param name="connectAsKubernetesCsiDriver"> True if connect via Kubernetes CSI Driver. </param>
        internal AzureKeyVaultProperties(AzureResourceType azureResourceType, bool? connectAsKubernetesCsiDriver)
        {
            ConnectAsKubernetesCsiDriver = connectAsKubernetesCsiDriver;
            AzureResourceType = azureResourceType;
        }
    }
}
