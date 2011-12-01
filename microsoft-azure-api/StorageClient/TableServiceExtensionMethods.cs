//-----------------------------------------------------------------------
// <copyright file="TableServiceExtensionMethods.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the TableServiceExtensionMethods class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System.Data.Services.Client;
    using System.Linq;

    /// <summary>
    /// Provides a set of extensions for the Table service.
    /// </summary>
    public static class TableServiceExtensionMethods
    {
        /// <summary>
        /// Converts the query into a <see cref="CloudTableQuery&lt;TElement&gt;"/> object that supports 
        /// additional operations like retries.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The converted query.</returns>
        public static CloudTableQuery<TElement> AsTableServiceQuery<TElement>(this IQueryable<TElement> query)
        {
            return new CloudTableQuery<TElement>(query as DataServiceQuery<TElement>);
        }
    }
}
