// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes;

namespace Azure.Search.Documents.Perf.Infrastructure
{
    /// <summary>
    /// Address.
    /// </summary>
    public sealed class Address
    {
        /// <summary>
        /// StreetAddress.
        /// </summary>
        [SearchableField]
        public string StreetAddress { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string City { get; set; }

        /// <summary>
        /// StateProvince.
        /// </summary>
        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string StateProvince { get; set; }

        /// <summary>
        /// PostalCode.
        /// </summary>
        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string Country { get; set; }
    }
}
