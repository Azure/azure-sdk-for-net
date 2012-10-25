// -----------------------------------------------------------------------------------------
// <copyright file="HttpResponseAdapterMessage.cs" company="Microsoft">
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

    internal class HttpResponseAdapterMessage : IODataResponseMessage
    {
        private HttpResponseMessage resp = null;
        private Stream str = null;

        public HttpResponseAdapterMessage(HttpResponseMessage resp, Stream str)
        {
            this.resp = resp;
            this.str = str;
        }

        public Task<Stream> GetStreamAsync()
        {
            return Task.Factory.StartNew(() => this.str);
        }

        public string GetHeader(string headerName)
        {
            switch (headerName)
            {
                case "Content-Type":
                    return this.resp.Content.Headers.ContentType != null ? this.resp.Content.Headers.ContentType.ToString() : null;
                case "Content-Range":
                    return this.resp.Content.Headers.ContentRange != null ? this.resp.Content.Headers.ContentRange.ToString() : null;
                case "Content-MD5":
                    return this.resp.Content.Headers.ContentMD5 != null ? Convert.ToBase64String(this.resp.Content.Headers.ContentMD5) : null;
                case "Content-Location":
                    return this.resp.Content.Headers.ContentLocation != null ? this.resp.Content.Headers.ContentLocation.ToString() : null;
                case "Content-Length":
                    return this.resp.Content.Headers.ContentLength != null ? this.resp.Content.Headers.ContentLength.ToString() : null;
                case "Content-Language":
                    return this.resp.Content.Headers.ContentLanguage != null ? this.resp.Content.Headers.ContentLanguage.ToString() : null;
                case "Content-Encoding":
                    return this.resp.Content.Headers.ContentEncoding != null ? this.resp.Content.Headers.ContentEncoding.ToString() : null;
                case "Content-Disposition":
                    return this.resp.Content.Headers.ContentDisposition != null ? this.resp.Content.Headers.ContentDisposition.ToString() : null;
                default:
                    return this.resp.Content.Headers.Contains(headerName) ? this.resp.Content.Headers.GetValues(headerName).First() : null;
            }
        }

        public Stream GetStream()
        {
            return this.str;
        }

        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get { return this.resp.Headers.Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value.FirstOrDefault())); }
        }

        public void SetHeader(string headerName, string headerValue)
        {
            throw new NotImplementedException();
        }

        public int StatusCode
        {
            get
            {
                return (int)this.resp.StatusCode;
            }

            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
