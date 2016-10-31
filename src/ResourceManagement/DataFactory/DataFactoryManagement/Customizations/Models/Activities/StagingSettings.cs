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
    /// Interim staging settings
    /// </summary>
    public class StagingSettings
    {
        /// <summary>
        /// Name of the Azure Storage linked service used as an interim staging. 
        /// Must be specified if copy via staging is enbled.
        /// </summary>
        [AdfRequired]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Optional. The storage path for storing the interim data.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Optional. Specifies whether to use compression when copy data via an interim staging.
        /// Default value is false.
        /// </summary>
        public bool? EnableCompression { get; set; }
    }
}