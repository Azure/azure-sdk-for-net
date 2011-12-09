//-----------------------------------------------------------------------
// <copyright file="BlobContainerAttributes.cs" company="Microsoft">
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
//    Contains code for the BlobContainerAttributes class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents a container's attributes, including its properties and metadata.
    /// </summary>
    public class BlobContainerAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerAttributes"/> class.
        /// </summary>
        public BlobContainerAttributes()
        {
            this.Metadata = new NameValueCollection();
            this.Properties = new BlobContainerProperties();
        }

        /// <summary>
        /// Gets the user-defined metadata for the container.
        /// </summary>
        /// <value>The container's metadata, as a collection of name-value pairs.</value>
        public NameValueCollection Metadata { get; internal set; }

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