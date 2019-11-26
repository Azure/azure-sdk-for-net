// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
                (recordEntry.EncodedRequestUri?? RecorderUtilities.EncodeUriAsBase64(recordEntry.RequestUri)),
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
            return GetMatchingKey(request.Method.Method, RecorderUtilities.EncodeUriAsBase64(request.RequestUri), requestHeaders);
        }   
    }
}
