namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System.Net.Http;
    using Microsoft.HDInsight.Net.Http.Formatting;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// This is the interface responsible for converting the the http message content to bytes on the network.
    /// </summary>
    internal interface IRequestFormatter
    {
        /// <summary>
        /// Gets the request formatter used to serialize the <see cref="ObjectContent"/>.
        /// </summary>
        /// <value>
        /// The request formatter.
        /// </value>
        MediaTypeFormatter RequestFormatter { get; }

    }
}