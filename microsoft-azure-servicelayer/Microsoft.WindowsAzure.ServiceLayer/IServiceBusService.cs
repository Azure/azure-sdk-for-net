/*
 * Copyright 2012 Microsoft Corporation
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Service bus service
    /// </summary>
    public interface IServiceBusService
    {
        /// <summary>
        /// Lists all available queues in the namespace.
        /// </summary>
        /// <returns>Collection of queues</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> ListQueuesAsync();

        /// <summary>
        /// Gets a queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue</param>
        /// <returns>Queue data</returns>
        IAsyncOperation<QueueInfo> GetQueueAsync(string queueName);

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <returns>Asynchronous operation</returns>
        IAsyncAction DeleteQueueAsync(string queueName);

        /// <summary>
        /// Creates a queue with the given name and default settings.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <returns>Created queue</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName);

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <param name="queueSettings">Queue parameters</param>
        /// <returns>Created queue</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName, QueueSettings queueSettings);
    }
}
