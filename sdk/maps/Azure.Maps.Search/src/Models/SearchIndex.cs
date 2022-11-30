// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search
{
    /// <summary> The SearchIndexes. </summary>
    [CodeGenModel("SearchIndexes")]
    public readonly partial struct SearchIndex
    {
        private const string AddressValue = "Addr";

        /// <summary> Address range interpolation. </summary>
        [CodeGenMember("Address")]
        public static SearchIndex Addresses { get; } = new SearchIndex(AddressValue);
    }
}
