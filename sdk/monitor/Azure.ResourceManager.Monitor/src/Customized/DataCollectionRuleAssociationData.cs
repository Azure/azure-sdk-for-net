// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary>
    /// A class representing the DataCollectionRuleAssociation data model.
    /// Definition of generic ARM proxy resource.
    /// </summary>
    public partial class DataCollectionRuleAssociationData : ResourceData
    {
        /// <summary>
        /// This property has been removed
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MetadataProvisionedBy { get { throw null; } }
    }
}
