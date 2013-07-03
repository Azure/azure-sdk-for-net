//-----------------------------------------------------------------------
// <copyright file="BlobContainerEntry.cs" company="Microsoft">
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
//    Contains code for the CloudStorageAccount class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a container item returned in the XML response for a container listing operation.
    /// </summary>
    /// 
#if WINDOWS_RT
    internal
#else
    public
#endif
        sealed class BlobContainerEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerEntry"/> class.
        /// </summary>
        internal BlobContainerEntry()
        {
        }

        /// <summary>
        /// Gets the user-defined metadata for the container.
        /// </summary>
        /// <value>The container's metadata, as a collection of name-value pairs.</value>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Gets the container's system properties.
        /// </summary>
        /// <value>The container's properties.</value>
        public BlobContainerProperties Properties { get; internal set; }

        /// <summary>
        /// Gets the name of the container.
        /// </summary>
        /// <value>The container's name.</value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the container's URI.
        /// </summary>
        /// <value>The absolute URI to the container.</value>
        public Uri Uri { get; internal set; }
    }
}
