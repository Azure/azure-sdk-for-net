namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// A class to derive from for concrete implementations of <see cref="IRequestFormatter"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Correct", MessageId = "Attributebase"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Correct")]
    internal abstract class HttpRestRequestFormatterAttributebase : Attribute, IRequestFormatter
    {
        /// <summary>
        /// Gets the request formatter used to serialize the object content.
        /// </summary>
        /// <value>
        /// The request formatter.
        /// </value>
        public abstract MediaTypeFormatter RequestFormatter { get; }
    }
}