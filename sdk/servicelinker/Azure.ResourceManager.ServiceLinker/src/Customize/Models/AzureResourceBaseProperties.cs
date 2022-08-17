// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The azure resource properties
    /// Please note <see cref="AzureResourceBaseProperties"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AzureKeyVaultProperties"/>.
    /// </summary>
    public partial class AzureResourceBaseProperties
    {
        /// <summary> Initializes a new instance of AzureResourceBaseProperties. </summary>
        public AzureResourceBaseProperties()
        {
        }
    }
}
