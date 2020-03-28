// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents.Tests
{
    public class SearchFieldComparer : IEqualityComparer<SearchField>
    {
        public static SearchFieldComparer Shared { get; } = new SearchFieldComparer();

        private static CollectionComparer<SearchField> SharedFieldsCollection { get; } = new CollectionComparer<SearchField>(Shared, compareNullOrEmpty: true);

        private SearchFieldComparer()
        {
        }

        public bool Equals(SearchField x, SearchField y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null || y is null)
            {
                return false;
            }

            // Simple comparisons.
            if (x.Name != y.Name ||
                x.Type != y.Type ||
                x.IsKey != y.IsKey ||
                x.IsHidden != y.IsHidden ||
                x.IsSearchable != y.IsSearchable ||
                x.IsFilterable != y.IsFilterable ||
                x.IsSortable != y.IsSortable ||
                x.IsFacetable != y.IsFacetable ||
                x.Analyzer != y.Analyzer ||
                x.SearchAnalyzer != y.SearchAnalyzer ||
                x.IndexAnalyzer != y.IndexAnalyzer)
            {
                return false;
            }

            if (!CollectionComparer<string>.SharedNullOrEmpty.Equals(x.SynonymMaps, y.SynonymMaps))
            {
                return false;
            }

            if (!SharedFieldsCollection.Equals(x.Fields, y.Fields))
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(SearchField obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Add(obj.Name);
            builder.Add(obj.Type);
            builder.Add(obj.IsKey);
            builder.Add(obj.IsHidden);
            builder.Add(obj.IsSearchable);
            builder.Add(obj.IsFilterable);
            builder.Add(obj.IsSortable);
            builder.Add(obj.IsFacetable);
            builder.Add(obj.Analyzer);
            builder.Add(obj.SearchAnalyzer);
            builder.Add(obj.IndexAnalyzer);
            builder.Add(obj.SynonymMaps, CollectionComparer<string>.Shared);
            builder.Add(obj.Fields, SharedFieldsCollection);

            return builder.ToHashCode();
        }
    }
}
