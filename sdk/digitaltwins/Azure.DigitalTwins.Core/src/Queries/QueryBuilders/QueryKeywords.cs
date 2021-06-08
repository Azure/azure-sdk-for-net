// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.Queries.QueryBuilders
{
    /// <summary>
    /// Query keywords for building queries in string format.
    /// </summary>
    internal static class QueryKeywords
    {
        internal const string Select = "SELECT";
        internal const string From = "FROM";
        internal const string Join = "JOIN";
        internal const string Where = "WHERE";
    }
}
