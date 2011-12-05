//-----------------------------------------------------------------------
// <copyright file="BlobContainerPublicAccessType.cs" company="Microsoft">
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
//    Contains code for the BlobContainerPublicAccessType enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Specifies the level of public access that is allowed on the container.
    /// </summary>
    public enum BlobContainerPublicAccessType
    {
        /// <summary>
        /// No public access. Only the account owner can read resources in this container.
        /// </summary>
        Off,

        /// <summary>
        /// Container-level public access. Anonymous clients can read container and blob data.
        /// </summary>
        Container,

        /// <summary>
        /// Blob-level public access. Anonymous clients can read only blob data within this container.
        /// </summary>
        Blob
    }
}
