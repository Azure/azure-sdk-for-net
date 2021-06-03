// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("ColumnDataType")]
    public partial struct LogColumnTypes
    {
        // TODO: https://github.com/Azure/autorest.csharp/issues/1294
        internal const string DatetimeTypeValue = "datetime";
        internal const string GuidTypeValue = "guid";
        internal const string IntTypeValue = "int";
        internal const string LongTypeValue = "long";
        internal const string RealTypeValue = "real";
        internal const string StringTypeValue = "string";
        internal const string TimespanTypeValue = "timespan";
        internal const string DecimalTypeValue = "decimal";
        internal const string BoolTypeValue = "bool";
        internal const string DynamicValueTypeValue = "dynamic";
    }
}