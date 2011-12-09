//-----------------------------------------------------------------------
// <copyright file="BlockSearchMode.cs" company="Microsoft">
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
//    Contains code for the BlockSearchMode enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Indicates which block lists should be searched to find a specified block. 
    /// </summary>
    public enum BlockSearchMode
    {
        /// <summary>
        /// Search the committed block list only.
        /// </summary>
        Committed,

        /// <summary>
        /// Search the uncommitted block list only.
        /// </summary>
        Uncommitted,

        /// <summary>
        /// Search the uncommitted block list first, and if the block is not found there, search 
        /// the committed block list.
        /// </summary>
        Latest
    }
}
