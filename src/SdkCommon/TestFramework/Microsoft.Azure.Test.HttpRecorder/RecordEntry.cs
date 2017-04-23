﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Microsoft.Azure.Test.HttpRecorder
{
    public class RecordEntry
    {
        public string RequestUri { get; set; }

        /// <summary>
        /// The request URi as a base64 string - removes encoding issues in matching
        /// </summary>
        public string EncodedRequestUri { get; set; }

        public string RequestMethod { get; set; }

        public string RequestBody { get; set; }

        public Dictionary<string, List<string>> RequestHeaders { get; set; }

        public string ResponseBody { get; set; }

        public Dictionary<string, List<string>> ResponseHeaders { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public RecordEntry()
        {
            
        }

        public RecordEntry(HttpResponseMessage response)
        {
            HttpRequestMessage request = response.RequestMessage;
            RequestUri = request.RequestUri.ToString();
            EncodedRequestUri = Utilities.EncodeUriAsBase64(request.RequestUri);
            RequestMethod = request.Method.Method;
            RequestHeaders = new Dictionary<string, List<string>>();
            if (request.Content != null)
            {
                RequestBody = Utilities.FormatString(request.Content.ReadAsStringAsync().Result);
                request.Content.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            }
            else
            {
                RequestBody = string.Empty;
            }
            request.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));

            ResponseHeaders = new Dictionary<string, List<string>>();
            if (response.Content != null)
            {
                ResponseBody = Utilities.FormatString(response.Content.ReadAsStringAsync().Result);
                response.Content.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));
            }
            else
            {
                ResponseBody = string.Empty;
            }
            response.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));

            StatusCode = response.StatusCode;
        }

        public HttpResponseMessage GetResponse()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = StatusCode;
            ResponseHeaders.ForEach(h => response.Headers.TryAddWithoutValidation(h.Key, h.Value));
            response.Content = new StringContent(ResponseBody);

            return response;
        }
    }
}
