namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// The default JSON serializer for the <see cref="HttpRestClient{TServiceInterface}"/>.
    /// </summary>
    internal sealed class JsonRequestFormatter : HttpRestRequestFormatterAttributebase
    {
        private static readonly Lazy<MediaTypeFormatter> _mediaTypeFormatter = new Lazy<MediaTypeFormatter>(() => new JsonMediaTypeFormatter());
    
        public override MediaTypeFormatter RequestFormatter
        {
            get { return _mediaTypeFormatter.Value; }
        }
    }
}