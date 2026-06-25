// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningFeatureSetVersionCollectionGetAllOptions
    {
        [WirePath("createdBy")]
        public string CreatedBy { get; set; }
        [WirePath("description")]
        public string Description { get; set; }
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        [WirePath("skip")]
        public string Skip { get; set; }
        [WirePath("stage")]
        public string Stage { get; set; }
        [WirePath("tags")]
        public string Tags { get; set; }
        [WirePath("version")]
        public string Version { get; set; }
        [WirePath("versionName")]
        public string VersionName { get; set; }
    }
}
