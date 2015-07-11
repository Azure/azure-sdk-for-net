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
    /// Parameters specifying the pipeline to be created or updated.
    /// </summary>
    public class PipelineCreateOrUpdateParameters
    {
        /// <summary>
        /// The pipeline instance.
        /// </summary>
        public Pipeline Pipeline { get; set; }

        public PipelineCreateOrUpdateParameters()
        {
        }

        public PipelineCreateOrUpdateParameters(Pipeline pipeline)
            : this()
        {
            Ensure.IsNotNull(pipeline, "pipeline");
            this.Pipeline = pipeline;
        }
    }
}
