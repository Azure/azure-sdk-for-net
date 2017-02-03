// 
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
