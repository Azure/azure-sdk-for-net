// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningRegistryModelVersionCollectionGetAllOptions
    {
        [WirePath("description")]
        public string Description { get; set; }
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        [WirePath("properties")]
        public string Properties { get; set; }
        [WirePath("skip")]
        public string Skip { get; set; }
        [WirePath("tags")]
        public string Tags { get; set; }
        [WirePath("top")]
        public int? Top { get; set; }
        [WirePath("version")]
        public string Version { get; set; }
    }
}
