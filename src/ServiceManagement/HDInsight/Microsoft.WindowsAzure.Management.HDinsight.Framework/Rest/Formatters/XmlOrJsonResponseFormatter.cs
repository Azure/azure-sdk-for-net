namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// An Xml or JSON response formatter.
    /// </summary>
    internal sealed class XmlOrJsonResponseFormatter : HttpRestResponseFormatterAttributebase
    {
        private static readonly Lazy<MediaTypeFormatterCollection> _defaultFormattersCollection = new Lazy<MediaTypeFormatterCollection>(()
            //The default mediatype formatter collection contains
            //both Xml and Json media type formatters
                                                                       => new MediaTypeFormatterCollection());

        /// <summary>
        /// Gets the response formatters.
        /// </summary>
        /// <value>
        /// The response formatters.
        /// </value>
        public override MediaTypeFormatterCollection ResponseFormatters
        {
            get { return _defaultFormattersCollection.Value; }
        }
    }
}