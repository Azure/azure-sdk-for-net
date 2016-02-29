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
    /// Data Lake Analytics U-SQL activity.
    /// </summary>
    [AdfTypeName("DataLakeAnalyticsU-SQL")]
    public class DataLakeAnalyticsUSQLActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Optional. The plaintext U-SQL script. This cannot be used at the same time as <see cref="ScriptPath"/> and <see cref="ScriptLinkedService"/>.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// Optional. The path to the U-SQL script in the ScriptLinkedService. This needs to be used at the same time as <see cref="ScriptLinkedService"/>.
        /// </summary>
        public string ScriptPath { get; set; }

        /// <summary>
        /// Optional. The linked service hosting the U-SQL script. This needs to be used at the same time as <see cref="ScriptPath"/>.
        /// </summary>
        public string ScriptLinkedService { get; set; }

        /// <summary>
        /// Optional. Runtime version of U-SQL engine to use.
        /// </summary>
        public string RuntimeVersion { get; set; }

        /// <summary>
        /// Optional. Compilation mode of U-SQL. Must be one of <see cref="USqlCompilationMode"/>.
        /// </summary>
        public string CompilationMode { get; set; }

        /// <summary>
        /// Optional. Also known as BAUs (Big Analytics Units), or the maximum number of nodes that will be used simultaneously to run the job.
        /// </summary>
        public int? DegreeOfParallelism { get; set; }

        /// <summary>
        /// Optional. Determines which jobs out of all that are queued should be selected to run first. The lower the number, the higher the priority (minimum is 0).
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Optional. Allows user to specify parameters for the U-SQL activity.
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeAnalyticsUSQLActivity"/>.
        /// </summary>
        public DataLakeAnalyticsUSQLActivity()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeAnalyticsUSQLActivity"/>
        /// with a plaintext script.
        /// </summary>
        public DataLakeAnalyticsUSQLActivity(string script)
            : this()
        {
            Ensure.IsNotNullOrEmpty(script, "script");

            this.Script = script;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeAnalyticsUSQLActivity"/>
        /// with script in linked service.
        /// </summary>
        public DataLakeAnalyticsUSQLActivity(string scriptPath, string scriptLinkedService)
            : this()
        {
            Ensure.IsNotNullOrEmpty(scriptPath, "scriptPath");
            Ensure.IsNotNullOrEmpty(scriptLinkedService, "scriptLinkedService");

            this.ScriptPath = scriptPath;
            this.ScriptLinkedService = scriptLinkedService;
        }
    }
}
