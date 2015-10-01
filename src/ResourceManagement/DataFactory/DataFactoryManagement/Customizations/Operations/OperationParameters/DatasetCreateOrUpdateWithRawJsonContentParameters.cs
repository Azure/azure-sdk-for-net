// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Parameters specifying the raw json content for creating or updating a
    /// Dataset.
    /// </summary>
    public class DatasetCreateOrUpdateWithRawJsonContentParameters
    {
        /// <summary>
        /// Required. The user specified raw json content for creating or
        /// updating a Linked Service.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// DatasetCreateOrUpdateWithRawJsonContentParameters class.
        /// </summary>
        public DatasetCreateOrUpdateWithRawJsonContentParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// DatasetCreateOrUpdateWithRawJsonContentParameters class with
        /// required arguments.
        /// </summary>
        public DatasetCreateOrUpdateWithRawJsonContentParameters(string content)
            : this()
        {
            Ensure.IsNotNullOrEmpty(content, "content");
            this.Content = content;
        }

        internal DatasetCreateOrUpdateWithRawJsonContentParameters(
            Core.Models.DatasetCreateOrUpdateWithRawJsonContentParameters internalParameters)
            : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");
            this.Content = internalParameters.Content;
        }
    }
}
