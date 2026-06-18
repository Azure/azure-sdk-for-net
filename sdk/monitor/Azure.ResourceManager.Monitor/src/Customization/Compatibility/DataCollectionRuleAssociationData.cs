// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionRuleAssociationData
    {
        /// <summary> Azure offering managing this resource on-behalf-of customer. </summary>
        public string MetadataProvisionedBy => Metadata?.ProvisionedBy;

        /// <summary> Resource Id of azure offering managing this resource on-behalf-of customer. </summary>
        public string MetadataProvisionedByResourceId => Metadata?.ProvisionedByResourceId;
    }
}
