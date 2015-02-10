namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// A base class to implement custom response content deserialization.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Correct", MessageId = "Attributebase"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Correct")]
    internal abstract class HttpRestResponseFormatterAttributebase : Attribute, IResponseFormatter
    {
        /// <summary>
        /// Gets the response formatters.
        /// </summary>
        /// <value>
        /// The response formatters.
        /// </value>
        public abstract MediaTypeFormatterCollection ResponseFormatters { get; }
    }
}