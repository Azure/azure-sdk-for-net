// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionRuleAssociationData : ResourceData
    {
        /// <summary> Azure offering managing this resource on-behalf-of customer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MetadataProvisionedBy
        {
            get => Metadata?.ProvisionedBy;
        }
    }
}
