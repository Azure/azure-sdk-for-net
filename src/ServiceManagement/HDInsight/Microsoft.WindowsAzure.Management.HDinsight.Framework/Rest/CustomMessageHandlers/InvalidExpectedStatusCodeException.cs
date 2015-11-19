namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// An exception that is thrown when the web reponse status code does not match 
    /// the expected http statuscode for the response.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Justification = "Correct"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "Not serialized"),
     System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "Not serialized"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Not serialized")]
    internal class InvalidExpectedStatusCodeException : Exception
    {
        private readonly HttpResponseMessage _response;
        private readonly HttpStatusCode receivedStatusCode;
        private readonly HttpStatusCode[] _expectedStatusCodes;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Not localized", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        public InvalidExpectedStatusCodeException(HttpStatusCode receivedStatusCode, IEnumerable<HttpStatusCode> expectedStatusCodes, HttpResponseMessage response)
            : base(string.Format("Received status code '{0}' did not match expected '{1}'", receivedStatusCode, string.Join(",", expectedStatusCodes)))
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            this.receivedStatusCode = receivedStatusCode;
            this._expectedStatusCodes = expectedStatusCodes.ToArray();
            this._response = response;
        }

        public IEnumerable<HttpStatusCode> ExpectedStatusCodes
        {
            get { return this._expectedStatusCodes; }
        }

        public HttpStatusCode ReceivedStatusCode
        {
            get { return this.receivedStatusCode; }
        }

        public HttpResponseMessage Response
        {
            get { return this._response; }
        }
    }
}