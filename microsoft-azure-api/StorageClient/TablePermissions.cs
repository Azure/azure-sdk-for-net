//-----------------------------------------------------------------------
// <copyright file="TablePermissions.cs" company="Microsoft">
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
// <summary>
//    Contains code for the TablePermissions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the permissions for a container.
    /// </summary>
    public class TablePermissions
    {
        /// <summary>
        /// Initializes a new instance of the TablePermissions class.
        /// </summary>
        public TablePermissions()
        {
            this.SharedAccessPolicies = new SharedAccessTablePolicies();
        }

        /// <summary>
        /// Gets the set of shared access policies for the container.
        /// </summary>
        /// <value>The set of shared access policies for the container.</value>
        public SharedAccessTablePolicies SharedAccessPolicies { get; private set; }
    }
}
