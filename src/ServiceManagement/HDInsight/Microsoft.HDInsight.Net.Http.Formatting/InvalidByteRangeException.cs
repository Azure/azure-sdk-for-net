// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// An exception thrown by <see cref="ByteRangeStreamContent"/> in case none of the requested ranges 
    /// overlap with the current extend of the selected resource. The current extend of the resource
    /// is indicated in the ContentRange property.
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "Exception is not intended to be serialized.")]
    [SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly", Justification = "Exception is not intended to be serialized.")]
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "The ContentRange is a required parameter.")]
    internal class InvalidByteRangeException : Exception
    {
        public InvalidByteRangeException(ContentRangeHeaderValue contentRange)
        {
            this.Initialize(contentRange);
        }

        public InvalidByteRangeException(ContentRangeHeaderValue contentRange, string message)
            : base(message)
        {
            this.Initialize(contentRange);
        }

        public InvalidByteRangeException(ContentRangeHeaderValue contentRange, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Initialize(contentRange);
        }

        public InvalidByteRangeException(ContentRangeHeaderValue contentRange, SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Initialize(contentRange);
        }

        /// <summary>
        /// The current extend of the resource indicated in terms of a ContentRange header field.
        /// </summary>
        public ContentRangeHeaderValue ContentRange { get; private set; }

        private void Initialize(ContentRangeHeaderValue contentRange)
        {
            if (contentRange == null)
            {
                throw Error.ArgumentNull("contentRange");
            }
            this.ContentRange = contentRange;
        }
    }
}
