// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests
{
    public class KnowledgeSourceReferenceComparer : IEqualityComparer<KnowledgeSourceReference>
    {
        public static KnowledgeSourceReferenceComparer Instance { get; } = new KnowledgeSourceReferenceComparer();

        private KnowledgeSourceReferenceComparer()
        {
        }

        public bool Equals(KnowledgeSourceReference x, KnowledgeSourceReference y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null || y is null)
            {
                return false;
            }

            return x.Name == y.Name;
        }

        public int GetHashCode(KnowledgeSourceReference obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();
            builder.Add(obj.Name);

            return builder.ToHashCode();
        }
    }
}
