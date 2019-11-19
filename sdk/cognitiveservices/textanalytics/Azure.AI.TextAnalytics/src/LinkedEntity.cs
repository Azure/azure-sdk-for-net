// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct LinkedEntity
    {
        internal LinkedEntity(string name, string id, string language, string dataSource, Uri uri, IEnumerable<LinkedEntityMatch> matches)
        {
            Name = name;
            Id = id;
            Language = language;
            DataSource = dataSource;
            Uri = uri;
            Matches = matches;
        }

        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// </summary>
        public string DataSource { get; }

        /// <summary>
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// </summary>
        public IEnumerable<LinkedEntityMatch> Matches { get; }
    }
}
