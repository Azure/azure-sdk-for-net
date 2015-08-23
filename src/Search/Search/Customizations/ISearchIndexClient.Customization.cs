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

using System;

namespace Microsoft.Azure.Search
{
    public partial interface ISearchIndexClient
    {
        /// <summary>
        /// Indicates whether the index client should use HTTP GET for making Search and Suggest requests to the
        /// Azure Search REST API. The default is <c>false</c>, which indicates that HTTP POST will be used.
        /// </summary>
        bool UseHttpGetForQueries { get; set; }

        /// <summary>
        /// Adds the given tracking ID to the HTTP request headers.
        /// </summary>
        /// <param name="guid">Tracking ID to add to the request.</param>
        void SetClientRequestId(Guid guid);
    }
}
