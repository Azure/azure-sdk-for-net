// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The options for the corresponding <c>GetAll</c> method. </summary>
    public partial class MachineLearningOnlineEndpointCollectionGetAllOptions
    {
        /// <summary> Gets the Count. </summary>
        [WirePath("count")]
        public int? Count { get; set; }
        /// <summary> The type of compute. </summary>
        [WirePath("computeType")]
        public MachineLearningEndpointComputeType? ComputeType { get; set; }
        /// <summary> Gets or sets the Name. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> Ordering of list. </summary>
        [WirePath("orderBy")]
        public MachineLearningOrderString? OrderBy { get; set; }
        /// <summary> [Required] Additional attributes of the entity. </summary>
        [WirePath("properties")]
        public string Properties { get; set; }
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Resource tags. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
    }
}
