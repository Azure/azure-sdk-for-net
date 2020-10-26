// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests
{
    public class SearchFieldComparer : IEqualityComparer<SearchField>
    {
        public static SearchFieldComparer Shared { get; } = new SearchFieldComparer();

        public static CollectionComparer<SearchField> SharedFieldsCollection { get; } = new CollectionComparer<SearchField>(Shared, compareNullOrEmpty: true);

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
                x.AnalyzerName != y.AnalyzerName ||
                x.SearchAnalyzerName != y.SearchAnalyzerName ||
                x.IndexAnalyzerName != y.IndexAnalyzerName)
            {
                return false;
            }

            if (!CollectionComparer<string>.SharedNullOrEmpty.Equals(x.SynonymMapNames, y.SynonymMapNames))
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
            builder.Add(obj.AnalyzerName);
            builder.Add(obj.SearchAnalyzerName);
            builder.Add(obj.IndexAnalyzerName);
            builder.Add(obj.SynonymMapNames, CollectionComparer<string>.Shared);
            builder.Add(obj.Fields, SharedFieldsCollection);

            return builder.ToHashCode();
        }
    }
}
