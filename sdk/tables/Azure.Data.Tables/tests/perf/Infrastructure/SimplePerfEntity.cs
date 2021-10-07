// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.Tables.Performance
{
    public class SimplePerfEntity : ITableEntity
    {
        public SimplePerfEntity()
        { }
        public string StringTypeProperty1 { get; set; }
        public string StringTypeProperty2 { get; set; }
        public string StringTypeProperty3 { get; set; }
        public string StringTypeProperty4 { get; set; }
        public string StringTypeProperty5 { get; set; }
        public string StringTypeProperty6 { get; set; }
        public string StringTypeProperty7 { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
