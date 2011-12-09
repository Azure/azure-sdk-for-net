//-----------------------------------------------------------------------
// <copyright file="StorageExtendedErrorInformation.cs" company="Microsoft">
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
//    Contains code for the StorageExtendedErrorInformation class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents extended error information returned by the Windows Azure storage services.
    /// </summary>
    [Serializable]
    public class StorageExtendedErrorInformation
    {
        /// <summary>
        /// Gets the storage service error code.
        /// </summary>
        /// <value>The storage service error code.</value>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Gets the storage service error message.
        /// </summary>
        /// <value>The storage service error message.</value>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Gets additional error details.
        /// </summary>
        /// <value>The additional error details.</value>
        public NameValueCollection AdditionalDetails { get; internal set; }
    }
}