// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Test.HttpRecorder
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    public class RecordEntry
    {
        public string RequestUri { get; set; }

        /// <summary>
        /// The request URi as a base64 string - removes encoding issues in matching
        /// </summary>
        public string EncodedRequestUri { get; set; }

        public string RequestMethod { get; set; }

        [JsonIgnore]
        public RecordEntryContentType RequestContentType { get; set; }
        
        public string RequestBody { get; set; }

        public Dictionary<string, List<string>> RequestHeaders { get; set; }

        [JsonIgnore]
        public RecordEntryContentType ResponseContentType { get; set; }
        public Dictionary<string, List<string>> ResponseHeaders { get; set; }

        public string ResponseBody { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public RecordEntry()
        {
            
        }

        public RecordEntry(RecordEntry recEntry) : this(recEntry.GetResponse())
        { }

        public RecordEntry(HttpResponseMessage response)
        {
            HttpRequestMessage request = response.RequestMessage;
            RequestUri = request.RequestUri.ToString();
            EncodedRequestUri = RecorderUtilities.EncodeUriAsBase64(request.RequestUri);
            RequestMethod = request.Method.Method;

            RequestHeaders = new Dictionary<string, List<string>>();
            ResponseHeaders = new Dictionary<string, List<string>>();

            RequestBody = string.Empty;
            ResponseBody = string.Empty;

            RequestContentType = DetectContentType(request.Content);
            ResponseContentType = DetectContentType(response.Content);

            request.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            response.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));

            StatusCode = response.StatusCode;

            //REQUEST
            if (RequestContentType != RecordEntryContentType.Null)            
            {
                RequestBody = RecorderUtilities.FormatHttpContent(request.Content);
                request.Content.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            }

            //RESPONSE
            if (ResponseContentType != RecordEntryContentType.Null)            
            {
                ResponseBody = RecorderUtilities.FormatHttpContent(response.Content);
                response.Content.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));
            }
        }

        public HttpResponseMessage GetResponse()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = StatusCode;
            ResponseHeaders.ForEach(h => response.Headers.TryAddWithoutValidation(h.Key, h.Value));
            response.Content = RecorderUtilities.CreateHttpContent(ResponseBody);
            ResponseHeaders.ForEach(h => response.Content.Headers.TryAddWithoutValidation(h.Key, h.Value));
            return response;
        }

        private RecordEntryContentType DetectContentType(HttpContent content)
        {
            RecordEntryContentType contentType = RecordEntryContentType.Null;

            if(content != null)
            {
                if(RecorderUtilities.IsHttpContentBinary(content))
                {
                    contentType = RecordEntryContentType.Binary;
                }
                else
                {
                    contentType = RecordEntryContentType.Ascii;
                }
            }

            return contentType;
        }
    }

    /// <summary>
    /// Request/Response content type enum
    /// </summary>
    public enum RecordEntryContentType
    {
        Binary,
        Ascii,
        Null
    }
}
