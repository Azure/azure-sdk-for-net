// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class SearchIndexerSkillsetComparer : IEqualityComparer<SearchIndexerSkillset>
    {
        public static SearchIndexerSkillsetComparer Shared { get; } = new SearchIndexerSkillsetComparer();

        private static CollectionComparer<SearchIndexerSkill> SharedSkillsCollection { get; } = new CollectionComparer<SearchIndexerSkill>(SearchIndexerSkillComparer.Shared, compareNullOrEmpty: true);

        private SearchIndexerSkillsetComparer()
        {
        }

        public bool Equals(SearchIndexerSkillset x, SearchIndexerSkillset y)
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
                x.Description != y.Description)
            {
                return false;
            }

            if (!SharedSkillsCollection.Equals(x.Skills, y.Skills))
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(SearchIndexerSkillset obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Add(obj.Name);
            builder.Add(obj.Description);
            builder.Add(obj.Skills, SharedSkillsCollection);

            return builder.ToHashCode();
        }
    }
}
