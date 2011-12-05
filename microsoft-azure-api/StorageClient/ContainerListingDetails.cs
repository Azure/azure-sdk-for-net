//-----------------------------------------------------------------------
// <copyright file="ContainerListingDetails.cs" company="Microsoft">
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
//    Contains code for the ContainerListingDetails enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Specifies which details to include when listing the containers in this storage account.
    /// </summary>
    [Flags]
    public enum ContainerListingDetails
    {
        /// <summary>
        /// No additional details.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Retrieve container metadata.
        /// </summary>
        Metadata = 0x1,

        /// <summary>
        /// Retrieve all available details.
        /// </summary>
        All = 0x1
    }
}
