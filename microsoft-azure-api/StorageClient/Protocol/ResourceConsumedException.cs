//-----------------------------------------------------------------------
// <copyright file="ResourceConsumedException.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the ResourceConsumedException class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown if the client attempts to parse the response a second time.
    /// </summary>
    [Serializable]
    public class ResourceConsumedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceConsumedException"/> class.
        /// </summary>
        public ResourceConsumedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceConsumedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the exception.</param>
        public ResourceConsumedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceConsumedException"/> class.
        /// </summary>
        /// <param name="message">The message for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ResourceConsumedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceConsumedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected ResourceConsumedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
