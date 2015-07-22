namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers
{
    using System;
    using System.Net.Http;
    using System.Threading;

    /// <summary>
    /// This attribute adds a custom header each of othe the http requests. 
    /// To add multiple headers add multiple copies of this attribute to the interface method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method , AllowMultiple = true)]
    internal sealed class CustomHeaderAttribute : Attribute, IHttpMessageProcessingHandler
    {
        private readonly string _headerName;
        private readonly string _headerValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHeaderAttribute"/> class.
        /// </summary>
        /// <param name="headerName">Name of the header.</param>
        /// <param name="headerValue">The header value.</param>
        public CustomHeaderAttribute(string headerName, string headerValue)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(headerName));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(headerValue));

            this._headerName = headerName;
            this._headerValue = headerValue;
        }

        private class AddCustomHeaderHandler : DelegatingHandler
        {
            private readonly CustomHeaderAttribute _parent;

            public AddCustomHeaderHandler(CustomHeaderAttribute parent)
            {
                this._parent = parent;
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Validated by the runtime.", MessageId = "0")]
            protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add(this._parent._headerName, this._parent._headerValue);
                return base.SendAsync(request, cancellationToken);
            }
        }

        public DelegatingHandler CreateHandler()
        {
            return new AddCustomHeaderHandler(this);
        }
    }
}
