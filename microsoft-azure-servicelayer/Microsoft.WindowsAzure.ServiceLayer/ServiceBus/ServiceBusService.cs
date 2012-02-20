﻿/*
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Factory for creating service bus services
    /// </summary>
    public static class ServiceBusService
    {
        /// <summary>
        /// Creates a service bus servive using given settings.
        /// </summary>
        /// <param name="serviceNamespace">Service namespace</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>A service bus service with the given parameters</returns>
        public static IServiceBusService Create(string serviceNamespace, string userName, string password)
        {
            if (serviceNamespace == null)
                throw new ArgumentNullException("serviceNamespace");
            if (userName == null)
                throw new ArgumentNullException("userName");
            if (password == null)
                throw new ArgumentNullException("password");

            ServiceConfiguration serviceOptions = new ServiceConfiguration(serviceNamespace, userName, password);
            return new ServiceBusRestProxy(serviceOptions);
        }
    }
}
