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
    /// Parameters specifying the data factory linkedService raw json content
    /// for a create or update operation.
    /// </summary>
    public class LinkedServiceCreateOrUpdateWithRawJsonContentParameters
    {
        /// <summary>
        /// Required. The raw json content for a create or update data factory
        /// linkedService operation.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// LinkedServiceCreateOrUpdateWithRawJsonContentParameters class.
        /// </summary>
        public LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// LinkedServiceCreateOrUpdateWithRawJsonContentParameters class with
        /// required arguments.
        /// </summary>
        public LinkedServiceCreateOrUpdateWithRawJsonContentParameters(string content)
            : this()
        {
            Ensure.IsNotNullOrEmpty(content, "content");
            this.Content = content;
        }

        internal LinkedServiceCreateOrUpdateWithRawJsonContentParameters(
            Core.Models.LinkedServiceCreateOrUpdateWithRawJsonContentParameters internalParameters)
            : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");
            this.Content = internalParameters.Content;
        }
    }
}
