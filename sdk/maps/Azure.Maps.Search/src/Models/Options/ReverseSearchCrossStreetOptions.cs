// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class ReverseSearchCrossStreetOptions: ReverseSearchBaseOptions
    {
        /// <summary> Maximum number of responses that will be returned. Default: 10, minimum: 1 and maximum: 100. </summary>
        public int? Top { get; set; }
    }
}
