// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.Tables.Performance
{
    public class ComplexPerfEntity : ITableEntity
    {
        public ComplexPerfEntity()
        { }

        public string StringTypeProperty { get; set; }
        public DateTime DatetimeTypeProperty { get; set; }
        public Guid GuidTypeProperty { get; set; }
        public byte[] BinaryTypeProperty { get; set; }
        public long Int64TypeProperty { get; set; }
        public double DoubleTypeProperty { get; set; }
        public int IntTypeProperty { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
