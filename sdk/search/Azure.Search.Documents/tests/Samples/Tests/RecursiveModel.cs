// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

namespace Azure.Search.Documents.Tests.Samples
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
