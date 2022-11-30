// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase identified as a known entity in a data source.
    /// A link to the entry in the data source is provided as well as the formal
    /// name of the entity used in the data source.  Note that the formal name
    /// may be different from the exact text match in the input document.
    /// </summary>
    [CodeGenModel("LinkedEntity")]
    public readonly partial struct LinkedEntity
    {
        internal LinkedEntity(string name, IEnumerable<LinkedEntityMatch> matches, string language, string dataSourceEntityId, Uri url, string dataSource, string bingEntitySearchApiId)
        {
            Name = name;
            DataSourceEntityId = dataSourceEntityId;
            Language = language;
            DataSource = dataSource;
            Url = url;
            Matches = matches;
            BingEntitySearchApiId = bingEntitySearchApiId;
        }

        /// <summary>
        /// Gets the formal name of the entity.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the unique identifier of the entity in the data source.
        /// </summary>
        [CodeGenMember("Id")]
        public string DataSourceEntityId { get; }

        /// <summary>
        /// Gets the language used in the data source.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets the name of the data source used to extract the entity linking.
        /// </summary>
        public string DataSource { get; }

        /// <summary>
        /// Gets the URL that identifies the linked entity's entry in the data source.
        /// </summary>
        [CodeGenMember("Url")]
        public Uri Url { get; }

        /// <summary>
        /// Collection identifying the substrings of the document that correspond
        /// to this linked entity.
        /// </summary>
        public IEnumerable<LinkedEntityMatch> Matches { get; }

        /// <summary> Bing Entity Search API unique identifier of the recognized entity.
        /// Use in conjunction with the Bing Entity Search API to fetch additional relevant information.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1"/>, <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/>, and newer.
        /// </remarks>
        [CodeGenMember("BingId")]
        public string BingEntitySearchApiId { get; }
    }
}
