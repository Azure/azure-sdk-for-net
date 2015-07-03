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
    /// HDInsight streaming activity.
    /// </summary>
    [AdfTypeName("HDInsightStreaming")]
    public class HDInsightStreamingActivity : HDInsightActivityBase
    {
        /// <summary>
        /// Mapper executable name.
        /// </summary>
        [AdfRequired]
        public string Mapper { get; set; }

        /// <summary>
        /// Reducer executable name.
        /// </summary>
        [AdfRequired]
        public string Reducer { get; set; }

        /// <summary>
        /// Input blob path.
        /// </summary>
        [AdfRequired]
        public string Input { get; set; }

        /// <summary>
        /// Output blob path.
        /// </summary>
        [AdfRequired]
        public string Output { get; set; }

        /// <summary>
        /// Paths to streaming job files. Can be directories.
        /// </summary>
        [AdfRequired]
        public IList<string> FilePaths { get; set; }

        /// <summary>
        /// Linked service where the files are located.
        /// </summary>
        public string FileLinkedService { get; set; }

        /// <summary>
        /// Combiner executable name.
        /// </summary>
        public string Combiner { get; set; }

        /// <summary>
        /// Command line environment values.
        /// </summary>
        public IList<string> CommandEnvironment { get; set; }

        /// <summary>
        /// Allows user to specify defines for streaming job request.
        /// </summary>
        public IDictionary<string, string> Defines { get; set; }

        /// <summary>
        /// Initializes a new instance of the HDInsightStreamingActivity class.
        /// </summary>
        public HDInsightStreamingActivity()
        {
            this.CommandEnvironment = new List<string>();
            this.Defines = new Dictionary<string, string>();
            this.FilePaths = new List<string>();
        }
    }
}
