// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Keywords for building queries.
    /// </summary>
    internal static class QueryConstants
    {
        public const string Select = "SELECT";
        public const string From = "FROM";
        public const string Join = "JOIN";
        public const string Where = "WHERE";
        public const string Top = "TOP";
        public const string Count = "COUNT";

        public const string And = "AND";
        public const string Or = "OR";

        public const string IsDefined = "IS_DEFINED";
        public const string IsNull = "IS_NULL";
        public const string StartsWith = "STARTSWITH";
        public const string EndsWith = "ENDSWITH";
        public const string IsOfModel = "IS_OF_MODEL";

        public static readonly IReadOnlyDictionary<AdtDataType, string> DataTypeToFunctionNameMap = new Dictionary<AdtDataType, string>()
        {
            { AdtDataType.AdtBool, "IS_BOOL" },
            { AdtDataType.AdtNumber, "IS_NUMBER" },
            { AdtDataType.AdtString, "IS_STRING" },
            { AdtDataType.AdtPrimative, "IS_PRIMATIVE" },
            { AdtDataType.AdtObject, "IS_OBJECT" }
        };

        // Maps comparison operators represented alphabetically to respective symbolic representations.
        public static readonly IReadOnlyDictionary<QueryComparisonOperator, string> ComparisonOperatorMap = new Dictionary<QueryComparisonOperator, string>()
        {
            { QueryComparisonOperator.Equal, "=" },
            { QueryComparisonOperator.NotEqual, "!=" },
            { QueryComparisonOperator.GreaterThan, ">" },
            { QueryComparisonOperator.LessThan, "<" },
            { QueryComparisonOperator.GreaterOrEqual, ">=" },
            { QueryComparisonOperator.LessOrEqual, "<=" }
        };

        // Maps contains operators
        public static readonly IReadOnlyDictionary<QueryContainsOperator, string> ContainOperatorMap = new Dictionary<QueryContainsOperator, string>()
        {
            { QueryContainsOperator.In, "IN" },
            { QueryContainsOperator.NotIn, "NIN" }
        };
    }
}
