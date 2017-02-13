// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Represents an exception that is thrown when an transfer fails.
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    internal class TransferFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferFailedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TransferFailedException(string message)
            : base(message)
        {
        }
#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferFailedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected TransferFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
