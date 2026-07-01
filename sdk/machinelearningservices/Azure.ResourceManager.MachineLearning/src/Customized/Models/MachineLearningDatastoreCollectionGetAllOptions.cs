// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The options for the corresponding <c>GetAll</c> method. </summary>
    public partial class MachineLearningDatastoreCollectionGetAllOptions
    {
        /// <summary> Gets the Count. </summary>
        [WirePath("count")]
        public int? Count { get; set; }
        /// <summary> Readonly property to indicate if datastore is the workspace default datastore. </summary>
        [WirePath("isDefault")]
        public bool? IsDefault { get; set; }
        /// <summary> Names of datastores to return. </summary>
        [WirePath("names")]
        public IList<string> Names { get; } = new List<string>();
        /// <summary> Ordering of list. </summary>
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        /// <summary> Order by property in ascending order. </summary>
        [WirePath("orderByAsc")]
        public bool? OrderByAsc { get; set; }
        /// <summary> Text to search for in the datastore names. </summary>
        [WirePath("searchText")]
        public string SearchText { get; set; }
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
    }
}
