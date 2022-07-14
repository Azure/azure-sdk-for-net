// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The azure resource properties
    /// Please note <see cref="AzureResourceBaseProperties"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AzureKeyVaultProperties"/>.
    /// </summary>
    [CodeGenSuppress("AzureResourceBaseProperties")]
    [CodeGenSuppress("AzureResourceBaseProperties", typeof(AzureResourceType))]
    public abstract partial class AzureResourceBaseProperties
    {
        /// <summary> The azure resource type. </summary>
        internal AzureResourceType AzureResourceType { get; set; }
    }
}
