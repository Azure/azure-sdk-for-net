// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace Microsoft.Azure.Common.OData
{
    /// <summary>
    /// Handles OData filter generation.
    /// </summary>
    public class FilterString
    {
        /// <summary>
        /// Generates an OData filter from a specified Linq expression.
        /// </summary>
        /// <typeparam name="T">Filter type.</typeparam>
        /// <param name="filter">Entity to use for filter generation.</param>
        /// <returns></returns>
        public static string Generate<T>(Expression<Func<T, bool>> filter)
        {
            UrlExpressionVisitor visitor = new UrlExpressionVisitor();
            visitor.Visit(filter);
            return visitor.ToString();
        }
    }
}
