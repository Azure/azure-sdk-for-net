//-----------------------------------------------------------------------
// <copyright file="CopyStatus.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//    Contains code for the CopyStatus enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Represents the status of a copy blob operation.
    /// </summary>
    public enum CopyStatus
    {
        /// <summary>
        /// The copy status is invalid.
        /// </summary>
        Invalid,

        /// <summary>
        /// The copy operation is pending.
        /// </summary>
        Pending,

        /// <summary>
        /// The copy operation succeeded.
        /// </summary>
        Success,

        /// <summary>
        /// The copy operation has been aborted.
        /// </summary>
        Aborted,

        /// <summary>
        /// The copy operation encountered an error.
        /// </summary>
        Failed
    }
}
