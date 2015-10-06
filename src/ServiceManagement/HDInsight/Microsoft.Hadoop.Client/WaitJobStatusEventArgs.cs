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

    /// <summary>
    ///     Provides event arguments for jobDetails Wait events.
    /// </summary>
    public class WaitJobStatusEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the WaitJobStatusEventArgs class.
        /// </summary>
        /// <param name="jobDetails">The jobDetails being polled.</param>
        public WaitJobStatusEventArgs(JobDetails jobDetails)
        {
            this.JobDetails = jobDetails;
        }

        /// <summary>
        ///     Gets the jobDetails being polled.
        /// </summary>
        public JobDetails JobDetails { get; private set; }
    }
}
