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
    using Microsoft.Hadoop.Client.WebHCatResources;

    /// <summary>
    /// Provides creation details for a new MapReduce jobDetails.
    /// </summary>
    public sealed class MapReduceJobCreateParameters : JobCreateParameters
    {
        /// <summary>
        /// Initializes a new instance of the MapReduceJobCreateParameters class.
        /// </summary>
        public MapReduceJobCreateParameters()
        {
            this.LibJars = new List<string>();
            this.Defines = new Dictionary<string, string>();
            this.Arguments = new Collection<string>();
        }

        /// <summary>
        /// Gets or sets the name of the jobDetails.
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Gets or sets the jar file to use for the jobDetails.
        /// </summary>
        public string JarFile { get; set; }

        /// <summary>
        /// Gets or sets the class name to use for the jobDetails.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets the libjars to use for the jobDetails.
        /// </summary>
        public ICollection<string> LibJars { get; private set; }

        /// <summary>
        /// Gets the parameters for the jobDetails.
        /// </summary>
        public IDictionary<string, string> Defines { get; private set; }

        /// <summary>
        /// Gets the arguments for the jobDetails.
        /// </summary>
        public ICollection<string> Arguments { get; private set; }
    }
}
