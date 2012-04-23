//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Class for generating unique queues.
    /// </summary>
    internal class UniqueQueue: IDisposable
    {
        /// <summary>
        /// Gets the queue name.
        /// </summary>
        internal string QueueName { get; private set; }

        /// <summary>
        /// Creates a unique queue.
        /// </summary>
        internal UniqueQueue()
        {
            QueueName = Configuration.GetUniqueQueueName();
            Configuration.ServiceBus.CreateQueueAsync(QueueName).AsTask().Wait();
        }

        /// <summary>
        /// Deletes the queue.
        /// </summary>
        void IDisposable.Dispose()
        {
            Configuration.ServiceBus.DeleteQueueAsync(QueueName).AsTask().Wait();
        }
    }
}
