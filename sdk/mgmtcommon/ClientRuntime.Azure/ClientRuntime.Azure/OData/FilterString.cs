// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Rest.Azure.OData
{
    /// <summary>
    /// Handles OData filter generation.
    /// </summary>
    public static class FilterString
    {
        /// <summary>
        /// Generates an OData filter from a specified Linq expression. Skips null parameters.
        /// </summary>
        /// <typeparam name="T">Filter type.</typeparam>
        /// <param name="filter">Entity to use for filter generation.</param>
        /// <returns></returns>
        public static string Generate<T>(Expression<Func<T, bool>> filter)
        {
            return Generate(filter, true);
        }

        /// <summary>
        /// Generates an OData filter from a specified Linq expression.
        /// </summary>
        /// <typeparam name="T">Filter type.</typeparam>
        /// <param name="filter">Entity to use for filter generation.</param>
        /// <param name="skipNullFilterParameters">Value indicating whether null values should be skipped.</param>
        /// <returns></returns>
        public static string Generate<T>(Expression<Func<T, bool>> filter, bool skipNullFilterParameters)
        {
            if (filter == null || !filter.Parameters.Any())
            {
                return string.Empty;
            }
            var visitor = new UrlExpressionVisitor(filter.Parameters.First(), skipNullFilterParameters);
            visitor.Visit(filter);
            return visitor.ToString();
        }
    }
}
