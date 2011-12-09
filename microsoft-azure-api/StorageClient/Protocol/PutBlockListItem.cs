//-----------------------------------------------------------------------
// <copyright file="PutBlockListItem.cs" company="Microsoft">
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
//    Contains code for the PutBlockListItem class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents a block in a block list.
    /// </summary>
    public class PutBlockListItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutBlockListItem"/> class.
        /// </summary>
        /// <param name="id">The block ID.</param>
        /// <param name="searchMode">One of the enumeration values that specifies in which block lists to search for the block.</param>
        public PutBlockListItem(string id, BlockSearchMode searchMode)
        {
            this.Id = id;
            this.SearchMode = searchMode;
        }

        /// <summary>
        /// Gets the block ID.
        /// </summary>
        /// <value>The block ID.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a value that indicates which block lists to search for the block.
        /// </summary>
        /// <value>One of the enumeration values that specifies in which block lists to search for the block.</value>
        public BlockSearchMode SearchMode { get; private set; }
    }
}