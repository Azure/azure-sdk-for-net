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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Provides the details of an HDInsight jobDetails when creating the jobDetails.
    /// </summary>
    public abstract class JobCreateParameters
    {
        /// <summary>
        /// Initializes a new instance of the JobCreateParameters class.
        /// </summary>
        protected JobCreateParameters()
        {
            this.Files = new List<string>();
            this.EnableTaskLogs = false;
        }

        /// <summary>
        /// Gets the resources for the jobDetails.
        /// </summary>
        public ICollection<string> Files { get; private set; }

        /// <summary>
        /// Gets or sets the status folder to use for the jobDetails.
        /// </summary>
        public string StatusFolder { get; set; }

        /// <summary>
        /// Gets or sets the callback URI to be called upon job completion.
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the job executor should persist task logs.
        /// </summary>
        public bool EnableTaskLogs { get; set; }
    }
}
