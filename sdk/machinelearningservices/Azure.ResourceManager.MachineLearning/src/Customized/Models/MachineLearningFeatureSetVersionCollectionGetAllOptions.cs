// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA paging options property shape and WirePath metadata. The current generator no longer emits
    // this options bag directly, and changing the TypeSpec shape would alter the service contract rather than only SDK compatibility.
    /// <summary> The options for the corresponding <c>GetAll</c> method. </summary>
    public partial class MachineLearningFeatureSetVersionCollectionGetAllOptions
    {
        /// <summary> who this data mount created by. </summary>
        [WirePath("createdBy")]
        public string CreatedBy { get; set; }
        /// <summary> The description of this workspace. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> View type for including/excluding (for example) archived entities. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        /// <summary> page size. </summary>
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Specifies the asset stage. </summary>
        [WirePath("stage")]
        public string Stage { get; set; }
        /// <summary> Resource tags. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> Model version. </summary>
        [WirePath("version")]
        public string Version { get; set; }
        /// <summary> name for the featureset version. </summary>
        [WirePath("versionName")]
        public string VersionName { get; set; }
    }
}
