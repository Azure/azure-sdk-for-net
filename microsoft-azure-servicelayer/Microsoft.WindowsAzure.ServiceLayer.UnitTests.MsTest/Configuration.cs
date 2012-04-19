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

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest
{
    /// <summary>
    /// Shared configuration for all service bus tests.
    /// </summary>
    internal static class Configuration
    {
        private static ServiceBusClient _serviceBus;

        /// <summary>
        /// Gets the namespace used for testing.
        /// </summary>
        private static string ServiceNamespace { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets the user name used for testing.
        /// </summary>
        private static string UserName { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets the password used for testing.
        /// </summary>
        private static string Password { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets an instance of the service bus service shared by all tests.
        /// </summary>
        internal static ServiceBusClient ServiceBus
        {
            get
            {
                if (_serviceBus == null)
                {
                    _serviceBus = new ServiceBusClient(ServiceNamespace, UserName, Password);
                }
                return _serviceBus;
            }
        }

        /// <summary>
        /// Generates unique queue name.
        /// </summary>
        /// <returns>Unique queue name.</returns>
        internal static string GetUniqueQueueName()
        {
            return "Queue." + Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates unique topic name.
        /// </summary>
        /// <returns>Unique topic name.</returns>
        internal static string GetUniqueTopicName()
        {
            return "Topic." + Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates unique subscription name.
        /// </summary>
        /// <returns>Unique subscription name.</returns>
        internal static string GetUniqueSubscriptionName()
        {
            return "S." + Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates unique queue name.
        /// </summary>
        /// <returns>Unique queue name.</returns>
        internal static string GetUniqueRuleName()
        {
            return "R." + Guid.NewGuid().ToString();
        }
    }
}
