//-----------------------------------------------------------------------
// <copyright file="ListBlobPrefixEntry.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    /// <summary>
    /// Represents the blob name prefix that is returned in the XML response for a blob listing operation.
    /// </summary>
#if RTMD
    internal
#else
    public
#endif
        sealed class ListBlobPrefixEntry : IListBlobEntry
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
