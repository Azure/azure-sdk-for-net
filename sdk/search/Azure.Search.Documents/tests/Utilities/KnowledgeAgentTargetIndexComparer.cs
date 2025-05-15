// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests
{
    public class KnowledgeAgentTargetIndexComparer : IEqualityComparer<KnowledgeAgentTargetIndex>
    {
        public static KnowledgeAgentTargetIndexComparer Instance { get; } = new KnowledgeAgentTargetIndexComparer();

        private KnowledgeAgentTargetIndexComparer()
        {
        }

        public bool Equals(KnowledgeAgentTargetIndex x, KnowledgeAgentTargetIndex y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null || y is null)
            {
                return false;
            }

            return x.IndexName == y.IndexName;
        }

        public int GetHashCode(KnowledgeAgentTargetIndex obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();
            builder.Add(obj.IndexName);

            return builder.ToHashCode();
        }
    }
}
