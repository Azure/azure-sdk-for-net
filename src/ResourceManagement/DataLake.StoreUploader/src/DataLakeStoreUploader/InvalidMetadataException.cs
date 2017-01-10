﻿// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
using System;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents an exception that is thrown when the local metadata is invalid or inconsistent.
    /// </summary>
    [Serializable]
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

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMetadataException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidMetadataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}
