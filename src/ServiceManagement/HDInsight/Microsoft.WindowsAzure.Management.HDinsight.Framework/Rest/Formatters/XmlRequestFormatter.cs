namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// This is the default xml request formatter for <see cref="HttpRestClient{TServiceInterface}"/>.
    /// </summary>
    internal sealed class XmlRequestFormatter : HttpRestRequestFormatterAttributebase
    {
        /// <summary>
        /// The media type formatter.
        /// </summary>
        private static readonly Lazy<MediaTypeFormatter> _mediaTypeFormatter = new Lazy<MediaTypeFormatter>(() => new XmlMediaTypeFormatter());

        /// <summary>
        /// Gets the request formatter used to serialize the object content.
        /// </summary>
        /// <value>
        /// The request formatter.
        /// </value>
        public override MediaTypeFormatter RequestFormatter
        {
            get { return _mediaTypeFormatter.Value; }
        }
    }
}
