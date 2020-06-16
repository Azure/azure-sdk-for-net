// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    public static class TableClientExtensions
    {
        /// <summary>
        /// Creates an Odata filter query string from the provided expression.
        /// </summary>
        /// <typeparam name="T">The type of the entity being queried. Typically this will be derrived from <see cref="TableEntity"/> or <see cref="Dictionary{String, Object}"/>.</typeparam>
        /// <param name="client">The <see cref="TableClient"/>.</param>
        /// <param name="filter">A filter expresssion.</param>
        /// <returns>The string representation of the filter expression.</returns>
        public static string CreateFilter<T>(this TableClient client, Expression<Func<T, bool>> filter) => client.Bind(filter);
    }
}
