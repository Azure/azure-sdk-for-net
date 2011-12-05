//-----------------------------------------------------------------------
// <copyright file="ResourceConsumedException.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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
