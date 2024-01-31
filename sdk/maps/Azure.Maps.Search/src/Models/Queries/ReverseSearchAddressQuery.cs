// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Search
{
    /// <summary> Initializes a new instance of ReverseSearchAddressQuery. </summary>
    public class ReverseSearchAddressQuery
    {
        /// <summary> Reverse search address options </summary>
        public ReverseSearchOptions ReverseSearchAddressOptions { get; }

        /// <summary> Initializes a new instance of ReverseSearchAddressQuery. </summary>
        /// <param name="options"> Reverse search address options. </param>
        public ReverseSearchAddressQuery(ReverseSearchOptions options = null)
        {
            this.ReverseSearchAddressOptions = options;
        }
    }
}
