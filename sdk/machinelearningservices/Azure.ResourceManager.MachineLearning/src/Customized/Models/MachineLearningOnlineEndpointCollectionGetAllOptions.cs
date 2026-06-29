// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningOnlineEndpointCollectionGetAllOptions
    {
        [WirePath("count")]
        public int? Count { get; set; }
        [WirePath("computeType")]
        public MachineLearningEndpointComputeType? ComputeType { get; set; }
        [WirePath("name")]
        public string Name { get; set; }
        [WirePath("orderBy")]
        public MachineLearningOrderString? OrderBy { get; set; }
        [WirePath("properties")]
        public string Properties { get; set; }
        [WirePath("skip")]
        public string Skip { get; set; }
        [WirePath("tags")]
        public string Tags { get; set; }
    }
}
