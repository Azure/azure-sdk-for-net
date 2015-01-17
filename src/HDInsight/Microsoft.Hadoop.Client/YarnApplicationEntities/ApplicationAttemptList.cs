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
    /// Represents a list of application attempts.
    /// </summary>
    internal class ApplicationAttemptList
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationAttemptList class.
        /// </summary>
        /// <param name="applicationAttemptListResult">
        /// Result of a REST call, containing list of application attempts.
        /// </param>
        /// <param name="parentApplication">
        /// The parent ApplicationDetails object.
        /// </param>
        internal ApplicationAttemptList(ApplicationAttemptListResult applicationAttemptListResult, ApplicationDetails parentApplication)
        {
            if (applicationAttemptListResult == null)
            {
                throw new ArgumentNullException("applicationAttemptListResult");
            }

            if (parentApplication == null)
            {
                throw new ArgumentNullException("parentApplication");
            }

            this.ApplicationAttempts = applicationAttemptListResult.ApplicationAttempts.Select(applicationAttemptResult => new ApplicationAttemptDetails(applicationAttemptResult, parentApplication));
        }

        /// <summary>
        /// Gets an enumeration of application attempts.
        /// </summary>
        internal IEnumerable<ApplicationAttemptDetails> ApplicationAttempts { get; private set; }
    }
}
