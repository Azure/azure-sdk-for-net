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
    using System.Collections.Generic;

    /// <summary>
    /// Provides extension methods for Queues.
    /// </summary>
#if Non_Public_SDK
    public static class QueueExtensions
#else
    internal static class QueueExtensions
#endif
    {
        /// <summary>
        /// Adds an item to the Queue.  This is the same as an Enqueue operation.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the item stored in the queue.
        /// </typeparam>
        /// <param name="queue">
        /// The queue.
        /// </param>
        /// <param name="item">
        /// The item to add.
        /// </param>
        public static void Add<T>(this Queue<T> queue, T item)
        {
            queue.ArgumentNotNull("queue");
            queue.Enqueue(item);
        }

        /// <summary>
        /// Removes an item from the Queuue.  This is the same as a Dequeue operation.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the item stored in the queue.
        /// </typeparam>
        /// <param name="queue">
        /// The queue.
        /// </param>
        /// <returns>
        /// The next item in the queue.
        /// </returns>
        public static T Remove<T>(this Queue<T> queue)
        {
            queue.ArgumentNotNull("queue");
            return queue.Dequeue();
        }

        /// <summary>
        /// Adds a range of items to the queue.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the item stored in the queue.
        /// </typeparam>
        /// <param name="queue">
        /// The queue.
        /// </param>
        /// <param name="items">
        /// The items to be added (they will be added in the order presented).
        /// </param>
        public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            queue.ArgumentNotNull("queue");
            items.ArgumentNotNull("items");
            foreach (var item in items)
            {
                queue.Add(item);
            }
        }
    }
}
