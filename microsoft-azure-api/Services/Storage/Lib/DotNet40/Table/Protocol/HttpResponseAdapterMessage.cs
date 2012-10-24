namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using Microsoft.Data.OData;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    internal class HttpResponseAdapterMessage : IODataResponseMessage
    {
        private HttpWebResponse resp = null;
        private Stream str = null;

        public HttpResponseAdapterMessage(HttpWebResponse resp, Stream str)
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
            if (headerName == "Content-Type")
            {
                return this.resp.ContentType;
            }
            else if (headerName == "Content-Encoding")
            {
                return this.resp.ContentEncoding;
            }

            return this.resp.GetResponseHeader(headerName);
        }

        public Stream GetStream()
        {
            return this.str;
        }

        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get
            {
                List<KeyValuePair<string, string>> retHeaders = new List<KeyValuePair<string, string>>();

                foreach (string key in this.resp.Headers.Keys)
                {
                    retHeaders.Add(new KeyValuePair<string, string>(key, this.resp.Headers[key]));
                }

                return retHeaders;
            }
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
