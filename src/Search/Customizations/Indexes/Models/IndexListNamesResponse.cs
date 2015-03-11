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
    /// Response from a List Index Names request. If successful, it includes
    /// the name of each index.
    /// </summary>
    public partial class IndexListNamesResponse : AzureOperationResponse, IEnumerable<string>
    {
        private IList<string> _indexNames;
        
        /// <summary>
        /// Optional. Gets the index names in the Search service.
        /// </summary>
        public IList<string> IndexNames
        {
            get { return this._indexNames; }
            set { this._indexNames = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the IndexListNamesResponse class.
        /// </summary>
        public IndexListNamesResponse()
        {
            this.IndexNames = new LazyList<string>();
        }
        
        /// <summary>
        /// Gets the sequence of IndexNames.
        /// </summary>
        public IEnumerator<string> GetEnumerator()
        {
            return this.IndexNames.GetEnumerator();
        }
        
        /// <summary>
        /// Gets the sequence of IndexNames.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
