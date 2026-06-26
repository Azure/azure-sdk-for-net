// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningFeatureCollectionGetAllOptions
    {
        [WirePath("description")]
        public string Description { get; set; }
        [WirePath("featureName")]
        public string FeatureName { get; set; }
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        [WirePath("skip")]
        public string Skip { get; set; }
        [WirePath("tags")]
        public string Tags { get; set; }
    }
}
