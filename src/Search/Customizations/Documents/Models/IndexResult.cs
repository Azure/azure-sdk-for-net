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

using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Status of an indexing operation for a single document. 
    /// </summary>
    public class IndexResult
    {
        [JsonProperty("key")]
        private string _key;

        [JsonProperty("status")]
        private bool _succeeded;

        [JsonProperty("errorMessage")]
        private string _errorMessage;

        /// <summary>
        /// Instantiates a new instance of the IndexResult class.
        /// </summary>
        public IndexResult()
        {
            _key = null;
            _succeeded = false;
            _errorMessage = null;
        }

        /// <summary>
        /// Gets the key of a document that was in the indexing request.
        /// </summary>
        public string Key
        {
            get { return _key; }
        }

        /// <summary>
        /// Gets a value indicating whether the indexing operation succeeded for the document identified by 
        /// <c cref="Microsoft.Azure.Search.Models.IndexResult.Key">Key</c>.
        /// </summary>
        public bool Succeeded
        {
            get { return _succeeded; }
        }

        /// <summary>
        /// Gets the error message explaining why the indexing operation failed for the document identified by " +
        /// <c cref="Microsoft.Azure.Search.Models.IndexResult.Key">Key</c>; <c>null</c> if
        /// <c cref="Microsoft.Azure.Search.Models.IndexResult.Succeeded">Succeeded</c> is <c>true</c>.
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}
