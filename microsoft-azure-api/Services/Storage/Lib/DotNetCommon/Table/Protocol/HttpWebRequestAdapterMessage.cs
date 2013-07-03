// -----------------------------------------------------------------------------------------
// <copyright file="HttpWebRequestAdapterMessage.cs" company="Microsoft">
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
    using Microsoft.Data.OData;
    using Microsoft.WindowsAzure.Storage.Core;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net;

    internal class HttpWebRequestAdapterMessage : IODataRequestMessage, IDisposable
    {
        public HttpWebRequestAdapterMessage(HttpWebRequest msg, IBufferManager buffManager)
        {
            this.msg = msg;
            this.outStr = new MultiBufferMemoryStream(buffManager);
        }

        private HttpWebRequest msg = null;

        private MultiBufferMemoryStream outStr = null;

        public HttpWebRequest GetPopulatedMessage()
        {
            this.outStr.Seek(0, SeekOrigin.Begin);
            this.msg.ContentLength = this.outStr.Length;
            return this.msg;
        }

        public string GetHeader(string headerName)
        {
            if (headerName == "Content-Type")
            {
                return this.msg.ContentType;
            }

            return this.msg.Headers[headerName];
        }

        public Stream GetStream()
        {
            return this.outStr;
        }

        public System.Collections.Generic.IEnumerable<KeyValuePair<string, string>> Headers
        {
            get
            {
                List<KeyValuePair<string, string>> retHeaders = new List<KeyValuePair<string, string>>();

                foreach (string key in this.msg.Headers.AllKeys)
                {
                    retHeaders.Add(new KeyValuePair<string, string>(key, this.msg.Headers[key]));
                }

                return retHeaders;
            }
        }

        public string Method
        {
            get
            {
                return this.msg.Method;
            }

            set
            {
                this.msg.Method = value;
            }
        }

        public void SetHeader(string headerName, string headerValue)
        {
            if (headerName == "Content-Type")
            {
                this.msg.ContentType = headerValue;
            }
            else
            {
                this.msg.Headers[headerName] = headerValue;
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
                throw new NotSupportedException();
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", Justification = "The memory stream is used after this adapter message is disposed", MessageId = "outStr")]
        public void Dispose()
        {
            this.msg = null;
            this.outStr = null;
        }
    }
}
