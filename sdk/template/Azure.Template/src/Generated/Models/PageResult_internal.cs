// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    /// <summary> Extracted information from a single page. </summary>
    internal partial class PageResult_internal
    {
        /// <summary> Page number. </summary>
        public int Page { get; set; }
        /// <summary> Cluster identifier. </summary>
        public int? ClusterId { get; set; }
        /// <summary> List of key-value pairs extracted from the page. </summary>
        public ICollection<KeyValuePair_internal> KeyValuePairs { get; set; }
        /// <summary> List of data tables extracted from the page. </summary>
        public ICollection<DataTable> Tables { get; set; }
    }
}
