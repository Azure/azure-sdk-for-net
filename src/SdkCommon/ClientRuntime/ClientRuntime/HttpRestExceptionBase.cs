namespace Microsoft.Rest
{
    public abstract class HttpRestExceptionBase<V> : RestException, IHttpRestException<V>
    {
        
        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        public HttpRestExceptionBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public HttpRestExceptionBase(string message)
            : base(message, null)
        {
        }

        public HttpRestExceptionBase(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }

        protected V Body { get; set; }

        public void SetErrorModel(V model)
        {
            this.Body = model;
        }

        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response { get; set; }
        
    }
}