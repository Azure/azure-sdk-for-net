namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;

    /// <summary>
    /// Rest Invoke attribute describes a Rest call on an interface method.
    /// </summary>
    internal sealed class HttpRestInvoke : Attribute
    {
        /// <summary>
        /// Gets the URI template.
        /// </summary>
        /// <value>
        /// The URI template.
        /// </value>
        public string UriTemplate { get; private set; }

        /// <summary>
        /// Gets the HTTP method.
        /// </summary>
        /// <value>
        /// The HTTP method.
        /// </value>
        public string HttpMethod { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRestInvoke"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="uriTemplate">The URI template.</param>
        public HttpRestInvoke(string httpMethod, string uriTemplate)
        {
            this.HttpMethod = httpMethod;
            this.UriTemplate = uriTemplate;
        }

    }
}
