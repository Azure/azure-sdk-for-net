namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Represents a method that intercepts a request to the Batch service in order
    /// to modify the parameters.
    /// </summary>
    /// <param name="request">The parameters of the request being intercepted.</param>
    public delegate void BatchRequestModificationInterceptHandler(Protocol.IBatchRequest request);

    /// <summary>
    /// Represents a method that intercepts a request to the Batch service in order
    /// to replace the parameters and/or operation context.
    /// </summary>
    /// <param name="request">The parameters of the request being intercepted.</param>
    public delegate void BatchRequestReplacementInterceptHandler(ref Protocol.IBatchRequest request);

    /// <summary>
    /// Derived classes can inspect, replace or modify a BatchRequest.
    /// </summary>
    public class RequestReplacementInterceptor : BatchClientBehavior
    {
        /// <summary>
        /// Initializes a new instance of RequestReplacementInterceptor.
        /// </summary>
        public RequestReplacementInterceptor()
        {
            this.ReplacementInterceptHandler = RequestReplacementInterceptor.NOOP; // benign noop.
        }

        /// <summary>
        /// Initializes a new instance of RequestReplacementInterceptor
        /// </summary>
        /// <param name="replacementInterceptor"></param>
        public RequestReplacementInterceptor(BatchRequestReplacementInterceptHandler replacementInterceptor)
        {
            this.ReplacementInterceptHandler = replacementInterceptor;
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        private static void NOOP(ref Protocol.IBatchRequest request)
        {
        }

        /// <summary>
        /// Gets or sets a method that will be called just before a <see cref="IBatchRequest"/> is executed.
        /// The request can be inspected, replaced, modified or ignored.
        /// </summary>
        public BatchRequestReplacementInterceptHandler ReplacementInterceptHandler
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class enables an interceptor to inspect, modify or ignore a <see cref="IBatchRequest"/>.
    /// </summary>
    public class RequestInterceptor : RequestReplacementInterceptor
    {
        private BatchRequestModificationInterceptHandler _modInterceptor;

        /// <summary>
        /// Initializes a new instance of RequestInterceptor.
        /// </summary>
        public RequestInterceptor()
        {
            this.ModificationInterceptHandler = RequestInterceptor.NOOP; // benign default
        }

        /// <summary>
        /// Initializes a new instance of RequestInterceptor that calls a given BatchRequestModificationInterceptHandler.
        /// </summary>
        /// <param name="interceptor">A delegate that will be allowed to inspect, modify or ignore a BatchRequest.</param>
        public RequestInterceptor(BatchRequestModificationInterceptHandler interceptor)
        {
            this.ModificationInterceptHandler = interceptor;
        }

        /// <summary>
        /// Gets or sets the BatchRequestModificationInterceptHandler.
        /// </summary>
        public BatchRequestModificationInterceptHandler ModificationInterceptHandler
        {
            get
            {
                return _modInterceptor;
            }
            set
            {
                _modInterceptor = value;
                base.ReplacementInterceptHandler = this.ReplacementInterceptHandler;
            }
        }

        /// <summary>
        /// An interceptor that does nothing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static void NOOP(object request)
        {
        }

        /// <summary>
        /// A replacment interceptor that calls our modification interceptor.
        /// </summary>
        private new void ReplacementInterceptHandler(ref Protocol.IBatchRequest request)
        {
            _modInterceptor(request);
        }
    }
}
