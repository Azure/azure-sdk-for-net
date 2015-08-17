namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters
{
    using System;
    using System.Net.Http;
    using Microsoft.HDInsight.Net.Http.Formatting;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// The default json serializer for the <see cref="HttpRestClient{TServiceInterface}"/>.
    /// </summary>
    internal sealed class JsonResponseFormatter : HttpRestResponseFormatterAttributebase
    {
        /// <summary>
        /// The default formatters collection.
        /// </summary>
        private static readonly Lazy<MediaTypeFormatterCollection> DefaultFormattersCollection = new Lazy<MediaTypeFormatterCollection>(()
                                                                                                                                         =>
        {
            var retval = new MediaTypeFormatterCollection();
            retval.Clear();
            retval.Add(new JsonMediaTypeFormatter());
            return retval;
        });

        /// <summary>
        /// Gets the request formatter used to serialize the <see cref="ObjectContent"/>.
        /// </summary>
        /// <value>
        /// The request formatter.
        /// </value>
        public override MediaTypeFormatterCollection ResponseFormatters
        {
            get { return DefaultFormattersCollection.Value; }
        }
    }
}