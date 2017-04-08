// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Represents an exception that is thrown when the local metadata is invalid or inconsistent.
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class InvalidMetadataException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMetadataException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        internal InvalidMetadataException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMetadataException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        internal InvalidMetadataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMetadataException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidMetadataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
