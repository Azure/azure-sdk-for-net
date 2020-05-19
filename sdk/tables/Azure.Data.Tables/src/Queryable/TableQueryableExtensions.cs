// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Data.Tables.Queryable
{
    /// <summary>
    /// Provides a set of extension methods for objects of type <see cref="TableQuery{TElement}"/>.
    /// </summary>
    public static class TableQueryableExtensions
    {
        /// <summary>
        /// Specifies that a query be returned as a <see cref="TableQuery{TElement}"/> object.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A query that implements <see cref="IQueryable{TElement}"/>.</param>
        /// <returns>An object of type <see cref="TableQuery{TElement}"/>.</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TableQuery<TElement> AsTableQuery<TElement>(this IQueryable<TElement> query) where TElement : TableEntity, new()
        {
            if (!(query is TableQuery<TElement> retQuery))
            {
                //TODO: Create Resource for strings
                throw new NotSupportedException(SR.IQueryableExtensionObjectMustBeTableQuery);
            }

            return retQuery;
        }
    }
}
