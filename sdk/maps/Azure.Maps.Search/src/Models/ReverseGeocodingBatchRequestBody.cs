// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    internal partial class ReverseGeocodingBatchRequestBody
    {
        /// <summary> Initializes a new instance of <see cref="ReverseGeocodingBatchRequestBody"/>. </summary>
        /// <param name="batchItems"> The list of queries to process. </param>
        public ReverseGeocodingBatchRequestBody(IList<ReverseGeocodingBatchRequestItem> batchItems)
        {
            BatchItems = batchItems;
        }
    }
}
