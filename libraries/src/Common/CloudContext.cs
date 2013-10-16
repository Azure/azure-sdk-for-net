//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using Microsoft.WindowsAzure.Common;

namespace Microsoft.WindowsAzure
{
    // TODO: Consider renaming this class to just Cloud.  It would shorten
    // a lot of common use cases by 7 characters.  It would also burn a very
    // basic name.

    /// <summary>
    /// The CloudContext class is your primary entry point for getting started
    /// with Windows Azure client libraries.  CloudContext.Clients contains
    /// helpful methods to create any of the clients currently referenced in
    /// your project (be sure to import the Microsoft.WindowsAzure namespace so
    /// you import its extension methods).  CloudContext.Configuration allows
    /// you to easily retrieve configuration settings across a variety of 
    /// platform appropriate sources.
    /// </summary>
    /// <remarks>
    /// The CloudContext class is static to make it easier to use, but all
    /// other classes should be instances so they can be targeted by extension
    /// methods given the layered approach of our client libraries.
    /// </remarks>
    public static class CloudContext
    {
        /// <summary>
        /// Initializes the CloudContext static class.
        /// </summary>
        static CloudContext()
        {
            Clients = new CloudClients();
            Configuration = new CloudConfiguration();
        }
        
        /// <summary>
        /// Gets an object providing a common location for service client
        /// discovery.  The Microsoft.WindowsAzure namespace should be imported
        /// when used because CloudClients is intended to be the target of
        /// extension methods by each service client library.
        /// </summary>
        public static CloudClients Clients { get; private set; }

        /// <summary>
        /// Gets utilities for easily retrieving configuration settings across
        /// a variety of platform appropriate sources.
        /// </summary>
        public static CloudConfiguration Configuration { get; private set; }
    }
}
