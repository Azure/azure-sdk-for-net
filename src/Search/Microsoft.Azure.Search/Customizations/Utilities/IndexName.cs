// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    internal class IndexName
    {
        private readonly string _name;

        public IndexName(string indexName)
        {
            Name.ThrowIfNullOrEmpty(indexName, "indexName", "index");
            _name = indexName;
        }

        public static implicit operator string(IndexName indexName)
        {
            return indexName.ToString();
        }

        public override string ToString()
        {
            return _name ?? String.Empty;
        }
    }
}
