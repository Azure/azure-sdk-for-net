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
    /// Write behavior when upserting documents into an Azure Search Index.
    /// A property of <see cref="AzureSearchIndexSink"/>.
    /// </summary>
    public static class AzureSearchIndexWriteBehavior
    {
        /// <summary>
        /// The document will be inserted if it is new and updated/replaced if it exists. 
        /// If an update is performed, all fields will be replaced.
        /// </summary>
        public const string Upload = "Upload";

        /// <summary>
        /// Merge updates an existing document with the specified fields. 
        /// Any field specified in a merge will replace the existing field in the document. 
        /// </summary>
        public const string Merge = "Merge";
    }
}
