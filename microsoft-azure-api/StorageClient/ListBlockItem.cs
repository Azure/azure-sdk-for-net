//-----------------------------------------------------------------------
// <copyright file="ListBlockItem.cs" company="Microsoft">
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
//    Contains code for the ListBlockItem class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a block retrieved from the blob's block list.
    /// </summary>
    public class ListBlockItem
    {
        /// <summary>
        /// Gets the name of the block.
        /// </summary>
        /// <value>The block name.</value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the size of block in bytes.
        /// </summary>
        /// <value>The block size.</value>
        public long Size { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether or not the block has been committed.
        /// </summary>
        /// <value><c>True</c> if the block has been committed; otherwise, <c>false</c>.</value>
        public bool Committed { get; internal set; }
    }
}