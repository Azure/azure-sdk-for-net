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

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Contains a document found by a suggestion query, plus associated metadata.
    /// </summary>
    public class SuggestResult : SuggestResultBase<Document>
    {
        /// <summary>
        /// Initializes a new instance of the SuggestResult class.
        /// </summary>
        public SuggestResult()
        {
            // Do nothing.
        }
    }
}
