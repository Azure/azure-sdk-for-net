// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    internal static class TableConstants
    {
        internal static class HeaderNames
        {
            public const string Date = "x-ms-date";
            public const string SharedKey = "SharedKeyLite";
            public const string Authorization = "Authorization";
            public const string IfMatch = "If-Match";
        }

        internal static class QueryParameterNames
        {
            public const string NextTableName = "NextTableName";
            public const string NextPartitionKey = "NextPartitionKey";
            public const string NextRowKey = "NextRowKey";
        }

        internal static class PropertyNames
        {
            public const string TimeStamp = "Timestamp";
            public const string PartitionKey = "PartitionKey";
            public const string RowKey = "RowKey";
            public const string Etag = "odata.etag";
        }
    }
}
