// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.Test.HttpRecorder
{
    /// <summary>
    /// This class does a simple mapping between given request and responses.
    /// The hashing algorithm works by combining the HTTP method of the request
    /// plus the request uri together. Optionally a key-value pair of headers
    /// can be added to the key.
    /// </summary>
    public class SimpleRecordMatcher : IRecordMatcher
    {
        public HashSet<string> MatchingHeaders { get; private set; }

        public SimpleRecordMatcher()
        {
            MatchingHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public SimpleRecordMatcher(params string[] matchingHeaders)
        {
            MatchingHeaders = new HashSet<string>(matchingHeaders, StringComparer.OrdinalIgnoreCase);
        }

        private string GetMatchingKey(string httpMethod, string requestUri, Dictionary<string, List<string>> requestHeaders)
        {
            StringBuilder key = new StringBuilder(string.Format("{0} {1}", httpMethod, requestUri));

            if (requestHeaders != null)
            {
                foreach (var requestHeader in requestHeaders.OrderBy(h => h.Key))
                {
                    if (MatchingHeaders.Contains(requestHeader.Key))
                    {
                        key.AppendFormat(" ({0}={1})", requestHeader.Key, string.Join(",", requestHeader.Value));
                    }
                }
            }

            return key.ToString();
        }

        public string GetMatchingKey(RecordEntry recordEntry)
        {
            return GetMatchingKey(recordEntry.RequestMethod, 
                (recordEntry.EncodedRequestUri?? Utilities.EncodeUriAsBase64(recordEntry.RequestUri)),
                recordEntry.RequestHeaders);
        }

        public string GetMatchingKey(HttpRequestMessage request)
        {
            var requestHeaders = new Dictionary<string, List<string>>();
            request.Headers.ForEach(h => requestHeaders.Add(h.Key, h.Value.ToList()));
            if (request.Content != null)
            {
                request.Content.Headers.ForEach(h => requestHeaders.Add(h.Key, h.Value.ToList()));
            }
            return GetMatchingKey(request.Method.Method, Utilities.EncodeUriAsBase64(request.RequestUri), requestHeaders);
        }   
    }
}
