// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The options for the corresponding <c>GetAll</c> method. </summary>
    public partial class MachineLearningModelVersionCollectionGetAllOptions
    {
        /// <summary> The description of this workspace. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> Name of the feed. </summary>
        [WirePath("feed")]
        public string Feed { get; set; }
        /// <summary> View type for including/excluding (for example) archived entities. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        /// <summary> Number of initial results to skip. </summary>
        [WirePath("offset")]
        public int? Offset { get; set; }
        /// <summary> Ordering of list. </summary>
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        /// <summary> [Required] Additional attributes of the entity. </summary>
        [WirePath("properties")]
        public string Properties { get; set; }
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Resource tags. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> The number of top features to include. </summary>
        [WirePath("top")]
        public int? Top { get; set; }
        /// <summary> Model version. </summary>
        [WirePath("version")]
        public string Version { get; set; }
    }
}
