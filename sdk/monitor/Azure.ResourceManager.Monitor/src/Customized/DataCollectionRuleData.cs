// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionRuleData : TrackedResourceData
    {
        /// <summary>
        /// This property has been removed
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MetadataProvisionedBy
        {
            get => Metadata?.ProvisionedBy;
        }
    }
}
