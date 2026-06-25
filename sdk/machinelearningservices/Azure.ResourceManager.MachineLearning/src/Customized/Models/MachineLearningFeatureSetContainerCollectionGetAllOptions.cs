// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA paging options property shape and WirePath metadata. The current generator no longer emits
    // this options bag directly, and changing the TypeSpec shape would alter the service contract rather than only SDK compatibility.
    public partial class MachineLearningFeatureSetContainerCollectionGetAllOptions
    {
        [WirePath("createdBy")]
        public string CreatedBy { get; set; }
        [WirePath("description")]
        public string Description { get; set; }
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        [WirePath("name")]
        public string Name { get; set; }
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        [WirePath("skip")]
        public string Skip { get; set; }
        [WirePath("tags")]
        public string Tags { get; set; }
    }
}
