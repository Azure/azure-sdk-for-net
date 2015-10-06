// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Adds Extension methods to the ICollection(of T) objects.
    /// </summary>
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Allows a range of objects IEnumerable(of T) to be added to the collection.
        /// </summary>
        /// <typeparam name="T">
        /// The Type of objects in the collection.
        /// </typeparam>
        /// <param name="collection">
        /// The collection that this extension method is extending.
        /// </param>
        /// <param name="items">
        /// The IEnumerable(of T) of objects in the collection.
        /// </param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection.IsNull())
            {
                throw new ArgumentNullException("collection");
            }
            if (items.IsNull())
            {
                throw new ArgumentNullException("items");
            }

            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
