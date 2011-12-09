//-----------------------------------------------------------------------
// <copyright file="BlobEntry.cs" company="Microsoft">
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
//    Contains code for the BlobEntry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents a blob item returned in the XML response for a blob listing operation.
    /// </summary>
    public class BlobEntry : IListBlobEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobEntry"/> class.
        /// </summary>
        /// <param name="name">The name of the blob.</param>
        /// <param name="attributes">The blob's attributes.</param>
        internal BlobEntry(string name, BlobAttributes attributes)
        {
            this.Name = name;
            this.Attributes = attributes;
        }

        /// <summary>
        /// Gets the attributes for this blob item.
        /// </summary>
        /// <value>The blob item's attributes.</value>
        public BlobAttributes Attributes { get; private set; }

        /// <summary>
        /// Gets the name of the blob item.
        /// </summary>
        /// <value>The name of the blob item.</value>
        public string Name { get; private set; }
    }
}