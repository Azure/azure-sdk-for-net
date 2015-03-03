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

using System.Collections.Generic;
using Hyak.Common;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Response containing search results from an Azure Search index.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
    /// from the index.
    /// </typeparam>
    public class DocumentSearchResponse<T> : DocumentSearchResponseBase<SearchResult<T>, T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the DocumentSearchResponse class.
        /// </summary>
        public DocumentSearchResponse()
        {
            // Do nothing.
        }
    }
}
