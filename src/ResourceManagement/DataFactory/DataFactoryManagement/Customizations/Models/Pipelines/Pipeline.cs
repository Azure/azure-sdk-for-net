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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A pipeline defines activities.
    /// </summary>
    public class Pipeline
    {
        /// <summary>
        /// Name of the pipeline.
        /// </summary>
        [AdfRequired]
        public string Name { get; set; }

        /// <summary>
        /// Pipeline properties.
        /// </summary>
        [AdfRequired]
        public PipelineProperties Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the Pipeline class.
        /// </summary>
        public Pipeline()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Pipeline class with required
        /// arguments.
        /// </summary>
        public Pipeline(string name, PipelineProperties properties)
            : this()
        {
            Ensure.IsNotNullOrEmpty(name, "name");
            Ensure.IsNotNull(properties, "properties");

            this.Name = name;
            this.Properties = properties;
        }
    }
}