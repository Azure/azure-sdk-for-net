// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable disable

using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionRuleData : TrackedResourceData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MetadataProvisionedBy
        {
            get => Metadata?.ProvisionedBy;
        }
    }
}
