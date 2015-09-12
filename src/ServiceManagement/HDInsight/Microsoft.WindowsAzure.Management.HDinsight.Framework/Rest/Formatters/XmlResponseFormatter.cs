namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// An XML response formatter for Rest Requests.
    /// </summary>
    internal sealed class XmlResponseFormatter : HttpRestResponseFormatterAttributebase
    {
        private static readonly Lazy<MediaTypeFormatterCollection> _defaultFormattersCollection = new Lazy<MediaTypeFormatterCollection>(()
                                                                                                                                         =>
            {
                var retval = new MediaTypeFormatterCollection();
                retval.Clear();
                retval.Add(new XmlMediaTypeFormatter());
                return retval;
            });

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
