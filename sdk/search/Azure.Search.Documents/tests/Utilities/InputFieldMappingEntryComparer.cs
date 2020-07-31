// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class InputFieldMappingEntryComparer : IEqualityComparer<InputFieldMappingEntry>
    {
        public static InputFieldMappingEntryComparer Shared { get; } = new InputFieldMappingEntryComparer();

        private static CollectionComparer<InputFieldMappingEntry> SharedInputsCollection => SearchIndexerSkillComparer.SharedInputsCollection;

        private InputFieldMappingEntryComparer()
        {
        }

        public bool Equals(InputFieldMappingEntry x, InputFieldMappingEntry y)
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
                x.Source != y.Source ||
                x.SourceContext != y.SourceContext)
            {
                return false;
            }

            if (!SharedInputsCollection.Equals(x.Inputs, y.Inputs))
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(InputFieldMappingEntry obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Add(obj.Name);
            builder.Add(obj.Source);
            builder.Add(obj.SourceContext);
            builder.Add(obj.Inputs, SharedInputsCollection);

            return builder.ToHashCode();
        }
    }
}
