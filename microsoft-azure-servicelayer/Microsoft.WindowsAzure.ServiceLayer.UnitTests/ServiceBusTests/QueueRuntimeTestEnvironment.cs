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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Enviromnent for queues runtime tests.
    /// </summary>
    public class QueueRuntimeTestEnvironment: TestEnvironment, IDisposable
    {
        /// <summary>
        /// Gets name of the queue used in tests.
        /// </summary>
        public string QueueName { get; private set; }

        /// <summary>
        /// Constructor. Creates a shared queue for tests.
        /// </summary>
        public QueueRuntimeTestEnvironment()
            : base()
        {
            QueueName = string.Format(CultureInfo.InvariantCulture, "Queue.{0}", Guid.NewGuid().ToString());
            ServiceBus.CreateQueueAsync(QueueName).AsTask().Wait();
        }

        /// <summary>
        /// Disposes the environment by removing the queue.
        /// </summary>
        void IDisposable.Dispose()
        {
            ServiceBus.DeleteQueueAsync(QueueName).AsTask().Wait();
        }
    }
}
