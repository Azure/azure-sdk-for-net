// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class SearchIndexerSkillComparer : IEqualityComparer<SearchIndexerSkill>
    {
        public static SearchIndexerSkillComparer Shared { get; } = new SearchIndexerSkillComparer();

        internal static CollectionComparer<InputFieldMappingEntry> SharedInputsCollection { get; } = new CollectionComparer<InputFieldMappingEntry>(InputFieldMappingEntryComparer.Shared, compareNullOrEmpty: true);
        internal static CollectionComparer<OutputFieldMappingEntry> SharedOutputsCollection { get; } = new CollectionComparer<OutputFieldMappingEntry>(OutputFieldMappingEntryComparer.Shared, compareNullOrEmpty: true);

        private SearchIndexerSkillComparer()
        {
        }

        public bool Equals(SearchIndexerSkill x, SearchIndexerSkill y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null || y is null)
            {
                return false;
            }

            // BUGBUG: Ignore the name since 1-based automatic names are only returned in GET methods, not PUT methods.
            if (x.ODataType != y.ODataType ||
                x.Description != y.Description ||
                x.Context != y.Context)
            {
                return false;
            }

            if (!SharedInputsCollection.Equals(x.Inputs, y.Inputs))
            {
                return false;
            }

            if (!SharedOutputsCollection.Equals(x.Outputs, y.Outputs))
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(SearchIndexerSkill obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            // BUGBUG: Ignore the name since 1-based automatic names are only returned in GET methods, not PUT methods.
            builder.Add(obj.ODataType);
            builder.Add(obj.Description);
            builder.Add(obj.Context);
            builder.Add(obj.Inputs, SharedInputsCollection);
            builder.Add(obj.Outputs, SharedOutputsCollection);

            return builder.ToHashCode();
        }
    }
}
