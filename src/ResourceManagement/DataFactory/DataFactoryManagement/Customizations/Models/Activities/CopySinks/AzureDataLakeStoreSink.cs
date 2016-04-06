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
    /// Azure Data Lake Store sink.
    /// </summary>
    public class AzureDataLakeStoreSink : CopySink
    {
        /// <summary>
        /// Optional. The type of copy behavior for copy sink.
        /// <see cref="CopyBehaviorType"/>
        /// </summary>
        public string CopyBehavior { get; set; }

        /// <summary>
        /// Initalizes a new instance of the <see cref="AzureDataLakeStoreSink"/> class.
        /// </summary>
        public AzureDataLakeStoreSink()
        {
        }
    }
}