// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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

        public const string IsDefined = "IS_DEFINED";
        public const string IsNull = "IS_NULL";
        public const string StartsWith = "STARTSWITH";
        public const string EndsWith = "ENDSWITH";
        public const string IsOfModel = "IS_OF_MODEL";
        public const string IsBool = "IS_BOOL";
        public const string IsNumber = "IS_NUMBER";
        public const string IsString = "IS_STRING";
        public const string IsPrimative = "IS_PRIMATIVE";
        public const string IsObject = "IS_OBJECT";

        // Maps comparison operators represented alphabetically to respective symbolic representations.
        public static Dictionary<string, string> ComparisonOperators = new Dictionary<string, string>()
        {
            { QueryComparisonOperator.Equal.ToString(), "=" },
            { QueryComparisonOperator.NotEqual.ToString(), "!=" },
            { QueryComparisonOperator.GreaterThan.ToString(), ">" },
            { QueryComparisonOperator.LessThan.ToString(), "<" },
            { QueryComparisonOperator.GreaterOrEqual.ToString(), ">=" },
            { QueryComparisonOperator.LessOrEqual.ToString(), "<=" }
        };
    }
}
