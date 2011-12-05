//-----------------------------------------------------------------------
// <copyright file="LeaseStatus.cs" company="Microsoft">
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
//    Contains code for the LeaseStatus enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System.ComponentModel;

    /// <summary>
    /// The lease status of the blob.
    /// </summary>
    public enum LeaseStatus
    {
        /// <summary>
        /// The lease status is not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The blob is locked for exclusive-write access.
        /// </summary>
        Locked,

        /// <summary>
        /// The blob is available to be locked for exclusive write access.
        /// </summary>
        Unlocked
    }
}
