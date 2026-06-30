// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionRuleData
    {
        /// <summary> Azure offering managing this resource on-behalf-of customer. </summary>
        public string MetadataProvisionedBy => Metadata?.ProvisionedBy;

        /// <summary> Resource Id of azure offering managing this resource on-behalf-of customer. </summary>
        public ResourceIdentifier MetadataProvisionedByResourceId => Metadata?.ProvisionedByResourceId is null ? null : new ResourceIdentifier(Metadata.ProvisionedByResourceId);
    }
}
