//-----------------------------------------------------------------------
// <copyright file="PageRange.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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