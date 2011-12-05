//-----------------------------------------------------------------------
// <copyright file="BlobPrefixEntry.cs" company="Microsoft">
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
//    Contains code for the BlobPrefixEntry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents the blob name prefix that is returned in the XML response for a blob listing operation.
    /// </summary>
    public class BlobPrefixEntry : IListBlobEntry
    {
        /// <summary>
        /// Gets the blob name prefix.
        /// </summary>
        /// <value>The blob name prefix.</value>
        public string Name
        {
            get;
            internal set;
        }
    }
}