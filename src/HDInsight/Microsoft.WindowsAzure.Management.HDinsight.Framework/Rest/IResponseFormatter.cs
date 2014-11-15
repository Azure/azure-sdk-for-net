namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// This is interface responsible deserializing the HttpResponseMessage content. You can specify
    /// multiple formatters in <see cref="MediaTypeFormatterCollection"/> and the runtime will pick the correct one.
    /// </summary>
    internal interface IResponseFormatter
    {
        /// <summary>
        /// Gets the response formatters.
        /// </summary>
        /// <value>
        /// The response formatters.
        /// </value>
        MediaTypeFormatterCollection ResponseFormatters { get; }
    }
}