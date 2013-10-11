﻿//-----------------------------------------------------------------------
// <copyright file="BlobContainerProperties.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;

    /// <summary>
    /// Represents the system properties for a container.
    /// </summary>
    public sealed class BlobContainerProperties
    {
        /// <summary>
        /// Gets the ETag value for the container.
        /// </summary>
        /// <value>The container's quoted ETag value.</value>
        public string ETag { get; internal set; }

        /// <summary>
        /// Gets the container's last-modified time.
        /// </summary>
        /// <value>The container's last-modified time.</value>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the container's lease status.
        /// </summary>
        /// <value>A <see cref="LeaseStatus"/> object that indicates the container's lease status.</value>
        public LeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// Gets the container's lease state.
        /// </summary>
        /// <value>A <see cref="LeaseState"/> object that indicates the container's lease state.</value>
        public LeaseState LeaseState { get; internal set; }

        /// <summary>
        /// Gets the container's lease duration.
        /// </summary>
        /// <value>A <see cref="LeaseDuration"/> object that indicates the container's lease duration.</value>
        public LeaseDuration LeaseDuration { get; internal set; }
    }
}
