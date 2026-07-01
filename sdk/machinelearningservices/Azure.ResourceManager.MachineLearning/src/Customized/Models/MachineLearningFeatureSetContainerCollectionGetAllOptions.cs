// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA paging options property shape and WirePath metadata. The current generator no longer emits
    // this options bag directly, and changing the TypeSpec shape would alter the service contract rather than only SDK compatibility.
    /// <summary> The options for the corresponding <c>GetAll</c> method. </summary>
    public partial class MachineLearningFeatureSetContainerCollectionGetAllOptions
    {
        /// <summary> The identity that created this entity. </summary>
        [WirePath("createdBy")]
        public string CreatedBy { get; set; }
        /// <summary> The description of this workspace. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> View type for including/excluding (for example) archived entities. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        /// <summary> Gets or sets the Name. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> The page size. </summary>
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Resource tags. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
    }
}
