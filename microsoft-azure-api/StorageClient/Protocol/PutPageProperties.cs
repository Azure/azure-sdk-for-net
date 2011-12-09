//-----------------------------------------------------------------------
// <copyright file="PutPageProperties.cs" company="Microsoft">
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
//    Contains code for the PutPageProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents properties for writing to a page blob.
    /// </summary>
    public class PutPageProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutPageProperties"/> class.
        /// </summary>
        public PutPageProperties()
        {
        }

        /// <summary>
        /// Gets or sets the range of bytes to write to.
        /// </summary>
        /// <value>The page range.</value>
        public PageRange Range { get; set; }

        /// <summary>
        /// Gets or sets the type of write operation.
        /// </summary>
        /// <value>The type of page write operation.</value>
        public PageWrite PageWrite { get; set; }
    }
}
