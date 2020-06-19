// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class SearchIndexerDataSourceConnectionComparer : IEqualityComparer<SearchIndexerDataSourceConnection>
    {
        public static SearchIndexerDataSourceConnectionComparer Shared { get; } = new SearchIndexerDataSourceConnectionComparer();

        private SearchIndexerDataSourceConnectionComparer()
        {
        }

        public bool Equals(SearchIndexerDataSourceConnection x, SearchIndexerDataSourceConnection y)
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
                x.Description != y.Description ||
                x.Container?.Name != y.Container?.Name ||
                x.Container?.Query != y.Container?.Query)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(SearchIndexerDataSourceConnection obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Add(obj.Name);
            builder.Add(obj.Type);
            builder.Add(obj.Description);
            builder.Add(obj.Container?.Name);
            builder.Add(obj.Container?.Query);

            return builder.ToHashCode();
        }
    }
}
