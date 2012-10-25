﻿// -----------------------------------------------------------------------------------------
// <copyright file="QueuePermissions.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    /// <summary>
    /// Represents the permissions for a queue.
    /// </summary>
    public sealed class QueuePermissions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueuePermissions"/> class.
        /// </summary>
        public QueuePermissions()
        {
            this.SharedAccessPolicies = new SharedAccessQueuePolicies();
        }

        /// <summary>
        /// Gets the set of shared access policies for the queue.
        /// </summary>
        /// <value>The set of shared access policies for the queue.</value>
        public SharedAccessQueuePolicies SharedAccessPolicies { get; private set; }
    }
}
