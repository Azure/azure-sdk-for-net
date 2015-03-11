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
using System.Linq;
using System.Net.Http;
using Hyak.Common;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
{
    /// <summary>
    /// Exception thrown when an indexing operation only partially succeeds.
    /// </summary>
    public class IndexBatchException : CloudException
    {
        private const string MessageFormat =
            "{0} of {1} indexing actions in the batch failed. The remaining actions succeeded and modified the " +
            "index. Check the IndexResponse property for the status of each index action.";

        private readonly DocumentIndexResponse _indexResponse;

        /// <summary>
        /// Initializes a new instance of the IndexBatchException class.
        /// </summary>
        /// <param name="httpRequest">The original HTTP index request.</param>
        /// <param name="httpResponse">The original HTTP index response.</param>
        /// <param name="indexResponse">The deserialized response from the index request.</param>
        public IndexBatchException(
            HttpRequestMessage httpRequest, 
            HttpResponseMessage httpResponse, 
            DocumentIndexResponse indexResponse) : base(CreateMessage(indexResponse))
        {
            // Null check in CreateMessage().
            _indexResponse = indexResponse;

            Error =
                new CloudError()
                {
                    Code = String.Empty,
                    Message = this.Message,
                    OriginalMessage = this.Message,
                    ResponseBody = String.Empty
                };

            Request = CloudHttpRequestErrorInfo.Create(httpRequest);
            Response = CloudHttpResponseErrorInfo.Create(httpResponse);
        }

        /// <summary>
        /// Gets the response for the index batch that contains the status for each individual index action.
        /// </summary>
        public DocumentIndexResponse IndexResponse
        {
            get { return _indexResponse; }
        }

        private static string CreateMessage(DocumentIndexResponse indexResponse)
        {
            if (indexResponse == null)
            {
                throw new ArgumentNullException("indexResponse");
            }

            return String.Format(
                MessageFormat, 
                indexResponse.Results.Count(r => !r.Succeeded),
                indexResponse.Results.Count);
        }
    }
}
