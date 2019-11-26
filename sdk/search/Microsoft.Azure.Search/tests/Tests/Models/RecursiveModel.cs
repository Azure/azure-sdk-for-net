// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    public class RecursiveModel
    {
        [IsFilterable]
        public int Data { get; set; }

        // This is to test that FieldBuilder gracefully fails on recursive models.
        public OtherRecursiveModel Next { get; set; }
    }

    public class OtherRecursiveModel
    {
        [IsFilterable, IsFacetable]
        public double Data { get; set; }

        public RecursiveModel RecursiveReference { get; set; }
    }
}
