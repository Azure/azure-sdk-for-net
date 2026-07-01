// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The options for the corresponding <c>GetAll</c> method. </summary>
    public partial class MachineLearningFeatureCollectionGetAllOptions
    {
        /// <summary> The description of this workspace. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> Inference FeatureName name. </summary>
        [WirePath("featureName")]
        public string FeatureName { get; set; }
        /// <summary> View type for including/excluding (for example) archived entities. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
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
