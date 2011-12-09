//-----------------------------------------------------------------------
// <copyright file="BlobContainerProperties.cs" company="Microsoft">
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
//    Contains code for the BlobContainerProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents the system properties for a container.
    /// </summary>
    public class BlobContainerProperties
    {
        /// <summary>
        /// Gets the ETag value for the container.
        /// </summary>
        /// <value>The container's ETag value.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "ETag",
            Justification = "ETag is the correct capitalization.")]
        public string ETag { get; internal set; }

        /// <summary>
        /// Gets the container's last-modified time, expressed as a UTC value.
        /// </summary>
        /// <value>The container's last-modified time.</value>
        public DateTime LastModifiedUtc { get; internal set; }
    }
}
