// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class OutputFieldMappingEntryComparer : IEqualityComparer<OutputFieldMappingEntry>
    {
        public static OutputFieldMappingEntryComparer Shared { get; } = new OutputFieldMappingEntryComparer();

        private OutputFieldMappingEntryComparer()
        {
        }

        public bool Equals(OutputFieldMappingEntry x, OutputFieldMappingEntry y)
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
                x.TargetName != y.TargetName)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(OutputFieldMappingEntry obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Add(obj.Name);
            builder.Add(obj.TargetName);

            return builder.ToHashCode();
        }
    }
}
