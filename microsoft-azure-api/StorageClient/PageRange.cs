//-----------------------------------------------------------------------
// <copyright file="PageRange.cs" company="Microsoft">
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
//    Contains code for the PageRange class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a range of pages in a page blob.
    /// </summary>
    public class PageRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageRange"/> class.
        /// </summary>
        /// <param name="start">The starting offset.</param>
        /// <param name="end">The ending offset.</param>
        public PageRange(long start, long end)
        {
            this.StartOffset = start;
            this.EndOffset = end;
        }

        /// <summary>
        /// Gets the starting offset of the page range.
        /// </summary>
        /// <value>The starting offset.</value>
        public long StartOffset { get; internal set; }

        /// <summary>
        /// Gets the ending offset of the page range.
        /// </summary>
        /// <value>The ending offset.</value>
        public long EndOffset { get; internal set; }

        /// <summary>
        /// Returns the content of the page range as a string.
        /// </summary>
        /// <returns>The content of the page range.</returns>
        public override string ToString()
        {
            return String.Format("bytes={0}-{1}", this.StartOffset, this.EndOffset);
        }
    }
}