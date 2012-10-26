// -----------------------------------------------------------------------------------------
// <copyright file="HttpRequestAdapterMessage.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Data.OData;

    internal class HttpRequestAdapterMessage : IODataRequestMessage, IDisposable
    {
        public HttpRequestMessage GetPopulatedMessage()
        {
            this.msg.Content = this.content;
            this.outStr.Seek(0, SeekOrigin.Begin);
            return this.msg;
        }

        // Summary:
        //     Initializes a new instance of the System.Net.Http.HttpRequestMessage class.
        public HttpRequestAdapterMessage(HttpRequestMessage msg)
        {
            this.msg = msg;
            this.outStr = new MemoryStream();
            this.content = new StreamContent(this.outStr);
        }

        private StreamContent content = null;

        private HttpRequestMessage msg = null;

        private MemoryStream outStr = null;

        public string GetHeader(string headerName)
        {
            switch (headerName)
            {
                case "Content-Type":
                    return this.content.Headers.ContentType != null ? this.content.Headers.ContentType.ToString() : null;
                case "Content-Range":
                    return this.content.Headers.ContentRange != null ? this.content.Headers.ContentRange.ToString() : null;
                case "Content-MD5":
                    return this.content.Headers.ContentMD5 != null ? Convert.ToBase64String(this.content.Headers.ContentMD5) : null;
                case "Content-Location":
                    return this.content.Headers.ContentLocation != null ? this.content.Headers.ContentLocation.ToString() : null;
                case "Content-Length":
                    return this.content.Headers.ContentLength != null ? this.content.Headers.ContentLength.ToString() : null;
                case "Content-Language":
                    return this.content.Headers.ContentLanguage != null ? this.content.Headers.ContentLanguage.ToString() : null;
                case "Content-Encoding":
                    return this.content.Headers.ContentEncoding != null ? this.content.Headers.ContentEncoding.ToString() : null;
                case "Content-Disposition":
                    return this.content.Headers.ContentDisposition != null ? this.content.Headers.ContentDisposition.ToString() : null;
                default:
                    return this.content.Headers.Contains(headerName) ? this.content.Headers.GetValues(headerName).First() : null;
            }
        }

        public Stream GetStream()
        {
            return this.outStr;
        }

        public System.Collections.Generic.IEnumerable<KeyValuePair<string, string>> Headers
        {
            get { return this.msg.Headers.Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value.FirstOrDefault())); }
        }

        public string Method
        {
            get
            {
                return this.msg.Method.Method;
            }

            set
            {
                this.msg.Method = new HttpMethod(value);
            }
        }

        public void SetHeader(string headerName, string headerValue)
        {
            if (headerName.StartsWith("Content-"))
            {
                this.content.Headers.Add(headerName, headerValue);
            }
            else
            {
                this.msg.Headers.Add(headerName, headerValue);
            }
        }

        public Uri Url
        {
            get
            {
                return this.msg.RequestUri;
            }

            set
            {
                this.msg.RequestUri = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", Justification = "Members used after adaptermessage is disposed")]
        public void Dispose()
        {
            this.msg = null;
            this.outStr = null;
            this.content = null;
        }
    }
}
