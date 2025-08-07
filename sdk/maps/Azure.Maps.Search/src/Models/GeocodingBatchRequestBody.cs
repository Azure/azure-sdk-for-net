// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    internal partial class GeocodingBatchRequestBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeocodingBatchRequestBody"/> class.
        /// </summary>
        /// <param name="batchItems"></param>
        public GeocodingBatchRequestBody(IList<GeocodingBatchRequestItem> batchItems)
        {
            BatchItems = batchItems;
        }
    }
}
