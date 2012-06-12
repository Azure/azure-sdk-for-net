//-----------------------------------------------------------------------
// <copyright file="TableServiceExtensionMethods.cs" company="Microsoft">
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
