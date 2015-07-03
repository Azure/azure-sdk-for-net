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

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// MapReduce activity which runs on HDInsight.
    /// </summary>
    [AdfTypeName("HDInsightMapReduce")]
    public class HDInsightMapReduceActivity : HDInsightActivityBase
    {
        /// <summary>
        /// Class name.
        /// </summary>
        [AdfRequired]
        public string ClassName { get; set; }

        /// <summary>
        /// Jar path.
        /// </summary>
        [AdfRequired]
        public string JarFilePath { get; set; }

        /// <summary>
        /// Jar linked service.
        /// </summary>
        public string JarLinkedService { get; set; }

        /// <summary>
        /// Jar libs. 
        /// </summary>
        public IList<string> JarLibs { get; set; }

        /// <summary>
        /// Allows user to specify defines for MapReduce job request.
        /// </summary>
        public IDictionary<string, string> Defines { get; set; }

         /// <summary>
        /// Initializes a new instance of the MapReduce class.
        /// </summary>
        public HDInsightMapReduceActivity()
        {
            this.Defines = new Dictionary<string, string>();
            this.JarLibs = new List<string>();
        }
        
        /// <summary>
        /// Initializes a new instance of the HDInsightMapReduceActivity
        /// class with required arguments.
        /// </summary>
        public HDInsightMapReduceActivity(string className, string jarFilePath)
            : this()
        {
            Ensure.IsNotNullOrEmpty(className, "className");
            Ensure.IsNotNullOrEmpty(jarFilePath, "jarFilePath");

            this.ClassName = className;
            this.JarFilePath = jarFilePath;
        }
    }
}
