namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System.Net.Http;

    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;

    /// <summary>
    /// This interface gives you the ability to intercept and modify <see cref="HttpRequestMessage"/> and <see cref="HttpResponseMessage"/>  objects 
    /// for the proxy
    /// Once can implement this interface for logging etc. adding custom header to http request, performing validations etc.
    /// </summary>
    /// <remarks>
    /// There are two ways to use this. 
    /// 1. Inherit from this interface and create an attribute, then tag the appropriate interface method with the attribute. Refer to the implementation of <see cref="ExpectedStatusCodeValidatorAttribute"/>
    /// 2. Inheit from this interface and add an instance of this to the MessageProcessingHandlers collection in <see cref="HttpRestClientConfiguration"/>.
    /// </remarks>
    public interface IHttpMessageProcessingHandler
    {
        /// <summary>
        /// Gets the message processing handler.
        /// </summary>
        /// <returns>A new instance of the message processing handler.</returns>
        /// <remarks>
        /// This method should return a new handler every time for it to be thread safe.
        /// </remarks>
        /// <value>
        /// The message processing handler.
        /// </value>
        DelegatingHandler CreateHandler();
    }
}
