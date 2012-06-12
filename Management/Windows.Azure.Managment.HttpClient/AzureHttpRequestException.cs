using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;

namespace Windows.Azure.Management.v1_7
{
    [Serializable]
    public class AzureHttpRequestException : HttpRequestException
    {
        private AzureHttpRequestException() { }
        private AzureHttpRequestException(String message): base(message) { }
        private AzureHttpRequestException(String message, Exception inner) : base(message, inner) { }

        internal AzureHttpRequestException(HttpResponseMessage response)
        {
            this.RequestUri = response.RequestMessage.RequestUri;

            this.StatusCode = response.StatusCode;
            try
            {
                ErrorInfo info = response.Content.ReadAsSync<ErrorInfo>(new XmlMediaTypeFormatter { UseXmlSerializer = false });
                this.AzureErrorInfo = info;
            }
            catch (Exception)
            {
            }
        }

        public AzureHttpRequestException(OperationStatusInfo statusInfo)
        {
            this.StatusCode = statusInfo.HttpStatusCode.Value;

            this.AzureErrorInfo = statusInfo.ErrorInfo;

        }

        public override string Message
        {
            get
            {
                if (this._message == null)
                {
                    ConstructMessage();
                }
                return this._message;
            }
        }

        public Uri RequestUri { get; private set; } 
        public HttpStatusCode StatusCode { get; private set; }

        public ErrorInfo AzureErrorInfo
        {
            get;
            private set;
        }

        private void ConstructMessage()
        {
            String message = String.Format(Resources.AzureRequestExceptionBaseMessage, this.RequestUri, (int)this.StatusCode, this.StatusCode.ToString());
            if (this.AzureErrorInfo != null)
            {
                message = message + String.Format(Resources.AzureRequestExceptionAdditionalInfo, this.AzureErrorInfo.Code, this.AzureErrorInfo.Message);
            }

            this._message = message;
        }

        private String _message;
    }
}
