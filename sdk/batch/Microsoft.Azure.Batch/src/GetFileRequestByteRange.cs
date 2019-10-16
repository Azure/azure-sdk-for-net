// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    using System;

    /// <summary>
    /// The byte range to retrieve in a file download operation.
    /// </summary>
    public class GetFileRequestByteRange
    {
        private const string OcpRangeFormat = "bytes={0}-{1}";

        /// <summary>
        /// Gets the start of the byte range to retrieve.
        /// </summary>
        public int StartRange { get; private set; }

        /// <summary>
        /// Gets the end of the byte range to retrieve.
        /// </summary>
        public int EndRange { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFileRequestByteRange"/> class.
        /// </summary>
        /// <param name="startRange">The start of the byte range to retrieve.</param>
        /// <param name="endRange">The end of the byte range to retrieve.</param>
        public GetFileRequestByteRange(int startRange, int endRange)
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }

        internal string GetOcpRangeHeader()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, OcpRangeFormat, this.StartRange, this.EndRange);
        }
    }
}
