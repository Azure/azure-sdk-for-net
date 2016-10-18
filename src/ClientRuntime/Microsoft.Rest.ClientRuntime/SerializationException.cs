// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Runtime.Serialization;
#if !PORTABLE
using System.Security.Permissions;
#endif

namespace Microsoft.Rest
{
    /// <summary>
    /// Serialization exception for Microsoft Rest Client. 
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class SerializationException : RestException
    {

        /// <summary>
        /// Initializes a new instance of the SerializationException class.
        /// </summary>
        public SerializationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SerializationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public SerializationException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SerializationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public SerializationException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SerializationException class from a message and a content.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="content">The failed content</param>
        /// <param name="innerException">The inner AdalException with additional details</param>
        public SerializationException(string message, string content, Exception innerException) : 
            base(message, innerException)
        {
            Content = content;
        }

        /// <summary>
        /// Gets of sets content that failed to serialize.
        /// </summary>
        public string Content { get; set; }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the SerializationException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected SerializationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Serializes content of the exception.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Content", Content);
        }
#endif
    }
}