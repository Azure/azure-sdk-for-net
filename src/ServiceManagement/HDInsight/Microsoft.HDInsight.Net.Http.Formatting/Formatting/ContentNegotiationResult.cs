// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Represents the result of content negotiation performed using
    /// <see cref="IContentNegotiator.Negotiate(Type, HttpRequestMessage, System.Collections.Generic.IEnumerable{Microsoft.HDInsight.Net.Http.Formatting.Formatting.MediaTypeFormatter})"/>
    /// </summary>
    internal class ContentNegotiationResult
    {
        private MediaTypeFormatter _formatter;

        /// <summary>
        /// Create the content negotiation result object.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        /// <param name="mediaType">The preferred media type. Can be <c>null</c>.</param>
        public ContentNegotiationResult(MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            this._formatter = formatter;
            this.MediaType = mediaType;
        }

        /// <summary>
        /// The formatter chosen for serialization.
        /// </summary>
        public MediaTypeFormatter Formatter
        {
            get { return this._formatter; }
            set
            {
                if (value == null)
                {
                    throw Error.ArgumentNull("value");
                }
                this._formatter = value;
            }
        }

        /// <summary>
        /// The media type that is associated with the formatter chosen for serialization. Can be <c>null</c>.
        /// </summary>
        public MediaTypeHeaderValue MediaType { get; set; }
    }
}
