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

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// The CloudClients class provides a common location for service client
    /// discovery.  It can be accessed via CloudContext.Clients.  The
    /// Microsoft.WindowsAzure namespace should be imported when used because
    /// CloudClients is intended to be the target of extension methods by each
    /// service client.
    /// </summary>
    /// <remarks>
    /// All service client libraries should add CreateXYZClient() extension
    /// methods on static classes declared in the Microsoft.WindowsAzure
    /// namespace.  This will allow any library loaded in a project to be
    /// easily discovered via CloudContext.Clients without developers having to
    /// figure out which namespaces to import, etc.  You may also add extension
    /// methods that create 
    /// 
    /// This class is used as a static class (internal .ctor) but not declared
    /// as such so it can be the target of extension methods.
    /// </remarks>
    public sealed class CloudClients
    {
        /// <summary>
        /// Initializes a new instance of the CloudClients class.
        /// </summary>
        internal CloudClients()
        {
        }
    }
}
