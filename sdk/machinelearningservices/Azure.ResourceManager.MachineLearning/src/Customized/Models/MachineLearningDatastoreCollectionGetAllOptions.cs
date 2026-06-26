// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningDatastoreCollectionGetAllOptions
    {
        [WirePath("count")]
        public int? Count { get; set; }
        [WirePath("isDefault")]
        public bool? IsDefault { get; set; }
        [WirePath("names")]
        public IList<string> Names { get; } = new List<string>();
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        [WirePath("orderByAsc")]
        public bool? OrderByAsc { get; set; }
        [WirePath("searchText")]
        public string SearchText { get; set; }
        [WirePath("skip")]
        public string Skip { get; set; }
    }
}
