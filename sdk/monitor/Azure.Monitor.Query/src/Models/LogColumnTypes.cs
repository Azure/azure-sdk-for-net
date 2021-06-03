// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("ColumnDataType")]
    public partial struct LogColumnTypes
    {
        internal const string Datetime = "datetime";
        internal const string Guid = "guid";
        internal const string Int = "int";
        internal const string Long = "long";
        internal const string Real = "real";
        internal const string String = "string";
        internal const string Timespan = "timespan";
        internal const string Decimal = "decimal";
        internal const string Bool = "bool";
    }
}