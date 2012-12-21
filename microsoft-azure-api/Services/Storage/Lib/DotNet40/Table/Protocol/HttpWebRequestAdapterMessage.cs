namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using Microsoft.Data.OData;

    internal class HttpWebRequestAdapterMessage : IODataRequestMessage, IDisposable
    {
        public HttpWebRequest GetPopulatedMessage()
        {
            this.outStr.Seek(0, SeekOrigin.Begin);
            this.msg.ContentLength = this.outStr.Length;
            return this.msg;
        }

        // Summary:
        //     Initializes a new instance of the System.Net.Http.HttpRequestMessage class.
        public HttpWebRequestAdapterMessage(HttpWebRequest msg)
        {
            this.msg = msg;
            this.outStr = new MemoryStream();
        }

        private HttpWebRequest msg = null;

        private MemoryStream outStr = null;

        public string GetHeader(string headerName)
        {
            if (headerName == "Content-Type")
            {
                return this.msg.ContentType;
            }

            return this.msg.Headers.Get(headerName);
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

                foreach (string key in this.msg.Headers.Keys)
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
                throw new NotSupportedException();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", Justification = "The memory stream is used after this adapter message is disposed",  MessageId = "outStr")]
        public void Dispose()
        {
            this.msg = null;
            this.outStr = null;
        }
    }
}
