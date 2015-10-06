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
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a list of application' containers.
    /// </summary>
    internal class ApplicationContainerList
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationContainerList class.
        /// </summary>
        /// <param name="containerListResult">
        /// Result of a REST call, containing list of application containers.
        /// </param>
        /// <param name="parentApplicationAttempt">
        /// The parent ApplicationAttemptDetails object.
        /// </param>
        internal ApplicationContainerList(ApplicationContainerListResult containerListResult, ApplicationAttemptDetails parentApplicationAttempt)
        {
            if (containerListResult == null)
            {
                throw new ArgumentNullException("containerListResult");
            }

            if (parentApplicationAttempt == null)
            {
                throw new ArgumentNullException("parentApplicationAttempt");
            }

            this.Containers = containerListResult.Containers.Select(containerResult => new ApplicationContainerDetails(containerResult, parentApplicationAttempt));
        }

        /// <summary>
        /// Gets an enumeration of an application' containers.
        /// </summary>
        internal IEnumerable<ApplicationContainerDetails> Containers { get; private set; }
    }
}
