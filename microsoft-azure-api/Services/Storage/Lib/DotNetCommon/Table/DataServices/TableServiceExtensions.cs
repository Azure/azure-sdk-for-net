//-----------------------------------------------------------------------
// <copyright file="TableServiceExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
{
    using System.Data.Services.Client;
    using System.Linq;

    /// <summary>
    /// Provides a set of extensions for the Table service.
    /// </summary>
    public static class TableServiceExtensions
    {
        /// <summary>
        /// Converts the query into a <see cref="TableServiceQuery&lt;TElement&gt;"/> object that supports 
        /// additional operations like retries.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="client">The associated CloudTableClient </param>
        /// <returns>The converted query.</returns>
        public static TableServiceQuery<TElement> AsTableServiceQuery<TElement>(this IQueryable<TElement> query, TableServiceContext context)
        {
            return new TableServiceQuery<TElement>(query as DataServiceQuery<TElement>, context);
        }
    }
}