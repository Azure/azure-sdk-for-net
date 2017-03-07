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
    /// A copy activity sink for an Azure Search Index.
    /// </summary>
    public class AzureSearchIndexSink : CopySink
    {
        /// <summary>
        /// Optional. Specifies how to upsert documents into an Azure Search Index.
        /// Must be one of <see cref="AzureSearchIndexWriteBehavior"/>. The default value is 'Merge' if no value is specified.
        /// </summary>
        public string WriteBehavior { get; set; }
    }
}
